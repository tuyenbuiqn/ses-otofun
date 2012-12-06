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
    public partial class ucEvent : System.Web.UI.UserControl
    {
        cmsEventDO objEvent = new cmsEventDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.DevCboDatabinder(cboParent, new cmsCategoryBL().SelectAll(), cmsCategoryDO.TITLE_FIELD, cmsCategoryDO.CATEGORYID_FIELD);
            if (Request.QueryString["EventID"] != null)
            {
                objEvent.EventID = int.Parse(Request.QueryString["EventID"].ToString());
                initForm();
            }
        }
        private void initForm()
        {
            objEvent = new cmsEventBL().Select(objEvent);
            txtTitle.Text = objEvent.Title;
            txtDescription.Text = objEvent.Description;
            chkIsPublish.Checked = objEvent.IsPublish;
            try
            {
                cboParent.Value = objEvent.CategoryID.ToString();

                txtOrderID.Text = objEvent.OrderID.ToString();
            }
            catch { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initObject();
            if (objEvent.CategoryID <= 0)
            {
                objEvent.CreateDate = DateTime.Now;
                objEvent.UserCreate = int.Parse(Session["UserID"].ToString());
                new cmsEventBL().Insert(objEvent);
            }
            else
            {
                new cmsEventBL().Update(objEvent);
            }
            Functions.Alert("Cập nhật thành công!", "Default.aspx?Page=ListEvent");
        }

        private void initObject()
        {
            objEvent.Title = txtTitle.Text;
            objEvent.Description = txtDescription.Text;
            objEvent.IsPublish = chkIsPublish.Checked;
            objEvent.CreateDate = DateTime.Now;
            objEvent.UserCreate = int.Parse(Session["UserID"].ToString());

            objEvent.OrderID = int.Parse(txtOrderID.Text);

            objEvent.CategoryID = int.Parse(cboParent.Value.ToString());
        }
    }
}