<%@ Page Title="" Language="C#" MasterPageFile="~/Otofun.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SES.CMS.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-top">
        <div class="body-out">
            <%--     TOP LEFT--%>
            <div class="body-top-left">
                <div class="QuangCao">
                    <a href="#">
                        <img id="ImgQuangCao" class="img-QuangCao" src="images/quangcao.jpg" alt="" /></a>
                </div>
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
                    <div class="box-under-car">
                        <div class="box-under-car-caption">
                            THAM KHẢO GIÁ XE</div>
                        <div class="line2">
                        </div>
                        <ul class="TKGX">
                            <li>
                                <p>
                                    Chọn Hãng</p>
                                <asp:DropDownList ID="DropDownList1" class="DDLTKGX" runat="server">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <p>
                                    Hãng Xe</p>
                                <asp:DropDownList ID="DropDownList2" class="DDLTKGX" runat="server">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <p>
                                    Tên Xe</p>
                                <asp:DropDownList ID="DropDownList3" class="DDLTKGX" runat="server">
                                </asp:DropDownList>
                            </li>
                        </ul>
                        <a href="#">
                            <img id="btnTimKiemXe" class="btnTimKiemXe" src="images/TimKiem-button.jpg" alt="" /></a>
                    </div>
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
                        Thứ x Ngày xx tháng xx năm xxxx</p>
                    <div class="tintuc-cap">
                        <p>
                            TIN TỨC MỚI</p>
                    </div>
                    <ul class="tintuc-box">
                        <li><a href="#">Bốc đầu ô tô như thế nào, ô tô giấy ô tô đồ chơi</a></li>
                        <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                        <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                        <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                        <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                        <li><a href="#">Bốc đầu ô tô như thế nào</a></li>
                    </ul>
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
            <div class="body-top-right">
                <div class="lienhe">
                    <div class="lienhe-up">
                        <div class="lh-icon1">
                        </div>
                        <div class="lh-text">
                            Liên hệ gửi bài & nội dung : team@otofun.net
                            <br />
                            Tel:(84-4) 3762 5678/ 3762 9999
                        </div>
                    </div>
                    <div class="lienhe-down">
                        <div class="lh-icon2">
                        </div>
                        <div class="lh-text">
                            Liên hệ quảng cáo: sales@otofun.net Hotline: 090 225 8907 / 090 568 4444
                        </div>
                    </div>
                </div>
                <a>
                    <img id="quangcao-box1" class="quangcao-box" src="images/quangcao-banner.jpg" alt="" /></a>
                <a>
                    <img id="quangcao-box2" class="quangcao-box" src="images/quangcao-banner.jpg" alt="" /></a>
            </div>
        </div>
    </div>
    <%--  mid--%>
</asp:Content>
