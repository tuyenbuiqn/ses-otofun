<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUser.ascx.cs" Inherits="SES.CMS.WEB.AdminCP.PageUC.ucUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
    <h2>
        User&nbsp;</h2>
<table width="100%">
    <tr>
        <td class="style1">
            <p style="width: 120px; margin: 0">
                Username</p>
        </td>
        <td class="style1">
            <asp:TextBox ID="txtUsername" autocomplete="off" runat="server" Width="235px"></asp:TextBox>
        </td>
        <td class="style1">
            <p style="width: 120px; margin: 0">
                Password</p>
        </td>
        <td class="style1">
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Email</td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" Width="235px"></asp:TextBox>
        </td>
        <td>
            Active</td>
        <td>
            <asp:CheckBox ID="cbActive" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Chọn quyền</td>
        <td>
             <asp:DropDownList runat="server" ID="ddlNhomQuyen" AppendDataBoundItems="true">
            <asp:ListItem Text="Phóng viên" Value="0"></asp:ListItem>
            <asp:ListItem Text="Biên tập viên" Value="1"></asp:ListItem>
            <asp:ListItem Text="Thư ký" Value="2"></asp:ListItem>
            <asp:ListItem Text="Quản trị" Value="3"></asp:ListItem>
        </asp:DropDownList>
        </td>
        <td>
            Địa chỉ</td>
        <td>
             <asp:TextBox ID="txtAddress" runat="server" Width="235px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <div style="float: left; margin-right: 10px; margin-top: 10px;">
                <dxe:ASPxButton ID="btSave" runat="server" Text="Lưu" CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css"
                    CssPostfix="Soft_Orange" OnClick="btSave_Click">
                </dxe:ASPxButton>
            </div>
            <div style="margin-top: 10px;">
                <dxe:ASPxButton ID="btCancel" runat="server" Text="Hủy" CssFilePath="~/App_Themes/SoftOrange/{0}/styles.css"
                    CssPostfix="Soft_Orange">
                </dxe:ASPxButton>
            </div>
        </td>
    </tr>
</table>