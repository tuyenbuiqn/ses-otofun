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
    public partial class ucArticleCategory : System.Web.UI.UserControl
    {
        cmsCategoryDO objCat = new cmsCategoryDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.DevCboDatabinder(cboParent, new cmsCategoryBL().SelectAll(), cmsCategoryDO.TITLE_FIELD, cmsCategoryDO.CATEGORYID_FIELD);
            if (Request.QueryString["CategoryID"] != null)
            {
                objCat.CategoryID = int.Parse(Request.QueryString["CategoryID"].ToString());
                initForm();
            }
        }

        private void initForm()
        {
            objCat = new cmsCategoryBL().Select(objCat);
            txtTitle.Text = objCat.Title;
            txtDescription.Text = objCat.Description;
            chkIsHomePage.Checked = objCat.IsHompage;
            chkIsPublish.Checked = !objCat.IsPublish;
            chkIsMenu.Checked = objCat.IsMenu;

            if (objCat.CategoryTypeID == 0) rdoNWC.Checked = true;
            else if (objCat.CategoryTypeID == 1) rdoNW.Checked = true;
            else if (objCat.CategoryTypeID == 2) rdoBC.Checked = true;
            else if (objCat.CategoryTypeID == 3) rdoB.Checked = true;
            else if (objCat.CategoryTypeID == 4) rdoCT.Checked = true;



            if (objCat.ParentID == 0) chkIsTop.Checked = true;
            else
            {
                chkIsTop.Checked = false;
                cboParent.Value = objCat.ParentID.ToString();
            }
            txtOrderID.Text = objCat.OrderID.ToString();
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initObject();
            if(objCat.CategoryID<=0)
            {
                objCat.CreateDate = DateTime.Now;
                objCat.UserCreate = int.Parse(Session["UserID"].ToString());
                new cmsCategoryBL().Insert(objCat);
            }
            else
            {
                new cmsCategoryBL().Update(objCat);
            }
            Functions.Alert("Cập nhật thành công!", "Default.aspx?Page=ListArticleCategory");
        }

        private void initObject()
        {
            objCat.Title = txtTitle.Text;
            objCat.Description = txtDescription.Text;
            objCat.IsHompage = chkIsHomePage.Checked;
            objCat.IsPublish = !chkIsPublish.Checked;
            objCat.IsMenu = chkIsMenu.Checked;
            if (rdoNWC.Checked) objCat.CategoryTypeID = 0;
            else if (rdoNW.Checked) objCat.CategoryTypeID = 1;
            else if (rdoBC.Checked) objCat.CategoryTypeID = 2;
            else if (rdoB.Checked) objCat.CategoryTypeID = 3;
            else if (rdoCT.Checked) objCat.CategoryTypeID = 4;

            objCat.OrderID = int.Parse(txtOrderID.Text);
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