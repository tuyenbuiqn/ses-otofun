<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTopRightAdv.ascx.cs"
    Inherits="SES.CMS.Module.ucTopRightAdv" %>
<div class="body-top-right">
    <div class="lienhe">
        <div class="lienhe-up">
            <div class="lh-icon1">
            </div>
            <div class="lh-text">
                <asp:Literal runat="server" ID="ltrLienHeGuiBai"></asp:Literal>
            </div>
        </div>
        <div class="lienhe-down">
            <div class="lh-icon2">
            </div>
            <div class="lh-text">
                <asp:Literal runat="server" ID="ltrLienHeQuangcao"></asp:Literal>
            </div>
        </div>
    </div>
    <a>
        <img id="quangcao-box1" class="quangcao-box" src="/images/quangcao-banner.jpg" alt="" /></a>
    <a>
        <img id="quangcao-box2" class="quangcao-box" src="/images/quangcao-banner.jpg" alt="" /></a>
</div>
