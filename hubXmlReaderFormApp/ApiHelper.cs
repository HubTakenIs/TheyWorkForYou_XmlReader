using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace hubXmlReaderFormApp
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } 

        public static void InitialiseClient()
        {
            ApiClient = new HttpClient();

        }
    }
}
