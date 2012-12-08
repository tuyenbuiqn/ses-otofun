<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdvertisement.ascx.cs"
    Inherits="SES.CMS.AdminCP.PageUC.ucAdvertisement" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<h2>
    Cập nhật quảng cáo</h2>
<table width="100%" class="tablet" style="border: 1px solid black;">
    <tr>
        <td class="style8">
            Tiêu đề:
        </td>
        <td class="style9" colspan="3">
            <asp:TextBox ID="txtTitle" runat="server" Width="90%" ValidationGroup="submitGrp"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                ErrorMessage="***" ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Vị trí
        </td>
        <td>
            <asp:DropDownList ID="ddlPosition" runat="server" CssClass="ddl-input" AppendDataBoundItems="true">
                <asp:ListItem Text="Top" Value="Top"></asp:ListItem>
                <asp:ListItem Text="Right" Value="Right"></asp:ListItem>
                <asp:ListItem Text="Top-Right" Value="Top-Right"></asp:ListItem>
                <asp:ListItem Text="Middle" Value="Middle"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Thuộc trang
        </td>
        <td>
            <asp:CheckBoxList runat="server" ID="chkLModule" AppendDataBoundItems="true">
                <asp:ListItem Text="Trang chủ" Value="Default.aspx"></asp:ListItem>
                <asp:ListItem Text="Bài viết chi tiết" Value="Article.aspx"></asp:ListItem>
                <asp:ListItem Text="Dòng sự kiện" Value="Event.aspx"></asp:ListItem>
                <asp:ListItem Text="Danh mục" Value="Category.aspx"></asp:ListItem>
                <asp:ListItem Text="Tag" Value="tag.aspx"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Mô tả quảng cáo
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtAdvInfo" runat="server" Height="102px" TextMode="MultiLine" Width="90%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Chi tiết:
        </td>
        <td colspan="3">
            <CKEditor:CKEditorControl ID="txtAdvDetail" runat="server" Width="90%">
            </CKEditor:CKEditorControl>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Hiển thị:
        </td>
        <td class="style4" colspan="3">
            <asp:CheckBox ID="chkIsPublish" runat="server" Text="Hiển thị" />
        </td>
    </tr>
    <tr>
        <td>
            Thứ tự
        </td>
        <td>
            <asp:TextBox ID="txtOrderID" runat="server" Width="68px" ValidationGroup="submitGrp"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrderID" ErrorMessage="*** Cần nhập số thứ tự"
                ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style8">
            &nbsp;
        </td>
        <td class="style4" colspan="3">
            <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" ValidationGroup="submitGrp" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy" />
        </td>
    </tr>
</table>
