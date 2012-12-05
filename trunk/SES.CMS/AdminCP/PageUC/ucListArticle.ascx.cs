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
using SES.CMS.BL;
using SES.CMS.DO;

namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucListArticle : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvAt.DataSource = new cmsArticleBL().SelectAll();
            gvAt.DataBind();


            Functions.ddlDatabinder(cboCategory, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectAll());
            cboCategory.Items.Insert(0, "Chọn tất cả -----------");
        }

        protected void gvArticle_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

        }

        protected void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex <= 0)
            {
                gvAt.DataSource = new cmsArticleBL().SelectAll();
                gvAt.DataBind();
            }
            else
            {
                Functions.GvDatabinder(gvAt, new cmsArticleBL().SelectByCategoryID(int.Parse(cboCategory.SelectedValue)));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=Article");
        }



        protected void gvAt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ArticleID = int.Parse(gvAt.DataKeys[gvAt.SelectedIndex].Value.ToString());
            Response.Redirect("Default.aspx?Page=Article&ArticleID=" + ArticleID.ToString());
        }

        protected void gvAt_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new cmsArticleBL().Delete(new cmsArticleDO { ArticleID = Convert.ToInt32(gvAt.DataKeys[e.RowIndex].Value) });
            Functions.Alert("Xóa bản tin thành công!", Request.Url.ToString());
        }


    }
}