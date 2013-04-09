<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTopAdvertisment.ascx.cs"
    Inherits="SES.CMS.Module.ucTopAdvertisment" %>
<div runat="server" visible="false" id="homeBanner" class="QuangCao">
    <embed src="/Ads/MercedesBenz670x80.swf" height="80" alt="" align="middle" width="670"
        pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
        allowscriptaccess="always" wmode="transparent" quality="high">
      
</div>
<div runat="server" visible="false" id="catBanner" class="QuangCao">
    <embed src="/Ads/Castrol678x80.swf" height="80" alt="" align="middle" width="670"
        pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
        allowscriptaccess="always" wmode="transparent" quality="high">
</div>
<div runat="server" visible="false" id="artBanner" class="QuangCao">
    <asp:Image ID="Image1" ImageUrl="/Ads/YourAds.jpg" Width="670px" Height="80px" runat="server">
    </asp:Image>
</div>
