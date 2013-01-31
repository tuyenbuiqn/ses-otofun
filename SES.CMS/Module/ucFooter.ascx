<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFooter.ascx.cs" Inherits="SES.CMS.Module.ucFooter" %>
<div class="footer">
    <div class="inner">
       <%-- <ul class="big-ul">
            <li>
                <p>
                    TIN TỨC & TƯ VẤN</p>
             <ul class="foot-split">
              <asp:Repeater ID="rptNews" runat="server">
                <ItemTemplate>
                       <li><a href="#"> <%#Eval("Title") %></a></li>
                </ItemTemplate>  
                      <ItemTemplate>
                       <li><a href="#"> <%#Eval("Title") %></a></li>
                      </ItemTemplate>  
                    </asp:Repeater>
                </ul>

            </li>
            <li>
                <p>
                    THÔNG TIN THỊ TRƯỜNG & MUA XE</p>
                <ul class="foot-split">
              <asp:Repeater ID="rptBuy" runat="server">
                <ItemTemplate>
                       <li><a href="#"> <%#Eval("Title") %></a></li>
                </ItemTemplate>  
                      <ItemTemplate>
                       <li><a href="#"> <%#Eval("Title") %></a></li>
                      </ItemTemplate>  
                    </asp:Repeater>
                </ul>
            </li>
            <li>
                <p>
                    LIÊN HỆ & QUẢNG CÁO</p>
                <p style="color: #575756; margin-top: 20px; margin-bottom: 7px;">
                    CÔNG TY CỔ PHẦN OTV</p>
                <p class="foot-lienhe">
                    ĐỊA CHỈ: P 2504, TÒA 25T1, TRUNG HÒA NHÂN CHÍNH - CẦU GIẤY - HÀ NỘI
                    <br />
                    ĐT: 3 555 8066 (GẶP MS LAN)<br />
                    Fax: 04 35558327<br />
                    Hotline: 091 559 9988
                    <br />
                </p>
            </li>
        </ul>--%>
        <ul class="link3">
            <li><a href="http://www.otofun.net/forum.php" title="Diễn đàn otofun.net">Diễn đàn</a>
            </li>
             <asp:Repeater runat="server" ID="rptMainMenu">
                <ItemTemplate>
                    <li>
                    <a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.aspx'
                        title='<%#Eval("Title") %>'>
                        <%#Eval("Title") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <p class="banquyen" style="margin-bottom: 3px;">
            Bản quyền © 2006 - 2012 OTOFUN®, bảo lưu mọi quyền. Ghi rõ nguồn "otofun.net" khi
            sử dụng thông tin từ website này.</p>
        <p class="banquyen" style="margin-left: 140px; margin-bottom: 7px;">
            Giấy phép số: 95/GXN-TTĐT do Cục QL Phát thanh, Truyền hình và Thông tin điện tử
            - Bộ TT&TT cấp. Cơ quan chủ quản: Công ty Cổ phần OTV</p>
    </div>
</div>
