using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;

namespace SES.CMS.ofeditor
{
    public partial class Event : System.Web.UI.Page
    {
        cmsEventDO objEvent = new cmsEventDO();
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
                    Functions.DevCboDatabinder(cboParent, new cmsCategoryBL().SelectAll(), cmsCategoryDO.TITLE_FIELD, cmsCategoryDO.CATEGORYID_FIELD);
                    if (Request.QueryString["EventID"] != null)
                    {
                        objEvent.EventID = int.Parse(Request.QueryString["EventID"].ToString());
                        initForm();
                    }
                }
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
            Functions.Alert("Cập nhật thành công!", "Events.aspx");
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