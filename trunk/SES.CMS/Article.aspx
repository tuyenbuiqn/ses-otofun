<%@ Page Title="" Language="C#" MasterPageFile="~/Otofun.Master" AutoEventWireup="true"
    CodeBehind="Article.aspx.cs" Inherits="SES.CMS.Article" %>

<%@ Register Src="Module/ucLeftAdv.ascx" TagName="ucLeftAdv" TagPrefix="uc1" %>
<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucArticleAdv.ascx" TagName="ucArticleAdv" TagPrefix="uc3" %>
<%@ Register Src="Module/ucNewArticles.ascx" TagName="ucNewArticles" TagPrefix="uc4" %>
<%@ Register Src="Module/ucTieuDiem.ascx" TagName="ucTieuDiem" TagPrefix="uc5" %>
<%@ Register Src="Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc6" %>
<%@ Register Src="Module/ucTags.ascx" TagName="ucTags" TagPrefix="uc7" %>
<%@ Register Src="Module/ucSameCateArticles.ascx" TagName="ucSameCateArticles" TagPrefix="u8" %>
<%@ Register Src="/Module/ucTopContactInfo.ascx" TagName="ucTopContactInfo" TagPrefix="uc13" %>
<%@ Register src="Module/ucComment.ascx" tagname="ucComment" tagprefix="uc8" %>
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
                            <a href="/Default.aspx" title="Trang chủ">Trang chủ </a>  » <asp:Label runat="server" ID="lblBreadcrumb"></asp:Label></h2>
                    </div>
                    <div class="article-box">
                        <asp:Repeater runat="server" ID="rptArticleDetail" OnItemDataBound="rptArticleDetail_ItemDataBound">
                            <ItemTemplate>
                                <div class="breadcrumb-box">
                                    <h1 class="article-title">
                                    <%#Eval("Title") %>
                                </h1>
                                    <span class="createdate-article">
                                        <%#Eval("CreateDate","{0:dd/MM/yyyy - hh:mm}") %></span>
                                </div>
                                <h2 class="article-desciption">
                                    <%#Eval("Description") %></h2>
                                   
                                        
                                        <asp:Repeater runat="server" ID="rptTinLienQuan2">
                                        <HeaderTemplate> <div class="tin-lien-quan-2"><span class="tin-lien-quan2-span">Tin liên quan</span></HeaderTemplate>
                                            <ItemTemplate>
                                                <a class="tin-lien-quan-2a" href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                                                title='<%#Eval("Title") %>'>» <%#Eval("Title")%></a>
                                            </ItemTemplate>
                                            <FooterTemplate></div></FooterTemplate>
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
                      <div class="newarticle-box">
                        <h2>
                            Gửi phản hồi</h2>
                        <div class="line-article">
                            <div class="comment-box">
                                <div class="comment-row">
                                    <asp:TextBox runat="server" ID="txtHoTen" CssClass="comment-name" placeholder="Họ tên"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                        ForeColor="Red" ControlToValidate="txtHoTen" ValidationGroup="comment"></asp:RequiredFieldValidator>
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="comment-email" placeholder="Email" Width="421px"></asp:TextBox>
                                    
                                        <%--<asp:TextBox runat="server" ID="txtSecCode" Width="70px" CssClass="comment-email" placeholder="Mã bảo mật"></asp:TextBox>--%>
                                </div>
                                <div class="comment-row">
                                    <asp:TextBox TextMode="MultiLine" CssClass="comment-content" runat="server" ID="txtContent"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                        ForeColor="Red" ControlToValidate="txtContent" ValidationGroup="comment"></asp:RequiredFieldValidator>
                                </div>
                                <div class="comment-row">
                                    <asp:Button runat="server" Text="Gửi thông tin" ID="btnSend" CssClass="comment-button"
                                        ValidationGroup="comment" onclick="btnSend_Click" />
                                    <asp:Button runat="server" Text="Làm lại" ID="btnReset" 
                                        CssClass="comment-button" onclick="btnReset_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <u8:ucSameCateArticles runat="server" ID="uc9UcSameCate"/>                  
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
