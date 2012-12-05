<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAlbum.ascx.cs" Inherits="SES.CMS.AdminCP.PageUC.ucAlbum" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<h2>
    Cập nhật Album</h2>
<table width="100%" border="1">
    <tr>
        <td class="style8">
            Tiêu đề:
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle" runat="server" Width="179px" 
                ValidationGroup="submitGrp"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtTitle" ErrorMessage="*** Cần nhập tiêu đề" 
                ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
        &nbsp;
            &nbsp;
            
            </td>
    </tr>   
   <tr>
        <td class="style8">
         Danh mục dịch vụ: 
        </td>
        <td class="style9">
      <asp:DropDownList ID="cboCategory" runat="server">
    </asp:DropDownList>
        </td>
        </tr>
   <tr>
        <td class="style8">
         Hình ảnh đại diện cho Ảnh Album:
        </td>   
        <td>
            <asp:TextBox ID="txtTitle1" runat="server" Width="179px"></asp:TextBox>
            <asp:FileUpload ID="fuImage1" runat="server" />
        </td>
   </tr>
   
   <tr>
        <td class="style8">
         Hình ảnh đại diện cho Ảnh Kiểu:
        </td> 
        <td>
            <asp:TextBox ID="txtTitle2" runat="server" Width="179px"></asp:TextBox>
            <asp:FileUpload ID="fuImage2" runat="server" />
        </td>
   </tr>
   
    <tr>
        <td class="style8">
            Mô tả:</td>
        <td>
            <CKEditor:CKEditorControl ID="txtDescription" runat="server" Width="90%">
            </CKEditor:CKEditorControl>
        </td>
    </tr>
    
   
    <tr>
        <td class="style8">
            &nbsp;
        </td>
        <td class="style4">
            <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" 
                ValidationGroup="submitGrp" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy" />
        </td>
    </tr>
</table>