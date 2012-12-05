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
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            setobject();
            if (objuser.UserID <= 0)
            {
                objuser.UserID = new sysUserBL().Insert(objuser);
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
            objuser.Password = Functions.EncryptMd5(txtPassword.Text);
            objuser.Email = txtEmail.Text;
            objuser.IsActive = cbActive.Checked;
        }
    }
}