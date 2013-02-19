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
                if (!IsPostBack)
                    rptNewArticleDataSource(articleID);
            }
        }
        protected void rptNewArticleDataSource(int articleID)
        {
            int categoryID = -1;
            string url = Request.Url.AbsolutePath;
            url = url.Substring(1, url.Length - 1);
            string url1 = url.Replace(".", "/");
            string Module = url1.Substring(0, url1.IndexOf("/"));
            try
            {
                // string s = Module.Substring(Module.LastIndexOf('-') + 1, Module.Length - (Module.LastIndexOf('-') + 1));
                categoryID = int.Parse(Module.Substring(Module.LastIndexOf('-') + 1, Module.Length - (Module.LastIndexOf('-') + 1)));
            }
            catch { }
          
            if (categoryID > 0)
            {
                DataTable dtNewArt = new cmsArticleBL().SelectBySameCategory(15,categoryID);
                rptNewArticle.DataSource = new DataView(dtNewArt, "ArticleID <> " + articleID, "", DataViewRowState.CurrentRows);
                rptNewArticle.DataBind();
            }
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        public string WordCut(string text)
        {
            return Ultility.WordCut(text, 50, new char[] { ' ', '.', ',', ';' }) + "...";
        }
    }
}