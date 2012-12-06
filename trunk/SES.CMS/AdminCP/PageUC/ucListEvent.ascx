<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListEvent.ascx.cs" Inherits="SES.CMS.AdminCP.PageUC.ucListEvent" %>
<h2>
    Dòng sự kiện</h2>
<asp:GridView ID="grvEvent" DataKeyNames="EventID" runat="server" AutoGenerateColumns="False"
    OnRowDeleting="grvEvent_RowDeleting" CssClass="tstyle2" OnSelectedIndexChanged="grvEvent_SelectedIndexChanged"
    PageSize="100" Width="100%" PagerStyle-CssClass="pgr" 
    onpageindexchanged="grvEvent_PageIndexChanged" 
    onpageindexchanging="grvEvent_PageIndexChanging">
    <Columns>
        <asp:BoundField DataField="EventID" HeaderText="EventID" ReadOnly="True" />
        <asp:BoundField DataField="Title" HeaderText="Tiêu đề"  />
        <asp:BoundField DataField="CategoryTitle" HeaderText="Danh mục"/>
        <asp:CheckBoxField DataField="IsPublish" HeaderText="Hiển thị" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
                <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("EventID") %>'
                    CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Thêm mới" />
