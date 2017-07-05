using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace DemoForms.Services
{
    public class RestService
    {
        public async Task<bool> SendData(string json)
        {
            using (var client = new HttpClient())
            {
                var restUrl = "http://api.myjson.com/bins/c4ucn";
                var uri = new Uri(string.Format(restUrl, string.Empty));
                try
                {
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = null;
                    response = await client.PutAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

                return false;
            }
        }
    }
}

