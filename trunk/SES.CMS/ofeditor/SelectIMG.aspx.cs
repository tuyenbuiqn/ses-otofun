using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Collections;
using System.Data;

namespace SES.CMS.ofeditor
{
    public partial class SelectIMG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["ID"]);
            cmsArticleDO obj = new cmsArticleBL().Select(new cmsArticleDO { ArticleID = id });
            lblTitle.Text = obj.Title;
            string imgs = obj.DescHome;
            string[] lstIMG = imgs.Split('*');
            DataTable asimg = new DataTable();
            asimg.Columns.Add("ID", typeof(string));
            asimg.Columns.Add("urls", typeof(string));
            DataRow dr;
            int ids = 0;
            foreach (string s in lstIMG)
            {
                ids++;
                dr = asimg.NewRow();
                dr["ID"] = ids;
                dr["urls"] = s;
                asimg.Rows.Add(dr);
            }
            rptIMG.DataSource = asimg;
            rptIMG.DataBind();
        }
    }
}