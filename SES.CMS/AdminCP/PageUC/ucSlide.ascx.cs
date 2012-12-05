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
    public partial class ucSlide : System.Web.UI.UserControl
    {
        cmsSlideDO objSlide = new cmsSlideDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.ddlDatabinder(ddlSlideCate, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectAll());
            Functions.ddlDatabinder(ddlSlideArt, cmsArticleDO.ARTICLEID_FIELD, cmsArticleDO.TITLE_FIELD, new cmsArticleBL().SelectAll());
            if (Request.QueryString["SlideID"] != null)
            {
                objSlide.SlideID = int.Parse(Request.QueryString["SlideID"].ToString());
                initForm();
            }
        }

        private void initForm()
        {
            objSlide = new cmsSlideBL().Select(objSlide);
            txtTitle.Text = objSlide.Title;
            txtDescription.Text = objSlide.Description;
            if (!string.IsNullOrEmpty(objSlide.SlideImg))
            {
                hplImage.Visible = true;
                hplImage.NavigateUrl = "~/Media/" + objSlide.SlideImg;
            }
            ddlSlideCate.SelectedValue = objSlide.CategoryID.ToString();
            txtOrder.Text = objSlide.OrderID.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initObject();
            if (objSlide.SlideID <= 0)
            {
                new cmsSlideBL().Insert(objSlide);
            }
            else
            {
                new cmsSlideBL().Update(objSlide);
            }
            Functions.Alert("Cập nhật thành công!", "Default.aspx?Page=ListSlide");
        }

        private void initObject()
        {
            objSlide.Title = txtTitle.Text;
            objSlide.Description = txtDescription.Text;
            if (!string.IsNullOrEmpty(fuImage.FileName))
                objSlide.SlideImg = UploadFile(fuImage);
            objSlide.OrderID = int.Parse(txtOrder.Text);
            objSlide.CategoryID = int.Parse(ddlSlideCate.SelectedValue);

        }
        private string UploadFile(FileUpload fulImages)
        {
            if (!string.IsNullOrEmpty(fulImages.FileName))
            {
                string FileName = string.Format("{0}{1}", Functions.Change_AV(txtTitle.Text) + "-" + DateTime.Now.ToString("ddMMyyyyhhmmss"), fulImages.FileName.Substring(fulImages.FileName.LastIndexOf(".")));
                string SaveLocation = string.Format("{0}\\{1}", Server.MapPath("~/Media/"), FileName);
                fulImages.SaveAs(SaveLocation);
                return FileName;
            }
            return string.Empty;
        }
    }
}