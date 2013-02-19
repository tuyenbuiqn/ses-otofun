<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLastestNews.ascx.cs"
    Inherits="SES.CMS.Module.ucLastestNews" %>
<ul class="tintuc-box">
    <asp:Repeater runat="server" ID="rptLastestNews">
        <ItemTemplate>
            <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.otofun' title='<%#Eval("Title") %>'>
                <%#Eval("Title") %></a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
