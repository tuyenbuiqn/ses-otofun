<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCateMenu.ascx.cs" Inherits="SES.CMS.Module.ucCateMenu" %>
    <asp:Repeater runat="server" ID="rptChildMenu">
    <HeaderTemplate>
    <div class="dmid-link">
<ul class="mid-link">
    </HeaderTemplate>
        <ItemTemplate>
           <li><a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.otofun'
                        title='<%#Eval("Title") %>'>
                        <%#Eval("Title") %></a></li>
        </ItemTemplate>
        <FooterTemplate></ul>
</div></FooterTemplate>
    </asp:Repeater>

