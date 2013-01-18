using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.DO;
using SES.CMS.BL;
using System.Data;
using SES.CMS.AdminCP;
using System.IO;
namespace SES.CMS.WEB.AdminCP.PageUC
{
    public partial class ucUser : System.Web.UI.UserControl
    {
        sysUserDO objuser = new sysUserDO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserID"] != null)
            {
                objuser.UserID = int.Parse(Request.QueryString["UserID"]);
                initForm();
            }

        }

      
        private void initForm()
        {
            objuser = new sysUserBL().Select(objuser);
            txtEmail.Text = objuser.Email;
            txtPassword.Text = objuser.Password;
            txtUsername.Text = objuser.Username;
            cbActive.Checked = objuser.IsActive;
            txtAddress.Text = objuser.Address;
            try
            {
                ddlNhomQuyen.SelectedValue = objuser.UserType.ToString();
            }
            catch 
            {
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            setobject();
            int userMedia;
            if (objuser.UserID <= 0)
            {
                userMedia = new sysUserBL().Insert(objuser);
                if (userMedia > 0)
                {
                    string createFolder = Server.MapPath("~/Media/" + userMedia);
                    if (!Directory.Exists(createFolder))
                    {
                        Directory.CreateDirectory(createFolder);
                    }
                }
                Functions.Alert("Thêm mới thành công", "Default.aspx?Page=ListUser");
            }
            else
            {
                new sysUserBL().Update(objuser);
                Functions.Alert("Cập nhật thành công", "Default.aspx?Page=ListUser");
            }
        }

        private void setobject()
        {
            objuser.Username = txtUsername.Text;
            if(!txtPassword.Text.Equals(""))
                objuser.Password = Functions.EncryptMd5(txtPassword.Text);
            objuser.Email = txtEmail.Text;
            objuser.IsActive = cbActive.Checked;
            objuser.Address = txtAddress.Text;
            objuser.UserType = int.Parse(ddlNhomQuyen.SelectedValue);
        }
    }
}