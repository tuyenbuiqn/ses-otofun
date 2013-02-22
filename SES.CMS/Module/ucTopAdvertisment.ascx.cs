using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SES.CMS.Module
{
    public partial class ucTopAdvertisment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["CategoryID"] == null) && (Request.QueryString["ArticleID"] == null))
                homeBanner.Visible = true;
            else if ((Request.QueryString["CategoryID"] != null) && (Request.QueryString["ArticleID"] == null))
                catBanner.Visible = true;
            else if ((Request.QueryString["ArticleID"] != null))
                artBanner.Visible = true;
            else artBanner.Visible = true;

        }
    }
}