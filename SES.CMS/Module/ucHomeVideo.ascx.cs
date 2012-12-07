using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using System.Data;

namespace SES.CMS.Module
{
    public partial class ucHomeVideo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtVideoHomepage = new cmsVideoBL().SelectVideoHomepage();
            if (dtVideoHomepage.Rows.Count > 0)
            {
                ltrHomeVideo.Text = "<iframe src='http://www.youtube.com/embed/" + dtVideoHomepage.Rows[0]["VideoUrl"] +"' width='300px' height='230px' style='margin:0px 0px 10px 0px;' frameborder='0' allowfullscreen></iframe>";
            }
        }
    }
}