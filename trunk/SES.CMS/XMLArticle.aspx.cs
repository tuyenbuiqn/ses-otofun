using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using SES.CMS.BL;
using SES.CMS.DO;
using System.Text.RegularExpressions;

namespace SES.CMS
{
    public partial class XMLArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NewsRSS rss = new NewsRSS();

            NewsRSS.RssChannel channel = new NewsRSS.RssChannel();

            channel.Title = "Trang tin Otofun";

            channel.Link = "http://news.otofun.net/";

            channel.Description = "Thế giới Phương tiện 24/7";

            rss.AddRssChannel(channel);


            cmsArticleDO dtnew = new cmsArticleBL().Select(new cmsArticleDO { ArticleID = int.Parse(Request.QueryString["ArticleID"]) });

           
                NewsRSS.RssItem item6 = new NewsRSS.RssItem();

                item6.Title = dtnew.Title;

                item6.Link = "http://news.otofun.net/";

                item6.Description = dtnew.ArticleSP;

                item6.DetailNews = FormatHtmlIntoBBCode(dtnew.ArticleDetail);

                rss.AddRssItem(item6);
           


            Response.Clear();

            Response.ContentType = "text/xml";

            Response.Write(rss.RssDocument);

            Response.End();
        }

        public string FormatHtmlIntoBBCode(string desc)
        {
            desc = Regex.Replace(desc, @"<table\b[^>]*>","[CENTER]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<tbody>", "", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<tr>", "", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<td>", "", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"</td>", "", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"</tr>", "", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<td\b[^>]*>", "[/CENTER][CENTER]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"</tbody>", "", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"</table>", "</CENTER>", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<br(.*?) />", "[br]", RegexOptions.IgnoreCase);
            
            desc = Regex.Replace(desc, @"<UL[^>]*>", "[ulist]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/UL>", "[/ulist]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<OL[^>]*>", "[olist]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/OL>", "[/olist]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<LI>", "[*]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/li>", "", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<B>", "[b]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/B>>", "[/b]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<strong>", "[B]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/strong>", "[/B]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<u>", "[u]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/u>", "[/u]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<i>", "[i]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/i>", "[/i]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<em>", "[I]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/em>", "[/I]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<center>", "[CENTER]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/center>", "[/CENTER]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<left>", "[LEFT]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/left>", "[/LEFT]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<right>", "[RIGHT]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/right>", "[/RIGHT]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<sup>", "[sup]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/sup>", "[/sup]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<sub>", "[sub]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/sub>", "[/sub]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<HR[^>]*>", "[hr]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<STRIKE>", "[strike]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/STRIKE>", "[/strike]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<h1>", "[h1]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/h1>", "[/h1]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<h2>", "[h2]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/h2>", "[/h2]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<h3>", "[h3]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/h3>", "[/h3]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<a href=", "[url=", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<\/a>", "[/url]", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"<span \b[^>]*>\b[^>]*</span>", "", RegexOptions.IgnoreCase);
            desc = Regex.Replace(desc, @"'>", "']", RegexOptions.IgnoreCase);
            
            
            //match on image tags
            var match = Regex.Matches(desc, @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>", RegexOptions.IgnoreCase);
            if (match.Count > 0)
                for(int i=0;i<match.Count;i++)
                    desc = Regex.Replace(desc, match[i].ToString(), "[IMG]" + match[0].Groups[1].Value + "[/IMG]", RegexOptions.IgnoreCase);

            return desc;
        }
    }

    public class NewsRSS
    {
        private XmlDocument _rss = null;
        public struct RssChannel
        {
            public string Title;
            public string Link;
            public string Description;
            public string DetailNews;
        }

        public struct RssItem
        {
            public string Title;
            public string Link;
            public string Description;
            public string DetailNews;
        }

        private static XmlDocument addRssChannel(XmlDocument xmlDocument, RssChannel channel)
        {
            XmlElement channelElement = xmlDocument.CreateElement("channel");

            XmlNode rssElement = xmlDocument.SelectSingleNode("rss");

            rssElement.AppendChild(channelElement);

            XmlElement titleElement = xmlDocument.CreateElement("title");

            titleElement.InnerText = channel.Title;

            channelElement.AppendChild(titleElement);

            XmlElement linkElement = xmlDocument.CreateElement("link");

            linkElement.InnerText = channel.Link;

            channelElement.AppendChild(linkElement);

            XmlElement descriptionElement = xmlDocument.CreateElement("description");

            descriptionElement.InnerText = channel.Description;

            channelElement.AppendChild(descriptionElement);

            XmlElement detailElement = xmlDocument.CreateElement("detail");

            detailElement.InnerText = channel.DetailNews;

            channelElement.AppendChild(detailElement);

            // Generator information

            XmlElement generatorElement = xmlDocument.CreateElement("generator");

            generatorElement.InnerText = "Your RSS Generator name and version ";

            channelElement.AppendChild(generatorElement);

            return xmlDocument;
        }

        private static XmlDocument addRssItem(XmlDocument xmlDocument, RssItem item)
        {
            XmlElement itemElement = xmlDocument.CreateElement("item");

            XmlNode channelElement = xmlDocument.SelectSingleNode("rss/channel");

            XmlElement titleElement = xmlDocument.CreateElement("title");

            titleElement.InnerText = item.Title;

            itemElement.AppendChild(titleElement);

            XmlElement linkElement = xmlDocument.CreateElement("link");

            linkElement.InnerText = item.Link;

            itemElement.AppendChild(linkElement);
            
            
            XmlElement DetailElement = xmlDocument.CreateElement("DetailNews");

            DetailElement.InnerText = item.DetailNews;

            itemElement.AppendChild(DetailElement);


            XmlElement descriptionElement = xmlDocument.CreateElement("description");

            descriptionElement.InnerText = item.Description;

            itemElement.AppendChild(descriptionElement);

            // append the item

            channelElement.AppendChild(itemElement);

            return xmlDocument;
        }

        public NewsRSS()
        {
            _rss = new XmlDocument();
            XmlDeclaration xmlDeclaration = _rss.CreateXmlDeclaration("1.0", "utf-8", null);
            _rss.InsertBefore(xmlDeclaration, _rss.DocumentElement);

            XmlElement rssElement = _rss.CreateElement("rss");
            XmlAttribute rssVersionAttribute = _rss.CreateAttribute("version");

            rssVersionAttribute.InnerText = "2.0";
            rssElement.Attributes.Append(rssVersionAttribute);

            _rss.AppendChild(rssElement);

        }

        public void AddRssChannel(RssChannel channel)
        {
            _rss = addRssChannel(_rss, channel);
        }

        public void AddRssItem(RssItem item)
        {
            _rss = addRssItem(_rss, item);
        }

        public string RssDocument
        {
            get
            {
                return _rss.OuterXml;
            }
        }

        public XmlDocument RssXMLDocument
        {
            get
            {
                return _rss;
            }
        }


    }
}