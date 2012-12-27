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

namespace SES.CMS.ofeditor
{
    public partial class AddNews : System.Web.UI.Page
    {
        cmsArticleDO objArt = new cmsArticleDO();
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {

                SES.CMS.AdminCP.Functions.ddlDatabinder(ddlEvent, cmsEventDO.EVENTID_FIELD, cmsEventDO.TITLE_FIELD, new cmsEventBL().SelectAll());
                if (Request.QueryString["ArticleID"] != null)
                {
                    objArt.ArticleID = int.Parse(Request.QueryString["ArticleID"].ToString());
                    objArt = new cmsArticleBL().Select(objArt);
                    
                    if (!CheckQuyenSuaBai(objArt)) SES.CMS.AdminCP.Functions.Alert("Bạn không có quyền sửa bài này", "Default.aspx");
                    else
                    {
                        objArt.DangBienTap = true; // Lock editting
                        objArt.BTVEdit = int.Parse(Session["UserID"].ToString());
                        new cmsArticleBL().Update(objArt);
                        initForm(); 
                    
                    }
                    
                }
                else
                {
                    BindRelatedNews("0", "0");
                }

            }


        }

        private bool CheckQuyenSuaBai(cmsArticleDO objA) // Của mình
        {
            int TypeID = -1;
            if (Session["UserType"] != null) TypeID = int.Parse(Session["UserType"].ToString());
            else return false;

            if (TypeID == 0)  //Nếu là PV --> Chỉ sửa các bài (Nháp(0) + Trả lại PV(4))
            {
                if ((objA.UserCreate == int.Parse(Session["UserID"].ToString()))) //Bài mình viết 
                {
                    if (objA.TrangThai == 0 || objA.TrangThai == 4) return true;
                }
                else return false;
            }
            else if (TypeID == 1)  //Nếu là BTV --> Chỉ sửa các bài (Nháp(0) + Trả lại BTV(4) + Cần b tập)
            {
                if ((objA.UserCreate == int.Parse(Session["UserID"].ToString()))) //Bài mình viết 
                {
                    if (objA.TrangThai == 0 || objA.TrangThai == 5) return true; // đang nháp hoặc bị trả lại BTV
                }
                else //Bài người khác viết
                {
                    if (objA.TrangThai == 5 || objA.TrangThai == 2) // Bị trả lại BTV hoặc Chờ BTV
                    {
                        //Nếu đang ko editing hoặc Đang editting bởi mình
                        if((!objA.DangBienTap)||(objA.BTVEdit==int.Parse(Session["UserID"].ToString())))
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
            txtDetail.Content = objArt.ArticleDetail;
            ddlEvent.SelectedValue = objArt.EventID.ToString();
            if (!string.IsNullOrEmpty(objArt.ImageUrl))
            {
                hplImage.NavigateUrl = "~/Media/" + objArt.ImageUrl;
                hplImage.Visible = true;
            }
            if (!string.IsNullOrEmpty(objArt.Tags))
                if (objArt.Tags.Length > 2)
                    txtTags.Text = objArt.Tags.Substring(1, objArt.Tags.Length - 2);
            hdfID1.Value = objArt.TinLienQuan1;
            hdfID2.Value = objArt.TinLienQuan2;
            BindRelatedNews(objArt.TinLienQuan1, objArt.TinLienQuan2);

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
                aid = new cmsArticleBL().Insert(objArt);

                
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
                //Sửa thì trạng thái giữ nguyên.
                
                     //* Lấy toàn bộ bản ghi cũ (id,aid,cid,oid) Theo Aid
                     DataTable dt = new cmsArticleCategoryBL().SelectByArticleID(aid);
                     List<cmsArticleCategoryDO> lstCur = new cmsArticleBL().ConvertTo<cmsArticleCategoryDO>(dt);
                     //* Lấy bản ghi mới (aid,cid,oid) Theo checked
                     List<cmsArticleCategoryDO> lstNewACID = new List<cmsArticleCategoryDO>();
                     foreach (RadTreeNode n in rtv.CheckedNodes)
                     {
                         int oid = int.Parse(((DropDownList)n.FindControl("ddl")).SelectedValue);
                         cmsArticleCategoryDO o = new cmsArticleCategoryDO { ArticleID = aid, CategoryID = int.Parse(n.Value), OrderID = oid };
                         lstNewACID.Add(o);
                     }
                     //* Lưu các bản ghi không có trong list mới để xóa
                     List<cmsArticleCategoryDO> lstDel = new List<cmsArticleCategoryDO>();
                    List<cmsArticleCategoryDO> lstUpdate = new List<cmsArticleCategoryDO>();
                    List<cmsArticleCategoryDO> lstInsert = new List<cmsArticleCategoryDO>();
                     foreach(cmsArticleCategoryDO cur in lstCur)
                     {
                         bool isCurr = false;
                         foreach (cmsArticleCategoryDO nw in lstNewACID) // lặp 1 lượt nếu trùng lưu, nếu ko lưu ra del
                         {
                             if (cur.CategoryID == nw.CategoryID) // Nếu trùng CID, (AID đã trùng rồi) ---> update
                             {
                                 cmsArticleCategoryDO ud = new cmsArticleCategoryDO{ArticleID = nw.ArticleID,CategoryID = nw.CategoryID, ArticleCategoryID = cur.ArticleCategoryID, OrderID = nw.OrderID};
                                 lstUpdate.Add(ud);
                                 isCurr = true;
                                 continue;
                             }
                            
                         }
                         if (!isCurr) lstDel.Add(cur); //lưu ra del
                     }
                     
       
                     // Thực hiện truy vấn
                     foreach (cmsArticleCategoryDO del in lstDel)
                     {
                         new cmsArticleCategoryBL().Delete(del);  ////////////////// Xóa
                     }

                     foreach (cmsArticleCategoryDO upd in lstUpdate)
                     {
                         new cmsArticleCategoryBL().Update(upd);  ////////////////// Sửa
                     }

                     foreach (cmsArticleCategoryDO ins in lstNewACID)
                     {
                         bool saved = false;
                         foreach (cmsArticleCategoryDO inud in lstUpdate)
                         {
                             if ((inud.CategoryID != ins.CategoryID))
                             {
                                 saved = true;
                             }
                             
                         }
                         if(saved) new cmsArticleCategoryBL().Insert(ins);  ////////////////// Thêm mới
                     }

            }
            SES.CMS.AdminCP.Functions.Alert("Cập nhật thành công!", "Default.aspx?Page=ListArticle");
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
            objArt.ArticleDetail = txtDetail.Content;
            objArt.Tags = "," + txtTags.Text + ",";
            objArt.EventID = int.Parse(ddlEvent.SelectedValue);
            objArt.TinLienQuan1 = hdfID1.Value;
            objArt.TinLienQuan2 = hdfID2.Value;
            

            if (!string.IsNullOrEmpty(fuImg.FileName))
                objArt.ImageUrl = UploadFile(fuImg);
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