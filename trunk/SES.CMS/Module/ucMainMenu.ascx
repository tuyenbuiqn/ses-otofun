<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMainMenu.ascx.cs"
    Inherits="SES.CMS.Module.ucMainMenu" %>
<div class="menu">
    <div class="menu-text">
        <div id="divhome" runat="server">
            <a href="http://news.otofun.net" title="Trang chủ">
                <asp:Image ID="homebutton" runat="server" CssClass="home-button" ImageUrl="/images/Home-button.png"
                    AlternateText="Otofun-homepage" /></a>
        </div>
        <ul class="toplink">
            <asp:Repeater runat="server" ID="rptMainMenu" OnItemDataBound="rptMainMenu_ItemDataBound">
                <ItemTemplate>
                    <%#ReturnLiActive(Eval("CategoryID").ToString())%>
                    <a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.ofn'
                        title='<%#Eval("Title") %>'>
                        <%#Eval("Title") %></a> </li>
                </ItemTemplate>
            </asp:Repeater>
            <li><a target="_blank" href="http://www.otofun.net/forum.php" title="Diễn đàn otofun.net">Diễn đàn</a>
            </li>
        </ul>
        <div class="search-box">
            <asp:ImageButton runat="server" ImageUrl="/images/search-button.jpg" CssClass="search-button"
                ID="imgbtnSearch" OnClick="imgbtnSearch_Click" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=""
                ControlToValidate="txtSearch"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtSearch" class="search" runat="server" BackColor="#454545"></asp:TextBox>
            <a href="#">
                <img id="rss-button" class="rss-button" src="/images/RSS-button.jpg" alt="" /></a>
        </div>
    </div>
</div>
