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
    public partial class ucTags : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ArticleID"]))
            {
                int articleID = int.Parse(Request.QueryString["ArticleID"]);
                if (!IsPostBack)
                {
                    if (dtTag(articleID).Rows.Count > 0)
                    {
                        rptTag.DataSource = dtTag(articleID);
                        rptTag.DataBind();
                    }
                }
            }
        }

        protected string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }

        protected DataTable dtTag(int articleID)
        {
            DataTable dtTag = new DataTable();
            dtTag.Columns.Add("Tag",typeof(string));
            string sTag = new cmsArticleBL().Select(new cmsArticleDO { ArticleID = articleID }).Tags;

            if (string.IsNullOrEmpty(sTag))
            {
                dtTag = null;
            }
            else
            {
                string[] tagArray = sTag.Split(',');
                for (int i = 1; i < tagArray.Length-1; i++)
                {
                    dtTag.Rows.Add(tagArray[i]);
                }
            }
            return dtTag;
        }
    }
}