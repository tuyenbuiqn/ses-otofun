<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMainHomePageCategory.ascx.cs"
    Inherits="SES.CMS.Module.ucMainHomePageCategory" %>
<div class="body-down-left">
    <asp:Repeater runat="server" ID="rptCategoryParent" OnItemDataBound="rptCategoryParent_ItemDataBound">
        <ItemTemplate>
            <div class="TinTuc-wrapper">
                <div class="Cap-TinTuc">
                    <p>
                        <a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.aspx'
                            title='<%#Eval("Title") %>'>
                            <%#Eval("Title") %></a></p>
                </div>
                <ul class="link2">
                    <asp:Repeater runat="server" ID="rptChildCate">
                        <ItemTemplate>
                            <li><a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.aspx'
                                title='<%#Eval("Title") %>'>
                                <%#Eval("Title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="noidung">
                    <asp:Repeater runat="server" ID="rptTopHighLight" OnItemDataBound="rptTopHightLight_ItemDataBound">
                        <ItemTemplate>
                            <div class="left-noidung">
                                <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                                    title='<%#Eval("Title") %>'>
                                    <img id="imgAnh-noidung" class="Anh-noidung" src='/Media/<%#Eval("ImageUrl") %>'
                                        alt='<%#Eval("Title") %>' /></a>
                            </div>
                            <div class="center-noidung">
                                <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                                    title='<%#Eval("Title") %>'>
                                    <%#Eval("Title") %></a>
                            
                                <div class="chitiet">
                                    <%#Eval("Description")%>
                                </div>
                                <div class="tin-lien-quan1">
                                    <asp:Repeater runat="server" ID="rptTinLienQuan1">
                                        <ItemTemplate>
                                            <span class="tin-lien-quan-1a"><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                                                title='<%#Eval("Title") %>'>» <%#WordCutArticle(Eval("Title").ToString()) %></a> </span>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <ul class="right-noidung">
                        <asp:Repeater runat="server" ID="rptTopOtherHighLight">
                            <ItemTemplate>
                                <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                                    title='<%#Eval("Title") %>'>
                                    <%#Eval("Title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <%--  body-down-right    --%>
</div>
