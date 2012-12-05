<%@ Page Title="" Language="C#" MasterPageFile="~/Otofun.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SES.CMS.Default" %>

<%@ Register Src="/Module/ucTopAdvertisment.ascx" TagName="ucTopAdvertisment" TagPrefix="uc1" %>
<%@ Register Src="/Module/ucLastestNews.ascx" TagName="ucLastestNews" TagPrefix="uc2" %>
<%@ Register Src="/Module/ucThamKhaoGiaXe.ascx" TagName="ucThamKhaoGiaXe" TagPrefix="uc3" %>
<%@ Register Src="/Module/ucTopRightAdv.ascx" TagName="ucTopRightAdv" TagPrefix="uc4" %>
<%@ Register Src="/Module/ucMiddleAdv.ascx" TagName="ucMiddleAdv" TagPrefix="uc5" %>
<%@ Register Src="/Module/ucMainHomePageCategory.ascx" TagName="ucMainHomePageCategory" TagPrefix="uc6" %>
<%@ Register Src="/Module/ucMostRead.ascx" TagName="ucMostRead" TagPrefix="uc7" %>
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
                    </div>
                    <ul class="AnhNho">
                        <li><a href="#">
                            <img id="Img1" class="img-car" src="images/car.jpg" alt="" /></a><a href="#">OF Test
                                xe: Mercedes-Benz GL 2013 Xứng danh Anh Hùng </a></li>
                        <li><a href="#">
                            <img id="Img2" class="img-car" src="images/car.jpg" alt="" /></a><a href="#">OF Test
                                xe: Mercedes-Benz GL 2013 Xứng danh Anh Hùng </a></li>
                        <li><a href="#">
                            <img id="Img3" class="img-car" src="images/car.jpg" alt="" /></a><a href="#">OF Test
                                xe: Mercedes-Benz GL 2013 Xứng danh Anh Hùng </a></li>
                        <li><a href="#">
                            <img id="Img4" class="img-car" src="images/car.jpg" alt="" /></a><a href="#">OF Test
                                xe: Mercedes-Benz GL 2013 Xứng danh Anh Hùng </a></li>
                    </ul>
                    <%-- box-under-car--%>
                    <uc3:ucThamKhaoGiaXe runat="server" ID="uc3ThamKhaoGiaXa" />
                    <div class="box-under-car">
                        <div class="box-under-car-caption">
                            HỎI ĐÁP & TƯ VẤN KỸ THUẬT</div>
                        <div class="line2">
                        </div>
                        <ul class="hoidap">
                            <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                            <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                            <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                            <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                            <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                        </ul>
                    </div>
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
            <%--TOP RIGHT--%>
          <uc4:ucTopRightAdv runat="server" ID="uc4TopRight" />
        </div>
        <uc5:ucMiddleAdv runat="server" ID="uc5MiddleAdv" />
        <div class="body-down">
            <uc6:ucMainHomePageCategory runat="server" ID="uc6Main" />
            <uc7:ucMostRead runat="server" ID="uc7ucMostRead" />
        </div>
    </div>
    <%--  mid--%>
</asp:Content>
