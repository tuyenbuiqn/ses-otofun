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

namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucAddMultiImg : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.ddlDatabinder(ddlCate, cmsCategoryDO.CATEGORYID_FIELD, cmsCategoryDO.TITLE_FIELD, new cmsCategoryBL().SelectAll());
            Functions.ddlDatabinder(ddlSlide, cmsSlideDO.SLIDEID_FIELD, cmsSlideDO.TITLE_FIELD, new cmsSlideBL().SelectAll());
            Functions.ddlDatabinder(ddlArticle, cmsArticleDO.ARTICLEID_FIELD, cmsArticleDO.TITLE_FIELD, new cmsArticleBL().SelectAll());
            Functions.ddlDatabinder(ddlAlbum, cmsAlbumDO.ALBUMID_FIELD, cmsAlbumDO.TITLE_FIELD, new cmsAlbumBL().SelectAll());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int AlbumID = int.Parse(ddlAlbum.SelectedValue.ToString());
            int SlideID = int.Parse(ddlSlide.SelectedValue.ToString());
            int CateID = int.Parse(ddlCate.SelectedValue.ToString());
            int ArticleID = int.Parse(ddlArticle.SelectedValue.ToString());
            initObject(fuImage1, txtTitle1.Text, AlbumID,SlideID,ArticleID,CateID);
            initObject(fuImage2, txtTitle2.Text, AlbumID, SlideID, ArticleID, CateID);
            initObject(fuImage3, txtTitle3.Text, AlbumID, SlideID, ArticleID, CateID);
            initObject(fuImage4, txtTitle4.Text, AlbumID, SlideID, ArticleID, CateID);
            initObject(fuImage5, txtTitle5.Text, AlbumID, SlideID, ArticleID, CateID);
            Functions.Alert("Cập nhật thành công!", "Default.aspx?Page=ListImages");
        }

        private void initObject(FileUpload fulImage, string title, int AlbumID,int SlideID, int ArticleID, int CateID)
        {
            if (string.IsNullOrEmpty(title)) return;
            cmsImagesDO objImg = new cmsImagesDO();
            objImg.Title = title;
            objImg.AlbumID = AlbumID;

            if (!string.IsNullOrEmpty(fulImage.FileName))
                objImg.ImgFile = UploadFile(fulImage, title);

            new cmsImagesBL().Insert(objImg);
        }
        private string UploadFile(FileUpload fulImages, string title)
        {
            if (!string.IsNullOrEmpty(fulImages.FileName))
            {
                string FileName = string.Format("{0}{1}", Functions.Change_AV(title) + "-" + DateTime.Now.ToString("ddMMyyyyhhmmss"), fulImages.FileName.Substring(fulImages.FileName.LastIndexOf(".")));
                string SaveLocation = string.Format("{0}\\{1}", Server.MapPath("~/Media/"), FileName);
                fulImages.SaveAs(SaveLocation);
                return FileName;
            }
            return string.Empty;
        }
    }
}
