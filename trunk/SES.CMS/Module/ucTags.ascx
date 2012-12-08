<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTags.ascx.cs" Inherits="SES.CMS.Module.ucTags" %>
<div class="tag-box">
    <ul class="tag-ul">
        <asp:Repeater runat="server" ID="rptTag">
            <ItemTemplate>
                <li>
                    <a href='/tag/<%#FriendlyUrl(Eval("Tag").ToString())%>.aspx' title='<%#Eval("Tag") %>'><%#Eval("Tag") %></a>,
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
