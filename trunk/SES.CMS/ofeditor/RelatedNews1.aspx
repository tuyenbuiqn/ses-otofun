<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelatedNews1.aspx.cs" Inherits="SES.CMS.ofeditor.RelatedNews1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function GetRadWindow() {
             var oWindow = null;
             if (window.radWindow) oWindow = window.radWindow;
             else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
             return oWindow;
         }

         function AdjustRadWidow() {
             var oWindow = GetRadWindow();
             setTimeout(function () { oWindow.autoSize(true); if ($telerik.isChrome || $telerik.isSafari) ChromeSafariFix(oWindow); }, 500);
         }

         //fix for Chrome/Safari due to absolute positioned popup not counted as part of the content page layout
         function ChromeSafariFix(oWindow) {
             var iframe = oWindow.get_contentFrame();
             var body = iframe.contentWindow.document.body;

             setTimeout(function () {
                 var height = body.scrollHeight;
                 var width = body.scrollWidth;

                 var iframeBounds = $telerik.getBounds(iframe);
                 var heightDelta = height - iframeBounds.height;
                 var widthDelta = width - iframeBounds.width;

                 if (heightDelta > 0) oWindow.set_height(oWindow.get_height() + heightDelta);
                 if (widthDelta > 0) oWindow.set_width(oWindow.get_width() + widthDelta);
                 oWindow.center();

             }, 650);
         }

         function returnToParent() {
             //create the argument that will be returned to the parent page
             var oArg = new Object();
             oArg.cityName = document.getElementById("<%= TextBox1.ClientID %>").value;
             oArg.cityName2 = "";
             oArg.ID = "1";
             var oWnd = GetRadWindow();
             //Close the RadWindow and send the argument to the parent page
             if (oArg.cityName) {
                 oWnd.close(oArg);
               
             }
             else {
                 alert("Please fill both fields");
             }
         }
    </script>
</head>
<body onload="AdjustRadWidow();">
    <form id="form1" runat="server">
    
    <div>
    <asp:TextBox ID="TextBox1" runat="server" Width="320px"></asp:TextBox><asp:Button ID="Button1"
        runat="server" OnClientClick="returnToParent(); return false;" Text="Button" />

    </div>
    </form>
</body>
</html>
