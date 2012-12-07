<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVideo.ascx.cs" Inherits="SES.CMS.AdminCP.PageUC.ucVideo" %>
<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<%@ Register assembly="DevExpress.Web.v9.2" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>

<script type="text/javascript">
    function SelectAndClosePopup(value) {
        cbParent.SetValue(value);
        pcParent.Hide();
    }
</script>

<h2>
    Cập nhật Video</h2>
<table width="100%" class="tablet" style="border: 1px solid black;">
    <tr>
        <td class="style8">
            Tiêu đề
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle" runat="server" Width="273px" ValidationGroup="submitGrp"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                ErrorMessage="*** Nhập tiêu đề" ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
        </td>
    </tr>
<%--    <tr>
        <td>
            Phân loại
        </td>
        <td>
            <asp:RadioButton ID="rdoNWC" GroupName="type" Text="Hiển thị dưới slide trang chủ" runat="server" />
            <asp:RadioButton ID="rdoNW" runat="server" GroupName="type" Text="Trang tin tức" Visible="false" />
            <asp:RadioButton ID="rdoBC" GroupName="type" Text="Danh mục nhãn hiệu" runat="server" Visible="false" />
            <asp:RadioButton ID="rdoB" GroupName="type" Text="Trang Nhãn hiệu" runat="server" Visible="false" />
            <asp:RadioButton ID="rdoCT" GroupName="type" Text="Trang Liên hệ" runat="server" Visible="false" />
        </td>
    </tr>--%>
    <tr>
        <td class="style8">
           Thuộc danh mục
        </td>
        <td class="style9">
            <div style="float: left; vertical-align: middle;">
                <dxe:ASPxComboBox ID="cboParent" ClientEnabled="false" ClientInstanceName="cbParent"
                    runat="server" Height="16px" Width="143px">
                </dxe:ASPxComboBox>
            </div>
            <div style="float: left; margin-left: 5px; vertical-align: middle;">
                <dxe:ASPxButton ID="btnSelectParent" runat="server" Text="Chọn">
                    <ClientSideEvents Click="function(s, e) { pcParent.Show();}" />
                </dxe:ASPxButton>
            </div>
            <div style="float: left; margin-left: 5px; vertical-align: middle;">
                <asp:CheckBox ID="chkIsTop" runat="server" />Danh mục cấp cao nhất</div>
        </td>
    </tr>
    <tr>
        <td class="style8">Thuộc bài viết</td>
        <td class="style9">
            <asp:DropDownList runat="server" ID="ddlArticle" AppendDataBoundItems="true">
                <asp:ListItem Text=".: Không chọn :." Value="0"></asp:ListItem>
            </asp:DropDownList> 
        </td>
    </tr>

    <tr>
        <td class="style8">Thuộc Album</td>
        <td class="style9">
            <asp:DropDownList runat="server" ID="ddlAlbum" AppendDataBoundItems="true">
                <asp:ListItem Text=".: Không chọn :." Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td class="style8">Thuộc sự kiện</td>
        <td class="style9">
            <asp:DropDownList runat="server" ID="ddlEvent" AppendDataBoundItems="true">
                <asp:ListItem Text=".: Không chọn :." Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td class="style8">
            Video
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
            Thông tin
        </td>
        <td class="style9">
            <CKEditor:CKEditorControl ID="txtDescription" runat="server">
            </CKEditor:CKEditorControl>
        </td>
    </tr>

    <tr>
        <td class="style8">
            Hiển thị
        </td>
        <td class="style4">
            <div style="float: left; vertical-align: middle;">
                Thuộc trang chủ: <asp:CheckBox ID="chkIsHomePage" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
                Hiển thị<asp:CheckBox ID="chkIsPublish" runat="server"/>  &nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td class="style8">
            Tùy chỉnh
        </td>
        <td class="style4">
            <div style="float: left; vertical-align: middle;">
                Video xem nhiều<asp:CheckBox ID="chkMostView" runat="server"/>  &nbsp;&nbsp;&nbsp;&nbsp;
                Video mới: <asp:CheckBox ID="chkIsNew" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td>Số thứ tự</td>
        <td>  <div style="float: left; vertical-align: middle;">
                <asp:TextBox ID="txtOrderID" runat="server" Width="68px" ValidationGroup="submitGrp"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrderID"
                ErrorMessage="*** Cần nhập số thứ tự" ValidationGroup="submitGrp"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="style8">
            &nbsp;
        </td>
        <td class="style4">
            <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" ValidationGroup="submitGrp" />
            <asp:Button ID="btnReset" runat="server" Text="Hủy" />
        </td>
    </tr>
</table>
<dxpc:ASPxPopupControl ID="pcParent" runat="server" ClientInstanceName="pcParent"
    CloseAction="CloseButton" ContentUrl="~/AdminCP/ListCategory.aspx" HeaderText="Chọn danh mục mẹ"
    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Height="336px"
    Width="699px">
    <ContentCollection>
        <dxpc:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
        </dxpc:PopupControlContentControl>
    </ContentCollection>
</dxpc:ASPxPopupControl>