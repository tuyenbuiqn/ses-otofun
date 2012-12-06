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
    public partial class ucTieuDiemCate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
            {
                int categoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
                rptTieuDiemArtDataSoucre(categoryID);
            }
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void rptTieuDiemArtDataSoucre(int categoryID)
        {

            rptTieuDiemArt.DataSource = new cmsArticleBL().HotEvents(categoryID);
            rptTieuDiemArt.DataBind();
        }
    }
}