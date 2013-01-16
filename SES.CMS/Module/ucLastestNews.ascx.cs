using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;

namespace SES.CMS.Module
{
    public partial class ucLastestNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                 rptLastestNewsDataSource();
        }
        protected void rptLastestNewsDataSource()
        {
            //rptLastestNews.DataSource = new cmsArticleBL().LastestNews();
            rptLastestNews.DataSource = new cmsTopNewsBL().SelectAll(10);
            rptLastestNews.DataBind();
        }

        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
    }
}