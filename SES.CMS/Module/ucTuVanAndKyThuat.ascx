<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTuVanAndKyThuat.ascx.cs"
    Inherits="SES.CMS.Module.ucTuVanAndKyThuat" %>
<div class="box-under-car">
    <div class="box-under-car-caption">
       <asp:Literal runat="server" ID="ltrTitle"></asp:Literal></div>
    <div class="line2">
    </div>
    <ul class="hoidap">
        <asp:Repeater runat="server" ID="rptTuVanKyThuat">
            <ItemTemplate>
                <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-19/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                    title='<%#Eval("Title") %>'>
                    <%#Eval("Title") %>
                </a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
