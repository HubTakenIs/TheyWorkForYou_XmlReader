using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace dotnetFormApp
{
    public class WebScraper
    {
       public static HtmlAgilityPack.HtmlDocument GetHtmlDocument(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            return doc;
        }

       public static string[] getPartyAndConstituency(string url)
        {
            HtmlAgilityPack.HtmlDocument doc = GetHtmlDocument(url);
            HtmlAgilityPack.HtmlNode partySpanNode =  doc.DocumentNode.SelectSingleNode("//span[@class=\"person-header__about__position__role\"]");
            HtmlAgilityPack.HtmlNode ConstituencySpanNode = doc.DocumentNode.SelectSingleNode("//span[@class=\"person-header__about__position__constituency\"]");
            string party = partySpanNode.InnerText;
            string constituency = ConstituencySpanNode.InnerText;
        

            string[] partyAndConstituency = new string[2];
            partyAndConstituency[0] = cleanString(party);
            partyAndConstituency[1] = cleanString(constituency);
            return partyAndConstituency;

        }

        private static string cleanString(string input)
        {
            string clean = "";
            clean =  string.Join(" ", input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => x.Trim()));
            return clean;
        }

    }
}
