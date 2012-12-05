<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMainMenu.ascx.cs"
    Inherits="SES.CMS.Module.ucMainMenu" %>
<div class="menu">
    <div class="menu-text">
        <a href="/Default.aspx" title="otofun-homepage">
            <img id="home-button" class="home-button" src="/images/Home-button.jpg" alt="Otofun-homepage" /></a>
        <ul class="toplink">
            <asp:Repeater runat="server" ID="rptMainMenu" OnItemDataBound="rptMainMenu_ItemDataBound">
                <ItemTemplate>
                    <li>
                    <a href='/Cat/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.aspx'
                        title='<%#Eval("Title") %>'>
                        <%#Eval("Title") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="search-box">
            <a href="#">
                <img id="search-button" class="search-button" src="/images/search-button.jpg" alt="" /></a>
            <asp:TextBox ID="TextBox1" class="search" runat="server" BackColor="#454545"></asp:TextBox>
            <a href="#">
                <img id="rss-button" class="rss-button" src="/images/RSS-button.jpg" alt="" /></a>
        </div>
    </div>
    <div class="menu-line">
    </div>
</div>
<ul class="mid-link">
    <asp:Repeater runat="server" ID="rptChildMenu">
        <ItemTemplate>
           <li><a href='/Cat/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.aspx'
                        title='<%#Eval("Title") %>'>
                        <%#Eval("Title") %></a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
