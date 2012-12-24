<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThongTinDoanhNghiep.ascx.cs"
    Inherits="SES.CMS.Module.ucThongTinDoanhNghiep" %>
<style type="text/css">
    
</style>
<div class="Cap-bottom-box">
    <div class="Cap-bottom">
        <p>
            <asp:Label runat="server" ID="lblTitle"></asp:Label></p>
    </div>
</div>
<div class="promo-wrapper">
    <div class="promo-list">
        <div id="foo">
            <asp:Repeater runat="server" ID="rptThongTinDoanhNghiep">
                <ItemTemplate>
                    <div class="promo-post fl clearfix">
                        <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-40/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                            title='<%#Eval("Title") %>' class="promo-post-img fl" >
                            <img src='/Media/<%#Eval("ImageUrl") %>'class="promo-img-post" alt='<%#Eval("Title") %>' />
                        </a>
                        <div class="promo-post-info fl">
                           <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-40/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'  title='<%#Eval("Title") %>' class="promo-post-title">
                                <h5>
                                    <%#Eval("Title") %></h5>
                            </a>
                            <p>
                                <%#WordCut(Eval("Description").ToString())%></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <a href="#" id="slide-prev" class="fl" style="display: block;"><span>prev</span></a><div
            class="slide-seperate fl">
        </div>
        <a href="#" id="slide-next" class="fl" style="display: block;"><span>next</span></a>
    </div>
</div>
