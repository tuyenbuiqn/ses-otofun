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
using SES.CMS.DO;
using SES.CMS.BL;
using SES.CMS.AdminCP;

namespace SES.CMS.WEB.AdminCP.PageUC
{
    public partial class ucListConfig : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            gvConfig.DataSource = new sysConfigBL().SelectAll();
            gvConfig.DataBind();
        }
        protected void gvConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ConfigID = Convert.ToInt32(gvConfig.DataKeys[gvConfig.SelectedIndex].Value);
            Functions.RedirectPage("Default.aspx?Page=Config&ConfigID=" + ConfigID.ToString());
        }

        protected void gvConfig_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvConfig.PageIndex = e.NewPageIndex;
            LoadConfig();
        }

        protected void gvConfig_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                new sysConfigBL().Delete(new sysConfigDO { ConfigID = Convert.ToInt32(gvConfig.DataKeys[e.RowIndex].Value) });
                Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
            }
            catch
            {
                Functions.Alert("Có lỗi xảy ra!", Request.Url.ToString());
            }
        }
        protected void btnNewConfig_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=Config");
        }
    }
}