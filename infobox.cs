
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wikicontent
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public class Pageval
        {
            public int pageid { get; set; }
            public int ns { get; set; }
            public string title { get; set; }
            public dynamic revisions { get; set; }
        }
        public class Query
        {
            public Dictionary<string, Pageval> pages { get; set; }
        }
        public class Limits
        {
            public int extracts { get; set; }
        }
        public class RootObject
        {
            public string batchcomplete { get; set; }
            public Query query { get; set; }
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] companies = TextArea1.InnerText.Split(',');
            StringBuilder sb = new StringBuilder();
            foreach (string company in companies)
            {
                string url = "https://en.wikipedia.org/wiki/" + company.Trim(); // to call API
                HtmlWeb hw = new HtmlWeb();
                HtmlDocument doc = hw.Load(url); // loading html document
                var table = doc.DocumentNode.SelectNodes("//table")[0];
                sb.Append("<tr><td>" + company + "</td><td>" + table.OuterHtml + "</td></tr>"); // Appending the output
            }
            result.InnerHtml = sb.ToString();
        }
    }
}
