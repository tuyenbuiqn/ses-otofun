<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucListConfig.ascx.cs"
    Inherits="SES.CMS.WEB.AdminCP.PageUC.ucListConfig" %>
<h2>
    Cấu hình hệ thống</h2>
<asp:GridView ID="gvConfig" runat="server" AutoGenerateColumns="False" Width="100%"
    DataKeyNames="ConfigID" OnPageIndexChanging="gvConfig_PageIndexChanging" OnRowDeleting="gvConfig_RowDeleting"
    OnSelectedIndexChanged="gvConfig_SelectedIndexChanged" AllowPaging="True" PagerStyle-CssClass="pgr"
    CssClass="tstyle2">
    <Columns>
        <asp:BoundField DataField="ConfigID" HeaderText="ConfigID">
            <HeaderStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="ConfigName" HeaderText="Tiêu đề" />
        <asp:TemplateField HeaderText="Thao tác">
            <ItemTemplate>
                <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
                <asp:ImageButton ID="btDelete" Visible="false" runat="server" CommandArgument='<%#Eval("ConfigID") %>'
                    CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button runat="server" ID="btnNewConfig" Text="Thêm mới" OnClick="btnNewConfig_Click"
    Visible="false" />
