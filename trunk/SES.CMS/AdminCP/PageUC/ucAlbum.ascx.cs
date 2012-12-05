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
using System.Security.Cryptography;

namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucAlbum : System.Web.UI.UserControl
    {
        cmsAlbumDO objArt = new cmsAlbumDO();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Ultility.ddlDatabinder(cboCategory, "CategoryID", "Title", new cmsCategoryBL().SelectAll());
            cboCategory.Items.Insert(0, "Chọn tất cả -----------");
           
            if (Request.QueryString["AlbumID"] != null)
            {
                objArt.AlbumID = int.Parse(Request.QueryString["AlbumID"].ToString());
                initForm();
            }
            
        }

        private void initForm()
        {
            objArt = new cmsAlbumBL().Select(objArt);
            txtTitle.Text = objArt.Title;
            txtDescription.Text = objArt.Description;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            initObject();
            if (objArt.AlbumID <= 0)
            {
                new cmsAlbumBL().Insert(objArt);
            }
            else
            {
                new cmsAlbumBL().Update(objArt);
            }
            Functions.Alert("Cập nhật thành công!", "Default.aspx?Page=ListAlbum");
        }
        private void initObject()
        {
            objArt.Title = txtTitle.Text;
            objArt.Description = txtDescription.Text;
        }

        private string UploadFile(FileUpload fulAlbum)
        {
            if (!string.IsNullOrEmpty(fulAlbum.FileName))
            {

                string FileName = string.Format("{0}{1}", Functions.Change_AV(txtTitle.Text) + "-" + DateTime.Now.ToString("ddMMyyyyhhmmss") + SecureRandom().ToString(), fulAlbum.FileName.Substring(fulAlbum.FileName.LastIndexOf(".")));
                string SaveLocation = string.Format("{0}\\{1}", Server.MapPath("~/Media/"), FileName);
                fulAlbum.SaveAs(SaveLocation);
                return FileName;
            }
            return string.Empty;
        }
        static public int SecureRandom()
        {
            RNGCryptoServiceProvider secureRandom = new RNGCryptoServiceProvider();
            byte[] randBytes = new byte[4];
            secureRandom.GetNonZeroBytes(randBytes);
            return (BitConverter.ToInt32(randBytes, 0));
        }
    }
}