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
            Boolean isAuto = false;
            try
            {

                isAuto = Boolean.Parse(new sysConfigBL().Select(new sysConfigDO { ConfigID = 5 }).ConfigValue);
            }
            catch { }
            // Value = true -> Lay tu dong
            if (isAuto == true)
            {
                rptTieuDiemArt.DataSource = new cmsArticleBL().MostReadOfCategory(categoryID);
            }
            else if (isAuto == false)
            {
                cmsCategoryDO objCategory = new cmsCategoryDO();
                objCategory.CategoryID = categoryID;
                objCategory = new cmsCategoryBL().Select(objCategory);

                if (objCategory.ParentID == 0)
                    rptTieuDiemArt.DataSource = new cmsMostReadBL().SelectByCategoryID(6, objCategory.CategoryID);
                else
                    rptTieuDiemArt.DataSource = new cmsMostReadBL().SelectByCategoryID(6, objCategory.ParentID);
            }
            rptTieuDiemArt.DataBind();
        }
    }
}