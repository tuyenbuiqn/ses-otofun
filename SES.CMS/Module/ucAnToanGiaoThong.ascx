<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAnToanGiaoThong.ascx.cs"
    Inherits="SES.CMS.Module.ucAnToanGiaoThong" %>
    <div class="box-under-car-caption">
        <asp:Literal runat="server" ID="ltrTitle"></asp:Literal></div>
    <div class="line2">
    </div>
    <div class="div-atgt">
        <asp:Repeater runat="server" ID="rptTuVanKyThuat">
            <ItemTemplate>
            <img title='<%#Eval("Title") %>' alt='<%#Eval("Title") %>' src='/Media/<%#Eval("ImageUrl") %>' />
                <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                    title='<%#Eval("Title") %>' class="atgt-title">
                    <%#Eval("Title") %>
                </a>
                <br />
                <span class="atgt-desc"><%#WordCut(Eval("Description").ToString()) %></span>
            </ItemTemplate>
        </asp:Repeater>
</div>
