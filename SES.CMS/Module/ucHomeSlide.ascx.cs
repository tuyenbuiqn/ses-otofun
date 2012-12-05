using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace SES.CMS.Module
{
    public partial class ucHomeSlide : System.Web.UI.UserControl
    {
        private static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadSlide();
        }

        public void loadSlide()
        {
            dt = new cmsSlideBL().SelectAll();
            if (dt.Rows.Count > 0)
            {
                rptSlide.DataSource = dt;
                rptSlide.DataBind();
            }
        }

        public string vTitle(string id)
        {
            string s = "";
            cmsSlideDO obj = new cmsSlideDO();
            obj = new cmsSlideBL().Select(new cmsSlideDO { SlideID = int.Parse(id) });

            s = obj.Title;

            return s;
        }

        public string vDescription(string id)
        {
            string s = "";
            cmsSlideDO obj = new cmsSlideBL().Select(new cmsSlideDO { SlideID = int.Parse(id) });

            s = obj.Description;

            return s;
        }

        private void addHeaderOne()
        {
            HtmlHead head = Page.Header;

            LiteralControl lctl = new LiteralControl("<script type=\"text/javascript\" src=\"/js/previewOne.js\"></script>");

            head.Controls.Add(lctl);
        }

        private void addHeaderAll()
        {
            HtmlHead head = Page.Header;

            LiteralControl lctl = new LiteralControl("<script type=\"text/javascript\" src=\"/js/preview.js\"></script>");

            head.Controls.Add(lctl);
        }
    }
}