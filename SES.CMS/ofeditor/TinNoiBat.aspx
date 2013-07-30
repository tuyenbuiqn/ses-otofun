<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="TinNoiBat.aspx.cs" Inherits="SES.CMS.ofeditor.TinNoiBat" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .mgrd .rgDataDiv
        {
            height: auto !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdfID1"></asp:HiddenField>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="RNServices.asmx" />
        </Services>
    </telerik:RadScriptManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
        //<![CDATA[

            var ArticleID, currentRowIndex, ArticleID2, currentRowIndex2 = null;
            var currentMultiID, currentMultiID2 = null;

            function ShowDialog() {
                var returnPopup = window.open('Child.aspx', '_blank', 'scrollbars=10, width=820,height=900');
                //          var txtPopup = document.getElementById(txtPopup).value;
                //          txtPopup.value = returnPopup;
            }

            function SetDataCurrent() {
                if (firstRun == 1) {

                    currentMultiID = document.getElementById("<%= hdfID1.ClientID %>").value;
                    firstRun = 0;
                }

            }
            function openWin() {

                SetDataCurrent();

                var oWnd = radopen("TinNoiBatForm.aspx", "RadWindow1",400,400);
                oWnd.set_autoSize(false);
            }

            function OnClientClose(oWnd, args) {


                var arg = args.get_argument();

                if (arg) {


                    var ID = arg.ID;
                    args = null;
                    oWnd = null;

                    //$get("order").innerHTML = "You chose to fly to " + cityName;
                    if (ID == "1") {
                        //alert(arg.cityName);
                        if (currentMultiID == null) currentMultiID = arg.cityName;
                        //currentMultiID = currentMultiID + ',' + arg.cityName;
                        currentMultiID = arg.cityName;
                        arg = null;
                        updateChanges(currentMultiID);

                    }

                }

            }



            //Get data key (ArticleID)
            function getDataItemKeyValue(radGrid, item) {
                return parseInt(radGrid.get_masterTableView().getCellByColumnUniqueName(item, "ArticleID").innerHTML);
            }




            function rowSelected(sender, args) {
                ArticleID = getDataItemKeyValue(sender, args.get_gridDataItem());
                currentRowIndex = args.get_gridDataItem().get_element().rowIndex;

            }

            function rowSelected2(sender, args) {
                ArticleID2 = getDataItemKeyValue(sender, args.get_gridDataItem());
                currentRowIndex2 = args.get_gridDataItem().get_element().rowIndex;

            }

            function updateChanges(stringID) {
                SES.CMS.ofeditor.RNServices.GetListOfArticle(stringID, updateGrid, OnError);
                document.getElementById("<%= hdfID1.ClientID %>").value = stringID;
            }


            function OnError(result) {
                alert("Error: " + result.get_message());
            }
            function updateGrid(result) {
                // alert(result.toString());
                var tableView = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                tableView.set_dataSource(result);
                tableView.dataBind();

                var grid = $find("<%= RadGrid1.ClientID %>");
                grid.repaint();
            }

            var firstRun = 1;
            function OnReplaceComplete(result) {
                currentMultiID = result;
                SES.CMS.ofeditor.RNServices.GetListOfArticle(currentMultiID, updateGrid, OnError);
                document.getElementById("<%= hdfID1.ClientID %>").value = result;
            }

            function deleteCurrent() {
                SetDataCurrent();
                var gridItems = $find("<%= RadGrid1.ClientID %>").get_masterTableView().get_dataItems();

                SES.CMS.ofeditor.RNServices.rmoveStr(currentMultiID, ArticleID, OnReplaceComplete, OnError);


                //gridItems[0].set_selected(true);
            }


            function OnClientPasteHtml(sender, args) {
                var commandName = args.get_commandName();
                var value = args.get_value();
                if (commandName == "ImageManager") {
                    //See if an img has an alt tag set
                    var div = document.createElement("DIV");
                    //Do not use div.innerHTML as in IE this would cause the image's src or the link's href to be converted to absolute path.
                    //This is a severe IE quirk.
                    Telerik.Web.UI.Editor.Utils.setElementInnerHtml(div, value);
                    //Now check if there is alt attribute
                    var img = div.firstChild;
                    //alert(div.innerHTML);

                    //Set new content to be pasted into the editor

                    if (!!img.alt) {
                        var newInner = "<table border='0' class='tbimage' cellspacing='0' cellpadding='3' width='1' align='center'><tbody><tr><td>";
                        newInner = newInner + "<img src='" + img.src + "' alt='" + img.alt + "' style='" + img.getAttribute("style") + "'/>" + "</td></tr><tr><td class='image_desc'>";
                        newInner = newInner + img.alt + "</td></tr></tbody></table>";

                        args.set_value(newInner);
                    }

                }
            }

        //]]>
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false"
        ReloadOnShow="true" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Width="650" Height="480" Modal="false"
                OnClientClose="OnClientClose" NavigateUrl="RelatedNews1.aspx">
            </telerik:RadWindow>
            <telerik:RadWindow ID="RadWindow2" runat="server" Width="650" Height="480" Modal="false"
                OnClientClose="OnClientClose" NavigateUrl="RelatedNews2.aspx">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <script type="text/javascript">
        function OnClientDropDownOpenedHandler(sender, eventArgs) {
            var tree = sender.get_items().getItem(0).findControl("RadTreeView1");
            var selectedNode = tree.get_selectedNode();
            if (selectedNode) {
                selectedNode.scrollIntoView();
            }
        }
    </script>
    <div style="float: left; width: 98%; margin: 10px 0 10px 10px;">
        <h1 class="h1-style1">
            Danh sách tin nổi bật</h1>
              <div runat="server" visible="false" id="divEdit" style="float: left; width: 98%;
        margin: 10px 0 10px 0px;">
       <%-- <h1 class="h1-style1">
            Sửa tin nổi bật</h1>--%>
        <div class="tin-noi-bat-box">
            <div class="tin-noi-bat-content">
                <h3>
                    Tin cần sửa</h3>
                    <div class="tin-noi-bat-table">
                    <table class="tstyle2">
                        <thead>
                            <tr>
                                <th style="display:none;">ArticleID</th>
                                <th>Tiêu đề</th>
                                <th>Số thứ tự</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="display:none;"><asp:Label runat="server" Visible="false" ID="lblOldArticleID" CssClass="tin-noi-bat-left"></asp:Label></td>
                                <td><asp:Label runat="server" ID="lblOldTitle" CssClass="tin-noi-bat-right"></asp:Label></td>
                                <td><asp:Label runat="server" ID="lblOrderID" CssClass="tin-noi-bat-right"></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                    </div>
            </div>
            <div class="tin-noi-bat-content">
                <div class="tin-noi-bat-new">
                    <h3>
                        Chọn tin thay thế</h3>
                    <div class="button-tinnoibat-box" style="">
                    <span>
                        <input class="button" type="submit" value="Thay đổi" onclick="openWin(); return false;" />
                        <input class="button" type="submit" value="Xóa" onclick="if(!confirm('Are you sure you want to delete this employee?'))return false; deleteCurrent(); return false;" />
                    </span>
                    </div>
                    <div style="float:left; width:100%;">
                        <telerik:RadGrid CssClass="mgrd" ID="RadGrid1" AutoGenerateColumns="False" runat="server"
                            ItemStyle-Height="150px" CellSpacing="0" GridLines="None">
                            <MasterTableView NoMasterRecordsText="->Không có dữ liệu" TableLayout="Fixed" ClientDataKeyNames="ArticleID"
                                DataKeyNames="ArticleID">
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="ArticleID" UniqueName="ArticleID" HeaderText="ArticleID">
                                        <HeaderStyle Width="70px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Title" UniqueName="Title" HeaderText="Tiêu đề">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <ClientSettings>
                                <ClientEvents OnRowSelected="rowSelected" />
                                <Selecting AllowRowSelect="True"></Selecting>
                                <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
                            </ClientSettings>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </div>
                </div>
                <div style="width: 100%; float: left; margin-top: 10px;">
                    <asp:Button ID="btnLuu" class="button" runat="server" Text="Lưu lại thay đổi" OnClick="btnLuu_Click" />
                    <asp:Button ID="btnCancel" class="button" runat="server" Text="Hủy thao tác" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
        <p style="color: Red; font-size: 14px; font-weight: bold; font-style: inherit;">
            <asp:Label runat="server" ID="lblError"></asp:Label></p>
    </div>
        <asp:GridView ID="grvListTinNoiBat" DataKeyNames="TinNoiBatID" runat="server" AutoGenerateColumns="False"
            CssClass="tstyle2" PageSize="35" AllowPaging="true" Width="100%" PagerStyle-CssClass="pgr"
            OnRowCancelingEdit="grvListTinNoiBat_RowCancelingEdit" OnRowEditing="grvListTinNoiBat_RowEditing"
            OnRowUpdating="grvListTinNoiBat_RowUpdating" OnRowDeleting="grvListTinNoiBat_RowDeleting"
            OnSelectedIndexChanged="grvListTinNoiBat_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Tiêu đề" Visible="false" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTinNoiBatID" Text='<%#Eval("TinNoiBatID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ArticleID" Visible="false" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblArticleID" Text='<%#Eval("ArticleID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tiêu đề" ItemStyle-Width="30%" ItemStyle-HorizontalAlign="left">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblTitle" Text='<%#Eval("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Danh mục" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDanhMuc" Text='<%#Eval("CategoryTitle") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Số thứ tự" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblOrderID" Text='<%#Eval("OrderID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Width="50px" ID="txtOrderID" Text='<%#Eval("OrderID") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ForeColor="Red" ControlToValidate="txtOrderID"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtOrderID"
                            Type="Integer" MinimumValue="0" MaximumValue="100"></asp:RangeValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="true" HeaderText="Sửa số thứ tự" CausesValidation="true"
                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField ItemStyle-Width="10%" HeaderText="Thao tác" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" CommandName="Select" ImageUrl="~/ofeditor/images/edit_16x16.gif" />
                        <asp:ImageButton Visible="false" ID="btnDelete" runat="server" CommandArgument='<%#Eval("TinNoiBatID") %>'
                            CommandName="Delete" ImageUrl="~/ofeditor/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
  
</asp:Content>
