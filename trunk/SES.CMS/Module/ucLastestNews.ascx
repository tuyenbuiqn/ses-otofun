<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLastestNews.ascx.cs"
    Inherits="SES.CMS.Module.ucLastestNews" %>
<h3 class="hmp-cate-maintitle">
    <span>NỔI BẬT</span>
</h3>
<ul class="tintuc-box">
    <asp:Repeater runat="server" ID="rptLastestNews">
        <ItemTemplate>
            <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.otofun'
                title='<%#Eval("Title") %>'>
                <%#Eval("Title") %></a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
