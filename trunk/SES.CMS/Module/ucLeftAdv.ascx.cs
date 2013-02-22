using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SES.CMS.Module
{
    public partial class ucLeftAdv : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["CategoryID"] != null))
            {
                if(Request.QueryString["CategoryID"]=="11")
                    catbanner.Visible = true;
                else  catImg.Visible = true;

            }
           
               
        }
    }
}