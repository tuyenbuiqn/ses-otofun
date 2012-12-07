<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListUser.ascx.cs" Inherits="SES.CMS.WEB.AdminCP.PageUC.ucListUser" %>
<h2 style="text-align: left;">
    Danh sách User</h2>
<table style="border: 0px;" width="100%">
    <tr>
        <td>
            <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" Width="100%"
                DataKeyNames="UserID" OnPageIndexChanging="gvUser_PageIndexChanging" OnRowDeleting="gvUser_RowDeleting"
                OnSelectedIndexChanged="gvUser_SelectedIndexChanged"
                AllowPaging="True" PagerStyle-CssClass="pgr" CssClass="tstyle2">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Username" HeaderText="Tên người dùng" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="isActive" HeaderText="Active" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
                            <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("UserID") %>'
                                CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>