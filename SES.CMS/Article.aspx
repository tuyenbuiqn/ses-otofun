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
                            <asp:Label runat="server" ID="lblBreadcrumb"></asp:Label></h2>
                    </div>
                    <div class="article-box">
                        <asp:Repeater runat="server" ID="rptArticleDetail">
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
                                <div class="article-detail">
                                    <%#Eval("ArticleDetail") %>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <uc7:ucTags runat="server" ID="uc7ucTag" />
                    <uc4:ucNewArticles ID="ucNewArticles1" runat="server" />
                    <u8:ucSameCateArticles runat="server" ID="uc9UcSameCate" />
                    <div class="newarticle-box">
                        <h2>
                            Gửi phản hồi</h2>
                        <div class="line-article">
                            <div class="comment-box">
                                <div class="comment-row">
                                    <asp:TextBox runat="server" ID="txtHoTen" CssClass="comment-name" placeholder="Họ tên"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                        ForeColor="Red" ControlToValidate="txtHoTen" ValidationGroup="comment"></asp:RequiredFieldValidator>
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="comment-email" placeholder="Email"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                                        ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="comment"></asp:RegularExpressionValidator>
                                </div>
                                <div class="comment-row">
                                    <span class="comment-span">(Bấm vào đây để nhận mã)</span>
                                    <asp:ImageButton runat="server" ID="imgbtnCode" CssClass="comment-img-code" ImageUrl="/images/comment-code.png" />
                                    <asp:TextBox runat="server" ID="txtCode" CssClass="comment-code" ReadOnly="true"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtPressCode" CssClass="comment-presscode"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                        ForeColor="Red" ControlToValidate="txtPressCode" ValidationGroup="comment"></asp:RequiredFieldValidator>
                                </div>
                                <div class="comment-row">
                                    <asp:TextBox TextMode="MultiLine" CssClass="comment-content" runat="server" ID="txtContent"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                        ForeColor="Red" ControlToValidate="txtContent" ValidationGroup="comment"></asp:RequiredFieldValidator>
                                </div>
                                <div class="comment-row">
                                    <asp:Button runat="server" Text="Gửi thông tin" ID="btnSend" CssClass="comment-button"
                                        ValidationGroup="comment" />
                                    <asp:Button runat="server" Text="Làm lại" ID="btnReset" CssClass="comment-button" />
                                </div>
                            </div>
                        </div>
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
