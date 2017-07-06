using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace StudySisterBot
{
    public class JsonToObject
    {
        public static T DataContract<T>(string jsonString)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T data = (T)serializer.ReadObject(ms);
            return data;
        }
    }
}