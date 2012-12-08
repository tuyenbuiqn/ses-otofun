using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;
using System.Data;

namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucAdvertisement : System.Web.UI.UserControl
    {
        cmsAdvertisementDO objAdv = new cmsAdvertisementDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AdvertisementID"]))
            {
                int advID = int.Parse(Request.QueryString["AdvertisementID"].ToString());
                objAdv.AdvertisementID = advID;
                InitForm();
            }
        }

        protected void InitForm()
        {
            objAdv = new cmsAdvertisementBL().Select(objAdv);

            txtTitle.Text = objAdv.Title;
            txtOrderID.Text = objAdv.OrderID.ToString();
            txtAdvInfo.Text = objAdv.AdvInfo;
            txtAdvDetail.Text = objAdv.AdvDetail;

            chkIsPublish.Checked = objAdv.IsPublish;
            try
            {
                ddlPosition.SelectedValue = objAdv.Position;
                if (!string.IsNullOrEmpty(objAdv.Module))
                {
                    if (objAdv.Module.Length > 2)
                    {
                        string[] arrayModule = objAdv.Module.Split(',');
                        for (int i = 1; i < arrayModule.Length-1; i++)
                        {
                            for (int j = 0; j < chkLModule.Items.Count; j++)
                            {
                                if (chkLModule.Items[j].Value.Equals(arrayModule[i]))
                                {
                                    chkLModule.Items[j].Selected = true;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        protected void InitObject()
        {
            objAdv.Title = txtTitle.Text;
            objAdv.OrderID = int.Parse(txtOrderID.Text);
            objAdv.AdvInfo = txtAdvInfo.Text;
            objAdv.AdvDetail = txtAdvDetail.Text;

            objAdv.IsPublish = chkIsPublish.Checked;
            objAdv.Position = ddlPosition.SelectedValue;
            string sModule = ",";
            for (int i = 0; i < chkLModule.Items.Count; i++)
            {
                if (chkLModule.Items[i].Selected == true)
                {
                    sModule += chkLModule.Items[i].Value + ",";
                }
            }
            objAdv.Module = sModule;


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitObject();
            if (objAdv.AdvertisementID <= 0)
            {
                objAdv.CreateDate = DateTime.Now;
                objAdv.CreateUser = int.Parse(Session["UserID"].ToString());

                new cmsAdvertisementBL().Insert(objAdv);
                Ultility.Alert("Thêm mới thành công!","Default.aspx?Page=ListAdvertisement");
            }
            else
            {
                new cmsAdvertisementBL().Update(objAdv);
                Ultility.Alert("Cập nhật thành công!", "Default.aspx?Page=ListAdvertisement");
            }
           
        }
    }
}