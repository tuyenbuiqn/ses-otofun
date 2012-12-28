<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="SES.CMS.ofeditor.Comments" %>
<%@ Register src="Module/ucDuyetComment.ascx" tagname="ucDuyetComment" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucDuyetComment ID="ucDuyetComment1" runat="server" />
</asp:Content>
