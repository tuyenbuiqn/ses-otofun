<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSameCateArticles.ascx.cs" Inherits="SES.CMS.Module.ucSameCateArticles" %>
<div class="newarticle-box">
    <%--<h2>
        Bài viết cùng Danh mục</h2>
        <div class="line-article"></div>
    <ul class="ul-new-article">
        <asp:Repeater runat="server" ID="rptNewArticle">
            <ItemTemplate>
                <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.otofun'
                    title='<%#Eval("Title") %>'>
                    <%#Eval("Title") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>--%>
    <div class="Cap-bottom-box">
   <%-- <div class="Cap-bottom">
        <p>
            <asp:Label runat="server" ID="lblTitle"></asp:Label></p>
    </div>--%>
    <h2>
        Bài viết cùng Danh mục</h2>
</div>
<div class="promox-wrapper">
    <div class="promox-list">
        <div id="foox">
            <asp:Repeater runat="server" ID="rptNewArticle">
                <ItemTemplate>
                    <div class="promox-post fl clearfix">
                    <div class="promox-img-wrap">
                        <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-40/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.otofun'
                            title='<%#Eval("Title") %>' class="promox-post-img fl" >
                            <img src='/Media/<%#Eval("ImageUrl") %>'class="promox-img-post" alt='<%#Eval("Title") %>' />
                        </a>
                        </div>
                        <div class="promox-post-info fl">
                           <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-40/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.otofun'  title='<%#Eval("Title") %>' class="promox-post-title">
                                <h5>
                                    <%#Eval("Title") %></h5>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <a href="#" id="slidex-prev" class="fl" style="display: block;"><span>prev</span></a><div
            class="slidex-seperate fl">
        </div>
        <a href="#" id="slidex-next" class="fl" style="display: block;"><span>next</span></a>
    </div>
</div>

</div>
