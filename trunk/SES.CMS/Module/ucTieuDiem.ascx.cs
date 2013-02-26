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
           // rptMostRead.DataSource = new cmsArticleBL().MostReadOfCategory(categoryID);
            rptMostRead.DataSource = new cmsMostReadBL().SelectByCategoryID(6, categoryID);
            rptMostRead.DataBind();
        }

        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
    }
}