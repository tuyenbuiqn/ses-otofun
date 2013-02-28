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
    public partial class ucEvent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*
                // check trang default
                string url = Request.Url.AbsolutePath;
                url = url.Substring(1, url.Length - 1);
                string url1 = url.Replace(".", "/");
                string Module = url1.Substring(0, url1.IndexOf("/"));
                if (Module.Equals("") || Module.ToLower().Equals("default"))
                {
                    rptEventDataSouce(8);
                }
                else
                {
                    // check trang category
                    if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
                    {
                        int categoryID = int.Parse(Request.QueryString["CategoryID"]);
                        cmsCategoryDO objCategory = new cmsCategoryDO();
                        objCategory.CategoryID = categoryID;
                        objCategory = new cmsCategoryBL().Select(objCategory);

                        if (objCategory.ParentID == 0)
                            rptEventDataSouce(objCategory.CategoryID);
                        else
                            rptEventDataSouce(objCategory.ParentID);
                    }
                    else
                    {
                        int categoryID = -1;
                        try
                        {
                            string urlx = Request.Url.AbsolutePath;
                            url = url.Substring(1, url.Length - 1);
                            string url1x = url.Replace(".", "/");
                            string Modulex = url1.Substring(0, url1.IndexOf("/"));
                            categoryID = int.Parse(Module.Substring(Module.LastIndexOf('-') + 1, Module.Length - (Module.LastIndexOf('-') + 1)));

                        }
                        catch { }
                        cmsCategoryDO objCategory = new cmsCategoryDO();
                        objCategory.CategoryID = categoryID;
                        objCategory = new cmsCategoryBL().Select(objCategory);

                        if (objCategory.ParentID == 0)
                            rptEventDataSouce(objCategory.CategoryID);
                        else
                            rptEventDataSouce(objCategory.ParentID);
                    }
                }


                // check trang article
                 */

            }
        }

        protected void rptEventDataSouce(int categoryID)
        {
            //   rptEvent.DataSource = new cmsEventBL().SelectAll();
            rptEvent.DataSource = new cmsEventBL().GetEventByCategoryID(categoryID, 5);
            rptEvent.DataBind();
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
    }
}