<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="AddNews.aspx.cs" Inherits="SES.CMS.ofeditor.AddNews" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdfID1"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="hdfID2"></asp:HiddenField>
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
                    currentMultiID2 = document.getElementById("<%= hdfID2.ClientID %>").value;
                    firstRun = 0;
                }

            }
            function openWin() {

                SetDataCurrent();

                var oWnd = radopen("RelatedNews1.aspx", "RadWindow1");
            }

            function openWin2() {
                SetDataCurrent();
                var oWnd2 = radopen("RelatedNews2.aspx", "RadWindow2");
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
                        currentMultiID = currentMultiID + ',' + arg.cityName;
                        arg = null;
                        updateChanges(currentMultiID);

                    }
                    else {

                        if (currentMultiID2 == null) currentMultiID2 = arg.cityName2;
                        currentMultiID2 = currentMultiID2 + ',' + arg.cityName2;
                        arg = null;
                        updateChanges2(currentMultiID2);
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

            function updateChanges2(stringID) {
                SES.CMS.ofeditor.RNServices.GetListOfArticle(stringID, updateGrid2, OnError);
                document.getElementById("<%= hdfID2.ClientID %>").value = stringID;
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

            function updateGrid2(result) {
                // alert(result.toString());
                var tableView = $find("<%= RadGrid2.ClientID %>").get_masterTableView();
                tableView.set_dataSource(result);
                tableView.dataBind();

                var grid = $find("<%= RadGrid2.ClientID %>");
                grid.repaint();
            }

            var firstRun = 1;
            function OnReplaceComplete(result) {
                currentMultiID = result;
                SES.CMS.ofeditor.RNServices.GetListOfArticle(currentMultiID, updateGrid, OnError);
                document.getElementById("<%= hdfID1.ClientID %>").value = result;
            }
            function OnReplaceComplete2(result1) {
                currentMultiID2 = result1;
                SES.CMS.ofeditor.RNServices.GetListOfArticle(currentMultiID2, updateGrid2, OnError);
                document.getElementById("<%= hdfID2.ClientID %>").value = result1;
            }

            function deleteCurrent() {
                SetDataCurrent();
                var gridItems = $find("<%= RadGrid1.ClientID %>").get_masterTableView().get_dataItems();

                SES.CMS.ofeditor.RNServices.rmoveStr(currentMultiID, ArticleID, OnReplaceComplete, OnError);


                //gridItems[0].set_selected(true);
            }

            function deleteCurrent2() {
                SetDataCurrent();
                var gridItems = $find("<%= RadGrid2.ClientID %>").get_masterTableView().get_dataItems();
                SES.CMS.ofeditor.RNServices.rmoveStr(currentMultiID2, ArticleID2, OnReplaceComplete2, OnError);

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
            <telerik:RadWindow ID="RadWindow1" runat="server" Width="650" Height="480" Modal="true"
                OnClientClose="OnClientClose" NavigateUrl="RelatedNews1.aspx">
            </telerik:RadWindow>
            <telerik:RadWindow ID="RadWindow2" runat="server" Width="650" Height="480" Modal="true"
                OnClientClose="OnClientClose" NavigateUrl="RelatedNews2.aspx">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <script type="text/javascript">
        function nodeClicking(sender, args) {
            var comboBox = $find("<%= RadComboBox1.ClientID %>");

            var node = args.get_node()

            comboBox.set_text(node.get_text());

            comboBox.trackChanges();
            comboBox.get_items().getItem(0).set_text(node.get_text());
            comboBox.commitChanges();

            comboBox.hideDropDown();

            // Call comboBox.attachDropDown if:
            //  1) The RadComboBox is inside an AJAX panel.
            //  2) The RadTreeView has a server-side event handler for the NodeClick event, i.e. it initiates a postback when clicking on a Node.
            // Otherwise the AJAX postback becomes a normal postback regardless of the outer AJAX panel.

            //comboBox.attachDropDown();
        }

        function StopPropagation(e) {
            if (!e) {
                e = window.event;
            }

            e.cancelBubble = true;
        }

        function OnClientDropDownOpenedHandler(sender, eventArgs) {
            var tree = sender.get_items().getItem(0).findControl("RadTreeView1");
            var selectedNode = tree.get_selectedNode();
            if (selectedNode) {
                selectedNode.scrollIntoView();
            }
        }
    </script>
    <style>
        .mgrd .rgDataDiv
        {
            height: auto !important;
        }
    </style>
    <div class="pad20">
        <fieldset>
            <legend>Thêm mới tin tức</legend>
            <div class="fieldsetdiv">
                <label for="lf">
                    Tiêu đề
                </label>
                <asp:TextBox CssClass="lf" ID="txtTitle" Width="450px" runat="server" ValidationGroup="submitGrp"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                    ErrorMessage="***" ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Tags
                </label>
                <asp:TextBox CssClass="lf" ID="txtTags" runat="server" ValidationGroup="submitGrp"
                    Width="484px"></asp:TextBox>
                ngăn cách nhau bới dấu phẩy (,)
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Hình ảnh
                </label>
                <asp:FileUpload ID="fuImg" runat="server" />
                190 x 140 (px)
                <asp:HyperLink ID="hplImage" Target="_blank" Visible="false" runat="server" Style="font-weight: 700">(Xem ảnh)</asp:HyperLink>
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Chuyên đề
                </label>
                <asp:DropDownList CssClass="dropdown" runat="server" ID="ddlEvent" AppendDataBoundItems="true"
                    Height="20px" Width="342px">
                    <asp:ListItem Text=".: Không chọn :." Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Danh mục
                </label>
                <div style="float: left;">
                    <telerik:RadComboBox ID="RadComboBox1" runat="server" Width="450px" ShowToggleImage="True"
                        Style="vertical-align: middle;" OnClientDropDownOpened="OnClientDropDownOpenedHandler"
                        EmptyMessage="Chọn Danh mục gửi bài" ExpandAnimation-Type="None" CollapseAnimation-Type="None"
                        OnInit="RadComboBox1_Init">
                        <ItemTemplate>
                            <div id="div1">
                                <telerik:RadTreeView CssClass="mtrv" runat="server" ID="RadTreeView1" OnClientNodeClicking="nodeClicking"
                                    Width="100%" CheckBoxes="True" OnNodeDataBound="RadTreeView1_NodeDataBound">
                                    <NodeTemplate>
                                        <asp:DropDownList CssClass="dropdown" ID="ddl" runat="server">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                        </asp:DropDownList>
                                        <%# DataBinder.Eval(Container, "Text") %>
                                    </NodeTemplate>
                                </telerik:RadTreeView>
                            </div>
                        </ItemTemplate>
                        <Items>
                            <telerik:RadComboBoxItem Text="" />
                        </Items>
                        <ExpandAnimation Type="None"></ExpandAnimation>
                        <CollapseAnimation Type="None"></CollapseAnimation>
                    </telerik:RadComboBox>
                </div>
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Mô tả ngắn
                </label>
                <div style="float: left;">
                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" CssClass="txtArea"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                        ErrorMessage="***" ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Nội dung
                </label>
                <div style="float: left;">
                    <telerik:RadEditor ID="txtDetail" runat="server" OnClientPasteHtml="OnClientPasteHtml"
                        Width="789px">
                        <ImageManager MaxUploadFileSize="1024000000" ViewPaths="~/Media/" UploadPaths="~/Media/"
                            DeletePaths="~/MediaDelete/"></ImageManager>
                    </telerik:RadEditor>
                </div>
            </div>
            <div class="fieldsetdiv">
                <label>
                    Tin liên quan 1:</label>
                <div style="float: left; width: 680px">
                    <telerik:RadGrid CssClass="mgrd" ID="RadGrid1" AutoGenerateColumns="False" runat="server"
                        CellSpacing="0" GridLines="None">
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
                <div style="float: left; width: 86px; margin-left: 10px;">
                    <input class="button" type="submit" value="Chọn" onclick="openWin(); return false;" />
                    <input class="button" type="submit" value="Xóa" onclick="if(!confirm('Are you sure you want to delete this employee?'))return false; deleteCurrent(); return false;" />
                </div>
            </div>
            <div class="fieldsetdiv">
                <label>
                    Tin liên quan 2:</label>
                <div style="float: left; width: 680px">
                    <telerik:RadGrid CssClass="mgrd" ID="RadGrid2" AutoGenerateColumns="False" runat="server"
                        CellSpacing="0" GridLines="None">
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
                            <ClientEvents OnRowSelected="rowSelected2" />
                            <Selecting AllowRowSelect="True"></Selecting>
                            <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </div>
                <div style="float: left; width: 86px; margin-left: 10px;">
                    <input class="button" type="submit" value="Chọn" onclick="openWin2(); return false;" />
                    <%--<input class="button" type="submit" value="Chọn" onclick="ShowDialog(); return false;" />--%>
                    <input class="button" type="submit" value="Xóa" onclick="if(!confirm('Are you sure you want to delete this employee?'))return false; deleteCurrent2(); return false;" />
                </div>
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Thực hiện
                </label>
                <asp:Button class="button" ID="btnSubmit" runat="server" ValidationGroup="submitGrp"
                    Text="Lưu bài" OnClick="btnSubmit_Click" />
                <asp:Button class="button" ID="Button1" runat="server" Text="Hủy" />
            </div>
        </fieldset>
    </div>
</asp:Content>
