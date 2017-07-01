using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace DemoForms.Models
{
    public class Country
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        public static List<Country> GetCountryList()
        {
            var assembly = typeof(Country).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("DemoForms.Resources.CountryList.json");
            string jsonString = "";
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Country>>(jsonString);
            }
        }
    }

}
