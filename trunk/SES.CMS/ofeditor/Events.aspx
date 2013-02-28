<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true"
    CodeBehind="Events.aspx.cs" Inherits="SES.CMS.ofeditor.Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 98%; margin-left: 5px; float: left;">
        <h2>
            Dòng sự kiện</h2>
            <p style="float:right">
            Chọn danh mục:
                <asp:DropDownList runat="server" ID="ddlDongSuKien" AppendDataBoundItems="true" 
                    AutoPostBack="true" onselectedindexchanged="ddlDongSuKien_SelectedIndexChanged">
                    <asp:ListItem Text=".: Chọn tất cả :." Value="0"></asp:ListItem>
                    <asp:ListItem Text="Trang chủ" Value="8"></asp:ListItem>
                </asp:DropDownList>
            </p>
        <asp:GridView ID="grvEvent" DataKeyNames="EventID" runat="server" AutoGenerateColumns="False"
            OnRowDeleting="grvEvent_RowDeleting" CssClass="tstyle2" OnSelectedIndexChanged="grvEvent_SelectedIndexChanged"
            PageSize="100" Width="100%" PagerStyle-CssClass="pgr" OnPageIndexChanged="grvEvent_PageIndexChanged"
            OnPageIndexChanging="grvEvent_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="EventID" HeaderText="EventID" ReadOnly="True" Visible="false" />
                <asp:BoundField DataField="Title" HeaderText="Tiêu đề" />
                <asp:BoundField DataField="CategoryTitle" HeaderText="Danh mục" />
                <asp:CheckBoxField DataField="IsPublish" HeaderText="Hiển thị" />
                <asp:TemplateField HeaderText="Thao tác">
                    <ItemTemplate>
                        <asp:ImageButton ID="btEdit" runat="server" CommandName="Select" ImageUrl="~/AdminCP/images/edit_16x16.gif" />
                        <asp:ImageButton ID="btDelete" runat="server" CommandArgument='<%#Eval("EventID") %>'
                            CommandName="Delete" ImageUrl="~/AdminCP/images/delete_16x16.gif" OnClientClick="return confirm('Có muốn xóa bản ghi này? Nhấn OK để xóa!')" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Thêm mới" Visible="false" />
    </div>
    <br />
    <p style="float: left; margin: 5px; margin-top: 10px;">
        <a href="Event.aspx" target="_self" class="button-gg-green">Thêm dòng sự kiện</a>
    </p>
</asp:Content>
