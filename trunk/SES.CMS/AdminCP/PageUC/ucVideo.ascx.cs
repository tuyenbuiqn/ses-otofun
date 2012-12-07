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
    public partial class ucVideo : System.Web.UI.UserControl
    {
        cmsVideoDO objVideo = new cmsVideoDO();
        cmsCategoryDO objCat = new cmsCategoryDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.ddlDatabinder(ddlEvent, cmsEventDO.EVENTID_FIELD, cmsEventDO.TITLE_FIELD, new cmsEventBL().SelectAll());
            Functions.ddlDatabinder(ddlArticle, cmsArticleDO.ARTICLEID_FIELD, cmsArticleDO.TITLE_FIELD, new cmsArticleBL().SelectAll());
            Functions.ddlDatabinder(ddlAlbum, cmsAlbumDO.ALBUMID_FIELD, cmsAlbumDO.TITLE_FIELD, new cmsAlbumBL().SelectAll());
            Functions.DevCboDatabinder(cboParent, new cmsCategoryBL().SelectAll(), cmsCategoryDO.TITLE_FIELD, cmsCategoryDO.CATEGORYID_FIELD);
            if (Request.QueryString["CategoryID"] != null)
            {
                objVideo.CategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
                initForm();
            }
        }

        private void initForm()
        {
            objVideo = new cmsVideoBL().Select(objVideo);
            txtTitle.Text = objVideo.Title;
            txtDescription.Text = objVideo.Description;
            chkIsHomePage.Checked = objVideo.IsHomepage;
            chkIsPublish.Checked = objVideo.IsPublish;
            chkIsNew.Checked = objVideo.IsNew;
            chkMostView.Checked = objVideo.IsMostView;

            //if (objVideo.CategoryTypeID == 1) rdoNWC.Checked = true;
            //else if (objVideo.CategoryTypeID == 2) rdoNW.Checked = true;
            //else if (objVideo.CategoryTypeID == 3) rdoBC.Checked = true;
            //else if (objVideo.CategoryTypeID == 4) rdoB.Checked = true;
            //else if (objVideo.CategoryTypeID == 5) rdoCT.Checked = true;


            int catID = objVideo.CategoryID;
            objCat.CategoryID = catID;

            if (catID == 0) chkIsTop.Checked = true;
            else
            {
                chkIsTop.Checked = false;
                cboParent.Value = catID.ToString();
            }
            txtOrderID.Text = objVideo.OrderID.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initObject();
            if (objVideo.VideoID <= 0)
            {
                objVideo.CreateDate = DateTime.Now;
                new cmsVideoBL().Insert(objVideo);
            }
            else
            {
                new cmsVideoBL().Update(objVideo);
            }
            Functions.Alert("Cập nhật thành công!", "Default.aspx?Page=ListVideo");
        }

        private void initObject()
        {
            int catID = objVideo.CategoryID;
            objCat.CategoryID = catID;

            objVideo.Title = txtTitle.Text;
            objVideo.Description = txtDescription.Text;
            objVideo.IsHomepage = chkIsHomePage.Checked;
            objVideo.IsPublish = chkIsPublish.Checked;
            objVideo.IsMostView = chkMostView.Checked;
            objVideo.IsNew = chkIsNew.Checked;
            objVideo.CreateDate = DateTime.Now;
            //if (rdoNWC.Checked) objVideo.CategoryTypeID = 1;
            //else if (rdoNW.Checked) objVideo.CategoryTypeID = 2;
            //else if (rdoBC.Checked) objVideo.CategoryTypeID = 3;
            //else if (rdoB.Checked) objVideo.CategoryTypeID = 4;
            //else if (rdoCT.Checked) objVideo.CategoryTypeID = 5;

            objVideo.OrderID = int.Parse(txtOrderID.Text);
            if (chkIsTop.Checked) objCat.ParentID = 0;
            else
                objCat.ParentID = int.Parse(cboParent.Value.ToString());
        }

        private string UploadFile(FileUpload fulImage)
        {
            if (!string.IsNullOrEmpty(fulImage.FileName))
            {
                string FileName = string.Format("{0}{1}", Functions.Change_AV(txtTitle.Text) + "-" + DateTime.Now.ToString("ddMMyyyyhhmmss"), fulImage.FileName.Substring(fulImage.FileName.LastIndexOf(".")));
                string SaveLocation = string.Format("{0}\\{1}", Server.MapPath("~/Media/"), FileName);
                fulImage.SaveAs(SaveLocation);
                return FileName;
            }
            return string.Empty;
        }
    }
}