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
            if (!IsPostBack)
                rptMostReadDataSource();
        }

        protected void rptMostReadDataSource()
        {
            int categoryID = -1;
            try
            {
                string url = Request.Url.AbsolutePath;
                url = url.Substring(1, url.Length - 1);
                string url1 = url.Replace(".", "/");
                string Module = url1.Substring(0, url1.IndexOf("/"));
                categoryID = int.Parse(Module.Substring(Module.LastIndexOf('-') + 1, Module.Length - (Module.LastIndexOf('-') + 1)));
            }
            catch { }
            Boolean isAuto = false;
            try
            {

                isAuto = Boolean.Parse(new sysConfigBL().Select(new sysConfigDO { ConfigID = 5 }).ConfigValue);
            }
            catch { }
            // Value = true -> Lay tu dong
            if (isAuto == true)
            {
                rptMostRead.DataSource = new cmsArticleBL().MostReadOfCategory(categoryID);
            }
            // Value = fasle: Lay = tay
            else if (isAuto == false)
            {
                cmsCategoryDO objCategory = new cmsCategoryDO();
                objCategory.CategoryID = categoryID;
                objCategory = new cmsCategoryBL().Select(objCategory);

                if (objCategory.ParentID == 0)
                    rptMostRead.DataSource = new cmsMostReadBL().SelectByCategoryID(6, objCategory.CategoryID);
                else
                    rptMostRead.DataSource = new cmsMostReadBL().SelectByCategoryID(6, objCategory.ParentID);
            }
            rptMostRead.DataBind();
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
    }
}