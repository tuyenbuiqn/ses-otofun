﻿<%@ Page Title="" Language="C#" EnableViewState="false" MasterPageFile="~/Otofun.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SES.CMS.Search" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="Module/ucTopRightCatAdv.ascx" TagName="ucTopRightCatAdv" TagPrefix="uc1" %>
<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucTieuDiem.ascx" TagName="ucTieuDiem" TagPrefix="uc5" %>
<%@ Register Src="Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc6" %>
<%@ Register Src="/Module/ucTopContactInfo.ascx" TagName="ucTopContactInfo" TagPrefix="uc13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="body-top">
        <div class="body-out">
            <div class="body-top-left">
                <uc6:ucTopAdvertisment runat="server" ID="uc1TopAdv" />
                <div class="category-box">
                    <div class="category-title-box">
                        <h2 class="category-title">
                            <asp:Label runat="server" ID="lblBreadcrumb"></asp:Label>Search</h2>
                        <span class="category-title-time">
                            <asp:Literal runat="server" ID="ltrDatetime"></asp:Literal></span>
                    </div>
                    <asp:Repeater runat="server" ID="rptTag" OnItemDataBound="rptTag_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel runat="server" id="divCategory">
                                <a title='<%#Eval("Title") %>' href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString()) %>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.ofn'>
                                    <img class="img-box" src='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>'></a>
                                <div class="cate-desc-box">
                                    <h2>
                                        <a title='<%#Eval("Title") %>' class="cate-title" href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString()) %>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.ofn'>
                                            <%#Eval("Title") %></a>
                                    </h2>
                                    <div class="cate-desc">
                                        <%#WordCut(Eval("Description").ToString()) %></div>
                                    <a class="readmore" title='<%#Eval("Title") %>' href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.ofn'>
                                        Xem tiếp</a>
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
                <uc5:ucTieuDiem runat="server" ID="uc5TieuDiem" />
                <uc1:ucTopRightCatAdv ID="ucTopRightCatAdv1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
