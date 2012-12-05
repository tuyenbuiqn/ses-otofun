<%@ Page Title="" Language="C#" MasterPageFile="~/Otofun.Master" AutoEventWireup="true"
    CodeBehind="Article.aspx.cs" Inherits="SES.CMS.Article" %>

<%@ Register Src="Module/ucLeftAdv.ascx" TagName="ucLeftAdv" TagPrefix="uc1" %>
<%@ Register Src="Module/ucRightAdv.ascx" TagName="ucRightAdv" TagPrefix="uc2" %>
<%@ Register Src="Module/ucArticleAdv.ascx" TagName="ucArticleAdv" TagPrefix="uc3" %>
<%@ Register src="Module/ucNewArticles.ascx" tagname="ucNewArticles" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-top">
        <div class="body-out">
            <div class="float-left wid470">
                <asp:Repeater runat="server" ID="rptArticleDetail">
                    <ItemTemplate>
                        <div class="breadcrumb-box">
                            <a href="/the-gioi.htm" class="breadcrumb-article">Thế giới</a><img src="">
                            <span class="createdate-article"><%#Eval("CreateDate","{0:dd/MM/yyyy - hh:mm}") %></span>
                        </div>
                        <p class="pBreadrumb">
                        </p>
                        <h1 class="article-title">
                            <%#Eval("Title") %>
                        </h1>
                        <h2 class="article-desciption">
                            <%#Eval("Description") %></h2>
                        <div class="article-detail">
                            <%#Eval("ArticleDetail") %>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <uc3:ucArticleAdv ID="ucArticleAdv1" runat="server" />
                <uc4:ucNewArticles ID="ucNewArticles1" runat="server" />
            </div>
            <uc1:ucLeftAdv ID="ucLeftAdv1" runat="server" />
            <uc2:ucRightAdv ID="ucRightAdv1" runat="server" />
        </div>
    </div>
</asp:Content>
