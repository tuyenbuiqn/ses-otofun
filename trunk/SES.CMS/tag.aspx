<%@ Page Title="" Language="C#" EnableViewState="false" MasterPageFile="~/Otofun.Master"
    AutoEventWireup="true" CodeBehind="tag.aspx.cs" Inherits="SES.CMS.tag" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="Module/ucTopRightCatAdv.ascx" TagName="ucTopRightCatAdv" TagPrefix="uc1" %>
<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucTieuDiem.ascx" TagName="ucTieuDiem" TagPrefix="uc5" %>
<%@ Register Src="Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc6" %>
<%@ Register Src="/Module/ucMostRead.ascx" TagName="ucMostRead" TagPrefix="uc7" %>
<%@ Register Src="/Module/ucTopContactInfo.ascx" TagName="ucTopContactInfo" TagPrefix="uc13" %>
<%@ Register Src="/Module/ucRightCatAdv.ascx" TagName="ucRightCatAdv" TagPrefix="uc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-top">
        <div class="body-out">
            <div class="body-top-left">
                <uc6:ucTopAdvertisment runat="server" ID="uc1TopAdv" />
                <div class="category-box">
                    <div class="category-title-box">
                         <h3 class="hmp-cate-maintitle">
                        <span><a class="rootcat">Từ khóa</a> » <asp:Literal ID="ltrKey" runat="server"></asp:Literal></span>
                            
                    </h3>
                        
                    </div>
                    <asp:Repeater runat="server" ID="rptTag" OnItemDataBound="rptTag_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel runat="server" ID="divCategory">
                                <a title='<%#Eval("Title") %>' href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString()) %>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.ofn'>
                                    <img class="img-box" src='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>'></a>
                                <div class="cate-desc-box">
                                    <h2>
                                        <a title='<%#Eval("Title") %>' class="cate-title" href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString()) %>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.ofn'>
                                            <%#Eval("Title") %></a>
                                    </h2>
                                    <div class="art-auth">
                                        <img src="/images/news-icon-d.png" style="margin-right: 3px;" />
                                        <%#CheckAuth(Eval("Author").ToString())%></div>
                                    <div class="cate-desc">
                                        <%#Eval("Description").ToString() %></div>
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
                            </asp:Panel>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="width: 100%; margin: 0 0 5px 0; float: right;">
                        <div class="collection">
                            <asp:HyperLink ID="hplPrevPage" runat="server">[Trang trước]</asp:HyperLink>
                            &nbsp;
                            <asp:HyperLink ID="hplNextPage" runat="server">[Trang sau]</asp:HyperLink>
                        </div>
                    </div>
                </div>
                <div style="width: 100%; margin: 20px 0; float: right;">
                    <div class="collection">
                        <cp:CollectionPager LabelText="Page:&amp;nbsp;&amp;nbsp;" FirstText="&amp;nbsp;&amp;nbsp;<<"
                            BackText="< &amp;nbsp;" LastText=">>" NextText=">" ShowFirstLast="True" ControlCssClass="collectionpager"
                            PagingMode="PostBack" runat="server" BackNextLinkSeparator="" BackNextLocation="Right"
                            PageNumbersDisplay="Numbers" ResultsLocation="None" BackNextDisplay="HyperLinks"
                            ID="CollectionPager1" BackNextButtonStyle="" BackNextStyle="margin-left:5px;"
                            ControlStyle="" PageNumbersSeparator="&amp;nbsp;" ShowLabel="True">
                        </cp:CollectionPager>
                        <div class="collectPage">
                        </div>
                    </div>
                </div>
            </div>
            <div class="body-top-right">
                <uc13:ucTopContactInfo runat="server" ID="uc13UcTopContactInfo" />
                <div class="adv-top-homepage-box" style="margin-top:12px;">
                    <div class="adv-homepage-right">
                        <img src="/Ads/pico.jpg" height="250" width="300">
                    </div>
                 
                </div>
                <uc7:ucmostread runat="server" ID="uc7ucMostRead" />
                <img src="/Ads/Your-ADS300x450.jpg" style="margin:10px;">
            </div>
        </div>
    </div>
                        
</asp:Content>
