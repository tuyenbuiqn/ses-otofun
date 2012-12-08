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
    public partial class ucListAdvertisement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvAdvDataSource();
            }
        }

        protected void gvAdvDataSource()
        {
            gvAdv.DataSource = new cmsAdvertisementBL().SelectAll();
            gvAdv.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string posistion = ddlPosition.SelectedValue;
            string module = ddlModule.SelectedValue;
            int isPublish = int.Parse(ddlIsPublish.SelectedValue);

            gvAdv.DataSource = new cmsAdvertisementBL().Advertisement_Filter(posistion, module, isPublish);
            gvAdv.DataBind();
        }
        protected void gvAdv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AdvertisementID = int.Parse(gvAdv.DataKeys[gvAdv.SelectedIndex].Value.ToString());
            Response.Redirect("Default.aspx?Page=Advertisement&AdvertisementID=" + AdvertisementID.ToString());
        }

        protected void gvAdv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new cmsAdvertisementBL().Delete(new cmsAdvertisementDO { AdvertisementID = Convert.ToInt32(gvAdv.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }

        protected void gvAdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAdv.PageIndex = e.NewPageIndex;

            string posistion = ddlPosition.SelectedValue;
            string module = ddlModule.SelectedValue;
            int isPublish = int.Parse(ddlIsPublish.SelectedValue);

            gvAdv.DataSource = new cmsAdvertisementBL().Advertisement_Filter(posistion, module, isPublish);
            gvAdv.DataBind();
        }
    }
}