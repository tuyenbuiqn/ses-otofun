<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSameCateArticles.ascx.cs" Inherits="SES.CMS.Module.ucSameCateArticles" %>
<div class="newarticle-box">
    <h2>
        Bài viết cùng Danh mục</h2>
        <div class="line-article"></div>
    <ul class="ul-new-article">
        <asp:Repeater runat="server" ID="rptNewArticle">
            <ItemTemplate>
                <li><a href='/<%#FriendlyUrl(Eval("CategoryName").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                    title='<%#Eval("Title") %>'>
                    <%#Eval("Title") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
