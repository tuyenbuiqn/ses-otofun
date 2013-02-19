<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSaleOff.ascx.cs" Inherits="SES.CMS.Module.ucSaleOff" %>
<div class="sale-off-box">
     <h3 class="hmp-cate-maintitle"> <span>
       <asp:Literal runat="server" ID="ltrTitle"></asp:Literal></span></h3>
    <ul class="sale-off">
        <asp:Repeater runat="server" ID="rptTuVanKyThuat">
            <ItemTemplate>
                <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-42/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.otofun'
                    title='<%#Eval("Title") %>'>
                    <%#Eval("Title") %>
                </a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="sale-off-readmore">
        <asp:HyperLink runat="server" ID="hplReadmore" ToolTip="Xem toàn bộ thông tin khuyến mãi">--> Xem chi tiết</asp:HyperLink>
    </div>
</div>
