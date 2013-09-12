<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTieuDiem.ascx.cs"
    Inherits="SES.CMS.Module.ucTieuDiem" %>
<div class="docnhieu">
   <h3 class="hmp-cate-maintitle">
                    <span>
                        ĐỌC NHIỀU</span>
                
                </h3>
    <ul class="docnhieu-noidung" style="background: none">
        <asp:Repeater runat="server" ID="rptMostRead">
            <ItemTemplate>
                <li>
                    <div class="out-image">
                            <a href='/<%#FriendlyUrl(Eval("CategoryTitle").ToString())%>-<%#Eval("CategoryID") %>/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.ofn'
                                title='<%#Eval("Title") %>'>
                                <img class="Anh-noidung-docnhieu" src='/Media/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>' _fl/>
                           
                            <h5>
                            <%#Eval("Title") %></h5>
                             </a>
                        </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
