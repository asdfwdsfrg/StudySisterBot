using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace StudySisterBot.Controllers
{
    public class DBController
    {
        public class ResultData
        {
            public string type;
            public List<string> result;

        }

        public class LUISData
        {
            public string query;
            public string intents;
            public List<string> entities;
        }

       public static ResultData GetObject(string data)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://bop.pescn.cc/";
                var json = wc.DownloadString(url+data);
                ResultData rs = (ResultData)JsonConvert.DeserializeObject(json);
                return rs;
            }
        }

        public static LUISData LastQuery;
        public static LUISData Getentities(string query)
        {
            using (WebClient wc = new WebClient())
            {
                string LUISurl = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/af995f23-f3fa-42f2-800f-179578b2e585?subscription-key=8e451d761a18455eaf4ba8ed5fc23a47&verbose=true&timezoneOffset=0&q=";
                var json = wc.DownloadString(LUISurl+query);
                LUISData rs = (LUISData)JsonConvert.DeserializeObject(json);
                LastQuery = rs;
                return rs;
            }
        }

    }
}