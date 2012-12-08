<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListAdvertisement.ascx.cs"
    Inherits="SES.CMS.AdminCP.PageUC.ucListAdvertisement" %>
<h2>
    Danh sách quảng cáo</h2>
<div style="width: 100%; float: left; margin-bottom: 10px;">
    <div class="xd-filter">
        <span class="span-xd-category">Vị trí:
            <asp:DropDownList ID="ddlPosition" runat="server" CssClass="ddl-input" AppendDataBoundItems="true">
            <asp:ListItem Text=".: Chọn tất cả :." Value="0"></asp:ListItem>
                <asp:ListItem Text="Top" Value="Top"></asp:ListItem>
                <asp:ListItem Text="Right" Value="Right"></asp:ListItem>
                <asp:ListItem Text="Top-Right" Value="Top-Right"></asp:ListItem>
                <asp:ListItem Text="Middle" Value="Middle"></asp:ListItem>
            </asp:DropDownList>
        </span><span class="span-xd-radio">Thuộc trang
            <asp:DropDownList ID="ddlModule" runat="server" Width="203px" CssClass="ddl-input"
                AppendDataBoundItems="true">
               <asp:ListItem Text=".: Chọn tất cả :." Value="0"></asp:ListItem>
               <asp:ListItem Text="Trang chủ" Value="Default.aspx"></asp:ListItem>
               <asp:ListItem Text="Bài viết chi tiết" Value="Article.aspx"></asp:ListItem>
               <asp:ListItem Text="Dòng sự kiện" Value="Event.aspx"></asp:ListItem>
               <asp:ListItem Text="Danh mục" Value="Category.aspx"></asp:ListItem>
               <asp:ListItem Text="Tag" Value="tag.aspx"></asp:ListItem>
            </asp:DropDownList>
        </span>Hiển thị
        <asp:DropDownList ID="ddlIsPublish" runat="server" CssClass="ddl-input" AppendDataBoundItems="true">
            <asp:ListItem Text=".: Chọn tất cả :." Value="-1"></asp:ListItem>
            <asp:ListItem Text="Không hiển thị" Value="0"></asp:ListItem>
            <asp:ListItem Text="Hiển thị" Value="1"></asp:ListItem>
        </asp:DropDownList>
        <span class="span-xd-button-filter">
            <asp:Button runat="server" CssClass="button-gg-green" ID="btnFilter" Text="Lọc quảng cáo"
                OnClick="btnFilter_Click" />
        </span>
    </div>
</div>
<asp:GridView ID="gvAdv" DataKeyNames="AdvertisementID" runat="server" AutoGenerateColumns="False"
    OnRowDeleting="gvAdv_RowDeleting" CssClass="tstyle2" OnSelectedIndexChanged="gvAdv_SelectedIndexChanged"
    PageSize="50" Width="100%" PagerStyle-CssClass="pgr" AllowPaging="True" 
    onpageindexchanging="gvAdv_PageIndexChanging">
    <Columns>
        <asp:BoundField DataField="Title" HeaderText="Tiêu đề" ItemStyle-Width="20%" />
        <asp:BoundField DataField="Position" HeaderText="Vị trí" ItemStyle-Width="15%" />
        <asp:BoundField DataField="Module" HeaderText="Trang hiển thị" ItemStyle-Width="15%" />
        <asp:BoundField DataField="AdvInfo" HeaderText="Thông tin" ItemStyle-Width="20%" />
        <asp:CheckBoxField DataField="IsPublish" HeaderText="Hiển thị" ItemStyle-Width="10%" />
        <asp:BoundField DataField="UserName" HeaderText="Người tạo" ItemStyle-Width="10%" />
        <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="10%">
            <ItemTemplate>
                <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
                <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("AdvertisementID") %>'
                    CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

