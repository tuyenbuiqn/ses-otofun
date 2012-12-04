<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SES.CMS.AdminCP.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"><head><title>Admin ControlPanel - S.E.S Content Management System</title>
<link href="images/phenotype.css" rel="stylesheet" type="text/css"/>
<link href="images/navigation.css" rel="stylesheet" type="text/css"/>
<link href="images/content.css" rel="stylesheet" type="text/css"/>
</head>
<body>
 <form id="form1" runat="server">
<table height=480 cellSpacing=0 cellPadding=0 width=640 align=center border=0>
  <tbody>
  <tr>
    <TD>
     
      <table cellSpacing=0 cellPadding=0 width=400 align=center border=0>
        <tbody>
        <tr>
          <TD class=windowFooterGrey2>
            <table cellSpacing=0 cellPadding=0 width="100%" border=0>
              <tbody>
              <tr vAlign=bottom>
                <TD style="BACKGROUND: url(images/pt_cover.jpg) no-repeat left top" 
                colSpan=2 height=145>
                  <DIV class=login></DIV></TD></TR>
              <tr bgColor=#ffffff>
                <TD colSpan=2><IMG height=3 src="images/white_border.gif" 
                  width=3></TD></TR>
              <tr>
                <TD class=padding20 style="width: 76px">
                    Username:</TD>
                <TD>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" 
                        ControlToValidate="txtUsername" ErrorMessage="***"></asp:RequiredFieldValidator>
                  </TD></TR>
              <tr>
                <TD class=padding20 style="width: 76px">Password:</TD>
                <TD>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input" 
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="frv2" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="***"></asp:RequiredFieldValidator>
                  </TD></TR>
              <tr>
                <TD height=30 style="width: 76px">&nbsp;</TD>
                <TD>
                    &nbsp;<asp:Button ID="btnLogin" runat="server" CssClass="buttonGreyh" Height="21px" 
                        onclick="btnLogin_Click" Text="Đăng nhập" Width="103px" />
                  </TD></TR></tbody></table></TD>
          <TD class=windowRightShadow vAlign=top width=10><IMG height=10 
            src="images/win_sh_ri_to.gif" width=10></TD></TR>
        <tr>
          <TD class=windowBottomShadow><IMG height=10 
            src="images/win_sh_bo_le.gif" width=10></TD>
          <TD class=windowRightShadow vAlign=top><SPAN 
            class=windowBottomShadow><IMG height=10 
            src="images/win_sh_bo_ri.gif" 
      width=10></SPAN></TD></TR></tbody></table>
     
      </TD></TR></tbody></table></form></body></html>
