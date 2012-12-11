<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucComment.ascx.cs" Inherits="SES.CMS.Module.ucComment" %>
<style type="text/css">
 
</style>
<div class="comment-box1" runat="server" id="comment">
<h2>
    Các phản hồi</h2>
<div class="line-article"></div>
    <asp:Repeater ID="rptComment" runat="server">
        <ItemTemplate>
            <div class="commment-info1">
                <div class="comment-content1">
                    <%#Eval("Contents") %>    
                </div>
                <div class="comment-info2">
                    <div class="comment-name1">
                        <span class="namecm">
                        <b><%#Eval("Name") %></b> &nbsp;&nbsp;-&nbsp;&nbsp;
                        <%#DateTime.Parse(Eval("CreateDate").ToString()).ToString("dd/MM/yyyy") %>      
                        </span>   
                    </div>
                    <div class="comment-vote1">
                        <%#Eval("VoteUp") %> 
                        <%#Eval("VoteDown") %> 
                    </div>
                    
                </div>
                <div class="dotted"></div>
            </div>
        </ItemTemplate>  
    </asp:Repeater>    
</div>
