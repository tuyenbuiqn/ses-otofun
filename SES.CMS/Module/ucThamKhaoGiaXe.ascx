<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThamKhaoGiaXe.ascx.cs"
    Inherits="SES.CMS.Module.ucThamKhaoGiaXe" %>
<div class="box-under-car">
    <div class="box-under-car-caption">
        THAM KHẢO GIÁ XE</div>
    <div class="line2">
    </div>
    <ul class="TKGX">
        <li>
            <p>
                Chọn Hãng</p>
            <asp:DropDownList ID="ddlHangXe" class="DDLTKGX" runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <p>
                Nhãn Xe</p>
            <asp:DropDownList ID="DropDownList2" class="DDLTKGX" runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <p>
                Dòng Xe</p>
            <asp:DropDownList ID="DropDownList3" class="DDLTKGX" runat="server">
            </asp:DropDownList>
        </li>
    </ul>
    <a href="#">
        <img id="btnTimKiemXe" class="btnTimKiemXe" src="/images/TimKiem-button.jpg" alt="search" /></a>
</div>
