<%@ Page EnableViewState="False" Title="" Language="C#" MasterPageFile="~/Otofun.Master"
    AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="SES.CMS.Category" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="Module/ucLeftAdv.ascx" TagName="ucLeftAdv" TagPrefix="uc1" %>
<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucTieuDiem.ascx" TagName="ucTieuDiem" TagPrefix="uc5" %>
<%@ Register Src="Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc6" %>
<%@ Register Src="/Module/ucTopContactInfo.ascx" TagName="ucTopContactInfo" TagPrefix="uc13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/styleCate.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-top">
        <div class="body-out">
            <div class="body-top-left">
                <uc6:ucTopAdvertisment runat="server" ID="uc1TopAdv" />
                <div class="category-box">
                    <div class="category-title-box">
                        <h2 class="category-title">
                            <asp:Label runat="server" ID="lblBreadcrumb"></asp:Label></h2>
                        <span class="category-title-time">
                            <asp:Literal runat="server" ID="ltrDatetime"></asp:Literal></span>
                    </div>
                    <asp:Repeater runat="server" ID="rptCategory" OnItemDataBound="rptCategory_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel runat="server" ID="divCategory">
                                <a title='<%#Eval("Title") %>' href='/<%#ReturnCateID()%>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.otofun'>
                                    <img class="img-box" src='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>'></a>
                                <div class="cate-desc-box">
                                    <h2>
                                        <a title='<%#Eval("Title") %>' class="cate-title" href='/<%#ReturnCateID() %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.otofun'>
                                            <%#Eval("Title") %></a>
                                    </h2>
                                    <div class="cate-desc">
                                        <%#Eval("Description") + "..."%></div>
                                    <div class="tin-lien-quan1" style="width:auto; float:none;">
                                        <asp:Repeater runat="server" ID="rptTinLienQuan1">
                                            <ItemTemplate>
                                                <span class="tin-lien-quan-1a tin-lien-quan-1-category"><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.otofun'
                                                    title='<%#Eval("Title") %>'>»
                                                    <%#Eval("Title")%></a> </span>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <a class="readmore fix-postion" title='<%#Eval("Title") %>' href='/<%#ReturnCateID()%>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID")%>.otofun'>
                                        Xem tiếp</a>
                            </asp:Panel>
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
                <uc5:ucTieuDiem runat="server" ID="uc5TieuDiem" />
                <uc1:ucLeftAdv ID="ucLeftAdv1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
