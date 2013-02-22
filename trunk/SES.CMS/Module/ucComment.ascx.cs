using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Data;

namespace SES.CMS.Module
{
    public partial class ucComment : System.Web.UI.UserControl
    {
        cmsCommentDO objcomment = new cmsCommentDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ArticleID"]))
            {
                DataTable dtComment = new cmsCommentBL().SelectByArticle(int.Parse(Request.QueryString["ArticleID"]), 0);
                if (dtComment.Rows.Count > 0)
                {
                    comment.Visible = true;
                    rptComment.DataSource = dtComment;
                    rptComment.DataBind();
                }
                else
                    comment.Visible = false;
            }
        }
        protected void rptComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            RepeaterItem item = e.Item;
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = (DataRowView)item.DataItem;
                int commentID = int.Parse(drv["CommentID"].ToString());

                Repeater rptReplyComment = (Repeater)e.Item.FindControl("rptReplyComment");
                rptReplyComment.DataSource = new cmsCommentBL().SelectByArticle(int.Parse(Request.QueryString["ArticleID"]), commentID);
                rptReplyComment.DataBind();
            }
        }
        protected void rptComment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int commentID = int.Parse(e.CommandArgument.ToString());
            string curSession = Session["artIpAddress"].ToString();
            cmsCommentDO objComment = new cmsCommentBL().Select(new cmsCommentDO { CommentID = commentID });
            cmsCommentBL CommentBL = new cmsCommentBL();
            // Reply
            if (e.CommandName == "Reply")
            {
                Session["ReplyCommentID"] = commentID;
                txtHoTen.Focus();
                HyperLink hplX = (HyperLink)e.Item.FindControl("hplX");
                hplX.Attributes.Add("href","#xxx");
            }
            // not reply
            else
            {
                //IP == IP comment -> Cannot like
                if (curSession.Equals(objComment.IP))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Hiện tại bạn không thể sử dụng chức năng này được nữa!');", true);
                }
                // IP != IP comment
                else
                {
                    // Check IP nay da like chua
                    if (Session["likedSession"] == null) // chua like
                    {
                        if (e.CommandName == "LikeR")
                        {
                            objComment.VoteUp = objComment.VoteUp + 1;
                            CommentBL.Update(objComment);
                        }

                        else if (e.CommandName == "DislikeR")
                        {
                            objComment.VoteDown = objComment.VoteDown + 1;
                            CommentBL.Update(objComment);
                        }
                        Session["likedSession"] = curSession; // Luu lai Session da like
                        // Luu lai CommentID dau tien da like
                        Session["likedComments"] = "," + commentID + ",";
                    }
                    // IP da like 1 comment bat ky
                    else
                    {
                        // Chua like comment nao ca
                        if (Session["likedComments"] == null)
                        {
                            if (e.CommandName == "LikeR")
                            {
                                objComment.VoteUp = objComment.VoteUp + 1;
                                CommentBL.Update(objComment);
                            }
                            else if (e.CommandName == "DislikeR")
                            {
                                objComment.VoteDown = objComment.VoteDown + 1;
                                CommentBL.Update(objComment);
                            }
                            // Luu lai CommentID dau tien da like
                            Session["likedComments"] = "," + commentID + ",";
                        }
                        // Da like comment va check xem commentID dang click da like chua?
                        else
                        {
                            string likedComments = Session["likedComments"].ToString();
                            string validateComment = "," + commentID + ",";
                            // CommentID nay da like -> no
                            if (likedComments.Contains(validateComment))
                            {
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Hiện tại bạn không thể sử dụng chức năng này được nữa!');", true);
                            }
                            //chua like comment nay
                            else
                            {
                                if (e.CommandName == "LikeR")
                                {
                                    objComment.VoteUp = objComment.VoteUp + 1;
                                    CommentBL.Update(objComment);
                                }

                                else if (e.CommandName == "DislikeR")
                                {
                                    objComment.VoteDown = objComment.VoteDown + 1;
                                    CommentBL.Update(objComment);
                                }
                                Session["likedComments"] = likedComments + commentID + ",";
                            }
                        }
                    }
                }
                UpdatePanel1.Update();
            }
        }
        protected void rptReplyComment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int commentID = int.Parse(e.CommandArgument.ToString());
            string curSession = Session["artIpAddress"].ToString();
            cmsCommentDO objComment = new cmsCommentBL().Select(new cmsCommentDO { CommentID = commentID });
            cmsCommentBL CommentBL = new cmsCommentBL();
            //IP == IP comment -> Cannot like
            if (curSession.Equals(objComment.IP))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Hiện tại bạn không thể sử dụng chức năng này được nữa!');", true);
            }
            // IP != IP comment
            else
            {
                // Check IP nay da like chua
                if (Session["likedSession"] == null) // chua like
                {
                    if (e.CommandName == "Like")
                    {
                        objComment.VoteUp = objComment.VoteUp + 1;
                        CommentBL.Update(objComment);
                    }

                    else if (e.CommandName == "Dislike")
                    {
                        objComment.VoteDown = objComment.VoteDown + 1;
                        CommentBL.Update(objComment);
                    }
                    Session["likedSession"] = curSession; // Luu lai Session da like
                    // Luu lai CommentID dau tien da like
                    Session["likedComments"] = "," + commentID + ",";
                }
                // IP da like 1 comment bat ky
                else
                {
                    // Chua like comment nao ca
                    if (Session["likedComments"] == null)
                    {
                        if (e.CommandName == "Like")
                        {
                            objComment.VoteUp = objComment.VoteUp + 1;
                            CommentBL.Update(objComment);
                        }
                        else if (e.CommandName == "Dislike")
                        {
                            objComment.VoteDown = objComment.VoteDown + 1;
                            CommentBL.Update(objComment);
                        }
                        // Luu lai CommentID dau tien da like
                        Session["likedComments"] = "," + commentID + ",";
                    }
                    // Da like comment va check xem commentID dang click da like chua?
                    else
                    {
                        string likedComments = Session["likedComments"].ToString();
                        string validateComment = "," + commentID + ",";
                        // CommentID nay da like -> no
                        if (likedComments.Contains(validateComment))
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Hiện tại bạn không thể sử dụng chức năng này được nữa!');", true);
                        }
                        //chua like comment nay
                        else
                        {
                            if (e.CommandName == "Like")
                            {
                                objComment.VoteUp = objComment.VoteUp + 1;
                                CommentBL.Update(objComment);
                            }

                            else if (e.CommandName == "Dislike")
                            {
                                objComment.VoteDown = objComment.VoteDown + 1;
                                CommentBL.Update(objComment);
                            }
                            Session["likedComments"] = likedComments + commentID + ",";
                        }
                    }
                }
            }
            UpdatePanel1.Update();
        }
        protected void imgbtnLike_Click(object sender, EventEntry e)
        {
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            ccJoin.ValidateCaptcha(txtSecCode.Text);
            if (!ccJoin.UserValidated)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Mã bảo vệ chưa chính xác!');", true);
                return;
            }
            else
            {
                if (Session["ReplyCommentID"] == null)
                {
                    objcomment.ReplyCommentID = 0;
                }
                else
                {
                    objcomment.ReplyCommentID = int.Parse(Session["ReplyCommentID"].ToString());
                }
                initObject();
                new cmsCommentBL().Insert(objcomment);
                Session["ReplyCommentID"] = null;
                txtHoTen.Text = "";
                txtEmail.Text = "";
                txtContent.Text = "";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Cám ơn đã đóng góp ý kiến về bài viết. Chúng tôi đã nhận được đóng góp của quý vị!');", true);
            }
        }

        private void initObject()
        {
            objcomment.ArticleID = int.Parse(Request.QueryString["ArticleID"].ToString());
            objcomment.Contents = txtContent.Text;
            objcomment.CreateDate = DateTime.Now;
            objcomment.Email = txtEmail.Text;
            objcomment.Name = txtHoTen.Text;
            objcomment.IsAccepted = false;
            objcomment.IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtContent.Text = "";
        }
    }
}