<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMainMenu.ascx.cs"
    Inherits="SES.CMS.Module.ucMainMenu" %>
<div class="menu">
    <div class="menu-text">
        <a href="/Default.aspx" title="otofun-homepage">
            <img id="home-button" class="home-button" src="/images/Home-button.jpg" alt="Otofun-homepage" /></a>
        <ul class="toplink">
            <asp:Repeater runat="server" ID="rptMainMenu" OnItemDataBound="rptMainMenu_ItemDataBound">
                <ItemTemplate>
                   <%#ReturnLiActive(Eval("CategoryID").ToString())%>
                    <a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.aspx'
                        title='<%#Eval("Title") %>'>
                        <%#Eval("Title") %></a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
              <li>
            <a href="http://www.otofun.net/forum.php" title="Diễn đàn otofun.net">Diễn đàn</a>
        </li>
        </ul>
        <div class="search-box">
            <asp:ImageButton runat="server" ImageUrl="/images/search-button.jpg" CssClass="search-button" ID="imgbtnSearch" OnClick="imgbtnSearch_Click" />
            <asp:TextBox ID="txtSearch" class="search" runat="server" BackColor="#454545"></asp:TextBox>
            <a href="#">
                <img id="rss-button" class="rss-button" src="/images/RSS-button.jpg" alt="" /></a>
        </div>
    </div>
    <div class="menu-line">
    </div>
</div>
