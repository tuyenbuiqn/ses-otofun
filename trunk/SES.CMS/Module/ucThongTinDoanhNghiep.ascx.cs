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
    public partial class ucThongTinDoanhNghiep : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            rptThongTinDoanhNghiepDataSource();
        }
        protected void rptThongTinDoanhNghiepDataSource()
        {
            DataTable dtThongTinDoanhNghiep = new cmsArticleBL().SelectPaging(40,0,20);
            lblTitle.Text = new cmsCategoryBL().Select(new cmsCategoryDO { CategoryID = 40 }).Title;
            rptThongTinDoanhNghiep.DataSource = dtThongTinDoanhNghiep;
            rptThongTinDoanhNghiep.DataBind();
        }

        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        public string WordCut(string text)
        {
            return Ultility.WordCut(text,40, new char[] { ' ', '.', ',', ';' }) + "...";
        }
    }
}