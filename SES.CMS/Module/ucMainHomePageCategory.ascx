<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMainHomePageCategory.ascx.cs"
    Inherits="SES.CMS.Module.ucMainHomePageCategory" %>
<div class="body-down-left">
    <asp:Repeater runat="server" ID="rptCategoryParent" OnItemDataBound="rptCategoryParent_ItemDataBound">
        <ItemTemplate>
            <div class="TinTuc-wrapper">
                <div class="Cap-TinTuc">
                    <p>
                        <a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.aspx'
                            title='<%#Eval("Title") %>'>
                            <%#Eval("Title") %></a></p>
                </div>
                <ul class="link2">
                    <asp:Repeater runat="server" ID="rptChildCate">
                        <ItemTemplate>
                            <li><a href='/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("CategoryID")%>.aspx'
                                title='<%#Eval("Title") %>'>
                                <%#Eval("Title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="noidung">
                    <asp:Repeater runat="server" ID="rptTopHighLight">
                        <ItemTemplate>
                            <div class="left-noidung">
                                <a href='/Art/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                                    title='<%#Eval("Title") %>'>
                                    <img id="imgAnh-noidung" class="Anh-noidung" src='/images/<%#Eval("ImageUrl") %>' alt='<%#Eval("Title") %>' /></a>
                            </div>
                            <div class="center-noidung">
                                <a href='/Art/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'  title='<%#Eval("Title") %>'>
                                    <%#Eval("Title") %></a>
                                <p>
                                    Cập nhật:&nbsp;</p>
                                <p>
                                    <%#Eval("CreateDate","{0:hh}h") %>&nbsp; <%#Eval("CreateDate","{0:dd-MM-yyyy}") %></p>
                                <p>
                                    &nbsp;|&nbsp; bởi</p>
                                <p>
                                    <%#Eval("UserName") %></p>
                                <div class="chitiet">
                                   <%#WordCut(Eval("Description").ToString())%>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <ul class="right-noidung">
                        <asp:Repeater runat="server" ID="rptTopOtherHighLight">
                            <ItemTemplate>
                                <li><a href='/Art/<%#FriendlyUrl(Eval("Title").ToString())%>-<%#Eval("ArticleID") %>.aspx'
                                    title='<%#Eval("Title") %>'>
                                    <%#Eval("Title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <%--  body-down-right    --%>
</div>
