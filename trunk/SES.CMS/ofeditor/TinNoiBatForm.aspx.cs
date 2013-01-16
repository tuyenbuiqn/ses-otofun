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

namespace SES.CMS.ofeditor
{
    public partial class TinNoiBatForm : System.Web.UI.Page
    {
        DateTime DateTimeStartDefault = new DateTime(1900, 1, 1);
        DateTime DateTimeEndDefault = new DateTime(9000, 12, 31);

        cmsCategoryDO objCate = new cmsCategoryDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdfListArticlesId.Value = "";
                hdfListArticlesName.Value = "";
                hdfSearchCategoryId.Value = "";
                hdfSearchDateEnd.Value = "";
                hdfSearchDateStart.Value = "";
                hdfSearchKey.Value = "";
                rdpStartDate.SelectedDate = DateTime.Now.AddDays(-180);

                pnlTitle01.Visible = false;
                pnlTitle02.Visible = false;
            }
        }

        public void BindrptListArticles()
        {

            string lstCategoryID = "";
            DateTime ArticleSearchDateStart = DateTimeStartDefault;
            DateTime ArticleSearchDateEnd = DateTimeEndDefault;
            string Title = "";
            lstCategoryID = hdfSearchCategoryId.Value;
            if (hdfSearchKey.Value != "")
            {
                Title = hdfSearchKey.Value.ToString();
            }
            if (hdfSearchDateStart != null)
            {
                if (hdfSearchDateStart.Value != "")
                {
                    try
                    {
                        ArticleSearchDateStart = Convert.ToDateTime(hdfSearchDateStart.Value.ToString());
                    }
                    catch (Exception)
                    {
                        //lblMessenger.Text="Bạn không nhập đúng định dạng ngày tháng!\nHãy chọn vào biểu tượng calenda.";
                    }
                }
                else
                {
                    ArticleSearchDateStart = Convert.ToDateTime(DateTimeStartDefault);
                }
            }
            if (hdfSearchDateEnd != null)
            {
                if (hdfSearchDateEnd.Value != "")
                {
                    try
                    {
                        ArticleSearchDateEnd = Convert.ToDateTime(hdfSearchDateEnd.Value.ToString());
                    }
                    catch (Exception)
                    {
                        //lblMessenger.Text = "Bạn không nhập đúng định dạng ngày tháng!<\\Br>Hãy chọn vào biểu tượng calenda.";
                    }
                }
                else
                {
                    ArticleSearchDateEnd = Convert.ToDateTime(DateTimeEndDefault);
                }
            }

            rptListArticles.DataSource = new cmsArticleBL().Article_Search(lstCategoryID, ArticleSearchDateStart, ArticleSearchDateEnd, Title);
            rptListArticles.DataBind();
        }

        public void BinrptListArticlesSelect()
        {
            int STT = 0;
            DataTable dtArticlesSelect = new DataTable();
            dtArticlesSelect.Columns.Add("ArticlesSelectId", typeof(int));
            string sListArticlesId = hdfListArticlesId.Value;
            string[] stringsListArticlesId = sListArticlesId.Split(',');
            for (int i = 0; i < stringsListArticlesId.Length; i++)
            {
                if (stringsListArticlesId[i] != "")
                {
                    dtArticlesSelect.Rows.Add(dtArticlesSelect.NewRow());
                    dtArticlesSelect.Rows[STT]["ArticlesSelectId"] = stringsListArticlesId[i].ToString();
                    STT++;
                }
            }
            rptListArticlesSelect.DataSource = dtArticlesSelect;
            rptListArticlesSelect.DataBind();
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

        public void DeleteItemInHdfListArticlesId(string Value)
        {
            string sHdfControlValue = hdfListArticlesId.Value;
            string[] stringsListControlValue = sHdfControlValue.Split(',');
            string sReturn = "";
            for (int i = 0; i < stringsListControlValue.Length; i++)
            {
                if ((stringsListControlValue[i] != "") && (stringsListControlValue[i] != Value))
                {
                    if (sReturn == "")
                    {
                        sReturn += stringsListControlValue[i];
                    }
                    else
                    {
                        sReturn += "," + stringsListControlValue[i];
                    }
                }
            }
            hdfListArticlesId.Value = sReturn;
            this.BinrptListArticlesSelect();
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchKey.Text != null)
            {
                hdfSearchKey.Value = txtSearchKey.Text;
            }


            if (rdpStartDate.SelectedDate.HasValue)
            {
                hdfSearchDateStart.Value = rdpStartDate.SelectedDate.ToString();
            }
            else
            {
                hdfSearchDateStart.Value = String.Format("{0:dd/MM/yyyy}", new DateTime(1900, 1, 1));
            }


            if (rdpEndDate.SelectedDate.HasValue)
            {
                hdfSearchDateEnd.Value = rdpEndDate.SelectedDate.ToString();
            }
            else
            {
                hdfSearchDateEnd.Value = String.Format("{0:dd/MM/yyyy}", new DateTime(2100, 12, 30));
            }


            RadTreeView rtv = (RadTreeView)rcbCat.Items[0].FindControl("RadTreeView1");

            string CatID = "-1";
            foreach (RadTreeNode n in rtv.CheckedNodes)
            {
                CatID += "," + n.Value.ToString();
            }
            hdfSearchCategoryId.Value = CatID;
            this.BindrptListArticles();
            pnlTitle01.Visible = true;
            pnlTitle02.Visible = true;
        }

        protected void rptListArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0)
            {
                return;
            }

            DataRowView itemData = (DataRowView)e.Item.DataItem;
            Label lblArticleId = (Label)e.Item.FindControl("lblArticleId");
            Label lblArticleName = (Label)e.Item.FindControl("lblArticleName");
            Label lblArticleCategory = (Label)e.Item.FindControl("lblArticleCategory");
            Label lblArticleTime = (Label)e.Item.FindControl("lblArticleTime");
            LinkButton lnkSelectItem = (LinkButton)e.Item.FindControl("lnkSelectItem");
            try
            {
                if (lblArticleId != null)
                {
                    lblArticleId.Text = itemData["ArticleID"].ToString();
                }
                if (lblArticleName != null)
                {
                    lblArticleName.Text = itemData["Title"].ToString();
                }
                if (lblArticleCategory != null)
                {
                    DataTable dtCategory = new DataTable();
                    dtCategory = new cmsCategoryBL().Category_GetByPK(Int32.Parse(itemData["CategoryID"].ToString()));
                    if (dtCategory != null)
                    {
                        lblArticleCategory.Text = dtCategory.Rows[0]["Title"].ToString();
                    }
                }
                if (lblArticleTime != null)
                {
                    lblArticleTime.Text = itemData["CreateDate"].ToString();
                }
                if (lnkSelectItem != null)
                {
                    lnkSelectItem.CommandName = "Select";
                    lnkSelectItem.CommandArgument = itemData["ArticleID"].ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void rptListArticles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (rptListArticlesSelect.Items.Count <= 0)
                {
                    int ArticleId = Int32.Parse(e.CommandArgument.ToString());
                    DataTable dtArticle = new DataTable();
                    int ArticleSelectId = 0;
                    bool flagDuplicate = false;
                    //Kiểm tra id nhập vào đã có bên rptListArticlesSelect chưa
                    if (hdfListArticlesId.Value != "")
                    {
                        string sListArticlesId = hdfListArticlesId.Value;
                        string[] stringListListArticlesId = sListArticlesId.Split(',');
                        for (int i = 0; i < stringListListArticlesId.Length; i++)
                        {
                            if (stringListListArticlesId[i] != "")
                            {
                                if (ArticleId.ToString() == stringListListArticlesId[i])
                                {
                                    flagDuplicate = true;
                                    break;
                                }
                            }
                        }
                        if (flagDuplicate == true)
                        {
                            ArticleSelectId = 0;
                        }
                        else
                        {
                            ArticleSelectId = ArticleId;
                        }
                    }
                    else
                    {
                        ArticleSelectId = ArticleId;
                    }
                    //End Kiểm tra id nhập vào đã có bên rptListArticlesSelect chưa
                    if (ArticleSelectId != 0)
                    {
                        dtArticle = new cmsArticleBL().SelectByPK(ArticleSelectId);
                        if (dtArticle != null)
                        {
                            if (hdfListArticlesId != null)
                            {
                                if (hdfListArticlesId.Value == "")
                                {
                                    hdfListArticlesId.Value += dtArticle.Rows[0]["ArticleID"].ToString();
                                }
                                else
                                {
                                    hdfListArticlesId.Value += "," + dtArticle.Rows[0]["ArticleID"].ToString();
                                }
                            }
                            if (hdfListArticlesName != null)
                            {
                                if (hdfListArticlesName.Value == "")
                                {
                                    hdfListArticlesName.Value += dtArticle.Rows[0]["Title"].ToString();
                                }
                                else
                                {
                                    hdfListArticlesName.Value += "," + dtArticle.Rows[0]["Title"].ToString();
                                }
                            }
                        }
                    }

                    this.BinrptListArticlesSelect();
                }
                else
                {
                    Ultility.Alert("Chỉ được chọn 1 bản tin mỗi lần!");
                    return;
                }
            }
        }

        protected void rptListArticlesSelect_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0)
            {
                return;
            }
            DataTable dtArticle = new DataTable();
            DataRowView itemData = (DataRowView)e.Item.DataItem;
            dtArticle = new cmsArticleBL().SelectByPK(Int32.Parse(itemData["ArticlesSelectId"].ToString()));
            Label lblArticleSelect = (Label)e.Item.FindControl("lblArticleSelect");
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            try
            {
                if (lblArticleSelect != null)
                {
                    if (dtArticle != null)
                    {
                        lblArticleSelect.Text = dtArticle.Rows[0]["Title"].ToString();
                    }
                }
                if (lnkDelete != null)
                {
                    lnkDelete.CommandName = "Delete";
                    if (dtArticle != null)
                    {
                        lnkDelete.CommandArgument = dtArticle.Rows[0]["ArticleID"].ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void rptListArticlesSelect_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string ArticleId = e.CommandArgument.ToString();
                this.DeleteItemInHdfListArticlesId(ArticleId);
            }
        }
    }
}