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
            int articleID = int.Parse(Request.QueryString["ArticleID"].ToString());
            loadrptComment(articleID);
        }

        private void loadrptComment(int articleID)
        {
            objcomment.ArticleID = articleID;
            objcomment = new cmsCommentBL().Select(objcomment);

            
        }
    }
}