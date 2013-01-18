<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListUser.ascx.cs"
    Inherits="SES.CMS.WEB.AdminCP.PageUC.ucListUser" %>
<h2 style="text-align: left;">
    Danh sách User</h2>
<div style="width: 100%; float: left;">
    <span style="float: right;">Chọn theo nhóm quyền:
        <asp:DropDownList runat="server" ID="ddlNhomQuyen" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlNhomQuyen_SelectedIndexChanged">
            <asp:ListItem Text=".: Chọn tất cả :." Value="-1"></asp:ListItem>
            <asp:ListItem Text="Phóng viên" Value="0"></asp:ListItem>
            <asp:ListItem Text="Biên tập viên" Value="1"></asp:ListItem>
            <asp:ListItem Text="Thư ký" Value="2"></asp:ListItem>
            <asp:ListItem Text="Quản trị" Value="3"></asp:ListItem>
        </asp:DropDownList>
    </span>
</div>
<table style="border: 0px;" width="100%">
    <tr>
        <td>
            <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" Width="100%"
                DataKeyNames="UserID" OnPageIndexChanging="gvUser_PageIndexChanging" OnRowDeleting="gvUser_RowDeleting"
                OnSelectedIndexChanged="gvUser_SelectedIndexChanged" AllowPaging="True" PagerStyle-CssClass="pgr"
                CssClass="tstyle2">
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
<div style="float:left; white-space:100%; margin-top:10px;">
    <a href="Default.aspx?Page=User" class="button-gg-green">Thêm người dùng</a>
</div>
