using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Web.Script.Services;
using System.Data;
using System.Text.RegularExpressions;
namespace SES.CMS.ofeditor
{
    /// <summary>
    /// Summary description for RNServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RNServices : System.Web.Services.WebService
    {


        public RNServices()
        {

        }


        [WebMethod]
        //[System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Xml)]


        public List<ArticleOD> GetListOfArticle(string StrArticleID)
        {
            //if ((!string.IsNullOrEmpty(StrArticleID)) && (!string.IsNullOrEmpty(deleteID)))
            //{
            //    StrArticleID = rmoveStr(StrArticleID, deleteID);
            //}
            if (StrArticleID.IndexOf(",") == 0) StrArticleID = StrArticleID.Remove(StrArticleID.IndexOf(","), 1);
            List<ArticleOD> quotes = new List<ArticleOD>();
            List<cmsArticleDO> table = new List<cmsArticleDO>();
            if(!string.IsNullOrEmpty(StrArticleID))
                table = new cmsArticleBL().GetListMultiID(StrArticleID);
            foreach (cmsArticleDO obj in table)
            { 
                ArticleOD a = new ArticleOD();
                a.ArticleID = obj.ArticleID;
                a.Title = obj.Title;
                quotes.Add(a);
            }
            return quotes;
        }
        [WebMethod]
        public string rmoveStr(string source, string replace)
        {
            
                string[] arrid1 = source.Split(',');
                List<string> lstID1 = new List<string>(arrid1);
                //List<int> lstDel = new List<int>();
                //int i = 0;
                //foreach (string a in lstID)
                //{

                //    if (a.Equals(deleteID))
                //    {
                //        lstDel.Add(i);
                //    }
                //    i++;
                //}
                //foreach (int k in lstDel)
                //{
                lstID1 = lstID1.Where(w => w != replace).ToList();
                //}
                source = string.Empty;
                foreach (string id in lstID1)
                {
                    source = source + id + ",";
                }
                if (!string.IsNullOrEmpty(source))
                    source = source.Remove(source.Length - 1);
                return source;

            
        }

    }
}
