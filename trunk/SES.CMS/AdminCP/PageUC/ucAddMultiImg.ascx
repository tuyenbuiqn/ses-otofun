<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAddMultiImg.ascx.cs"
    Inherits="SES.CMS.AdminCP.PageUC.ucAddMultiImg" %>
<h2>
    Cập nhật hình ảnh</h2>
<table width="100%" border="1">
    <tr visible="false" runat="server">
        <td class="style8">
            Album:
        </td>
        <td class="style9">
            <asp:DropDownList ID="ddlAlbum" runat="server" AppendDataBoundItems="true" Width="250px">
                <asp:ListItem Text=" .: Không chọn :. " Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Slide:
        </td>
        <td>
            <asp:DropDownList ID="ddlSlide" runat="server" AppendDataBoundItems="true" Width="250px">
                <asp:ListItem Text=" .: Không chọn :. " Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Danh mục:
        </td>
        <td>
            <asp:DropDownList ID="ddlCate" runat="server" AppendDataBoundItems="true" Width="250px">
                <asp:ListItem Text=" .: Không chọn :. " Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Bài viết:
        </td>
        <td>
            <asp:DropDownList ID="ddlArticle" runat="server" AppendDataBoundItems="true" Width="250px">
                <asp:ListItem Text=" .: Không chọn :. " Value="0"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Hình ảnh 1
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle1" runat="server" Width="179px"></asp:TextBox>
            <asp:FileUpload ID="fuImage1" runat="server" />
            &nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" Visible="False">[Xem 
        ảnh]</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Hình ảnh 2
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle2" runat="server" Width="179px" ValidationGroup="submitGrp"></asp:TextBox>
            <asp:FileUpload ID="fuImage2" runat="server" />
            &nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" Visible="False">[Xem 
        ảnh]</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Hình ảnh 3
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle3" runat="server" Width="179px" ValidationGroup="submitGrp"></asp:TextBox>
            <asp:FileUpload ID="fuImage3" runat="server" />
            &nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" Target="_blank" Visible="False">[Xem 
        ảnh]</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Hình ảnh 4
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle4" runat="server" Width="179px" ValidationGroup="submitGrp"></asp:TextBox>
            <asp:FileUpload ID="fuImage4" runat="server" />
            &nbsp;
            <asp:HyperLink ID="HyperLink4" runat="server" Target="_blank" Visible="False">[Xem 
        ảnh]</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Hình ảnh 5
        </td>
        <td class="style9">
            <asp:TextBox ID="txtTitle5" runat="server" Width="179px" ValidationGroup="submitGrp"></asp:TextBox>
            <asp:FileUpload ID="fuImage5" runat="server" />
            &nbsp;
            <asp:HyperLink ID="HyperLink5" runat="server" Target="_blank" Visible="False">[Xem 
        ảnh]</asp:HyperLink>
        </td>
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
