using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;
using System.Data;
namespace SES.CMS.Module
{
    public partial class ucDanhMucNoiBat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptCategoryParentDataSource();
        }
        protected void rptCategoryParentDataSource()
        {

            DataTable dtCateParent = new cmsArticleBL().HotArticle_UnderSlideHomepage();
            rptDanhMucNoiBat.DataSource = dtCateParent;
            rptDanhMucNoiBat.DataBind();
        }

        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
    }
}