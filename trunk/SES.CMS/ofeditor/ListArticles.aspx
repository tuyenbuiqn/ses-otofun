<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="ListArticles.aspx.cs" Inherits="SES.CMS.ofeditor.ListArticles" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
    </telerik:RadWindowManager>
    <div class="pad20">
        <h2>
            <asp:Label runat="server" ID="lblAction" Text=""></asp:Label>
        </h2>
        <div style="width: 90%; float: left; margin-bottom: 10px;">
            <span style="float: left; font-size: 16px; font-weight: bold;">Chọn theo Danh mục:</span>
            <div style="float: left; width: 260px;">
                <telerik:RadComboBox ID="rcbCat" CssClass="SearchrcbCat" runat="server" Width="250px"
                    Height="24px" ShowToggleImage="True" Style="vertical-align: middle;" OnClientDropDownOpened="OnClientDropDownOpenedHandler"
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
            </div>
            <span style="float: left;">
                <asp:Button runat="server" ID="btnFilter" CssClass="button" Text="Tìm kiếm" />
            </span>
        </div>
        <div visible="false" runat="server" id="divPV" class="article-action">
            <asp:Button runat="server" ID="btnXoaPV" Text="Xóa bài đã chọn" CssClass="button-article"
                OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" OnClick="btnXoaPV_Click" />
            <asp:Button runat="server" ID="btnGuiBTV" Text="Gửi Biên tập" CssClass="button-article"
                OnClientClick="return confirm('Xác nhận gửi Biên tập? Nhấn OK để đồng ý!')" OnClick="btnGuiBTV_Click" />
        </div>
        <div visible="false" runat="server" id="divBTV" class="article-action">
            <asp:Button runat="server" ID="btnXoaBTV" Text="Xóa bài đã chọn" CssClass="button-article"
                OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" OnClick="btnXoaBTV_Click" />
            <asp:Button runat="server" ID="btnGuiXuatBan" Text="Gửi xuất bản" CssClass="button-article"
                OnClick="btnGuiXuatBan_Click" OnClientClick="return confirm('Xác nhận gửi xuất bản? Nhấn OK để đồng ý!')" />
            <asp:Button runat="server" ID="btnTraLaiPhongVien" Text="Trả lại bài cho phóng viên"
                CssClass="button-article" OnClick="btnTraLaiPhongVien_Click" OnClientClick="return confirm('Xác nhận trả lại bài viết cho phóng viên? Nhấn OK để đồng ý!')" />
            <asp:Button runat="server" ID="btnChiuTrachNhiem" Text="Chịu trách nhiệm bài này"
                CssClass="button-article" OnClick="btnBTVChiuTrachNhiem_Click" OnClientClick="return confirm('Xác nhận chịu trách nhiệm? Nhấn OK để đồng ý!')" />
        </div>
        <div visible="false" runat="server" id="divTK" class="article-action">
            <asp:Button runat="server" ID="btnXoaTK" Text="Xóa bài đã chọn" CssClass="button-article"
                OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" OnClick="btnXoaTK_Click" />
            <asp:Button runat="server" ID="btnTKChiuTrachNhiem" Text="Chọn Biên tập bài này"
                CssClass="button-article" OnClick="btnTKChiuTrachNhiem_Click" OnClientClick="return confirm('Xác nhận chịu trách nhiệm? Nhấn OK để đồng ý!')" />
            <asp:Button runat="server" ID="btnDuyetXuatBan" Text="Duyệt Xuất bản" CssClass="button-article"
                OnClientClick="return confirm('Xác nhận Duyệt xuất bản? Nhấn OK để đồng ý!')"
                OnClick="btnDuyetXuatBan_Click" />
            <asp:Button runat="server" ID="btnHuyDuyetXB" Text="Gỡ bài" CssClass="button-article"
                OnClientClick="return confirm('Xác nhận Gỡ bài? Nhấn OK để đồng ý!')" OnClick="btnHuyDuyetXB_Click" />
            <asp:Button runat="server" ID="btnTKTraPV" Text="Trả lại bài cho phóng viên" CssClass="button-article"
                OnClientClick="return confirm('Xác nhận trả lại bài viết cho phóng viên? Nhấn OK để đồng ý!')"
                OnClick="btnTKTraPV_Click" />
            <asp:Button runat="server" ID="btnTraBTV" Text="Trả bài Biên tập lại" CssClass="button-article"
                OnClientClick="return confirm('Xác nhận trả bài viết cho Biên tập lại? Nhấn OK để đồng ý!')"
                OnClick="btnTraBTV_Click" />
            <div runat="server" id="divInfoDelete" class="divInfoDelete"  visible="false">
            <p style="font-weight:bold; color:#333; font-size:16px; ">Dữ liệu bạn đang xóa đang được sử dụng ở các phần dưới đây</p>
                <p> 
                    <asp:Literal runat="server" ID="ltrDeleteInfo"></asp:Literal>
                </p>
                 <p style="font-weight:bold; color:#333; font-size:16px; ">Xem lại dữ liệu </p>
                <ul class="delete-confirm">
                    <li>
                        <a href="/ofeditor/TinNoiBat.aspx" target="_blank">3 Nổi bật trang chủ</a>
                    </li>
                     <li>
                        <a href="/ofeditor/TopNews.aspx" target="_blank">9 Nổi bật trang chủ</a>
                    </li>
                      <li>
                        <a href="/ofeditor/TinSetTop.aspx" target="_blank">2 Nổi bật chuyên mục</a>
                    </li>
                     <li>
                        <a href="/ofeditor/TinMostReadCate.aspx" target="_blank">6 đọc nhiều chuyên mục</a>
                    </li>
                </ul>
                 <p>
                    <asp:Button runat="server" ID="btnDeleteSubmit" Text="Xác nhận xóa" CssClass="button" OnClick="btnDeleteSubmit_Click" />
                    <asp:Button runat="server" ID="btnDeleteCancel" Text="Hủy thao tác" CssClass="button" OnClick="btnDeleteCancel_Click" />
                </p>
            </div>
        </div>
        <asp:GridView ID="grvListArticle" DataKeyNames="ArticleID" runat="server" AutoGenerateColumns="False"
            OnRowDeleting="grvListArticle_RowDeleting" CssClass="tstyle2" OnSelectedIndexChanged="grvListArticle_SelectedIndexChanged"
            PageSize="15" AllowPaging="true" Width="100%" PagerStyle-CssClass="pgr" OnPageIndexChanging="grvListArticle_PageIndexChanging"
            OnDataBound="grvListArticle_DataBound" OnRowDataBound="grvListArticle_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Select" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this);"
                            runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ArticleID" HeaderText="ID" ItemStyle-HorizontalAlign="Left"
                    ItemStyle-Width="5%" Visible="false" />
                <asp:BoundField DataField="Title" HeaderText="Tiêu đề" ItemStyle-HorizontalAlign="Left"
                    ItemStyle-Width="35%" />
                <asp:BoundField DataField="Username" HeaderText="Tác giả" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Ngày viết" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCreateDate" Text='<%# (bool)(Eval("CreateDate")==null)==true?"":Eval("CreateDate","{0:dd/MM/yyyy hh:mm}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày gửi biên tập" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCreateDate2" Text='<%# (bool)(Eval("ThoiGianGui")==null)==true?"":Eval("ThoiGianGui","{0:dd/MM/yyyy hh:mm}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày gửi xuất bản" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCreateDate3" Text='<%# (bool)(Eval("ThoiGianGuiXuatBan")==null)==true?"":Eval("ThoiGianGuiXuatBan","{0:dd/MM/yyyy hh:mm}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày xuất bản" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCreateDate4" Text='<%# (bool)(Eval("ThoiGianXuatBan")==null)==true?"":Eval("ThoiGianXuatBan","{0:dd/MM/yyyy hh:mm}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LuotView" HeaderText="Lượt view" ItemStyle-HorizontalAlign="Left"
                    ItemStyle-Width="10%" />
                <asp:TemplateField ItemStyle-Width="10%" HeaderText="Thao tác" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" CommandName="Select" ImageUrl="~/ofeditor/images/edit_16x16.gif" />
                        <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("ArticleID") %>'
                            CommandName="Delete" ImageUrl="~/ofeditor/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Hẹn giờ xuất"
                    ItemStyle-Width="8%">
                    <ItemTemplate>
                        <%#returnPub(Eval("ArticleID").ToString()) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Biên tập"
                    ItemStyle-Width="8%">
                    <ItemTemplate>
                        <%#Eval("NguoiBienTap").ToString() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Danh mục" ItemStyle-Width="8%">
                    <ItemTemplate>
                        <%#Eval("TenDanhMuc").ToString() %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="width: 100%; float: left;">
            <a href="/ofeditor/AddNews.aspx" class="button-gg-green" title="Thêm bài viết">Thêm
                bài viết</a>
        </div>
    </div>
</asp:Content>
