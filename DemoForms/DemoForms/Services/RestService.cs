using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace DemoForms.Services
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
        }

        public async Task SendData(string json)
        {
            using (var client = new HttpClient())
            {
                var RestUrl = "http://api.myjson.com/bins/c4ucn";
                var uri = new Uri(string.Format(RestUrl, string.Empty));
                try
                {
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = null;
                    response = await client.PutAsync(uri, content);
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}

