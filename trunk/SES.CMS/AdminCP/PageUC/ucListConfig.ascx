<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListConfig.ascx.cs" Inherits="SES.CMS.WEB.AdminCP.PageUC.ucListConfig" %>
<h2>Cấu hình hệ thống</h2>
<asp:GridView ID="gvConfig" runat="server" AutoGenerateColumns="False" BackColor="White"
    BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Width="100%"
    DataKeyNames="ConfigID" OnPageIndexChanging="gvConfig_PageIndexChanging" OnRowDeleting="gvConfig_RowDeleting"
    OnSelectedIndexChanged="gvConfig_SelectedIndexChanged" AllowPaging="True">
    <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" />
    <Columns>
        <asp:BoundField DataField="ConfigID" HeaderText="ConfigID">
            <HeaderStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="ConfigName" HeaderText="Tiêu đề" />
        <asp:TemplateField HeaderText="Thao tác">
            <ItemTemplate>
                <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
                <asp:ImageButton ID="btDelete" Visible="false" runat="server" CommandArgument='<%#Eval("ConfigID") %>'
                    CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
</asp:GridView>
<asp:Button runat="server" ID="btnNewConfig" Text="Thêm mới" OnClick="btnNewConfig_Click" Visible="false" />
