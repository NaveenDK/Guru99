using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Guru99.Utilities
{
   public class JsonReader
    {
        public JsonReader()
        {

        }
        
        public string extractData(String tokenName)
        {

            var myJsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
         //   Console.WriteLine(jsonObject.SelectToken("username").Value<string>());
            return jsonObject.SelectToken(tokenName).Value<string>();



        }
    }
   
}
