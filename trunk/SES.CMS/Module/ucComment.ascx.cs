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
                DataTable dtComment = new cmsCommentBL().SelectByArt(int.Parse(Request.QueryString["ArticleID"]));
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
        protected void rptComment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int commentID = int.Parse(e.CommandArgument.ToString());
           
            if (e.CommandName == "Like")
            {
                cmsCommentDO objcomment = new cmsCommentDO();
                cmsCommentBL CommentBL = new cmsCommentBL();
                objcomment.CommentID = commentID;

                objcomment = CommentBL.Select(objcomment);
                    objcomment.VoteUp = objcomment.VoteUp + 1;
                CommentBL.Update(objcomment);

            }

            if (e.CommandName == "Dislike")
            {
                cmsCommentDO objcomment = new cmsCommentDO();
                cmsCommentBL CommentBL = new cmsCommentBL();
                objcomment.CommentID = commentID;

                objcomment = CommentBL.Select(objcomment);
                    objcomment.VoteDown = objcomment.VoteDown + 1;
                CommentBL.Update(objcomment);

            }
                Response.Redirect(Request.Url.AbsolutePath);
            }
        }
    }