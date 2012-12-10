<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SES.CMS.AdminCP.Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Otofun.net - Administrator CP</title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.3/jquery.min.js"></script>

    <!-- MASTER STYLESHEET-->
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
    <link href="css/TableDesign.css" rel="stylesheet" type="text/css" />
    <!-- LOAD TIPSY TOOLTIPS-->

    <script type="text/javascript" src="js/jquery.tipsy.js"></script>
    <script type="text/javascript" src="js/JScript.js"></script>

    <!-- LOAD CUSTOM JQUERY SCRIPTS-->

    <script type="text/javascript" src="js/scripts.js"></script>

    <!-- LOAD FACEBOX -->

    <script type="text/javascript" src="js/facebox.js"></script>

    <link href="css/facebox.css" rel="stylesheet" type="text/css" />
    <!-- LOAD FLOT GRAPHS -->

    <script type="text/javascript" src="js/jquery.flot.pack.js"></script>

    <script type="text/javascript" src="js/LoaiDau.js"></script>

    <!--[if IE]>
     <script language="javascript" type="text/javascript" src="js/excanvas.pack.js"></script>
    <![endif]-->
    <!--[if IE 6]>
    <script src="js/pngfix.js"></script>
    <script>
        DD_belatedPNG.fix('.png_bg');
    </script>        
    <![endif]-->
    <!-- LOAD GRAPH JAVASCRIPT FILE-->

    <script src="js/graphs.js" type="text/javascript"></script>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>

    <script type="text/javascript" src="/fancybox/jquery.easing-1.3.pack.js"></script>

    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>

    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />

    <script type="text/javascript">
		$(document).ready(function() {
			/*
			*   Examples - images
			*/

				$("a.fancyboxx").fancybox({
		'transitionIn'	:	'elastic',
		'transitionOut'	:	'elastic',
		'speedIn'		:	600, 
		'speedOut'		:	200, 
		'titlePosition' : 'inside',
		'overlayShow'	:	false
	});

			
		});
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <Ajax:ToolkitScriptManager runat="server" ID="toolkit"></Ajax:ToolkitScriptManager>
    <div id="header" class="png_bg">
        <div id="head_wrap" class="container_12">
            <!-- start of logo - you could replace this with an image of your logo -->
            <div id="logo" class="grid_4">
                <img src="images/seslogo.png" />
            </div>
            <!-- end logo -->
            <!-- start control panel -->
            <div id="controlpanel" class="grid_8">
               <div style="float: right; margin-top: 10px;">
                    <div class="userInfo">
                        Xin chào:
                        <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>| <a class="text"
                            href="Login.aspx?Option=Logout">Thoát</a> <a class="text" href="../Default.aspx"
                                target="_blank">Trang chủ</a>
                    </div>
                </div>
            </div>
            <!-- end control panel -->
            <!-- start navigation -->
            <div id="navigation" class=" grid_12">
                <ul>
                    <li>
                        <asp:HyperLink ID="hplDestination" NavigateUrl="Default.aspx?Page=ListArticleCategory"
                            runat="server">Danh mục</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hplImage" NavigateUrl="Default.aspx?Page=ListImages" runat="server">Hình ảnh - video</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hplConfig" NavigateUrl="Default.aspx?Page=ListConfig" runat="server">Hệ thống</asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hplSlide" NavigateUrl="Default.aspx?Page=ListSlide" runat="server">QL slide</asp:HyperLink>
                    </li>
                     <li>
                        <asp:HyperLink ID="hplAdvertisement" NavigateUrl="Default.aspx?Page=ListAdvertisement" runat="server">Quảng cáo</asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hplBusiness" NavigateUrl="Default.aspx?Page=ListBusiness" runat="server">Thông tin doanh nghiệp</asp:HyperLink>
                    </li>

                </ul>
            </div>
            <!-- end navigation -->
        </div>
        <!-- end headwarp  -->
    </div>
    <!-- end header -->
    <!-- start subnav -->
    <div id="sub_nav">
        <div id="subnav_wrap" class="container_12">
            <!-- start sub nav list -->
            <div id="subnav" class=" grid_12">
                <ul>
                    <asp:PlaceHolder ID="phSubNav" runat="server"></asp:PlaceHolder>
                </ul>
            </div>
            <!-- end subnavigation list -->
        </div>
    </div>
    <!-- end sub_nav -->
    <!-- START EVERYTING BELOW IS THE MAIN CONTENT -->
    <%--<asp:Label Text="<%# checkNonCustomer()%>" runat="server"></asp:Label><br />
    <asp:Label ID="Label1" Text="<%# checkNonServices()%>" runat="server"></asp:Label>--%>
    <div class="container_12">
        <asp:PlaceHolder ID="phPageControl" runat="server"></asp:PlaceHolder>
        <div class="clearfix">
            &nbsp;</div>
    </div>
    <!-- END EVERYTING BELOW IS THE MAIN CONTENT -->
    <div class="clearfix">
        &nbsp;</div>
    <div class="container_12">
        <!-- START FOOTER -->
        <div id="footer" class="grid_12">
            <p>
                &copy; Copyright 2011 EuroArt.com.vn | Powered by <a href="http://www.ses.vn" target="_blank">
                    SES.VN</a> | <a href="#">Top</a></p>
        </div>
        <!-- END FOOTER -->
    </div>
    <!-- end content wrap -->
    </form>
</body>
</html>
