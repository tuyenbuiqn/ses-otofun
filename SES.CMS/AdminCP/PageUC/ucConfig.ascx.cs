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
using System.IO;


namespace SES.CMS.WEB.AdminCP.PageUC
{
    public partial class ucConfig : System.Web.UI.UserControl
    {
        sysConfigDO objConfig = new sysConfigDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ConfigID"] != null)
            {
                objConfig.ConfigID = int.Parse(Request.QueryString["ConfigID"].ToString());
                initForm();
            }
        }

        private void initForm()
        {
            objConfig = new sysConfigBL().Select(objConfig);

            txtTitle.Text = objConfig.ConfigName;

            // Không sử dụng CKEditor
            if (objConfig.ConfigID == 1 || objConfig.ConfigID == 2 )
            {
                trDes.Visible = true;
                trSupport.Visible = false;
                txtDescription.Text = objConfig.ConfigValue;
            }
            //else if (objConfig.ConfigID == 4)
            //{
            //    trDes.Visible = false;
            //    trSupport.Visible = false;
            //    trPopup.Visible = true;
            //    txtTitle.Text = objConfig.ConfigName;
            //    if (!File.Exists("~/Media/contact.jpg"))
            //    {
            //        hplImage.Visible = true;
            //        hplImage.NavigateUrl = "~/Media/contact.jpg";
            //    }
            //}
            else if (objConfig.ConfigID == 5)
            {
                trDes.Visible = false;
                trSupport.Visible = false;
                trPopup.Visible = true;
                txtTitle.Text = objConfig.ConfigName;
                if (!File.Exists("~/Media/logo.jpg"))
                {
                    hplImage.Visible = true;
                    hplImage.NavigateUrl = "~/Media/logo.jpg";
                }
            }
            // Sử dụng CKEditor
            else if (objConfig.ConfigID == 3 || objConfig.ConfigID == 4)
            {
                trDes.Visible = false;
                trSupport.Visible = true;
                txtCK.Text = objConfig.ConfigValue;
            }

            else
            {
                trDes.Visible = false;
                trSupport.Visible = true;
                txtCK.Text = objConfig.ConfigValue;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initObject();
            if (objConfig.ConfigID <= 0)
            {
                new sysConfigBL().Insert(objConfig);
            }
            else
            {
                new sysConfigBL().Update(objConfig);
            }
            Functions.Alert("Cập nhật thành công!", "Default.aspx?Page=ListConfig");
        }

        private void initObject()
        {
            objConfig.ConfigName = txtTitle.Text;
            // Không sử dụng CKEditor
            if (objConfig.ConfigID == 1 || objConfig.ConfigID == 2)
            {
                objConfig.ConfigValue = txtDescription.Text;
            }
            // Sử dụng CKEditor
            else if (objConfig.ConfigID == 3 || objConfig.ConfigID == 4)
            {
                objConfig.ConfigValue = txtCK.Text;
            }
            else if (objConfig.ConfigID == 5)
            {
                UploadFile(fuImage);
            }
            else
            {
                objConfig.ConfigValue = txtCK.Text;
            }


        }
        private string UploadFile(FileUpload fulImages)
        {
            if (fulImages.HasFile)
            {
                string FileName = "contact.jpg";
                if (objConfig.ConfigID == 5)
                    FileName = "contact.jpg";
                else if (objConfig.ConfigID == 6)
                    FileName = "logo.jpg";

                string SaveLocation = string.Format("{0}\\{1}", Server.MapPath("~/Media/"), FileName);
                if (System.IO.File.Exists(SaveLocation))
                    System.IO.File.Delete(SaveLocation);
                fulImages.SaveAs(SaveLocation);
                return FileName;
            }
            return string.Empty;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Page=ListConfig");
        }
    }
}