using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using SES.CMS;

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
    }
}