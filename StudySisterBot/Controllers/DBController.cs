using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace StudySisterBot.Controllers
{
    public class DBController
    {
        public class ResultData
        {
            public string type;
            public string result;
        }
        public static ResultData GetObject(string data)
        {
            using (WebClient wc = new WebClient())
            {
                data = data.Replace(" ", "");
                string url = "http://bop.pescn.cc/";
                var json =  wc.DownloadString(url + data);
                ResultData rs = JsonToObject.DataContract<ResultData> (json);
                return rs;
            }
        }

    }
}