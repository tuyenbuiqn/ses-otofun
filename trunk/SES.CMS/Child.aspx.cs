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
using DevExpress.Web.ASPxEditors;
using SES.CMS.BL;
using SES.CMS.DO;

namespace SES.CMS
{
    public partial class Child : System.Web.UI.Page
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

                BindddlSearchCategory();

                pnlTitle01.Visible = false;
                pnlTitle02.Visible = false;
            }
        }

        public void BindrptListArticles()
        {

            int CategoryID = 0;
            DateTime ArticleSearchDateStart = DateTimeStartDefault;
            DateTime ArticleSearchDateEnd = DateTimeEndDefault;
            string Title = "";
           
                if (hdfSearchCategoryId.Value != "")
                {
                    CategoryID = Int32.Parse(hdfSearchCategoryId.Value.ToString());
                }
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

                rptListArticles.DataSource = new cmsArticleBL().Article_Search(CategoryID.ToString(), ArticleSearchDateStart, ArticleSearchDateEnd, Title);
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

        public void BindddlSearchCategory()
        {
            ddlSearchCategory.DataSource = new cmsCategoryBL().SelectAll();
            ddlSearchCategory.DataTextField = "Title";
            ddlSearchCategory.DataValueField = "CategoryID";
            ddlSearchCategory.DataBind();
            ddlSearchCategory.Items.Insert(0, new ListItem("---Chọn danh mục bài viết---", "0"));
        }

        public void DeleteItemInHdfListArticlesId(string Value)
        {
            string sHdfControlValue = hdfListArticlesId.Value;
            string[] stringsListControlValue = sHdfControlValue.Split(',');
            string sReturn = "";
            for (int i = 0; i < stringsListControlValue.Length; i++)
            {
                if ((stringsListControlValue[i] != "")&&(stringsListControlValue[i] != Value))
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
            if (txtSearchKey.Text !=null)
            {
                hdfSearchKey.Value = txtSearchKey.Text;
            }
            if (ddlSearchCategory != null)
            {
                hdfSearchCategoryId.Value = ddlSearchCategory.SelectedValue.ToString(); ;
            }
            if (txtSearchDateStart != null)
            {
                if (txtSearchDateStart.Text != "")
                {
                    hdfSearchDateStart.Value = txtSearchDateStart.Text;
                }
                else
                {
                    hdfSearchDateStart.Value = DateTimeStartDefault.ToString();
                }
            }
            if (txtSearchDateEnd != null)
            {
                if (txtSearchDateEnd.Text != "")
                {
                    hdfSearchDateEnd.Value = txtSearchDateEnd.Text;
                }
                else
                {
                    hdfSearchDateEnd.Value = DateTimeEndDefault.ToString();
                }
            }

            this.BindrptListArticles();
            pnlTitle01.Visible = true;
            pnlTitle02.Visible = true;
            hdfSearchCategoryId.Value = "";
            hdfSearchDateEnd.Value = "";
            hdfSearchDateStart.Value = "";
            hdfSearchKey.Value = "";
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
                DataTable dtCategory= new DataTable();
                dtCategory= new cmsCategoryBL().Category_GetByPK(Int32.Parse(itemData["CategoryID"].ToString()));
                if (dtCategory != null)
                {
                    if (dtCategory != null)
                    {
                        lblArticleCategory.Text = dtCategory.Rows[0]["Title"].ToString();
                    }
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

        protected void rptListArticles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
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
