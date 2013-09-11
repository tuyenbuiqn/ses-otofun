<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDuyetComment.ascx.cs"
    Inherits="SES.CMS.ofeditor.Module.ucDuyetComment" %>
<h2>
    Danh sách bình luận</h2>
<div style="width: 100%; float: left; margin-bottom: 10px;">
    <div class="xd-filter">
        <span class="span-xd-category">Bài viết:
            <asp:DropDownList ID="ddlArticle" runat="server" CssClass="ddl-input" AppendDataBoundItems="true">
                <asp:ListItem Text=".: Chọn tất cả :." Value="0"></asp:ListItem>
            </asp:DropDownList>
        </span><span class="span-xd-radio">Trạng thái
            <asp:DropDownList ID="ddlTrangThai" runat="server" Width="183px" CssClass="ddl-input"
                AppendDataBoundItems="true">
                <asp:ListItem Text=".: Chọn tất cả :." Value="-1"></asp:ListItem>
                <asp:ListItem Text="Chưa duyệt" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Đã duyệt" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </span>User xét duyệt
        <asp:DropDownList ID="ddlUserCreate" runat="server" CssClass="ddl-input" AppendDataBoundItems="true">
            <asp:ListItem Text=".: Chọn tất cả :." Value="0"></asp:ListItem>
        </asp:DropDownList>
        <span class="span-xd-button-filter">
            <asp:Button runat="server" CssClass="button-gg-green1" ID="btnFilter" Text="Lọc bình luận"
                OnClick="btnFilter_Click" />
        </span>
    </div>
</div>
<div style="width: 100%; float: right; margin-bottom: 10px;">
    <span class="span-xd-button">
        <asp:Button runat="server" CssClass="button-gg-green1" ID="btnAccept" Text="Duyệt bình luận"
            OnClick="btnAccept_Click" />
        <asp:Button runat="server" CssClass="button-gg-green1" ID="btnNotAccept" Text="Bỏ duyệt"
            OnClick="btnNotAccept_Click" />
        <asp:Button runat="server" CssClass="button-gg-green1" ID="btnDeleteMulti" Text="Xóa bình luận"
            OnClick="btnDeleteMulti_Click" />
    </span>
</div>
<asp:GridView ID="gvAt" DataKeyNames="CommentID" runat="server" AutoGenerateColumns="False"
    OnRowDeleting="gvAt_RowDeleting" CssClass="tstyle2" PageSize="40" Width="100%"
    PagerStyle-CssClass="pgr" AllowPaging="True" OnPageIndexChanging="gvAt_PageIndexChanging"
    OnRowCancelingEdit="gvAt_RowCancelingEdit" OnRowEditing="gvAt_RowEditing" OnRowUpdating="gvAt_RowUpdating">
    <Columns>
        <asp:TemplateField Visible="false">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblCommentID" Text='<%#Eval("CommentID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Select">
            <HeaderTemplate>
                <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this);"
                    runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkSelect" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Họ tên" ItemStyle-Width="15%">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblHoTen" Text='<%#Eval("Name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email" ItemStyle-Width="10%">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblEmail" Text='<%#Eval("Email") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="50%">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblContent" Text='<%#Eval("Contents") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Width="500px" Rows="5"
                    Height="50px" Text='<%#Eval("Contents")%>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bài viết" ItemStyle-Width="15%">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblTitle" Text='<%#Eval("ArticleTitle") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CheckBoxField DataField="IsAccepted" HeaderText="Duyệt" ItemStyle-Width="5%" />
        <asp:CommandField ShowEditButton="true" HeaderText="Edit" CausesValidation="false" />
        <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
                <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("CommentID") %>'
                    CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div style="width: 100%; float: left; margin-top: 20px;">
    <span class="span-xd-button">
        <asp:Button runat="server" CssClass="button-gg-green1" ID="btnAccept1" Text="Duyệt bình luận"
            OnClick="btnAccept_Click" />
        <asp:Button runat="server" CssClass="button-gg-green1" ID="btnNotAccept1" Text="Bỏ duyệt"
            OnClick="btnNotAccept_Click" />
              <asp:Button runat="server" CssClass="button-gg-green1" ID="btnDeleteMulti1" Text="Xóa bình luận"
            OnClick="btnDeleteMulti_Click" />
    </span>
</div>
