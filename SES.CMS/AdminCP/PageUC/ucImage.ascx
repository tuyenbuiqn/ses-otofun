<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucImage.ascx.cs" Inherits="SES.CMS.AdminCP.PageUC.ucImage" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<h2>
    Cập nhật hình ảnh</h2>
<table width="100%" class="tablet">
    <tr>
        <td class="style8">
            Tiêu đề:
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle" runat="server" Width="179px" ValidationGroup="submitGrp"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                ErrorMessage="*** Cần nhập tiêu đề" ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr id="trDes" runat="server" visible="true">
        <td class="style8">
            Mô tả:
        </td>
        <td>
            <CKEditor:CKEditorControl FilebrowserImageBrowseUrl="/ckfinder/ckfinder.html?type=Images"
                FilebrowserImageUploadUrl="/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images"
                BasePath="/ckeditor/" ID="txtDescription" TextMode="MultiLine" runat="server"
                Width="90%">
            </CKEditor:CKEditorControl>
        </td>
    </tr>
      <tr visible="false" runat="server">
        <td>
            Thuộc album
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlAlbum" AppendDataBoundItems="true" Width="200px">
                <asp:ListItem Text=".: Không chọn :. " Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Thuộc danh mục
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlCate" AppendDataBoundItems="true" Width="200px">
                <asp:ListItem Text=".: Không chọn :. " Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td>
            Thuộc slide
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlSlide" AppendDataBoundItems="true" Width="200px">
                <asp:ListItem Text=".: Không chọn :. " Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td>
            Thuộc bài viết
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlArticle" AppendDataBoundItems="true" Width="200px">
            <asp:ListItem Text=".: Không chọn :. " Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr runat="server" id="trPopup">
        <td class="style8">
            Hình ảnh
        </td>
        <td class="style9">
            <asp:FileUpload ID="fuImage" runat="server" />
            &nbsp;
            <asp:HyperLink ID="hplImage" runat="server" Target="_blank">[Xem 
            ảnh]</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="style8">
            &nbsp;
        </td>
        <td class="style4">
            <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" ValidationGroup="submitGrp" />
        </td>
    </tr>
</table>
