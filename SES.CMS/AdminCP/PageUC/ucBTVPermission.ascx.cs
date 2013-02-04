using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Data;

namespace SES.CMS.AdminCP.PageUC
{
    public partial class ucBTVPermission : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ddlBTVDataSource();

        }

        protected void ddlBTVDataSource()
        {
            ddlBTV.DataSource = new DataView(new sysUserBL().SelectAll(), " UserType = 1", "", DataViewRowState.CurrentRows);
            ddlBTV.DataValueField = "UserID";
            ddlBTV.DataTextField = "UserName";
            ddlBTV.DataBind();
        }
        protected void SetSelectedRow()
        {
            tlCategory.UnselectAll();
            int btvID = int.Parse(ddlBTV.SelectedValue);
            if (btvID > 0)
            {
                DataTable dtUserCategory = new cmsUserCategoryBL().SelectByUserID(btvID);

                for (int i = 0; i < tlCategory.Nodes.Count; i++)
                {
                    for (int j = 0; j < dtUserCategory.Rows.Count; j++)
                    {
                        if (int.Parse(tlCategory.Nodes[i].GetValue("CategoryID").ToString()) == int.Parse(dtUserCategory.Rows[j]["CategoryID"].ToString()))
                            tlCategory.Nodes[i].Selected = true;
                        else
                            for (int k = 0; k < tlCategory.Nodes[i].ChildNodes.Count; k++)
                            {
                                if (int.Parse(tlCategory.Nodes[i].ChildNodes[k].GetValue("CategoryID").ToString()) == int.Parse(dtUserCategory.Rows[j]["CategoryID"].ToString()))
                                    tlCategory.Nodes[i].ChildNodes[k].Selected = true;
                            }
                    }
                }

            }
        }

        protected void ddlBTV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlBTV.SelectedValue.Equals("0"))
            {
                tlCategory.DataSource = new cmsCategoryBL().SelectAll();
                tlCategory.DataBind();
                SetSelectedRow();
                tlCategory.ExpandToLevel(3);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!ddlBTV.SelectedValue.Equals("0"))
            {
                tlCategory.DataSource = new cmsCategoryBL().SelectAll();
                tlCategory.DataBind();
                tlCategory.ExpandToLevel(3);
                int BTVID = int.Parse(ddlBTV.SelectedValue);
                cmsUserCategoryBL uscateBL = new cmsUserCategoryBL();
                cmsUserCategoryDO objUser = new cmsUserCategoryDO();
                objUser.UserID = int.Parse(ddlBTV.SelectedValue);
                uscateBL.DeleteByUserID(BTVID);

                for (int i = 0; i < tlCategory.Nodes.Count; i++)
                {
                    if (tlCategory.Nodes[i].Selected)
                    {
                        objUser.CategoryID = int.Parse(tlCategory.Nodes[i].GetValue("CategoryID").ToString());
                        uscateBL.Insert(objUser);
                        for (int j = 0; j < tlCategory.Nodes[i].ChildNodes.Count; j++)
                        {
                            if (tlCategory.Nodes[i].ChildNodes[j].Selected)
                            {
                                objUser.CategoryID = int.Parse(tlCategory.Nodes[i].ChildNodes[j].GetValue("CategoryID").ToString());
                                uscateBL.Insert(objUser);
                            }
                        }

                    }
                    else
                    {
                        for (int k = 0; k < tlCategory.Nodes[i].ChildNodes.Count; k++)
                        {
                            if (tlCategory.Nodes[i].ChildNodes[k].Selected)
                            {
                                objUser.CategoryID = int.Parse(tlCategory.Nodes[i].ChildNodes[k].GetValue("CategoryID").ToString());
                                uscateBL.Insert(objUser);
                            }
                        }
                    }
                }
                Ultility.Alert("Cập nhật dữ liệu thành công","Default.aspx?Page=ListUser");
            }
            else
            {
                Ultility.Alert("Vui lòng chọn biên tập viên");
            }
        }
    }
}