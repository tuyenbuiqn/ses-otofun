<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEvent.ascx.cs" Inherits="SES.CMS.Module.ucEvent" %>
<div class="event-box">
    <a href="/Event.aspx" title="Toàn bộ dòng sự kiện" class="event-page">Dòng sự kiện »</a>
    <ul class="event-ul">
        <asp:Repeater runat="server" ID="rptEvent">
            <ItemTemplate>
                <li><a href='/Event/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("EventID")%>.aspx'>
                    <%#Eval("Title") %></a> </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
