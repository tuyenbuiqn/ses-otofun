<%@ Page EnableViewState="False" Title="" Language="C#" MasterPageFile="~/Otofun.Master"
    AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="SES.CMS.Category" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="Module/ucTopRightCatAdv.ascx" TagName="ucTopRightCatAdv" TagPrefix="uc1" %>
<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucTieuDiem.ascx" TagName="ucTieuDiem" TagPrefix="uc5" %>
<%@ Register Src="Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc6" %>
<%@ Register Src="/Module/ucTopContactInfo.ascx" TagName="ucTopContactInfo" TagPrefix="uc13" %>
<%@ Register Src="/Module/ucRightCatAdv.ascx" TagName="ucRightHomeCat" TagPrefix="uc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/styleCate.css" rel="stylesheet" type="text/css" />
      <script src="/js/js-scroll-cat.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="body-top">
        <div class="body-out">
            <div class="body-top-left">
                <uc6:ucTopAdvertisment runat="server" ID="uc1TopAdv" />
                <div class="category-box">
                    <h3 class="hmp-cate-maintitle">
                        <span>
                            <asp:Literal runat="server" ID="lblBreadcrumb"></asp:Literal></span>
                    </h3>
                    <div class="settop-wrap">
                    <asp:Repeater runat="server" ID="rptSetTop" OnItemDataBound="rptSetTop_ItemDataBound">
                        <ItemTemplate>
                     <asp:Panel runat="server" ID="divCategory">
                            
                                <a title='<%#Eval("Title") %>' href='/<%#ReturnCateID()%>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.ofn'>
                                    <img class="img-box" src="/images/grey.gif" data-original='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>'></a>
                                <div class="cate-desc-box">
                                    <h2>
                                        <a title='<%#Eval("Title") %>' class="cate-title" href='/<%#ReturnCateID() %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.ofn'>
                                            <%#Eval("Title") %></a>
                                    </h2>
                                    <div class="art-auth">
                                        <img src="/images/news-icon-d.png" style="margin-right: 3px;" />
                                        <%#CheckAuth(Eval("Author").ToString())%></div>
                                    <div class="cate-desc">
                                        <%#Eval("Description")%></div>
                                </div>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:Repeater>
                    </div>
                    <asp:Repeater runat="server" ID="rptCategory" OnItemDataBound="rptCategory_ItemDataBound">
                        <ItemTemplate>
                            <div class="category-wrap-first">
                                <%--<asp:Panel runat="server" ID="divCategory">--%>
                                <a title='<%#Eval("Title") %>' href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.ofn'>
                                    <img class="img-box" src="/images/grey.gif" data-original='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>'></a>
                                <div class="cate-desc-box">
                                    <h2>
                                        <a title='<%#Eval("Title") %>' class="cate-title" href='<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.ofn'>
                                            <%#Eval("Title") %></a>
                                    </h2>
                                    <div class="art-auth">
                                        <img src="/images/news-icon-d.png" style="margin-right: 3px;" />
                                        <%#CheckAuth(Eval("Author").ToString())%></div>
                                    <div class="cate-desc">
                                        <%#Eval("Description")%></div>
                                    <div class="tin-lien-quan1" style="width: auto; float: none;">
                                        <asp:Repeater runat="server" ID="rptTinLienQuan1">
                                            <ItemTemplate>
                                                <span class="tin-lien-quan-1a tin-lien-quan-1-category">
                                                    <img src="/images/news-icon-d.png" />
                                                    <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                                        title='<%#Eval("Title") %>'>
                                                        <%#Eval("Title")%></a> </span>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <%--</asp:Panel>--%>
                                </div>
                                </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div style="width: 100%; margin: 0 0 5px 0; float: right;">
                    <div class="collection">
                        <asp:HyperLink ID="hplPrevPage" runat="server">[Trang trước]</asp:HyperLink>
                        &nbsp;
                        <asp:HyperLink ID="hplNextPage" runat="server">[Trang sau]</asp:HyperLink>
                    </div>
                </div>
            </div>
            <div class="body-top-right">
                <uc13:ucTopContactInfo runat="server" ID="uc13UcTopContactInfo" />
                <uc1:ucTopRightCatAdv ID="ucTopRightCatAdv1" runat="server" />
                <uc5:ucTieuDiem runat="server" ID="uc5TieuDiem" />
                <uc11:ucRightHomeCat runat="server" ID="uc11ucRightHomeCat" />
            </div>
        </div>
    </div>
    <div id="divad" visible="false" runat="server">
<script language="javascript" type="text/javascript">
    var adbrand_zoneId = 'va_5E10E3FAAB615BF6';
    var adbrand_width = '250';
    var adbrand_height = '250';
    var adbrand_sizeId = '12';
    var adbrand_typeId = '2';  
</script> 
<script type="text/javascript" src="http://embed.adbrand.net/adbrand.js"></script> 
<!-- End: Adbrand -->
</div>
</asp:Content>
