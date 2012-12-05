<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListSlide.ascx.cs" Inherits="SES.CMS.WEB.AdminCP.PageUC.ucListSlide" %>
<h2>
    Danh sách Slide</h2>

<asp:GridView ID="gvSlide" DataKeyNames="SlideID" runat="server" AutoGenerateColumns="False" 
    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
    CellPadding="4" onrowdeleting="gvSlide_RowDeleting" 
    onselectedindexchanged="gvSlide_SelectedIndexChanged" PageSize="100" Width="100%">
    <Columns>
        <asp:BoundField DataField="Title" HeaderText="Tiêu đề" SortExpression="Title" />
        <asp:BoundField DataField="SlideURL" HeaderText="Đường dẫn" SortExpression="SlideURL" />
        <asp:TemplateField Visible="false">
            <ItemTemplate>
                <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
              
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
       <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
</asp:GridView>
<asp:Button ID="btnAddImages" runat="server" onclick="btnAddImages_Click" Text="Thêm ảnh" />