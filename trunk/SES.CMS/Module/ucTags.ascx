<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTags.ascx.cs" Inherits="SES.CMS.Module.ucTags" %>
<div class="tag-box">
    <ul class="tag-ul">
        <asp:Repeater runat="server" ID="rptTag">
        <HeaderTemplate> <li> Tags: </li> </HeaderTemplate>
            <ItemTemplate>
                <li class="litag">
                    <a href='/tag/otofun-<%#Eval("Tag") %>.otofun' title='<%#Eval("Tag") %>'><%#Eval("Tag") %></a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
