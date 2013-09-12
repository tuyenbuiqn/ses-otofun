<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMainHomePageCategory.ascx.cs"
    Inherits="SES.CMS.Module.ucMainHomePageCategory" %>
<div class="body-down-left">
    <%--   <div class="TinTuc-wrapper">
                <div class="Cap-TinTuc">
                    <p>
                        <a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.ofn'
                            title='<%#Eval("Title") %>'>
                            <%#Eval("Title") %></a></p>
                </div>
                <ul class="link2">
                    <asp:Repeater runat="server" ID="rptChildCate">
                        <ItemTemplate>
                            <li><a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.ofn'
                                title='<%#Eval("Title") %>'>
                                <%#Eval("Title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="noidung">
                    <asp:Repeater runat="server" ID="rptTopHighLight" OnItemDataBound="rptTopHightLight_ItemDataBound">
                        <ItemTemplate>
                            <div class="left-noidung">
                                <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                    title='<%#Eval("Title") %>'>
                                    <img id="imgAnh-noidung" class="Anh-noidung" src='/Media/<%#Eval("ImageUrl") %>'
                                        alt='<%#Eval("Title") %>' /></a>
                            </div>
                            <div class="center-noidung">
                                <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                    title='<%#Eval("Title") %>'>
                                    <%#Eval("Title") %></a>
                            
                                <div class="chitiet">
                                    <%#Eval("Description")%>
                                </div>
                                <div class="tin-lien-quan1">
                                    <asp:Repeater runat="server" ID="rptTinLienQuan1">
                                        <ItemTemplate>
                                            <span class="tin-lien-quan-1a"><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                                title='<%#Eval("Title") %>'>» <%#Eval("Title")%></a> </span>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <ul class="right-noidung">
                        <asp:Repeater runat="server" ID="rptTopOtherHighLight">
                            <ItemTemplate>
                                <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                    title='<%#Eval("Title") %>'>
                                    <%#Eval("Title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>--%>
    <%--  body-down-right    --%>
    <asp:Repeater runat="server" ID="rptCategoryParent" OnItemDataBound="rptCategoryParent_ItemDataBound">
        <ItemTemplate>
            <div class="hmp-cate-wrap">
                <h3 class="hmp-cate-maintitle">
                    <span><a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.ofn'
                        title='<%#Eval("Title") %>'>
                        <%#Eval("Title") %></a> </span>
                    <ul class="link2" style="display: none;">
                        <asp:Repeater runat="server" ID="rptChildCate">
                            <ItemTemplate>
                                <li><a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.ofn'
                                    title='<%#Eval("Title") %>'>
                                    <%#Eval("Title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </h3>
                <div class="hmp-cate-wrap-inner">
                    <asp:Repeater runat="server" ID="rptTopArticle" OnItemDataBound="rptTopArticle_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel runat="server" ID="posTop">
                                <div class="hmp-top-article">
                                    <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                        title='<%#Eval("Title") %>'>
                                        <img src="/images/grey.gif" data-original='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>' />
                                    </a>
                                </div>
                                <h4 class="hmp-top-articletitle">
                                    <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                        title='<%#Eval("Title") %>'>
                                        <%#Eval("Title") %></a>
                                </h4>
                                <p class="hmp-top-articledes">
                                    <%#Eval("Description")%>
                                </p>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="hmp-cate-wrap-inner">
                    <ul class="hmp-ul-samecate-left">
                        <asp:Repeater runat="server" ID="rptOtherTopArticleLeft">
                            <ItemTemplate>
                                <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                    title='<%#Eval("Title") %>'>
                                    <%#Eval("Title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <ul class="hmp-ul-samecate-right">
                        <asp:Repeater runat="server" ID="rptOtherTopArticleRight">
                            <ItemTemplate>
                                <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                    title='<%#Eval("Title") %>'>
                                    <%#Eval("Title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
