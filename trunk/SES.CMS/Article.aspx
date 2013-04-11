<%@ Page Title="" EnableViewState="False" Language="C#" MasterPageFile="~/Otofun.Master"
    AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="SES.CMS.Article" %>


<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucArticleAdv.ascx" TagName="ucArticleAdv" TagPrefix="uc3" %>
<%@ Register Src="Module/ucNewArticles.ascx" TagName="ucNewArticles" TagPrefix="uc4" %>
<%@ Register Src="Module/ucTieuDiem.ascx" TagName="ucTieuDiem" TagPrefix="uc5" %>
<%@ Register Src="Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc6" %>
<%@ Register Src="Module/ucTags.ascx" TagName="ucTags" TagPrefix="uc7" %>
<%@ Register Src="Module/ucSameCateArticles.ascx" TagName="ucSameCateArticles" TagPrefix="u8" %>
<%@ Register Src="/Module/ucTopContactInfo.ascx" TagName="ucTopContactInfo" TagPrefix="uc13" %>
<%@ Register Src="Module/ucComment.ascx" TagName="ucComment" TagPrefix="uc8" %>
<%@ Register Src="Module/ucRightArtAdv.ascx" TagName="ucRightArtAdv" TagPrefix="uc9" %>
<%@ Register Src="Module/ucTopRightArtAdv.ascx" TagName="ucTopRightArtAdv" TagPrefix="uc10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
	<script type="text/javascript" src="/js/jquery.nicescroll.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divListComment").niceScroll({ touchbehavior: false, cursorcolor: "#900000", cursoropacitymax: 0.7, cursorwidth: 5, cursorborderradius: "1px", autohidemode: "scroll" }).cursor.css(); // MAC like scrollbar
        });
</script>
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
                        <div class="social-content">
                            <iframe runat="server" id="abc" scrolling="no" frameborder="0" style="margin-top: 12px;
                                border: none; width: 75px; height: 20px;" allowtransparency="true"></iframe>
                            <asp:HyperLink runat="server" Target="_blank" ID="hplFacebook" NavigateUrl="http://www.facebook.com/sharer.php?u="><img alt="Chia sẻ thông tin này lên Facebook" width="20px" height="20px" src="/images/facebook.png" /></asp:HyperLink>
                            <asp:HyperLink runat="server" Target="_blank" ID="hplGoogle" NavigateUrl="https://plusone.google.com/_/+1/confirm?hl=en&url="><img alt="Chia sẻ lên Google Plus" width="20px" height="20px" src="/images/google.png" /></asp:HyperLink>
                            <asp:HyperLink runat="server" Target="_blank" ID="hplTwitter" NavigateUrl="http://twitter.com/home/?status="><img alt="Chia sẻ thông tin này lên Twitter" width="20px" height="20px" src="/images/twitter.png" /></asp:HyperLink>
                        </div>
                        <asp:Repeater runat="server" ID="rptArticleDetail" OnItemDataBound="rptArticleDetail_ItemDataBound">
                            <ItemTemplate>
                                <div class="breadcrumb-box">
                                    <h1 class="article-title">
                                        <%#Eval("Title") %>
                                    </h1>
                                </div>
                                <div class="art-authx">
                                    <img src="/images/news-icon-d.png" style="margin-right: 3px;" alt="">
                                    <%#CheckAuth(Eval("Author").ToString())%></div>
                                <div class="social-wrap">
                                    <span class="createdate-article">
                                        <%#Eval("ThoiGianXuatBan","{0:dd/MM/yyyy - hh:mm}") %></span>
                                </div>
                                <span class="article-desciption">
                                    <%#Eval("ArticleSP") %></span>
                                <asp:Repeater runat="server" ID="rptTinLienQuan2">
                                    <HeaderTemplate>
                                        <div class="tin-lien-quan-2">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a class="tin-lien-quan-2a" href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
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
                <div class="adv-homepage-right" style="margin: 14px 10px 0 10px;">
                    <uc10:ucTopRightArtAdv ID="ucTopRightArtAdv1" runat="server" />
                </div>
                <uc5:ucTieuDiem runat="server" ID="uc5TieuDiem" />
                <uc9:ucRightArtAdv ID="ucRightArtAdv1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
