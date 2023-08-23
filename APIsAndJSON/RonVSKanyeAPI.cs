using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public static class RonVSKanyeAPI
    {
        public static void Convo()
        {
            var client = new HttpClient();  

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye says, '{KanyeSaid(client)}'\n");
                Thread.Sleep(2000);
                Console.WriteLine($"Ron says, '{RonSaid(client)}'\n '");
                Thread.Sleep(2000);
            }
        }

        private static string KanyeSaid(HttpClient client)
        {
            var jtext = client.GetStringAsync("https://api.kanye.rest/").Result;
            var quote = JObject.Parse(jtext).GetValue("quote").ToString();
            return quote;
        }

        private static string RonSaid(HttpClient client)
        {
            var jtext = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            var qoute = JArray.Parse(jtext).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"',' ').Trim();
            return qoute; 
        }
    }
}
