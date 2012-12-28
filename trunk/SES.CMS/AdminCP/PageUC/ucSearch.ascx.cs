using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SES.CMS.BL;
using SES.CMS.DO;
using Telerik.Web.UI;

namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucSearch : System.Web.UI.UserControl
    {
        cmsHistoryDO objHtr = new cmsHistoryDO();

        private int _NumberItemPerPage = 20;

        public int NumberItemPerPage
        {
            get { return _NumberItemPerPage; }
            set { _NumberItemPerPage = value; }
        }

        int _PageIndex = 1;

        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdfPageIndex.Value = "0";
                lblPvCreate.Visible = false;
                ddlPvCreate.Visible = false;
                lblBtvEdit.Visible = false;
                ddlBtvEdit.Visible = false;
                lblTkApproved.Visible = false;
                ddlTkApproved.Visible = false;
                pnlListArticle.Visible = false;

                this.BindddlListStatus();
                this.BindddlPvCreate();
                this.BindddlBtvEdit();
                this.BindddlTkApproved();

                this.BindddlNumberItemPerPageData();

                this.chekRights();//Kiểm tra quyền để hiện thị control
            }
        }

        public void BindddlListStatus()
        {
            DataTable dtStatus = new DataTable("dtStatus");
            dtStatus.Columns.Add("Value", typeof(int));
            dtStatus.Columns.Add("Title", typeof(string));
            ddlListStatus.DataSource = dtStatus;
            ddlListStatus.DataTextField = "Title";
            ddlListStatus.DataValueField = "Value";
            ddlListStatus.DataBind();
            ddlListStatus.Items.Insert(0, new ListItem("---Chọn trạng thái---", "-1"));
            ddlListStatus.Items.Insert(1, new ListItem("Nháp", "0"));
            ddlListStatus.Items.Insert(2, new ListItem("Chờ biên tập", "1"));
            ddlListStatus.Items.Insert(3, new ListItem("Chờ xuất bản", "2"));
            ddlListStatus.Items.Insert(4, new ListItem("Xuất bản", "3"));
            ddlListStatus.Items.Insert(5, new ListItem("Viết lại", "4"));
            ddlListStatus.Items.Insert(6, new ListItem("Biên tập lại", "5"));
        }

        public void BindddlPvCreate()
        {
            if (Session["UserType"] != null)
            {
                string sRights = Session["UserType"].ToString();
                if (sRights == "0")
                {
                    int iUserId = int.Parse(Session["UserID"].ToString());
                    ddlPvCreate.DataSource = new sysUserBL().User_GetByPK(iUserId);
                    ddlPvCreate.DataTextField = "Username";
                    ddlPvCreate.DataValueField = "UserID";
                    ddlPvCreate.DataBind();
                }
                else
                {
                    ddlPvCreate.DataSource = new sysUserBL().SelectAll();
                    ddlPvCreate.DataTextField = "Username";
                    ddlPvCreate.DataValueField = "UserID";
                    ddlPvCreate.DataBind();
                    ddlPvCreate.Items.Insert(0, new ListItem("---Chọn PV viết bài---", "0"));
                }
            }
            else
            {
                ddlPvCreate.DataSource = new sysUserBL().SelectAll();
                ddlPvCreate.DataTextField = "Username";
                ddlPvCreate.DataValueField = "UserID";
                ddlPvCreate.DataBind();
                ddlPvCreate.Items.Insert(0, new ListItem("---Chọn PV viết bài---", "0"));
            }
            
        }

        public void BindddlBtvEdit()
        {
            if (Session["UserType"] != null)
            {
                string sRights = Session["UserType"].ToString();
                if (sRights == "1")
                {
                    int iUserId = int.Parse(Session["UserID"].ToString());
                    ddlBtvEdit.DataSource = new sysUserBL().User_GetByPK(iUserId);
                }
                else
                {
                    ddlBtvEdit.DataSource = new sysUserBL().SelectAll();
                }
            }
            else
            {
                ddlBtvEdit.DataSource = new sysUserBL().SelectAll();
            }
            ddlBtvEdit.DataTextField = "Username";
            ddlBtvEdit.DataValueField = "UserID";
            ddlBtvEdit.DataBind();
            ddlBtvEdit.Items.Insert(0, new ListItem("---Chọn BTV biên tập---", "0"));
        }

        public void BindddlTkApproved()
        {
            if (Session["UserType"] != null)
            {
                string sRights = Session["UserType"].ToString();
                if (sRights == "2")
                {
                    int iUserId = int.Parse(Session["UserID"].ToString());
                    ddlTkApproved.DataSource = new sysUserBL().User_GetByPK(iUserId);
                }
                else
                {
                    ddlTkApproved.DataSource = new sysUserBL().SelectAll();
                }
            }
            else
            {
                ddlTkApproved.DataSource = new sysUserBL().SelectAll();
            }
            ddlTkApproved.DataTextField = "Username";
            ddlTkApproved.DataValueField = "UserID";
            ddlTkApproved.DataBind();
            ddlTkApproved.Items.Insert(0, new ListItem("---Chọn TK phê duyệt---", "0"));
        }

        protected void BindddlNumberItemPerPageData()
        {
            if (ddlNumberItemPerPage != null)
            {
                for (int i = 5; i <= 50; i += 5)
                {
                    ddlNumberItemPerPage.Items.Add(new ListItem(Convert.ToString(i)));
                }
                ddlNumberItemPerPage.SelectedValue = NumberItemPerPage.ToString();
            }
        }

        protected void BindddlPageIndexData( DataTable dtArticle)
        {
            if (ddlPageIndex != null)
            {
                NumberItemPerPage = Int32.Parse(ddlNumberItemPerPage.SelectedValue);
                int countArticle = dtArticle.Rows.Count;
                if ((countArticle % NumberItemPerPage) == 0)
                {
                    PageIndex = countArticle / NumberItemPerPage;
                    lblTotalPages.Text = Convert.ToString(PageIndex);
                }
                else
                {
                    PageIndex = (countArticle / NumberItemPerPage) + 1;
                    lblTotalPages.Text = Convert.ToString(PageIndex);
                }
                ddlPageIndex.Items.Clear();
                for (int i = 1; i <= PageIndex; i++)
                {
                    ddlPageIndex.Items.Add(new ListItem(Convert.ToString(i)));
                }
                //PageIndex = 1;
            }
        }

        public void BindrptListArticle()
        {
            DataTable dtArticle = new DataTable("dtArticle");
            string lstCategoryID= "-1";
            DateTime ArticleSearchDateStart = new DateTime(1900, 1, 1);
            DateTime ArticleSearchDateEnd= new DateTime(2100, 1, 1);
            string Keyw="";
            string iListStatus = "";
            string iPvCreate = "";
            string iBtvEdit = "";
            string iTkApproved = "";
            if (hdfKey.Value != null)
            {
                Keyw = hdfKey.Value.ToString();
            }
            if (hdfCategory.Value != "-1")
            {
                lstCategoryID = hdfCategory.Value.ToString();
            }
            if (hdfListStatus.Value != "")
            {
                iListStatus = hdfListStatus.Value.ToString();
            }
            if (hdfPvCreate.Value != "")
            {
                iPvCreate = hdfPvCreate.Value.ToString();
            }
            if (hdfBtvEdit.Value != "")
            {
                iBtvEdit = hdfBtvEdit.Value.ToString();
            }
            if (hdfTkApproved.Value != "")
            {
                iTkApproved = hdfTkApproved.Value.ToString();
            }
            if (hdfRadDatePickerStart.Value != "")
            {
                ArticleSearchDateStart = Convert.ToDateTime(hdfRadDatePickerStart.Value.ToString());
            }
            if (hdfRadDatePickerEnd.Value != "")
            {
                ArticleSearchDateEnd = Convert.ToDateTime(hdfRadDatePickerEnd.Value.ToString());
            }

            dtArticle = new cmsArticleBL().Article_SearchAdvanced(lstCategoryID, ArticleSearchDateStart, ArticleSearchDateEnd, Keyw, iListStatus, iPvCreate, iBtvEdit, iTkApproved);

            this.BindddlPageIndexData(dtArticle);
            ddlPageIndex.SelectedValue = Convert.ToString(int.Parse(hdfPageIndex.Value) + 1);
            if (dtArticle.Rows.Count > 0)
            {
                pnlListArticle.Visible = true;
            }
            else
            {
                pnlListArticle.Visible = false;
            }

            this.BindrptListArticleOnPage(dtArticle);
        }

        public void BindrptListArticleOnPage(DataTable dtArticle)
        {
            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = dtArticle.DefaultView;
            objPds.AllowPaging = true;
            objPds.PageSize = NumberItemPerPage;
            objPds.CurrentPageIndex = Int32.Parse(hdfPageIndex.Value);

            rptListArticle.DataSource = objPds;
            rptListArticle.DataBind();
        }

        public void chekRights()
        {
            if (Session["UserType"] != null)
            {
                string sRights = Session["UserType"].ToString();
                if (sRights == "3")
                {
                    lblPvCreate.Visible = true;
                    ddlPvCreate.Visible = true;
                    lblBtvEdit.Visible = true;
                    ddlBtvEdit.Visible = true;
                    lblTkApproved.Visible = true;
                    ddlTkApproved.Visible = true;
                }
                if (sRights == "2")
                {
                    lblPvCreate.Visible = true;
                    ddlPvCreate.Visible = true;
                    lblBtvEdit.Visible = true;
                    ddlBtvEdit.Visible = true;
                    lblTkApproved.Visible = true;
                    ddlTkApproved.Visible = true;
                }
                if (sRights == "1")
                {
                    lblPvCreate.Visible = true;
                    ddlPvCreate.Visible = true;
                    lblBtvEdit.Visible = true;
                    ddlBtvEdit.Visible = true;
                    lblTkApproved.Visible = false;
                    ddlTkApproved.Visible = false;
                }
                if (sRights == "0")
                {
                    lblPvCreate.Visible = true;
                    ddlPvCreate.Visible = true;
                    lblBtvEdit.Visible = false;
                    ddlBtvEdit.Visible = false;
                    lblTkApproved.Visible = false;
                    ddlTkApproved.Visible = false;
                }
            }
        }

        protected void rcbCat_Init(object sender, EventArgs e)
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
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            hdfKey.Value = "";
            hdfCategory.Value = "";
            hdfListStatus.Value = "";
            hdfPvCreate.Value = "";
            hdfBtvEdit.Value = "";
            hdfTkApproved.Value = "";
            hdfRadDatePickerStart.Value = "";
            hdfRadDatePickerEnd.Value = "";

            if (txtKey.Text != "")
            {
                hdfKey.Value = txtKey.Text;
            }
            if (ddlListStatus.SelectedValue != "-1")
            {
                hdfListStatus.Value = ddlListStatus.SelectedValue.ToString();
            }
            if (ddlPvCreate.SelectedValue != "0")
            {
                hdfPvCreate.Value = ddlPvCreate.SelectedValue.ToString();
            }
            if (ddlBtvEdit.SelectedValue != "0")
            {
                hdfBtvEdit.Value = ddlBtvEdit.SelectedValue.ToString();
            }
            if (ddlTkApproved.SelectedValue != "0")
            {
                hdfTkApproved.Value = ddlTkApproved.SelectedValue.ToString();
            }
            if (RadDatePickerStart.SelectedDate.HasValue)
            {
                hdfRadDatePickerStart.Value = RadDatePickerStart.SelectedDate.ToString();
            }
            else
            {
                hdfRadDatePickerStart.Value = String.Format("{0:dd/MM/yyyy}", new DateTime(1900, 1, 1));
            }
            if (RadDatePickerEnd.SelectedDate.HasValue)
            {
                hdfRadDatePickerEnd.Value = RadDatePickerEnd.SelectedDate.ToString();
            }
            else
            {
                hdfRadDatePickerEnd.Value = String.Format("{0:dd/MM/yyyy}", new DateTime(2100, 1, 1));
            }

            RadTreeView rtv = (RadTreeView)rcbCat.Items[0].FindControl("RadTreeView1");

            string CatID = "-1";
            foreach (RadTreeNode n in rtv.CheckedNodes)
            {
                
                CatID += "," + n.Value.ToString();
            }
            
            hdfCategory.Value = CatID;
            hdfPageIndex.Value = "0";
            this.BindrptListArticle();
        }

        protected void rptListArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0)
            {
                return;
            }
            DataRowView itemData = (DataRowView)e.Item.DataItem;
            Label lblArticleId = (Label)e.Item.FindControl("lblArticleId");
            Label lblArticleTitle = (Label)e.Item.FindControl("lblArticleTitle");
            Label lblArticleCategory = (Label)e.Item.FindControl("lblArticleCategory");
            Label lblArticleUserCreate = (Label)e.Item.FindControl("lblArticleUserCreate");
            Label lblArticleDateCreate = (Label)e.Item.FindControl("lblArticleDateCreate");
            Label lblArticleView = (Label)e.Item.FindControl("lblArticleView");
            LinkButton lnkEdit = (LinkButton)e.Item.FindControl("lnkEdit");
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            CheckBox chkView = (CheckBox)e.Item.FindControl("chkView");

            if (lblArticleId != null)
            {
                lblArticleId.Text = itemData["ArticleID"].ToString();
            }
            if (lblArticleTitle != null)
            {
                lblArticleTitle.Text = itemData["Title"].ToString();
            }
            if (lblArticleCategory != null)
            {
                try
                {
                    DataTable dtCategory = new DataTable();
                    dtCategory = new cmsCategoryBL().Category_GetByPK(Int32.Parse(itemData["CategoryID"].ToString()));
                    lblArticleCategory.Text = dtCategory.Rows[0]["Title"].ToString();
                }
                catch (Exception)
                {
                    lblArticleCategory.Text = "";
                }
                
            }
            if (lblArticleUserCreate != null)
            {
                try
                {
                    DataTable dtUser = new DataTable();
                    dtUser = new sysUserBL().User_GetByPK(Int32.Parse(itemData["UserCreate"].ToString()));
                    lblArticleUserCreate.Text = dtUser.Rows[0]["Username"].ToString();
                }
                catch (Exception)
                {
                    lblArticleUserCreate.Text = "";
                }
            }
            if (lblArticleDateCreate != null)
            {
                try
                {
                    DateTime sdate = Convert.ToDateTime(itemData["CreateDate"].ToString());
                    lblArticleDateCreate.Text = string.Format("{0:dd/MM/yyyy}", sdate);
                }
                catch (Exception)
                {
                    lblArticleDateCreate.Text = "";
                }
            }
            if (lblArticleView != null)
            {
                if (itemData["LuotView"].ToString() != "")
                {
                    lblArticleView.Text = itemData["LuotView"].ToString();
                }
                else
                {
                    lblArticleView.Text = "0";
                }
            }
            if (lnkEdit != null)
            {
                lnkEdit.CommandName = "Edit";
                lnkEdit.CommandArgument = itemData["ArticleID"].ToString();
                string temp = itemData["IsPublish"].ToString();
                if (itemData["IsPublish"].ToString() == "True")
                {
                    lnkEdit.Visible = true;
                }
                else
                {
                    if (Session["UserType"].ToString() == "2")
                    {
                        lnkEdit.Visible = true;
                    }
                    else
                    {
                        if (Session["UserID"] != null)
                        {
                            if (Session["UserID"].ToString() == itemData["UserCreate"].ToString())
                            {
                                lnkEdit.Visible = true;
                            }
                            else
                            {
                                lnkEdit.Visible = false;
                            }
                        }
                        else
                        {
                            lnkEdit.Visible = false;
                        }
                    }
                }
            }
            if (lnkDelete != null)
            {
                lnkDelete.CommandName = "Delete";
                lnkDelete.CommandArgument = itemData["ArticleID"].ToString();
                if (itemData["IsPublish"].ToString() == "True")
                {
                    lnkDelete.Visible = true;
                }
                else
                {
                    if (Session["UserType"].ToString() == "2")
                    {
                        lnkDelete.Visible = true;
                    }
                    else
                    {
                        if (Session["UserID"] != null)
                        {
                            if (Session["UserID"].ToString() == itemData["UserCreate"].ToString())
                            {
                                lnkDelete.Visible = true;
                            }
                            else
                            {
                                lnkDelete.Visible = false;
                            }
                        }
                        else
                        {
                            lnkDelete.Visible = false;
                        }
                    }
                }
            }
            if (chkView != null)
            {
                string temp = itemData["IsPublish"].ToString();
                if (itemData["IsPublish"].ToString() == "True")
                {
                    chkView.Checked = true;
                }
                else
                {
                    chkView.Checked = false;
                }
            }
        }

        protected void rptListArticle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int iArticleId = Int32.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Delete")
            {
                DataTable dtArticle = new DataTable();
                DataTable dtUser = new DataTable();
                dtArticle = new cmsArticleBL().SelectByPK(iArticleId);
                new cmsArticleBL().Delete(new cmsArticleDO { ArticleID = iArticleId });
                objHtr.Action = "Xóa bài viết ";
                objHtr.Contents = "Bài viết tác động: [" + iArticleId + "]" + dtArticle.Rows[0]["Title"].ToString();
                if(Session["UserID"] != null){
                    string iUserId = Session["UserID"].ToString();
                    dtUser = new sysUserBL().User_GetByPK(int.Parse(iUserId));
                    objHtr.Comment = "User tác động: [" + dtUser.Rows[0]["UserID"].ToString() + "] " + dtUser.Rows[0]["Username"].ToString();
                }
                objHtr.HistoryTime = DateTime.Now;
                new cmsHistoryBL().Insert(objHtr);
                Functions.Alert("Xóa bản tin thành công!");
                this.BindrptListArticle();
            }
            if (e.CommandName == "Edit")
            {
                //Khi nào dùng thì sửa lại link bên dưới
                //Response.Redirect("Default.aspx?Page=Article&ArticleID=" + iArticleId.ToString());
            }
        }

        protected void ddlPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdfPageIndex.Value = Convert.ToString(int.Parse(ddlPageIndex.SelectedValue) - 1);
            NumberItemPerPage = Int32.Parse(ddlNumberItemPerPage.SelectedValue);
            this.BindrptListArticle();
        }

        protected void ddlNumberItemPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumberItemPerPage = Int32.Parse(ddlNumberItemPerPage.SelectedValue);
            this.BindrptListArticle();
        }
    }
}