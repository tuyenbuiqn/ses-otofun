<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="Event.aspx.cs" Inherits="SES.CMS.ofeditor.Event" %>

<%@ Register Assembly="DevExpress.Web.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function SelectAndClosePopup(value) {
            cbParent.SetValue(value);
            pcParent.Hide();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 98%; float: left; margin-left: 5px;">
        <h2>
            Cập nhật Danh mục Tin tức</h2>
        <table width="100%" class="tablet" style="border: 1px solid black;">
            <tr>
                <td class="style8">
                    Tiêu đề:
                </td>
                <td class="style9">
                    <asp:TextBox ID="txtTitle" runat="server" Width="273px" ValidationGroup="submitGrp"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="*** Nhập tiêu đề" ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Thuộc danh mục:
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
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Mô tả
                </td>
                <td class="style9">
                    <CKEditor:CKEditorControl ID="txtDescription" runat="server">
                    </CKEditor:CKEditorControl>
            </tr>
            <tr>
                <td class="style8">
                    Hiển thị:
                </td>
                <td class="style4">
                    <div style="float: left; vertical-align: middle;">
                        <asp:CheckBox ID="chkIsPublish" runat="server" Text="Có" />
                </td>
            </tr>
            <tr>
                <td>
                    Số thứ tự
                </td>
                <td>
                    <div style="float: left; vertical-align: middle;">
                        <asp:TextBox ID="txtOrderID" runat="server" Width="68px" ValidationGroup="submitGrp"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrderID"
                        ErrorMessage="*** Cần nhập số thứ tự" ValidationGroup="submitGrp"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;
                </td>
                <td class="style4">
                    <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" ValidationGroup="submitGrp" CssClass="button" />
                    <asp:Button ID="btnReset" runat="server" Text="Hủy"  CssClass="button"/>
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
    </div>
</asp:Content>
