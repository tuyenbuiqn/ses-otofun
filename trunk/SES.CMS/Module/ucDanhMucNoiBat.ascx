<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDanhMucNoiBat.ascx.cs"
    Inherits="SES.CMS.Module.ucDanhMucNoiBat" %>
<ul class="AnhNho">
    <asp:Repeater runat="server" ID="rptDanhMucNoiBat">
        <ItemTemplate>
            <li><a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                title='<%#Eval("Title") %>'>
                <img id="Img1" class="img-car" src='/Media/<%#Eval("ImageUrl") %>'
                    alt='<%#Eval("Title") %>' /></a> <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                        title='<%#Eval("Title") %>'>
                        <%#Eval("Title") %></a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
