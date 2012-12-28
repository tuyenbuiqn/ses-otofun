<%@ Page Title="" Language="C#" MasterPageFile="~/ofeditor/Editor.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SES.CMS.ofeditor.Search" %>

<%@ Register src="Module/ucSearch.ascx" tagname="ucSearch" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <uc1:ucSearch ID="ucSearch1" runat="server" />


</asp:Content>
