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
}