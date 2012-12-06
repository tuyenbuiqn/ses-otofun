using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;

namespace SES.CMS.Module
{
    public partial class ucTieuDiem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ArticleID"]))
            {
                int articleID = int.Parse(Request.QueryString["ArticleID"].ToString());
                rptTieuDiemArtDataSoucre(articleID);
            }
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void rptTieuDiemArtDataSoucre(int articleID)
        {
            cmsArticleDO objArt = new cmsArticleDO();
            objArt.ArticleID = articleID;
            objArt = new cmsArticleBL().Select(objArt);

            rptTieuDiemArt.DataSource = new cmsArticleBL().HotEvents(objArt.CategoryID);
            rptTieuDiemArt.DataBind();
        }
    }
}