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
    public partial class ucSameCateArticles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ArticleID"]))
            {
                int articleID = int.Parse(Request.QueryString["ArticleID"]);
                rptNewArticleDataSource(articleID);
            }
        }
        protected void rptNewArticleDataSource(int articleID)
        {
            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = articleID;
            objArt = new cmsArticleBL().Select(objArt);
            if (objArt.CategoryID > 0)
            {
                DataTable dtNewArt = new cmsArticleBL().SelectByCategoryID(objArt.CategoryID);
                rptNewArticle.DataSource = new DataView(dtNewArt, "ArticleID <> " + articleID, "", DataViewRowState.CurrentRows);
                rptNewArticle.DataBind();
            }
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
    }
}