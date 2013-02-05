using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using Telerik.Web.UI;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace SES.CMS.ofeditor
{
    public partial class AddNews : System.Web.UI.Page
    {
        cmsArticleDO objArt = new cmsArticleDO();
        string sRef = "Default.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {


            txtDetail.CssFiles.Add("~/css/imageEdit.css");
            if (Session["UserID"] == null) Functions.Alert("Bạn cần đăng nhập!", "Login.aspx?ReturnURL=" + Request.Url.AbsolutePath);
            else
                if (!IsPostBack)
                {
                    if (Request.UrlReferrer != null)
                    {
                        sRef = Request.UrlReferrer.AbsoluteUri;
                        hdfRFR.Value = sRef;
                    }
                    int TypeID = -1;
                    if (Session["UserType"] != null) TypeID = int.Parse(Session["UserType"].ToString());
                    if (TypeID >= 2)
                    {
                        divTKAutoPost.Visible = true;
                        ddlHour.Items.Add(new ListItem("Hãy chọn", "-1"));
                        for (int id = 0; id <= 23; id++)
                        {
                            ddlHour.Items.Add(new ListItem(id.ToString() + "h", id.ToString()));
                        }
                        ddlMin.Items.Add(new ListItem("Hãy chọn", "-1"));
                        for (int id = 0; id <= 59; id++)
                        {
                            ddlMin.Items.Add(new ListItem(id.ToString() + "p", id.ToString()));
                        }
                    }
                    SES.CMS.AdminCP.Functions.ddlDatabinder(ddlEvent, cmsEventDO.EVENTID_FIELD, cmsEventDO.TITLE_FIELD, new cmsEventBL().SelectAll());
                    if (Request.QueryString["ArticleID"] != null)
                    {

                        objArt.ArticleID = int.Parse(Request.QueryString["ArticleID"].ToString());
                        objArt = new cmsArticleBL().Select(objArt);
                        divHistory.Visible = true;
                        grvHistoryDataSource(objArt.ArticleID);
                        if (!CheckQuyenSuaBai(objArt)) SES.CMS.AdminCP.Functions.Alert("Bạn không có quyền sửa bài này", "Default.aspx");
                        else
                        {

                            if (TypeID == 1)
                            {
                                objArt.DangBienTap = true; // Lock editting
                                objArt.BTVEdit = int.Parse(Session["UserID"].ToString());
                                new cmsArticleBL().Update(objArt);
                            }


                            initForm();

                        }

                    }
                    else
                    {
                        divHistory.Visible = false;
                        BindRelatedNews("0", "0");
                    }
                    if (!Directory.Exists(Server.MapPath("~/Media/" + Session["UserID"].ToString() + "/")))
                        Directory.CreateDirectory(Server.MapPath("~/Media/" + Session["UserID"].ToString() + "/"));
                    txtDetail.ImageManager.ViewPaths = txtDetail.ImageManager.DeletePaths = new string[] { "~/Media/" + Session["UserID"].ToString() + "/" };
                    txtDetail.ImageManager.UploadPaths = new string[] { "~/Media/" + Session["UserID"].ToString() + "/" };



                }


        }
        protected void grvHistoryDataSource(int articleID)
        {
            grvHistory.DataSource = new cmsHistoryBL().SelectByArticeID(articleID);
            grvHistory.DataBind();
        }
        private bool CheckQuyenSuaBai(cmsArticleDO objA) // Của mình
        {
            int TypeID = -1;
            if (Session["UserType"] != null) TypeID = int.Parse(Session["UserType"].ToString());
            else return false;

            if (TypeID == 0)  //Nếu là PV --> Chỉ sửa các bài (Nháp(0) + Trả lại PV(5))
            {
                if ((objA.UserCreate == int.Parse(Session["UserID"].ToString()))) //Bài mình viết 
                {
                    if (objA.TrangThai == 0 || objA.TrangThai == 5) return true;
                }
                else return false;
            }
            else if (TypeID == 1)  //Nếu là BTV --> Chỉ sửa các bài (Nháp(0) + Trả lại BTV(4) + Cần b tập)
            {
                if ((objA.UserCreate == int.Parse(Session["UserID"].ToString()))) //Bài mình viết 
                {
                    if (objA.TrangThai == 0 || objA.TrangThai == 4) return true; // đang nháp hoặc bị trả lại BTV
                }
                else //Bài người khác viết
                {
                    if (objA.TrangThai == 4 || objA.TrangThai == 1) // Bị trả lại BTV hoặc Chờ BTV
                    {
                        //Nếu đang editting bởi mình
                        if (objA.BTVEdit == int.Parse(Session["UserID"].ToString()))
                            return true;
                        else return false; // Ko thì cũng k cho sửa
                    }
                }
            }
            else if (TypeID == 2 || TypeID == 3)  //Nếu là Thư ký --> thoải mái
            {
                return true;

            }


            return false;

        }
        private void BindRelatedNews(string RelatedNews1, string RelatedNews2)
        {
            RadGrid1.DataSource = new cmsArticleBL().GetListMultiID(RelatedNews1);
            RadGrid1.DataBind();
            RadGrid2.DataSource = new cmsArticleBL().GetListMultiID(RelatedNews2);
            RadGrid2.DataBind();
        }

        private void initForm()
        {

            objArt = new cmsArticleBL().Select(objArt);
            txtTitle.Text = objArt.Title;
            txtDescription.Text = objArt.Description;

            txtAuthor.Text = objArt.Author;
            txtDetail.Content = objArt.ArticleDetail;
            txtNote.Text = objArt.Note;
            ddlEvent.SelectedValue = objArt.EventID.ToString();
            if (!string.IsNullOrEmpty(objArt.ImageUrl))
            {
                hplImage.NavigateUrl = "~/Media/" + objArt.ImageUrl;
                hplImage.Visible = true;
            }
            if (!string.IsNullOrEmpty(objArt.Tags))
                if (objArt.Tags.Length > 2)
                    txtTags.Text = objArt.Tags.Substring(1, objArt.Tags.Length - 2);
            string sTinLienQuan1 = objArt.TinLienQuan1;
            if (sTinLienQuan1.Contains(",") && sTinLienQuan1.Length > 2)
                sTinLienQuan1 = sTinLienQuan1.Substring(1, sTinLienQuan1.Length - 1);

            string sTinLienQuan2 = objArt.TinLienQuan2;
            if (sTinLienQuan2.Contains(",") && sTinLienQuan2.Length > 2)
                sTinLienQuan2 = sTinLienQuan2.Substring(1, sTinLienQuan2.Length - 1);
            hdfID1.Value = objArt.TinLienQuan1;
            hdfID2.Value = objArt.TinLienQuan2;
            //   BindRelatedNews(objArt.TinLienQuan1, objArt.TinLienQuan2);
            BindRelatedNews(sTinLienQuan1, sTinLienQuan2);

            if ((objArt.ThoiGianXuatBan > new DateTime(1950, 01, 01)))
            {
                if (objArt.IsWaitingPublish) chkCho.Checked = true;
                dtNgayXB.SelectedDate = objArt.ThoiGianXuatBan.Date;
                ddlHour.SelectedValue = objArt.ThoiGianXuatBan.Hour.ToString();
                ddlMin.SelectedValue = objArt.ThoiGianXuatBan.Minute.ToString();
            }
            else
            {
                dtNgayXB.SelectedDate = objArt.CreateDate.Date;
                ddlHour.SelectedValue = objArt.CreateDate.Hour.ToString();
                ddlMin.SelectedValue = objArt.CreateDate.Minute.ToString();
            }


            if (objArt.TrangThai == 3) chkCho.Enabled = false;


        }

        protected void RadComboBox1_Init(object sender, EventArgs e)
        {
            RadComboBox objCombo = ((RadComboBox)sender);
            RadTreeView treeView = (RadTreeView)objCombo.Items[0].FindControl("RadTreeView1");
            if (null != treeView)
            {
                treeView.DataTextField = "Title";
                treeView.DataFieldID = "CategoryID";
                treeView.DataValueField = "CategoryID";

                treeView.DataFieldParentID = "ParentCID";
                treeView.DataSource = new cmsCategoryBL().SelectAll();
                treeView.DataBind();
                treeView.ExpandAllNodes();

                //if (Request.QueryString["ArticleID"] != null)
                //{
                //    int ArtID = int.Parse(Request.QueryString["ArticleID"].ToString());
                //    cmsArticleDO objA = new cmsArticleBL().Select(new cmsArticleDO { ArticleID = ArtID });
                //    DataTable dtCat = new cmsCategoryBL().GetByArticleID(objA.ArticleID);
                //    for (int i = 0; i < treeView.GetAllNodes().Count; i++) // lặp toàn bộ node
                //    {

                //        foreach (DataRow dr in dtCat.Rows) // lặp các CatID lấy được
                //        {
                //            if (treeView.GetAllNodes()[i].Value == dr[cmsArticleCategoryDO.CATEGORYID_FIELD].ToString()) // Nếu node = catID thì check
                //            {
                //                treeView.GetAllNodes()[i].Checked = true;
                //            }
                //            else continue;
                //        }

                //    }

                //}
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            cmsHistoryDO objHistory = new cmsHistoryDO();
            objHistory.HistoryTime = DateTime.Now;
            objHistory.IP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            objHistory.UserID = int.Parse(Session["UserID"].ToString());
            if (chkCho.Checked)
            {
                if (!dtNgayXB.SelectedDate.HasValue)
                {
                    lblError.Visible = true;
                    lblError.Text = "Chưa chọn ngày giờ xuất bản !";
                    return;
                }
                if (ddlHour.SelectedIndex <= 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "Chưa chọn ngày giờ  xuất bản !";
                    return;

                }
            }
            initObject();
            int aid = objArt.ArticleID;
            RadTreeView rtv = (RadTreeView)RadComboBox1.Items[0].FindControl("RadTreeView1");
            if (objArt.ArticleID <= 0)
            {
                ////thêm mới
                ////Nếu là Phóng viên ko cần xét
                //int UTypeID = int.Parse(Session["UserType"].ToString());
                //if (UTypeID == 1) objArt.TrangThai = 1; // BTV
                //if (UTypeID == 1) objArt.TrangThai = 2; // BTV

                objArt.CreateDate = DateTime.Now;
                objArt.UserCreate = int.Parse(Session["UserID"].ToString());
                int TypeID = -1;
                if (Session["UserType"] != null) TypeID = int.Parse(Session["UserType"].ToString());
                if (TypeID == 1)
                {
                    objArt.BTVEdit = int.Parse(Session["UserID"].ToString());
                    objArt.ThoiGianGui = DateTime.Now;

                }
                else if (TypeID == 2)
                {
                    objArt.BTVEdit = int.Parse(Session["UserID"].ToString());
                    objArt.ThuKyEdit = objArt.BTVEdit;
                    if (chkCho.Checked)
                    {
                        objArt.IsWaitingPublish = true;
                        DateTime dt = Convert.ToDateTime(dtNgayXB.SelectedDate);
                        objArt.ThoiGianXuatBan = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
                    }
                }

                aid = new cmsArticleBL().Insert(objArt);
                objHistory.ArticleID = aid;
                objHistory.Action = 1;//Tạo bai viet
                objHistory.Contents = "User: " + Session["Username"] + "Tạo bài viết: <b>" + txtTitle.Text + "</b>";
                new cmsHistoryBL().Insert(objHistory);
                foreach (RadTreeNode n in rtv.CheckedNodes)
                {
                    int oid = int.Parse(((DropDownList)n.FindControl("ddl")).SelectedValue);
                    cmsArticleCategoryDO o = new cmsArticleCategoryDO { ArticleID = aid, CategoryID = int.Parse(n.Value), OrderID = oid };
                    new cmsArticleCategoryBL().Insert(o);

                }

            }
            else
            {
                // Lưu thì có giữ lock edit ko ????????????????????????????????????????

                new cmsArticleBL().Update(objArt);
                objHistory.ArticleID = objArt.ArticleID;
                objHistory.Action = 2;//Sửa bài viết
                objHistory.Contents = "User: " + Session["Username"] + "Tạo bài viết: <b>" + objArt.Title + "</b>";
                new cmsHistoryBL().Insert(objHistory);
                new cmsArticleCategoryBL().DeleteByArticleID(objArt.ArticleID);

                foreach (RadTreeNode n in rtv.CheckedNodes)
                {
                    int oid = int.Parse(((DropDownList)n.FindControl("ddl")).SelectedValue);
                    cmsArticleCategoryDO o = new cmsArticleCategoryDO { ArticleID = aid, CategoryID = int.Parse(n.Value), OrderID = oid };
                    new cmsArticleCategoryBL().Insert(o);

                }

            }
            SES.CMS.AdminCP.Functions.Alert("Cập nhật thành công!", hdfRFR.Value);
        }
        public string FetchLinksFromSource(string htmlSource)
        {
            string s = "";
            List<Uri> links = new List<Uri>();
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
            MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;
                s = s + "*" + href;
            }
            string ms = "";
            if (!string.IsNullOrEmpty(s)) ms = s.Substring(1);
            return ms;
        }

        private void initObject()
        {
            if (Request.QueryString["ArticleID"] != null)
            {
                objArt.ArticleID = int.Parse(Request.QueryString["ArticleID"].ToString());
            }
            objArt = new cmsArticleBL().Select(objArt);
            objArt.Title = txtTitle.Text;
            objArt.Description = txtDescription.Text;
            objArt.DescHome = FetchLinksFromSource(txtDetail.Content);
            objArt.Author = txtAuthor.Text;
            objArt.ArticleDetail = txtDetail.Content;
            objArt.Tags = "," + txtTags.Text + ",";
            objArt.EventID = int.Parse(ddlEvent.SelectedValue);
            objArt.TinLienQuan1 = hdfID1.Value;
            objArt.TinLienQuan2 = hdfID2.Value;
            objArt.Note = txtNote.Text;

            if (!string.IsNullOrEmpty(fuImg.FileName))
                objArt.ImageUrl = UploadFile(fuImg);

            int TypeID = -1;
            if (Session["UserType"] != null) TypeID = int.Parse(Session["UserType"].ToString());
            if (TypeID == 2)
            {
                if (chkCho.Checked)
                {
                    objArt.IsWaitingPublish = true;
                    DateTime dt = Convert.ToDateTime(dtNgayXB.SelectedDate);
                    objArt.ThoiGianXuatBan = new DateTime(dt.Year, dt.Month, dt.Day, int.Parse(ddlHour.SelectedValue), int.Parse(ddlMin.SelectedValue), 0);
                }
            }

        }

        private string UploadFile(FileUpload fulImage)
        {
            if (!string.IsNullOrEmpty(fulImage.FileName))
            {
                string FileName = string.Format("{0}{1}", SES.CMS.AdminCP.Functions.Change_AV(txtTitle.Text) + "-" + DateTime.Now.ToString("ddMMyyyyhhmmss"), fulImage.FileName.Substring(fulImage.FileName.LastIndexOf(".")));
                string SaveLocation = string.Format("{0}\\{1}", Server.MapPath("~/Media/"), FileName);
                fulImage.SaveAs(SaveLocation);
                return FileName;
            }
            return string.Empty;
        }

        protected void RadTreeView1_NodeDataBound(object sender, RadTreeNodeEventArgs e)
        {
            if (Request.QueryString["ArticleID"] != null)
            {
                int ArtID = int.Parse(Request.QueryString["ArticleID"].ToString());
                cmsArticleDO objA = new cmsArticleBL().Select(new cmsArticleDO { ArticleID = ArtID });
                DataTable dtCat = new cmsCategoryBL().GetByArticleID(objA.ArticleID);


                foreach (DataRow dr in dtCat.Rows) // lặp các CatID lấy được
                {
                    if (e.Node.Value == dr[cmsArticleCategoryDO.CATEGORYID_FIELD].ToString()) // Nếu node = catID thì check
                    {
                        e.Node.Checked = true;
                        ((DropDownList)e.Node.FindControl("ddl")).SelectedValue = dr[cmsArticleCategoryDO.ORDERID_FIELD].ToString();
                    }
                    else continue;
                }



            }
        }

    }
}