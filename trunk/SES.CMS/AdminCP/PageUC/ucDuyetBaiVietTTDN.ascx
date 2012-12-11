<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDuyetBaiVietTTDN.ascx.cs" Inherits="SES.CMS.AdminCP.PageUC.ucDuyetBaiVietTTDN" %>
<h2>
    Danh sách Tin tức</h2>
<div style="width: 100%; float: left; margin-bottom: 10px;">
    <div class="xd-filter">
        <span class="span-xd-radio">Trạng thái
            <asp:DropDownList ID="ddlTrangThai" runat="server" Width="203px" CssClass="ddl-input"
                AppendDataBoundItems="true">
                <asp:ListItem Text=".: Chọn tất cả :." Value="-1"></asp:ListItem>
                <asp:ListItem Text="Chưa duyệt" Value="0"></asp:ListItem>
                <asp:ListItem Text="Đã duyệt" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </span>
        Username
         <asp:DropDownList ID="ddlUserCreate" runat="server" CssClass="ddl-input" AppendDataBoundItems="true">
                <asp:ListItem Text=".: Chọn tất cả :." Value="0"></asp:ListItem>
            </asp:DropDownList>
        <span class="span-xd-button-filter">
            <asp:Button runat="server" CssClass="button-gg-green" ID="btnFilter" Text="Lọc bài viết"
                OnClick="btnFilter_Click" />
        </span>
    </div>
  
</div>
<div style="width: 100%; float: right; margin-bottom: 10px;">
        <span class="span-xd-button">
            <asp:Button runat="server" CssClass="button-gg-green" ID="btnAccept" Text="Duyệt bài viết"
                OnClick="btnAccept_Click" />
            <asp:Button runat="server" CssClass="button-gg-green" ID="btnNotAccept" Text="Bỏ duyệt"
                OnClick="btnNotAccept_Click" />
        </span>
    </div>
<asp:GridView ID="gvAt" DataKeyNames="ArticleID" runat="server" AutoGenerateColumns="False"
    OnRowDeleting="gvAt_RowDeleting" CssClass="tstyle2" OnSelectedIndexChanged="gvAt_SelectedIndexChanged"
    PageSize="40" Width="100%" PagerStyle-CssClass="pgr" AllowPaging="True" 
    onpageindexchanging="gvAt_PageIndexChanging">
    <Columns>
        <asp:TemplateField HeaderText="Select">
            <HeaderTemplate>
                <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this);"
                    runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkSelect" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="True" SortExpression="STT" />
        <asp:BoundField DataField="Title" HeaderText="Tiêu đề" SortExpression="Title" />
        <asp:BoundField DataField="CategoryName" HeaderText="Danh mục" SortExpression="CategoryName" />
        <asp:BoundField DataField="Username" HeaderText="Người tạo" SortExpression="Username" />
        <asp:BoundField DataField="Username" HeaderText="Người duyệt" SortExpression="UsernameXetDuyet" />
        <asp:CheckBoxField DataField="IsPublish" HeaderText="Hiển thị" />
        <asp:CheckBoxField DataField="IsHompage" HeaderText="Trang chủ" />
        <asp:CheckBoxField DataField="IsAccepted" HeaderText="Duyệt" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
                <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("ArticleID") %>'
                    CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div style="width: 100%; float: left; margin-top: 20px;">
    <span class="span-xd-button">
        <asp:Button runat="server" CssClass="button-gg-green" ID="btnAccept1" Text="Duyệt bài viết"
            OnClick="btnAccept_Click" />
        <asp:Button runat="server" CssClass="button-gg-green" ID="btnNotAccept1" Text="Bỏ duyệt"
            OnClick="btnNotAccept_Click" />
    </span>
</div>
