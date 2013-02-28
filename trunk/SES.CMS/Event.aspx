<%@ Page Title="" EnableViewState="false" Language="C#" MasterPageFile="~/Otofun.Master"
    AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="SES.CMS.Event" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="Module/ucLeftAdv.ascx" TagName="ucLeftAdv" TagPrefix="uc1" %>
<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucTieuDiem.ascx" TagName="ucTieuDiem" TagPrefix="uc5" %>
<%@ Register Src="Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc6" %>
<%@ Register Src="/Module/ucRightCatAdv.ascx" TagName="ucRightCatAdv" TagPrefix="uc11" %>
<%@ Register Src="/Module/ucTopContactInfo.ascx" TagName="ucTopContactInfo" TagPrefix="uc13" %>
<%@ Register Src="/Module/ucMostRead.ascx" TagName="ucMostRead" TagPrefix="uc7" %>
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
                        <span>DÒNG SỰ KIỆN <asp:Literal ID="ltrKey" runat="server"></asp:Literal></span>
                            
                    </h3>
                       
                    </div>
                    <div runat="server" id="divEvent">
                        <div class="list-event">
                            <asp:Repeater runat="server" ID="rptEvent">
                                <ItemTemplate>
                                    <div class="event-boxes-rows">
                                        <a href='/Event/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("EventID") %>.aspx'
                                            title='<%#Eval("Title") %>'>
                                            <%#Eval("Title") %>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div style="width: 100%; margin: 20px 0; float: right;">
                                <div class="collection">
                                    <cp:CollectionPager LabelText="Page:&amp;nbsp;&amp;nbsp;" FirstText="&amp;nbsp;&amp;nbsp;<<"
                                        BackText="< &amp;nbsp;" LastText=">>" NextText=">" ShowFirstLast="True" ControlCssClass="collectionpager"
                                        PagingMode="PostBack" runat="server" BackNextLinkSeparator="" BackNextLocation="Right"
                                        PageNumbersDisplay="Numbers" ResultsLocation="None" BackNextDisplay="HyperLinks"
                                        ID="CollectionPager2" BackNextButtonStyle="" BackNextStyle="margin-left:5px;"
                                        ControlStyle="" PageNumbersSeparator="&amp;nbsp;" ShowLabel="True">
                                    </cp:CollectionPager>
                                    <div class="collectPage">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divDetail" runat="server" visible="false">
                        <asp:Repeater runat="server" ID="rptCategory" OnItemDataBound="rptCategory_ItemDataBound">
                            <ItemTemplate>
                                <asp:Panel runat="server" ID="divCategory">
                                    <a title='<%#Eval("Title") %>' href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString()) %>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.otofun'>
                                        <img class="img-box" src='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>'></a>
                                    <div class="cate-desc-box">
                                        <h2>
                                            <a title='<%#Eval("Title") %>' class="cate-title" href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString()) %>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.otofun'>
                                                <%#Eval("Title") %></a>
                                        </h2>
                                        <div class="cate-desc">
                                            <%#WordCut(Eval("Description").ToString()) %></div>
                                        <a class="readmore" title='<%#Eval("Title") %>' href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.otofun'>
                                            Xem tiếp</a>
                                </asp:Panel>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
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
                </div>
            </div>
            <div class="body-top-right">
                <uc13:ucTopContactInfo runat="server" ID="uc13UcTopContactInfo" />
                 <div class="adv-top-homepage-box" style="margin-top:12px;">
                    <div class="adv-homepage-right">
                        <img src="/Ads/audi-rs6-06300x250.jpg" height="250" width="300">
                    </div>
                 
                </div>
                 <uc7:ucmostread runat="server" ID="uc7ucMostRead" />
                 <uc11:ucRightCatAdv runat="server" ID="uc11ucRightCatAdv" />
                <uc1:ucLeftAdv ID="ucLeftAdv1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
