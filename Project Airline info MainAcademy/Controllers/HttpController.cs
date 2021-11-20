using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy.Controllers
{
    class HttpController
    {
        public string ParsePlanes()
        {
            string content ;
            using (var client = new HttpClient())
            {
                var urlPlane = "https://csharpvinnytsia.at.ua/res/yakiv/Plane.json";
                var result = client.GetAsync(urlPlane).Result;

                 content = client.GetStringAsync(urlPlane).Result;
            }

            return content;
        }
        public string ParseAeroports()
        {
            string content;
            using (var client = new HttpClient())
            {
                var urlPlane = "https://csharpvinnytsia.at.ua/res/yakiv/Aeroports.json";
                var result =  client.GetAsync(urlPlane).Result;

                content = client.GetStringAsync(urlPlane).Result;
            }
            return content;
        }
    }
}
