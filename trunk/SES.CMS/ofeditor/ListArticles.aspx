<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="ListArticles.aspx.cs" Inherits="SES.CMS.ofeditor.ListArticles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pad20">
            <h2>
                Danh sách bài viết nháp</h2>
            <div style="width: 90%; float: left; margin-bottom: 10px;">
                Lựa chọn theo Danh mục:
                <asp:DropDownList ID="cboCategoryNhap" AppendDataBoundItems="true" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="cboCategoryNhap_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text=".: Chọn tất cả :."></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="article-action">
                <asp:Button runat="server" ID="btnXoa1" Text="Xóa bài đã chọn" CssClass="button-article"
                    OnClick="btnXoa_Click" /><span>|</span>
                <asp:Button runat="server" ID="btnGuiXuatBan1" Text="Gửi xuất bản" CssClass="button-article"
                    OnClick="btnGuiXuatBan_Click" /><span>|</span>
                    <asp:Button runat="server" ID="btnTraLaiPhongVien1" Text="Trả lại bài cho phóng viên" CssClass="button-article"
                    OnClick="btnGuiTraLaiBai_Click" /><span>|</span>
                    <asp:Button runat="server" ID="btnChiuTrachNhiem1" Text="Chịu trách nhiệm bài này" CssClass="button-article"
                    OnClick="btnBTVChiuTrachNhiem_Click" />
            </div>
            <asp:GridView ID="grvListArticle" DataKeyNames="ArticleID" runat="server" AutoGenerateColumns="False"
                OnRowDeleting="grvListArticle_RowDeleting" CssClass="tstyle2" OnSelectedIndexChanged="grvListArticle_SelectedIndexChanged"
                PageSize="35" AllowPaging="true" Width="100%" PagerStyle-CssClass="pgr" 
                OnPageIndexChanging="grvListArticle_PageIndexChanging" 
                OnDataBound="grvListArticle_DataBound" 
                onrowdatabound="grvListArticle_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Select" ItemStyle-Width="5%">
                        <HeaderTemplate>
                            <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this);"
                                runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ArticleID" HeaderText="ID" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-Width="5%" />
                    <asp:BoundField DataField="Title" HeaderText="Tiêu đề" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-Width="35%" />
                    <asp:BoundField DataField="Username" HeaderText="Tác giả" ItemStyle-Width="15%" />
                    <asp:TemplateField HeaderText="Ngày viết" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreateDate" Text='<%# (bool)(Eval("CreateDate")==null)==true?"":Eval("CreateDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Ngày gửi biên tập" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCreateDate" Text='<%# (bool)(Eval("NgayGuiBienTap")==null)==true?"":Eval("NgayGuiBienTap","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Thao tác">
                        <ItemTemplate>
                            <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/ofeditor/images/edit_16x16.gif" />
                            <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("ArticleID") %>'
                                CommandName="Delete" ImageUrl="~/ofeditor/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="article-action">
                <asp:Button runat="server" ID="btnXoa2" Text="Xóa bài đã chọn" CssClass="button-article"
                    OnClick="btnXoa_Click" /><span>|</span>
                <asp:Button runat="server" ID="btnGuiXuatBan2" Text="Gửi xuất bản" CssClass="button-article"
                    OnClick="btnGuiXuatBan_Click" /><span>|</span>
                    <asp:Button runat="server" ID="btnTraLaiPhongVien2" Text="Trả lại bài cho phóng viên" CssClass="button-article"
                    OnClick="btnGuiTraLaiBai_Click" /><span>|</span>
                    <asp:Button runat="server" ID="btnChiuTrachNhiem2" Text="Chịu trách nhiệm bài này" CssClass="button-article"
                    OnClick="btnBTVChiuTrachNhiem_Click" />
            </div>
            <div style="width: 100%; float: left;">
                <a href="/ofeditor/AddNews.aspx" class="button-gg-green" title="Thêm bài viết">Thêm
                    bài viết</a>
            </div>
    </div>
</asp:Content>
