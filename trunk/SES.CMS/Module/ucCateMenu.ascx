<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCateMenu.ascx.cs" Inherits="SES.CMS.Module.ucCateMenu" %>
<ul class="mid-link">
    <asp:Repeater runat="server" ID="rptChildMenu">
        <ItemTemplate>
           <li><a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.aspx'
                        title='<%#Eval("Title") %>'>
                        <%#Eval("Title") %></a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
