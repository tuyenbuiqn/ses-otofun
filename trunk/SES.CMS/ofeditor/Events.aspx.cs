using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;

namespace SES.CMS.ofeditor
{
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == null || Session["UserName"] == null)
            {
                Response.Redirect("/ofeditor/Login.aspx");
            }
            else
            {
                int userType = int.Parse(Session["UserType"].ToString());
                if (userType == 2)
                {
                    if (!IsPostBack)
                    {
                        Ultility.ddlDatabinder(ddlDongSuKien, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectAll());
                        rptEventDataSource();
                    }
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
            }
        }
        protected void rptEventDataSource()
        {
            grvEvent.DataSource = new cmsEventBL().SelectAll();
            grvEvent.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Event.aspx");
        }

        protected void grvEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int EventID = int.Parse(grvEvent.DataKeys[grvEvent.SelectedIndex].Value.ToString());
            Response.Redirect("Event.aspx?EventID=" + EventID.ToString());
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

        protected void ddlDongSuKien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(ddlDongSuKien.SelectedValue) == 0)
            {
                grvEvent.DataSource = new cmsEventBL().SelectAll();

            }
            else
            { 
                grvEvent.DataSource = new cmsEventBL().GetEventByCategoryID(int.Parse(ddlDongSuKien.SelectedValue), 100);
            }
            grvEvent.DataBind();
        }
    }
}