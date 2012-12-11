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
    public partial class ucSaleOff : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptTuVanKyThuatDataSource();
        }
        protected void rptTuVanKyThuatDataSource()
        {
            string cateTitle =new cmsCategoryBL().Select(new cmsCategoryDO { CategoryID = 42 }).Title; 
            ltrTitle.Text = cateTitle;
            hplReadmore.NavigateUrl = "/" + FriendlyUrl(cateTitle) + "-" + 42 + ".aspx";
            DataTable dtCateParent = new cmsArticleBL().SelectByCatNum(42, 10);
            rptTuVanKyThuat.DataSource = dtCateParent;
            rptTuVanKyThuat.DataBind();
        }

        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
    }
}