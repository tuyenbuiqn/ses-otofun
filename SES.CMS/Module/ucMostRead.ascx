<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMostRead.ascx.cs"
    Inherits="SES.CMS.Module.ucMostRead" %>
<div class="body-down-right">
    <div class="docnhieu">
        <div class="docnhieu-cap">
            ĐỌC NHIỀU</div>
        <ul class="docnhieu-noidung">
            <asp:Repeater runat="server" ID="rptMostRead">
                <ItemTemplate>
                    <li>
                        <div class="out-image">
                            <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                                title='<%#Eval("Title") %>'>
                                <img alt="<%#Eval("Title") %>" class="Anh-noidung-docnhieu" src='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>' /></a></div>
                        <p>
                            <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                                title='<%#Eval("Title") %>'>
                                <%#Eval("Title") %></a></p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
