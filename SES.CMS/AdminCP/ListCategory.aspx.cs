using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SES.CMS.BL;

namespace SES.CMS.AdminCP
{
    public partial class ListCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tlCategory.DataSource = new cmsCategoryBL().SelectAll();
            tlCategory.DataBind();
            tlCategory.ExpandToLevel(3);
        }
    }
}
