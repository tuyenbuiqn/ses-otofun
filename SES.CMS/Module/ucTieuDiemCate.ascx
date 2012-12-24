<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTieuDiemCate.ascx.cs" Inherits="SES.CMS.Module.ucTieuDiemCate" %>
  
<div class="hotevent-box">
  <h2 class="hotevent-h2-title">Tiêu điểm</h2>
    <asp:Repeater runat="server" ID="rptTieuDiemArt">
        <ItemTemplate>
            <div class="hotevent">
                <div class="hotevent-img-box">
                    <img class="hotevent-img" src='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>' />
                </div>
                <a  class="hotevent-title" href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                    title='<%#Eval("Title") %>'>
                    <%#Eval("Title") %></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
