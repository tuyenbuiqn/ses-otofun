<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTieuDiem.ascx.cs"
    Inherits="SES.CMS.Module.ucTieuDiem" %>
<div class="hotevent-box">
    <h2 class="hotevent-h2-title">
        Đọc nhiều</h2>
    <ul class="docnhieu-noidung" style="background:none">
        <asp:Repeater runat="server" ID="rptMostRead">
            <ItemTemplate>
                <li>
                    <div class="out-image">
                        <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                            title='<%#Eval("Title") %>'>
                            <img alt="<%#Eval("Title") %>" class="Anh-noidung-docnhieu" src='/Media/<%#Eval("ImageUrl") %>'
                                alt='<%#Eval("Title") %>' /></a></div>
                    <p>
                        <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                            title='<%#Eval("Title") %>'>
                            <%#Eval("Title") %></a></p>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
