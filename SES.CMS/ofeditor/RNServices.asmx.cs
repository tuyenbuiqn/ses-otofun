using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Web.Script.Services;
using System.Data;

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

        
        [WebMethod(EnableSession = true)]
        //[System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Xml)]
        

        public List<ArticleOD> GetListOfArticle(string StrArticleID)
        {
           
            List<ArticleOD> quotes = new List<ArticleOD>();
            List<cmsArticleDO> table = new cmsArticleBL().GetListMultiID(StrArticleID);
            foreach (cmsArticleDO obj in table)
            { 
                ArticleOD a = new ArticleOD();
                a.ArticleID = obj.ArticleID;
                a.Title = obj.Title;
                quotes.Add(a);
            }
            return quotes;
        }

    }
}
