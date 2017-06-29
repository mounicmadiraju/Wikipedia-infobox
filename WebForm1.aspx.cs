// Author mounicraju@gmail.com //

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
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
                string url = "http://en.wikipedia.org/w/api.php?action=query&prop=revisions&rvprop=content&format=json&titles=" + company.Trim();
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(url).Result;
                var responseJson = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);
                var firstKey = responseJson.query.pages.First().Key;
                var title = responseJson.query.pages[firstKey].title;
                Object revision = responseJson.query.pages[firstKey].revisions[0];
                var extract = revision.GetType().GetProperty("*").GetValue(revision, null);
                

                sb.Append("<tr><td>" + title + "</td><td>" + extract + "</td></tr>");
            }
            result.InnerHtml = sb.ToString();
        }
    }
}
