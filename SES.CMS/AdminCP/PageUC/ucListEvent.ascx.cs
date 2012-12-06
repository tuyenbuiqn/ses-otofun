using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;

namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucListEvent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptEventDataSource();
            }

        }

        protected void rptEventDataSource()
        {
            grvEvent.DataSource = new cmsEventBL().SelectAll();
            grvEvent.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=Event");
        }

        protected void grvEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int EventID = int.Parse(grvEvent.DataKeys[grvEvent.SelectedIndex].Value.ToString());
            Response.Redirect("Default.aspx?Page=Event&EventID=" + EventID.ToString());
        }

        protected void grvEvent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new cmsEventBL().Delete(new cmsEventDO { EventID = Convert.ToInt32(grvEvent.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }

        protected void grvEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvEvent.PageIndex = e.NewPageIndex;
            rptEventDataSource();
        }

        protected void grvEvent_PageIndexChanged(object sender, EventArgs e)
        {
        }
    }
}