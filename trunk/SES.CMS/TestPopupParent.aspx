<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPopupParent.aspx.cs" Inherits="SES.CMS.TestPopupParent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript">
        function ShowDialog()  
      {
          var returnPopup = window.open('Child.aspx', '_blank', 'scrollbars=10, width=820,height=900');
//          var txtPopup = document.getElementById(txtPopup).value;
//          txtPopup.value = returnPopup;
      }  
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="parentDiv"></div>
        <asp:TextBox ID="txtPopup" runat="server"></asp:TextBox>
            <%--<asp:Button ID="btnShowPopup" runat="server" Text="Hiện thị Popup" OnClientClick='ShowDialog(<%=txtPopup.ClientID %>);' />--%>
            <input type='button' name = 'button' value='Hiển thị Popup' onclick='ShowDialog();' />
    </div>
    </form>
</body>
</html>
