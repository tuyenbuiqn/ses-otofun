<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewArticles.ascx.cs"
    Inherits="SES.CMS.Module.ucNewArticles" %>
<div class="newarticle-box">
    <h2>
        Bài viết mới</h2>
        <div class="line-article"></div>
    <ul class="ul-new-article">
        <asp:Repeater runat="server" ID="rptNewArticle">
            <ItemTemplate>
                <li><a href='/<%#FriendlyUrl(Eval("CategoryName").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                    title='<%#Eval("Title") %>' class="new-article">
                    <%#Eval("Title") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
