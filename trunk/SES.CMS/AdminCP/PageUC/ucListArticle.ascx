<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListArticle.ascx.cs" Inherits="SES.CMS.AdminCP.PageUC.ucListArticle" %>
<h2>
    Danh sách Tin tức</h2>
<div style="width:90%; float:left; margin-bottom:10px;">
Lựa chọn theo Danh mục: <asp:DropDownList ID="cboCategory" runat="server" 
        AutoPostBack="True" 
        onselectedindexchanged="cboCategory_SelectedIndexChanged">
    </asp:DropDownList>
</div>

<asp:GridView ID="gvAt" DataKeyNames="ArticleID" runat="server" AutoGenerateColumns="False" 
    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
    CellPadding="4" onrowdeleting="gvAt_RowDeleting" 
    onselectedindexchanged="gvAt_SelectedIndexChanged" PageSize="100" Width="100%">
    <RowStyle BackColor="White" ForeColor="#330099" />
    <Columns>
        <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="True" 
            SortExpression="STT" />
        <asp:BoundField DataField="Title" HeaderText="Tiêu đề" SortExpression="Title" />
        <asp:BoundField DataField="CategoryName" HeaderText="Danh mục" 
            SortExpression="CategoryName" />
        <asp:BoundField DataField="Username" HeaderText="Người tạo" 
            SortExpression="Username" />
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
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
</asp:GridView>
<asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Thêm mới" />
