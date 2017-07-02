using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoForms.Models;

namespace DemoForms.Helpers
{
    using DemoForms.Models;

    public class JsonHelper
    {
        public static async Task<string> ConvertToJson(Form form)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(form);
        }
    }
}
