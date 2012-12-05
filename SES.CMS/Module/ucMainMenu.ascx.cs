using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using SES.CMS;
using System.Data;
namespace SES.CMS.Module
{
    public partial class ucMainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptMainMenuDataSource(); rptChildDataSource();
        }

        private void rptMainMenuDataSource()
        {
            rptMainMenu.DataSource = new cmsCategoryBL().SelectMenu(7);
            rptMainMenu.DataBind();
        }

        private void rptChildDataSource()
        {
            if (Request.Url.AbsolutePath.ToUpper().Equals("/DEFAULT.ASPX"))
            {
                rptChildMenu.Visible = false;
            }
            else
            {
                string url = Request.Url.AbsolutePath;
                url = url.Substring(1, url.Length - 1);
                string url1 = url.Replace(".", "/");
                string Module = url1.Substring(0, url1.IndexOf("/"));

                if (Module.Equals("Cat"))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
                    {
                        int cateID = int.Parse(Request.QueryString["CategoryID"]);
                        rptChildMenu.Visible = true;
                        rptChildMenu.DataSource = new cmsCategoryBL().SelectByParent(cateID);
                        rptChildMenu.DataBind();
                    }
                }
            }
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void rptMainMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //cmsCategoryBL cateBL = new cmsCategoryBL();
            //cmsCategoryDO objCate = new cmsCategoryDO();
            //RepeaterItem item = e.Item;
            //if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            //{
            //    DataRowView drv = (DataRowView)item.DataItem;
            //    int categoryID = int.Parse(drv["CategoryID"].ToString());
            //    objCate.CategoryID = categoryID;
            //    objCate = cateBL.Select(objCate);
            //     string url = Request.Url.AbsolutePath;
            //    url = url.Substring(1, url.Length - 1);
            //    string url1 = url.Replace(".", "/");
            //    string Module = url1.Substring(0, url1.IndexOf("/"));

            //    if (Module.Equals("Cat"))
            //    {
            //        if (objCate.ParentID == 0)
            //        {
                        
            //        }
            //        else if (objCate.ParentID > 0)
            //        { }

            //    }
            
            //}
        }
    }
}