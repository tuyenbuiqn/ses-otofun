using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;

namespace SES.CMS.ofeditor
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        sysUserDO objUser = new sysUserDO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                int userID = int.Parse(Session["UserID"].ToString());
                objUser.UserID = userID;
                objUser = new sysUserBL().Select(objUser);
                lblTaiKhoan.Text = objUser.Username;
            }
            else
                Response.Redirect("Login.aspx");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (Ultility.EncryptMd5(txtOldPassword.Text.Trim()).ToUpper().Equals(objUser.Password.ToUpper()))
            {
                objUser.Password = Ultility.EncryptMd5(txtReNewPassword.Text);
                new sysUserBL().Update(objUser);
                Ultility.Alert("Đổi mật khẩu thành công...", Request.Url.ToString());
            }
            else
            {
                Ultility.Alert("Mật khẩu nhập vào không đúng...",Request.Url.ToString());
            }
         }
    }
}