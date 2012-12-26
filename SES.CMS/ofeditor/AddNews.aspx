<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="AddNews.aspx.cs" Inherits="SES.CMS.ofeditor.AddNews" %>

<%@ Register Assembly="ASTreeView" Namespace="Geekees.Common.Controls" TagPrefix="ct" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            
            function ShowDialog()  
              {
                  var returnPopup = window.open('Child.aspx', '_blank', 'scrollbars=10, width=820,height=900');
        //          var txtPopup = document.getElementById(txtPopup).value;
        //          txtPopup.value = returnPopup;
              }  

            function openWin() {
                var oWnd = radopen("RelatedNews1.aspx", "RadWindow1");
            }

            function openWin2() {
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
                        alert(currentMultiID2);
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

            }

            function updateChanges2(stringID) {
                SES.CMS.ofeditor.RNServices.GetListOfArticle(stringID, updateGrid2, OnError);

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

            function deleteCurrent() {
                var gridItems = $find("<%= RadGrid1.ClientID %>").get_masterTableView().get_dataItems();
                alert(currentMultiID);
                currentMultiID = currentMultiID.replace("," + ArticleID, "");
                alert(currentMultiID);
                SES.CMS.ofeditor.RNServices.GetListOfArticle(currentMultiID, updateGrid, OnError);
               
                //gridItems[0].set_selected(true);
            }

            function deleteCurrent2() {
                var gridItems = $find("<%= RadGrid2.ClientID %>").get_masterTableView().get_dataItems();
                currentMultiID2 = currentMultiID2.replace("," + ArticleID2, "");
                SES.CMS.ofeditor.RNServices.GetListOfArticle(currentMultiID2, updateGrid2, OnError);
                //gridItems[0].set_selected(true);
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
        .mgrd
        {
        }
    </style>
    <div class="pad20">
        <fieldset>
            <legend>Thêm mới tin tức</legend>
            <div class="fieldsetdiv">
                <label for="lf">
                    Tiêu đề
                </label>
                <asp:TextBox CssClass="lf" ID="txtTitle" Width="230px" runat="server" ValidationGroup="submitGrp"></asp:TextBox>
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
                192 x 171 (px)
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Danh mục
                </label>
                <div style="float: left;">
                    <telerik:RadComboBox ID="RadComboBox1" runat="server" Width="450px" ShowToggleImage="True"
                        Style="vertical-align: middle;" OnClientDropDownOpened="OnClientDropDownOpenedHandler"
                        EmptyMessage="Choose a destination" ExpandAnimation-Type="None" CollapseAnimation-Type="None"
                        OnInit="RadComboBox1_Init">
                        <ItemTemplate>
                            <div id="div1">
                                <telerik:RadTreeView runat="server" ID="RadTreeView1" OnClientNodeClicking="nodeClicking"
                                    Width="100%" Height="140px" CheckBoxes="True">
                                    <NodeTemplate>
                                        <asp:DropDownList CssClass="dropdown" ID="ddl" runat="server">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="6" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="7" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="8" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="9" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="4"></asp:ListItem>
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
                </div>
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Nội dung
                </label>
                <div style="float: left;">
                    <telerik:RadEditor ID="RadEditor1" runat="server" ToolsFile="RadEditorForm_ToolsFile.xml"
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
                        <MasterTableView TableLayout="Fixed" ClientDataKeyNames="ArticleID" DataKeyNames="ArticleID">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="ArticleID" UniqueName="ArticleID" HeaderText="ArticleID">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Title" UniqueName="Title" HeaderText="Title">
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
                        <MasterTableView TableLayout="Fixed" ClientDataKeyNames="ArticleID" DataKeyNames="ArticleID">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="ArticleID" UniqueName="ArticleID" HeaderText="ArticleID">
                                    <HeaderStyle Width="70px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Title" UniqueName="Title" HeaderText="Title">
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
                <label>
                    Duyệt bài:</label>
                <div class="inpcol">
                    <p>
                        <asp:CheckBox ID="CheckBox8" runat="server" />Gửi chờ Biên tập
                    </p>
                </div>
                <div class="inpcol">
                    <p>
                        <asp:CheckBox ID="CheckBox10" runat="server" />Gửi chờ Xuất bản
                    </p>
                </div>
                <div class="inpcol">
                    <p>
                        <asp:CheckBox ID="CheckBox9" runat="server" />Chính thức Xuất bản
                    </p>
                </div>
            </div>
            <div class="fieldsetdiv">
                <label>
                    Trả lại bài:</label>
                <div class="inpcol">
                    <p>
                        <asp:CheckBox ID="CheckBox11" runat="server" />Trả lại PV/CTV
                    </p>
                </div>
                <div class="inpcol">
                    <p>
                        <asp:CheckBox ID="CheckBox12" runat="server" />Trả lại BTV
                    </p>
                </div>
            </div>
            <div class="fieldsetdiv">
                <label for="lf">
                    Thực hiện
                </label>
                <input class="button" type="submit" value="Submit" />
                <input class="button" type="reset" value="Reset" />
            </div>
        </fieldset>
    </div>
</asp:Content>
