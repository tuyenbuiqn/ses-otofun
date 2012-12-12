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
    public partial class ucAnToanGiaoThong : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptTuVanKyThuatDataSource();
        }
        protected void rptTuVanKyThuatDataSource()
        {
            ltrTitle.Text = new cmsCategoryBL().Select(new cmsCategoryDO { CategoryID = 43 }).Title;
            DataTable dtCateParent = new cmsArticleBL().SelectByCatNum(43, 1);
            rptTuVanKyThuat.DataSource = dtCateParent;
            rptTuVanKyThuat.DataBind();
        }

        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        public string WordCut(string s)
        {
            return Ultility.WordCut(s, 100, new char[] { ' ', '.', ',', ';' }) + "...";
        }
    }
}