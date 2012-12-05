using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;

namespace SES.CMS
{
    public partial class Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ArticleID"]))
            {
                int articleID = int.Parse(Request.QueryString["ArticleID"].ToString());
                rptArticeDataSource(articleID);

                Page.Title = new cmsArticleBL().SelectByPK(articleID).Rows[0]["Title"].ToString() + " - " + (new sysConfigBL().Select(new sysConfigDO { ConfigID = 1}).ConfigValue);
            }
        }

        protected void rptArticeDataSource(int articleID)
        {
            rptArticleDetail.DataSource = new cmsArticleBL().SelectByPK(articleID);
            rptArticleDetail.DataBind();
        }
    }
}