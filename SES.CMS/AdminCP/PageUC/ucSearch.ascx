<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSearch.ascx.cs" Inherits="SES.CMS.AdminCP.PageUC.ucSearch" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<link href="../../css/StyleSearch.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function OnClientDropDownOpenedHandler(sender, eventArgs) {
        var tree = sender.get_items().getItem(0).findControl("RadTreeView1");
        var selectedNode = tree.get_selectedNode();
        if (selectedNode) {
            selectedNode.scrollIntoView();
        }
    }
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
</script>
<div id="ucSearch">
    <asp:HiddenField ID="hdfKey" runat="server" />
    <asp:HiddenField ID="hdfCategory" runat="server" />
    <asp:HiddenField ID="hdfListStatus" runat="server" />
    <asp:HiddenField ID="hdfPvCreate" runat="server" />
    <asp:HiddenField ID="hdfBtvEdit" runat="server" />
    <asp:HiddenField ID="hdfTkApproved" runat="server" />
    <asp:HiddenField ID="hdfRadDatePickerStart" runat="server" />
    <asp:HiddenField ID="hdfRadDatePickerEnd" runat="server" />
    <asp:HiddenField ID="hdfPageIndex" runat="server" />
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <p id="ucSearchTitle">Tìm kiếm nâng cao</p>
    <div id="Search">
        <table>
            <tr>
                <td>Từ khóa</td>
                <td colspan="3">
                    <asp:TextBox ID="txtKey" CssClass="ucSearchTextbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Danh mục tin tức</td>
                <td>
                    <telerik:RadComboBox ID="rcbCat" CssClass="SearchrcbCat" runat="server" Width="250px" Height="24px" ShowToggleImage="True"
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
                <td>Trạng thái</td>
                <td>
                    <asp:DropDownList ID="ddlListStatus" CssClass="ucSearchDdl" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPvCreate" runat="server" Text="PV viết bài"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPvCreate" CssClass="ucSearchDdl" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblBtvEdit" runat="server" Text="BTV biên tập"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBtvEdit" CssClass="ucSearchDdl" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTkApproved" runat="server" Text="TK phê duyệt"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlTkApproved" CssClass="ucSearchDdl" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Ngày khởi tạo</td>
                <td colspan="3">
                    Từ: 
                    <telerik:RadDatePicker ID="RadDatePickerStart" DateInput-DateFormat="dd/MM/yyyy" runat="server">
                    </telerik:RadDatePicker>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Đến: 
                    <telerik:RadDatePicker ID="RadDatePickerEnd"  DateInput-DateFormat="dd/MM/yyyy" runat="server">
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr class="ucSearchButtom">
                <td></td>
                <td colspan="3">
                    <asp:Button ID="btnSearch" CssClass="ucSearchbtnSearch" runat="server" Text="Tìm kiếm" 
                        onclick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="ListArticle">
        <asp:Panel ID="pnlListArticle" runat="server">
            <asp:Repeater ID="rptListArticle" runat="server" 
                onitemdatabound="rptListArticle_ItemDataBound" 
                onitemcommand="rptListArticle_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Mã ID</th>
                        <th>Tiêu đề</th>
                        <th>Danh mục</th>
                        <th>Người tạo</th>
                        <th>Ngày viết</th>
                        <th>Lượt view</th>
                        <th>Hiển thị</th>
                        <th>Action</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td  style="text-align: center;">
                        <asp:Label ID="lblArticleId" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblArticleTitle" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblArticleCategory" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblArticleUserCreate" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblArticleDateCreate" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td  style="text-align: center;">
                        <asp:Label ID="lblArticleView" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="text-align: center;">
                        <asp:CheckBox ID="chkView" Enabled="false" runat="server" />
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkEdit" runat="server">
                            <img alt="Edit" src="/AdminCP/images/edit_16x16.gif" border="0" style="width: 16px; height: 16px;" />
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server">
                            <img alt="Delete" src="/AdminCP/images/delete_16x16.gif" border="0" style="width: 16px; height: 16px;" />
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background: #edf5ff;">
                    <td  style="text-align: center;">
                        <asp:Label ID="lblArticleId" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblArticleTitle" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblArticleCategory" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblArticleUserCreate" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblArticleDateCreate" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td  style="text-align: center;">
                        <asp:Label ID="lblArticleView" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="text-align: center;">
                        <asp:CheckBox ID="chkView" Enabled="false" runat="server" />
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkEdit" runat="server">
                            <img alt="Edit" src="/AdminCP/images/edit_16x16.gif" border="0" style="width: 16px; height: 16px;" />
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server">
                            <img alt="Delete" src="/AdminCP/images/delete_16x16.gif" border="0" style="width: 16px; height: 16px;" />
                        </asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div id="Paging">
            <div style="float:left;">
                Trang 
                <asp:DropDownList ID="ddlPageIndex" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="ddlPageIndex_SelectedIndexChanged">
                </asp:DropDownList>
                /
                <asp:Label ID="lblTotalPages" runat="server" Text=""></asp:Label>
            </div>
            <div style="float:right;">
                Hiển thị
                <asp:DropDownList ID="ddlNumberItemPerPage" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlNumberItemPerPage_SelectedIndexChanged">
                </asp:DropDownList>
                Kết quả/ trang
            </div>
        </div>
        </asp:Panel>
        
    </div>
</div>