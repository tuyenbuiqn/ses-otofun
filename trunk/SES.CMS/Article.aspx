<%@ Page Title="" EnableViewState="False" Language="C#" MasterPageFile="~/Otofun.Master"
    AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="SES.CMS.Article" %>

<%@ Register Src="Module/ucLeftAdv.ascx" TagName="ucLeftAdv" TagPrefix="uc1" %>
<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucArticleAdv.ascx" TagName="ucArticleAdv" TagPrefix="uc3" %>
<%@ Register Src="Module/ucNewArticles.ascx" TagName="ucNewArticles" TagPrefix="uc4" %>
<%@ Register Src="Module/ucTieuDiem.ascx" TagName="ucTieuDiem" TagPrefix="uc5" %>
<%@ Register Src="Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc6" %>
<%@ Register Src="Module/ucTags.ascx" TagName="ucTags" TagPrefix="uc7" %>
<%@ Register Src="Module/ucSameCateArticles.ascx" TagName="ucSameCateArticles" TagPrefix="u8" %>
<%@ Register Src="/Module/ucTopContactInfo.ascx" TagName="ucTopContactInfo" TagPrefix="uc13" %>
<%@ Register Src="Module/ucComment.ascx" TagName="ucComment" TagPrefix="uc8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-top">
        <div class="body-out">
            <div class="body-top-left">
                <uc6:ucTopAdvertisment runat="server" ID="uc1TopAdv" />
                <div class="category-box">
                    <h3 class="hmp-cate-maintitle">
                        <span>
                            <asp:Literal runat="server" ID="lblBreadcrumb"></asp:Literal>
                        </span>
                    </h3>
                    <div class="article-box">
                        <asp:Repeater runat="server" ID="rptArticleDetail" OnItemDataBound="rptArticleDetail_ItemDataBound">
                            <ItemTemplate>
                                <div class="breadcrumb-box">
                                    <h1 class="article-title">
                                        <%#Eval("Title") %>
                                    </h1>
                                </div> <div class="art-authx">
                                   
                                        <img src="/images/news-icon-d.png" style="margin-right: 3px;" alt="">
                                        <%#CheckAuth(Eval("Author").ToString())%></div>
                                <span class="createdate-article">
                                    <%#Eval("CreateDate","{0:dd/MM/yyyy - hh:mm}") %></span>
                               
                                <span class="article-desciption">
                                    <%#Eval("ArticleSP") %></span>
                                <asp:Repeater runat="server" ID="rptTinLienQuan2">
                                    <HeaderTemplate>
                                        <div class="tin-lien-quan-2">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a class="tin-lien-quan-2a" href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.otofun'
                                            title='<%#Eval("Title") %>'>
                                            <img src="/images/news-icon-d.png" style="margin-right: 5px;" /><%#Eval("Title")%></a>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </div></FooterTemplate>
                                </asp:Repeater>
                                <div class="article-detail">
                                    <%#Eval("ArticleDetail") %>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <uc7:ucTags runat="server" ID="uc7ucTag" />
                    <uc8:ucComment ID="ucComment1" runat="server" />
                    <uc4:ucNewArticles Visible="false" ID="ucNewArticles1" runat="server" />
                    <u8:ucSameCateArticles runat="server" ID="uc9UcSameCate" />
                </div>
            </div>
            <div class="body-top-right">
                <uc13:ucTopContactInfo runat="server" ID="uc13UcTopContactInfo" />
                <uc5:ucTieuDiem runat="server" ID="uc5TieuDiem" />
                <uc1:ucLeftAdv ID="ucLeftAdv1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
