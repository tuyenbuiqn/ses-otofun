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
    public partial class ucMostRead : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptMostReadDataSource();
        }

        protected void rptMostReadDataSource()
        {
            rptMostRead.DataSource = new cmsArticleBL().MostRead();
            rptMostRead.DataBind();
        }

        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
    }
}