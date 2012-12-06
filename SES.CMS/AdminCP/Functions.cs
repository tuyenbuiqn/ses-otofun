using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SES.CMS.AdminCP
{
    public class Functions
    {

        public Functions()
        {
            //
            // TODO: Add constructor logic here
            //


        }
        // Message and Redirect
        public static void Alert(string msg, string url)
        {
            // Cleans the message to allow single quotation marks
            string cleanMessage = msg.Replace("'", "\\'");
            string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');location='" + url + "';</script>";

            // Gets the executing web page
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("functions"))
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(Functions), "functions", script);
            }
        }
        public static void Alert(string msg)
        {
            // Cleans the message to allow single quotation marks
            string cleanMessage = msg.Replace("'", "\\'");
            string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";

            // Gets the executing web page
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("functions"))
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(Functions), "functions", script);
            }
        }
        public static void RedirectPage(string url)
        {
            // Cleans the message to allow single quotation marks
            string script = "<script type=\"text/javascript\">location='" + url + "';</script>";

            // Gets the executing web page
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("functions"))
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(Functions), "functions", script);
            }
        }
        public static string EncryptMd5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] b1 = UTF8Encoding.UTF8.GetBytes(str);
            byte[] b2 = md5.ComputeHash(b1);
            string encrypted = BitConverter.ToString(b2).Replace("-", "");
            return encrypted;
        }
        public static void GvDatabinder(DevExpress.Web.ASPxGridView.ASPxGridView gv, object obDataSource)
        {
            gv.DataSource = obDataSource;
            gv.DataBind();
        }

        public static void DevCboDatabinder(DevExpress.Web.ASPxEditors.ASPxComboBox cbo, object obDataSource, string TxtField, string dtField)
        {
            cbo.DataSource = obDataSource;
            cbo.TextField = TxtField;
            cbo.ValueField = dtField;
            cbo.DataBind();
        }

        public static void ddlDatabinder(DropDownList ddl, string DataField, string TextField, object obDataSource)
        {
            ddl.DataSource = obDataSource;
            ddl.DataValueField = DataField;
            ddl.DataTextField = TextField;
            ddl.DataBind();
        }
        public static string Change_AV(string ip_str_change)
        {
            ip_str_change = ip_str_change.Replace('"', '-');
            Regex v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string v_str_FormD = ip_str_change.Normalize(NormalizationForm.FormD);
            return v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(" ", "-").Replace(".", "").Replace(":", "-").Replace("%", "phan-tram").Replace("?", "-");
        }
        public static void GvDatabinder(GridView gv, object obDataSource)
        {
            gv.DataSource = obDataSource;
            gv.DataBind();
        }


        public static void GvDatabinder(DataList dlImages, System.Data.DataTable dataTable)
        {
            dlImages.DataSource = dataTable;
            dlImages.DataBind();
        }
    }
}
