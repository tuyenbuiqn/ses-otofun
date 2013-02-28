<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TinNoiBatForm.aspx.cs" Inherits="SES.CMS.ofeditor.TinNoiBatForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Chọn tin tức yêu cầu</title>
    <link href="/css/CssForDateControl/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/CssForDateControl/StyleChild.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jsForDateControl/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="/js/jsForDateControl/jquery-ui.js"></script>
    <link href="/css/CssForDateControl/jquery-ui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 459px;
        }
        .style2
        {
            width: 116px;
        }
    </style>
</head>
<body onload="AdjustRadWidow();">
    <form id="form1" runat="server">
    <fieldset style="height: auto;">
        <legend>TÌM KIẾM TIN </legend>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow;
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                    oWindow.ID = "1";
                    return oWindow;
                }

                function AdjustRadWidow() {
                    var oWindow = GetRadWindow();
                    setTimeout(function () { oWindow.autoSize(true); if ($telerik.isChrome || $telerik.isSafari) ChromeSafariFix(oWindow); }, 500);
                }

                //fix for Chrome/Safari due to absolute positioned popup not counted as part of the content page layout
                function ChromeSafariFix(oWindow) {
                    var iframe = oWindow.get_contentFrame();
                    var body = iframe.contentWindow.document.body;

                    setTimeout(function () {
                        var height = body.scrollHeight;
                        var width = body.scrollWidth;

                        var iframeBounds = $telerik.getBounds(iframe);
                        var heightDelta = height - iframeBounds.height;
                        var widthDelta = width - iframeBounds.width;

                        if (heightDelta > 0) oWindow.set_height(oWindow.get_height() + heightDelta);
                        if (widthDelta > 0) oWindow.set_width(oWindow.get_width() + widthDelta);
                        oWindow.center();

                    }, 650);
                }

                function returnToParent2() {
                    var oArg = new Object();
                    oArg.cityName = document.getElementById("<%=hdfListArticlesId.ClientID%>").value;
                    oArg.cityName2 = "";
                    oArg.ID = "1";

                    var oWnd = GetRadWindow();
                    //Close the RadWindow and send the argument to the parent page
                    if (oArg.cityName) {

                        oWnd.Close(oArg);

                    }
                    else {
                        alert("Please fill both fields");
                    }
                }
            </script>
        </telerik:RadCodeBlock>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <script type="text/javascript">
            function nodeClicking(sender, args) {
                var comboBox = $find("<%= rcbCat.ClientID %>");

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
        <div id="Child">
            <p>
                <asp:Label ID="lblMessenger" CssClass="lblMess" runat="server" Text=""></asp:Label></p>
            <asp:HiddenField ID="hdfListArticlesId" runat="server" />
            <asp:HiddenField ID="hdfListArticlesName" runat="server" />
            <asp:HiddenField ID="hdfSearchDateStart" runat="server" />
            <asp:HiddenField ID="hdfSearchDateEnd" runat="server" />
            <asp:HiddenField ID="hdfSearchCategoryId" runat="server" />
            <asp:HiddenField ID="hdfSearchKey" runat="server" />
            <div id="ListArticlesAndSearch">
                <div id="Search" style="width: 99%; height: auto;">
                    <table style="width: 797px;">
                        <tr>
                            <td class="style2">
                                Keyword:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchKey" CssClass="Textbox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                Danh mục:
                            </td>
                            <td>
                                <telerik:RadComboBox ID="rcbCat" runat="server" Width="250px" ShowToggleImage="True"
                                    Style="vertical-align: middle;" OnClientDropDownOpened="OnClientDropDownOpenedHandler"
                                    EmptyMessage="Chọn danh mục" ExpandAnimation-Type="None" CollapseAnimation-Type="None"
                                    OnInit="rcbCat_Init">
                                    <ItemTemplate>
                                        <div id="div1">
                                            <telerik:RadTreeView runat="server" ID="RadTreeView1" OnClientNodeClicking="nodeClicking"
                                                Width="100%" Height="140px" CheckBoxes="True">
                                            </telerik:RadTreeView>
                                        </div>
                                    </ItemTemplate>
                                    <Items>
                                        <telerik:RadComboBoxItem Text="" />
                                    </Items>
                                    <ExpandAnimation Type="None"></ExpandAnimation>
                                    <CollapseAnimation Type="None"></CollapseAnimation>
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                Ngày tháng:
                            </td>
                            <td class="style1">
                                &nbsp;từ ngày
                                <telerik:RadDatePicker DateInput-DateFormat="dd/MM/yyyy" ID="rdpStartDate" runat="server">
                                </telerik:RadDatePicker>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; đến
                                <telerik:RadDatePicker DateInput-DateFormat="dd/MM/yyyy" ID="rdpEndDate" runat="server">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkSearch" ToolTip="Tìm Kiếm" CssClass="Buttom" runat="server"
                                    OnClick="lnkSearch_Click">
                                <img alt="Select" src="/images/Search.png" border="0" style="width: 32px; height: 32px;" />
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                  <div id="ArticlesSelect">
                <div id="ListArticlesSelect">
                    <asp:Panel ID="pnlTitle02" runat="server">
                        <p class="Title">
                            Danh sách tin đã chọn</p>
                    </asp:Panel>
                    <asp:Repeater ID="rptListArticlesSelect" runat="server" OnItemDataBound="rptListArticlesSelect_ItemDataBound"
                        OnItemCommand="rptListArticlesSelect_ItemCommand">
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <th>
                                        Tên bài viết
                                    </th>
                                    <th style="width: 45px;">
                                        Action
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblArticleSelect" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkDelete" ToolTip="Xóa" runat="server">
                                    <img alt="Delete" src="/images/action_delete.png"border="0" style="width: 16px; height: 16px;" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <input type='button' class="inputButtom" style="margin-bottom: 10px;" name='button'
                    value='HOÀN THÀNH' onclick="returnToParent2(); return false;" />
            </div>
                <div id="ListArticles">
                    <asp:Panel ID="pnlTitle01" runat="server">
                        <p class="Title">
                            Danh sách tin bài</p>
                    </asp:Panel>
                    <asp:Repeater ID="rptListArticles" runat="server" OnItemDataBound="rptListArticles_ItemDataBound"
                        OnItemCommand="rptListArticles_ItemCommand">
                        <HeaderTemplate>
                            <table class="classListArticles">
                                <tr>
                                    <th>
                                        Mã
                                    </th>
                                    <th>
                                        Tên bài viết
                                    </th>
                                    <th>
                                        Danh mục
                                    </th>
                                    <th>
                                        Ngày viết
                                    </th>
                                    <th>
                                        Action
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblArticleId" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblArticleName" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblArticleCategory" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblArticleTime" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkSelectItem" ToolTip="Chọn" runat="server">
                                    <img alt="Select" src="/images/rt.gif" border="0" style="width: 16px; height: 16px;" />
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>

          
        </div>
    </fieldset>
    </form>
</body>
</html>
