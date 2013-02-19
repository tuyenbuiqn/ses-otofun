<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTieuDiem.ascx.cs"
    Inherits="SES.CMS.Module.ucTieuDiem" %>
<div class="docnhieu" style="margin-top:15px;">
   <h3 class="hmp-cate-maintitle">
                    <span>
                        ĐỌC NHIỀU NHẤT</span>
                
                </h3>
    <ul class="docnhieu-noidung" style="background: none">
        <asp:Repeater runat="server" ID="rptMostRead">
            <ItemTemplate>
                <li>
                    <div class="out-image">
                            <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.otofun'
                                title='<%#Eval("Title") %>'>
                                <img class="Anh-noidung-docnhieu" src='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>' />
                           
                            <h5>
                            <%#Eval("Title") %></h5>
                             </a>
                        </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
