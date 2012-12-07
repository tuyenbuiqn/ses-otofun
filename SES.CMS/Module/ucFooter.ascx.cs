using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
namespace SES.CMS.Module
{
    public partial class ucFooter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptMainMenuDataSource(); //rptChildDataSource();
        }

        private void rptMainMenuDataSource()
        {
            rptMainMenu.DataSource = new cmsCategoryBL().SelectMenu(7);
            rptMainMenu.DataBind();
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
    }
}