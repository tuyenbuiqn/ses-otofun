<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true" CodeBehind="Slide.aspx.cs" Inherits="SES.CMS.ofeditor.Slide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width:98%; float:left; margin-left:5px;">
<h2>
    Cập nhật Slide</h2>
<table width="100%" class="tstyle2">
    <tr>
        <td class="style8">
            Tiêu đề:
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle" runat="server" Width="179px" ValidationGroup="submitGrp"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                ErrorMessage="*** Cần nhập tiêu đề" ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
            &nbsp; &nbsp; Số thứ tự:
            <asp:TextBox ID="txtOrder" runat="server" Width="50px" ValidationGroup="submitGrp"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOrder" ErrorMessage="*** Cần nhập số thứ tự"
                ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Hình ảnh
        </td>
        <td class="style9">
            <asp:FileUpload ID="fuImage" runat="server" />
            &nbsp;
            <asp:HyperLink ID="hplImage" runat="server" Target="_blank" Visible="False">[Xem 
            ảnh]</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Đường dẫn:
        </td>
        <td class="style9">
            <asp:TextBox ID="txtSlideURL" runat="server" Width="439px" ValidationGroup="submitGrp"></asp:TextBox>
            &nbsp; &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style8">
            Chi tiết:
        </td>
        <td>
            <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" Width="90%">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style8">
            &nbsp;
        </td>
        <td class="style4">
            <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" ValidationGroup="submitGrp" CssClass="button" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy" CssClass="button" />
        </td>
    </tr>
</table>
</div>
</asp:Content>
