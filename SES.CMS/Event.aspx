<%@ Page Title="" Language="C#" MasterPageFile="~/Otofun.Master" AutoEventWireup="true"
    CodeBehind="Event.aspx.cs" Inherits="SES.CMS.Event" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="Module/ucLeftAdv.ascx" TagName="ucLeftAdv" TagPrefix="uc1" %>
<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucTieuDiem.ascx" TagName="ucTieuDiem" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-top">
        <div class="body-out">
            <div class="float-left wid470">
                <div id="divEvent" runat="server" visible="false">
                    <div class="Event-boxes">
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
                    <asp:Repeater runat="server" ID="rptCategory">
                        <ItemTemplate>
                            <div class="category-wrap">
                                <a title='<%#Eval("Title") %>' href='/<%#FriendlyUrl(Eval("CategoryName").ToString()) %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.aspx'>
                                    <img class="img130" src='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>'></a>
                                <div class="mr1">
                                    <h2>
                                        <a title='<%#Eval("Title") %>' class="fon6" href='/<%#FriendlyUrl(Eval("CategoryName").ToString()) %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.aspx'
                                            alt='<%#Eval("Title") %>'>
                                            <%#Eval("Title") %></a>
                                    </h2>
                                    <div class="fon5 fl">
                                        <%#WordCut(Eval("Description").ToString()) %></div>
                                    <a class="readmore" title='<%#Eval("Title") %>' href='/<%#FriendlyUrl(Eval("CategoryName").ToString()) %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.aspx'>
                                        Xem tiếp</a>
                                </div>
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
            <div class="leftContent-box">
                <uc1:ucLeftAdv ID="ucLeftAdv1" runat="server" />
            </div>
            <div class="rightContent-box">
                <uc2:ucRightAdv ID="ucRightAdv1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
