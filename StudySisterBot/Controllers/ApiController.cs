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
    public class ApiController
    {
        public class ResultData
        {
            public string type;
            public List<string> result;

        }
       public ResultData GetObject(string data)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://bop.pescn.cc/";
                var json = wc.DownloadString(url+data);
                ResultData rs = (ResultData)JsonConvert.DeserializeObject(json);

                return rs;
            }
        }

    }
}