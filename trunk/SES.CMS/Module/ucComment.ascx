<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucComment.ascx.cs" Inherits="SES.CMS.Module.ucComment" %>
<style type="text/css">
    .comment-box
{
    width: 100%;
    min-height: 300px;
    }

.comment-info
{
    width: 100%;
    min-height: 120px; 
    }
    
.comment-content
{
    width: 100%;
    height: 60px;
    float: none;
}

.comment-info1
{
    width: 100%;
    height: 60px;
    float: none;
    }
.comment-name
{
    width: 80%;
    height: 60%;
    float: left;
    }

.comment-vote
{
    width: 20%;
    height: 60%;
    float: left;
    }  
 
</style>
<div class="comment-box">
    <asp:Repeater ID="rptComment" runat="server">
        <ItemTemplate>
            <div class="commment-info">
                <div class="comment-content">
                    <asp:Label ID="lblContent" runat="server"></asp:Label>     
                </div>
                <div class="comment-info1">
                    <div class="comment-name">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                        <asp:Label ID="lblDate" runat="server"></asp:Label>         
                    </div>
                    <div class="comment-vote">
                        <asp:Label ID="lblUp" runat="server"></asp:Label> 
                        <asp:Label ID="lblDown" runat="server"></asp:Label>  
                    </div>
                </div>
            </div>
        </ItemTemplate>  
    </asp:Repeater>    
</div>
