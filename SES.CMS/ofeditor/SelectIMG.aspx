<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectIMG.aspx.cs" Inherits="SES.CMS.ofeditor.SelectIMG" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Chọn tin tức yêu cầu</title>
    <link href="/css/CssForDateControl/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/CssForDateControl/StyleChild.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jsForDateControl/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="/js/jsForDateControl/jquery-ui.js"></script>
    <link href="/css/CssForDateControl/jquery-ui.css" rel="stylesheet" type="text/css" />
    </head>
<body onload="AdjustRadWidow();">
    <form id="form1" runat="server">
    <fieldset style="height: auto;width: 740px;">
        <legend>TÌM KIẾM TIN </legend>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow;
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                    oWindow.ID = "1";
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

                function selectImage(imgURL) {
                    var oArg = new Object();
                    oArg.cityName = "";
                    oArg.cityName2 = document.getElementById("i-" + imgURL).src;
                    oArg.ID = "2";

                    var oWnd = GetRadWindow();
                    //Close the RadWindow and send the argument to the parent page
                    if (oArg.cityName2) {

                        oWnd.Close(oArg);

                    }
                    else {
                        alert("Please fill both fields");
                    }
                }
            </script>
        </telerik:RadCodeBlock>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        
        <div id="Child" style="margin-right:10px; margin-bottom:10px; width:740px;">
            <p>
                <asp:Label ID="lblMessenger" CssClass="lblMess" runat="server" Text=""></asp:Label></p>
            <div id="ListArticlesAndSearch">
                <div id="ListArticles" style="width:740px;">
                    <asp:Panel ID="pnlTitle01" runat="server">
                        <p class="Title">
                           HÌNH ẢNH BÀI VIẾT:
                            <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
                        </p>
                    </asp:Panel>
                </div>
                <div id="ListArticles" style="width:740px; height:150px;">
                <asp:Repeater ID="rptIMG" runat="server">
                <ItemTemplate>
                   <div style="float:left; width:180px; height:96px; padding:2px; text-align:center;">
                   <a href="javascript:selectImage(<%#Eval("ID")%>)">
                   <img style="border:1px solid #000;padding:1px;width:120px; height:90px;" src="<%#Eval("urls")%>" id="i-<%#Eval("ID")%>" alt="Click vào ảnh để chọn" title="Click vào ảnh để chọn" />
                   </a>
                   </div>
                </ItemTemplate>
                   </asp:Repeater>
                </div>
                
            </div>
            
        </div>
    </fieldset>
    </form>
</body>
</html>
