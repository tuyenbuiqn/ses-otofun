<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucComment.ascx.cs" Inherits="SES.CMS.Module.ucComment" %>
<style type="text/css">
 
</style>
<div class="comment-box1" runat="server" id="comment">
<h3 class="hmp-cate-maintitle">
                    <span>
                        BÌNH LUẬN </span>
                
                </h3>
    <asp:Repeater ID="rptComment" runat="server" OnItemCommand="rptComment_ItemCommand">
        <ItemTemplate>
            <div class="comment-info1">
                
                <div class="comment-info2">
                    <div class="comment-name1">
                       
                        <span><%#Eval("Name") %></span> &nbsp;&nbsp;-&nbsp;&nbsp; Gửi lúc
                        <%#DateTime.Parse(Eval("CreateDate").ToString()).ToString("HH:mm dd/MM/yyyy ")%>      
                         
                    </div>
                    <div class="comment-vote1">
                        <span class="social-box">
                            <span class="social-button">
                                <asp:LinkButton runat="server" ID="lbtnLike" CommandArgument='<%#Eval("CommentID")%>'
                                    CommandName="Like" Text="Thích"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lntnDislike" CommandName="Dislike" 
                                CommandArgument='<%#Eval("CommentID")%>' Text="| Không Thích"></asp:LinkButton>
                            </span>
                                    <span class="like-icon"></span>
                                    <span class="total-like"><%#Eval("VoteUp") %></span>
                                    <span class="dislike-icon"></span>
                                    <span class="total-dislike">
                                    <%#Eval("VoteDown") %></span>
                         
                    </div>
                    
                </div>
                <div class="comment-content1">
                    <span class="contentcm">
                        <%#Eval("Contents") %>       
                    </span>
  
                </div>
               
            </div>
            
        </ItemTemplate>  
    </asp:Repeater>    
</div>
