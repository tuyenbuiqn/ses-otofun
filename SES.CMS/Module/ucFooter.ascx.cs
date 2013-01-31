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
            if (!IsPostBack)
                rptMainMenuDataSource(); //rptChildDataSource();
            //rptNewsDataSource();
            //rptBuyDataSource();
        }

        //private void rptNewsDataSource()
        //{
        //    rptNews.DataSource = new cmsArticleBL().SelectByCatNum(5,8);
        //    rptNews.DataBind();
        //}

        //private void rptBuyDataSource()
        //{
        //    rptBuy.DataSource = new cmsArticleBL().SelectByCatNum(13,8);
        //    rptBuy.DataBind();
        //}

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