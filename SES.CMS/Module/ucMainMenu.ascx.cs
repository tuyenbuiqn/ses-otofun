﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SES.CMS.BL;
using SES.CMS.DO;
using SES.CMS;
using System.Data;
using System.Text.RegularExpressions;
namespace SES.CMS.Module
{
    public partial class ucMainMenu : System.Web.UI.UserControl
    {
        string CategoryIDS = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //string u = Request.ServerVariables["HTTP_USER_AGENT"];
            //Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            //Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            //if (Request.QueryString["UI"] != null)
            //{
            //    if (Request.QueryString["UI"] == "Desktop")
            //        Session["WantFull"] = "Yes";
            //    else
            //    {
            //        Session["WantFull"] = "No";
            //        Response.Redirect("http://m.otofun.net");
            //    }
            //}
            //else
            //{
            //    if ((b.IsMatch(u) || v.IsMatch(u.Substring(0, 4))))
            //    {
            //        if (Session["WantFull"] != "Yes")
            //        {
            //            Session["WantFull"] = "No";
            //            Response.Redirect("http://m.otofun.net");
            //        }
            //    }
            //    else
            //    Session["WantFull"] = "Yes";
            //}


            if (!string.IsNullOrEmpty(Request.QueryString["UI"]))
            {
                string type = Request.QueryString["UI"];
                string currentURL = Request.Url.AbsolutePath;
                if (type.Equals("Desktop"))
                {
                    Session["UI"] = "Desktop";
                    Response.Redirect("http://news.otofun.net" + currentURL);
                }
                else
                {

                }
            }
            else
            {
                if (Session["UI"] != null)
                {

                }
                else
                {
                    string u = Request.ServerVariables["HTTP_USER_AGENT"];
                    string currentURL = Request.Url.AbsolutePath;
                    Regex b = new Regex("(android|bb\\d+|meego).+mobile|avantgo|bada\\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase);
                    Regex v = new Regex("1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\\-(n|u)|c55\\/|capi|ccwa|cdm\\-|cell|chtm|cldc|cmd\\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\\-s|devi|dica|dmob|do(c|p)o|ds(12|\\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\\-|_)|g1 u|g560|gene|gf\\-5|g\\-mo|go(\\.w|od)|gr(ad|un)|haie|hcit|hd\\-(m|p|t)|hei\\-|hi(pt|ta)|hp( i|ip)|hs\\-c|ht(c(\\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\\-(20|go|ma)|i230|iac( |\\-|\\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\\/)|klon|kpt |kwc\\-|kyo(c|k)|le(no|xi)|lg( g|\\/(k|l|u)|50|54|\\-[a-w])|libw|lynx|m1\\-w|m3ga|m50\\/|ma(te|ui|xo)|mc(01|21|ca)|m\\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\\-2|po(ck|rt|se)|prox|psio|pt\\-g|qa\\-a|qc(07|12|21|32|60|\\-[2-7]|i\\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\\-|oo|p\\-)|sdk\\/|se(c(\\-|0|1)|47|mc|nd|ri)|sgh\\-|shar|sie(\\-|m)|sk\\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\\-|v\\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\\-|tdg\\-|tel(i|m)|tim\\-|t\\-mo|to(pl|sh)|ts(70|m\\-|m3|m5)|tx\\-9|up(\\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\\-|your|zeto|zte\\-", RegexOptions.IgnoreCase);
                    if (b.IsMatch(u))
                        Response.Redirect("http://m.otofun.net" + currentURL);
                }
            }
            

            if (Request.QueryString["CategoryID"] != null) CategoryIDS = Request.QueryString["CategoryID"];
            rptMainMenuDataSource(); //rptChildDataSource();
            if (string.IsNullOrEmpty(CategoryIDS)) divhome.Attributes.Add("class", "home-active");
            else divhome.Attributes.Add("class", "home-inactive");

        }

        private void rptMainMenuDataSource()
        {
            rptMainMenu.DataSource = new cmsCategoryBL().SelectMenu(9);
            rptMainMenu.DataBind();
        }
/*
        private void rptChildDataSource()
        {
            if (Request.Url.AbsolutePath.ToUpper().Equals("/DEFAULT.ASPX"))
            {
                rptChildMenu.Visible = false;
            }
            else
            {
                string url = Request.Url.AbsolutePath;
                url = url.Substring(1, url.Length - 1);
                string url1 = url.Replace(".", "/");
                string Module = url1.Substring(0, url1.IndexOf("/"));

                if (Module.Equals("Cat"))
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
                    {
                        int cateID = int.Parse(Request.QueryString["CategoryID"]);
                        rptChildMenu.Visible = true;
                        rptChildMenu.DataSource = new cmsCategoryBL().SelectByParent(cateID);
                        rptChildMenu.DataBind();
                    }
                }
            }
        }*/
        protected void imgbtnSearch_Click(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                Response.Redirect("/search/otofun-" + txtSearch.Text.Trim() + ".ofn");
            }
        }
        public string ReturnLiActive(string id)
        {
            if (string.IsNullOrEmpty(CategoryIDS)) return "<li>";
            int ids = int.Parse(id);
            if (ids.ToString().Equals(CategoryIDS)) return "<li class='liactive'>";
            else 
            {
                cmsCategoryDO o = new cmsCategoryBL().Select(new cmsCategoryDO { CategoryID = int.Parse(CategoryIDS) });
                if (o.ParentID == ids) return "<li class='liactive'>";
            }
            return "<li>";
        }
        public string FriendlyUrl(string s)
        {
            return Ultility.Change_AVCate(s);
        }
        protected void rptMainMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //cmsCategoryBL cateBL = new cmsCategoryBL();
            //cmsCategoryDO objCate = new cmsCategoryDO();
            //RepeaterItem item = e.Item;
            //if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            //{
            //    DataRowView drv = (DataRowView)item.DataItem;
            //    int categoryID = int.Parse(drv["CategoryID"].ToString());
            //    objCate.CategoryID = categoryID;
            //    objCate = cateBL.Select(objCate);
            //     string url = Request.Url.AbsolutePath;
            //    url = url.Substring(1, url.Length - 1);
            //    string url1 = url.Replace(".", "/");
            //    string Module = url1.Substring(0, url1.IndexOf("/"));

            //    if (Module.Equals("Cat"))
            //    {
            //        if (objCate.ParentID == 0)
            //        {
                        
            //        }
            //        else if (objCate.ParentID > 0)
            //        { }

            //    }
            
            //}
        }
    }
}