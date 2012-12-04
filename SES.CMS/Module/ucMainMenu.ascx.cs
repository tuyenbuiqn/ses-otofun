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
    public partial class ucMainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptMainMenuDataSource();
        }

        private void rptMainMenuDataSource()
        {
            rptMainMenu.DataSource = new cmsCategoryBL().SelectMenu(7);
            rptMainMenu.DataBind();
        }

        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AV(s);
        }
    }
}