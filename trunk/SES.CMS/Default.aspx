<%@ Page Title="" Language="C#" MasterPageFile="~/Otofun.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SES.CMS.Default" %>

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
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <uc3:ucThamKhaoGiaXe runat="server" ID="uc3ThamKhaoGiaXa" />
                    <uc9:ucTuVanAndKyThuat runat="server" ID="uc9TuVanAndKyThuat" />
                </div>
                <div class="TinTuc">
                    <p>
                        <asp:Literal runat="server" ID="ltrNgay"></asp:Literal></p>
                    <uc2:ucLastestNews runat="server" ID="uc2lastestnews" />
                </div>
                <div class="box-under-car" style="margin: 9px 0px 0px 5px;">
                    <div class="box-under-car-caption">
                        HỎI ĐÁP & TƯ VẤN KỸ THUẬT</div>
                    <div class="line2">
                    </div>
                    <ul class="hoidap">
                        <li>
                            <div>
                            </div>
                            <a href="#">Bốc đầu ô tô như thế nào</a></li>
                        <li>
                            <div>
                            </div>
                            <a href="#">Bốc đầu ô tô như thế nào</a></li>
                        <li>
                            <div>
                            </div>
                            <a href="#">Bốc đầu ô tô như thế nào</a></li>
                        <li>
                            <div>
                            </div>
                            <a href="#">Bốc đầu ô tô như thế nào</a></li>
                        <li>
                            <div>
                            </div>
                            <a href="#">Bốc đầu ô tô như thế nào</a></li>
                    </ul>
                </div>
            </div>
            <%--TOP RIGHT--%><div class="body-top-right">
            <uc13:ucTopContactInfo runat="server" ID="uc13UcTopContactInfo" />
            <uc4:ucTopRightAdv runat="server" ID="uc4TopRight" />
            </div>
        </div>
        <uc5:ucMiddleAdv runat="server" ID="uc5MiddleAdv" />
        <div class="body-down">
            <uc6:ucMainHomePageCategory runat="server" ID="uc6Main" />
            <uc7:ucMostRead runat="server" ID="uc7ucMostRead" />
            <uc11:ucRightHomeAdv runat="server" ID="uc11ucRightHomeAdv" />
            <div class="video">
                <div class="video-cap">
                    VIDEO</div>
                <div class="video-detail">
                <uc12:ucHomeVideo runat="server" ID="uc12Video" />
                </div>
            </div>
        </div>
        <div class="bottom">
            <div class="Cap-bottom">
                <p>
                    THÔNG TIN DOANH NGHIỆP</p>
            </div>
            <ul>
                <li><a href="#">
                    <img id="Img19" class="bottom-image" src="images/thongtindoanhnghiep.jpg" alt="" /></a>
                    <a href="#" class="bottom-detail">Tin giật gân : tập đoàn công nghệ SES vừa triển khai
                        xong dự án website cho nhà trắng</a></li>
                <li><a href="#">
                    <img id="Img20" class="bottom-image" src="images/thongtindoanhnghiep.jpg" alt="" /></a>
                    <a href="#" class="bottom-detail">Tin giật gân : tập đoàn công nghệ SES vừa triển khai
                        xong dự án website cho nhà trắng</a></li>
                <li><a href="#">
                    <img id="Img21" class="bottom-image" src="images/thongtindoanhnghiep.jpg" alt="" /></a>
                    <a href="#" class="bottom-detail">Tin giật gân : tập đoàn công nghệ SES vừa triển khai
                        xong dự án website cho nhà trắng</a></li>
                <li><a href="#">
                    <img id="Img22" class="bottom-image" src="images/thongtindoanhnghiep.jpg" alt="" /></a>
                    <a href="#" class="bottom-detail">Tin giật gân : tập đoàn công nghệ SES vừa triển khai
                        xong dự án website cho nhà trắng</a></li>
            </ul>
        </div>
    </div>
    <%--  mid--%>
</asp:Content>
