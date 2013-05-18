<%@ Page Title="" EnableViewState="False" Language="C#" MasterPageFile="~/Otofun.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SES.CMS.Default" %>

<%@ Register Src="/Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc1" %>
<%@ Register Src="/Module/ucLastestNews.ascx" TagName="ucLastestNews" TagPrefix="uc2" %>
<%@ Register Src="/Module/ucThamKhaoGiaXe.ascx" TagName="ucThamKhaoGiaXe" TagPrefix="uc3" %>
<%@ Register Src="/Module/ucTopRightAdv.ascx" TagName="ucTopRightAdv" TagPrefix="uc4" %>
<%@ Register Src="/Module/ucMiddleAdv.ascx" TagName="ucMiddleAdv" TagPrefix="uc5" %>
<%@ Register Src="/Module/ucMainHomePageCategory.ascx" TagName="ucMainHomePageCategory"
    TagPrefix="uc6" %>
<%@ Register Src="/Module/ucMostRead.ascx" TagName="ucMostRead" TagPrefix="uc7" %>
<%@ Register Src="/Module/ucHomeSlide.ascx" TagName="ucHomeSlide" TagPrefix="uc8" %>
<%@ Register Src="/Module/ucTuVanAndKyThuat.ascx" TagName="ucTuVanAndKyThuat" TagPrefix="uc9" %>
<%@ Register Src="/Module/ucDanhMucNoiBat.ascx" TagName="ucDanhMucNoiBat" TagPrefix="uc10" %>
<%@ Register Src="/Module/ucRightHomeAdv.ascx" TagName="ucRightHomeAdv" TagPrefix="uc11" %>
<%@ Register Src="/Module/ucHomeVideo.ascx" TagName="ucHomeVideo" TagPrefix="uc12" %>
<%@ Register Src="/Module/ucTopContactInfo.ascx" TagName="ucTopContactInfo" TagPrefix="uc13" %>
<%@ Register Src="/Module/ucAnToanGiaoThong.ascx" TagName="ucAnToanGiaoThong" TagPrefix="uc15" %>
<%@ Register Src="/Module/ucThongTinDoanhNghiep.ascx" TagName="ucThongTinDoanhNghiep"
    TagPrefix="uc14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Begin Adbrand -->

    <div class="body-top">
        <div class="body-out">
            <%--     TOP LEFT--%>
            <div class="body-top-left">
                <uc1:ucTopAdvertisment runat="server" ID="uc1TopAdv" />
                <div class="image-box">
                    <div class="AnhTo">
                        <uc8:ucHomeSlide runat="server" ID="uc8HomeSlide" />
                    </div>
                    <uc10:ucDanhMucNoiBat runat="server" ID="uc10ucDanhMucNoiBat" />
                    <%-- box-under-car--%>
                    <%-- <uc3:ucThamKhaoGiaXe runat="server" ID="uc3ThamKhaoGiaXa" />
                    <uc9:ucTuVanAndKyThuat runat="server" ID="uc9TuVanAndKyThuat" />--%>
                </div>
                <div class="TinTuc">
                    <uc2:ucLastestNews runat="server" ID="uc2lastestnews" />
                </div>
                <%-- <div class="box-under-car" style="margin: 9px 0px 0px 5px;">
               <uc15:ucAnToanGiaoThong runat="server" ID="uc15ucAntoanGiaoThong" />
                </div>--%>
            </div>
            <%--TOP RIGHT--%><div class="body-top-right">
                <uc13:ucTopContactInfo runat="server" ID="uc13UcTopContactInfo" />
                <div class="adv-top-homepage-box">
                
                    <div class="adv-homepage-right">
                        <img src="/Ads/heaven.jpg" style="width: 300px; height: 450px;" />
                    </div>
                </div>
            </div>
        </div>
        <uc5:ucMiddleAdv runat="server" ID="uc5MiddleAdv" />
        <div class="body-down">
            <uc6:ucMainHomePageCategory runat="server" ID="uc6Main" />
            <uc7:ucMostRead runat="server" ID="uc7ucMostRead" />
            <uc11:ucRightHomeAdv runat="server" ID="uc11ucRightHomeAdv" />
            <div class="video">
                <h3 class="hmp-cate-maintitle">
                    <span>VIDEO</span>
                </h3>
                <div class="video-detail">
                    <uc12:ucHomeVideo runat="server" ID="uc12Video" />
                </div>
            </div>
            <div class="quangcao-right">
                <embed src="/Ads/ALIPAS.swf" height="600" alt="" align="middle" width="300"
                    pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                    allowscriptaccess="always" quality="high">
        <p></p>

         <embed src="/Ads/topcare300x250.swf" height="250" alt="" align="middle" width="300"
                    pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                    allowscriptaccess="always" quality="high">
        <p></p>

         <embed src="/Ads/MAZDA300x600.swf" height="600" alt="" align="middle" width="300"
                    pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                    allowscriptaccess="always" quality="high">
        <p></p>
            </div>
        </div>
        <div class="bottom">
            <uc14:ucThongTinDoanhNghiep runat="server" ID="uc14ucThongTinDoanhNghiep" />
        </div>
    </div>
    <%--  mid--%>
</asp:Content>
