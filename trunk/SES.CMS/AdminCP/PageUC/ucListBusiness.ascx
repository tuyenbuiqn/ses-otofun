<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListBusiness.ascx.cs" Inherits="SES.CMS.AdminCP.PageUC.ucListBusiness" %>
<h2>
    Danh sách thông tin doanh nghiệp</h2>

<asp:GridView ID="gvAt" DataKeyNames="ArticleID" runat="server" AutoGenerateColumns="False"
    OnRowDeleting="gvAt_RowDeleting" CssClass="tstyle2""
    PageSize="100" Width="100%" PagerStyle-CssClass="pgr">
    <Columns>
        <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="True" SortExpression="STT" />
        <asp:BoundField DataField="Title" HeaderText="Tiêu đề" SortExpression="Title" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="Username" HeaderText="Người tạo" SortExpression="Username" />
        <asp:CheckBoxField DataField="IsPublish" HeaderText="Hiển thị" />
        <asp:CheckBoxField DataField="IsHompage" HeaderText="Trang chủ" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
                <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("ArticleID") %>'
                    CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Thêm mới" />
