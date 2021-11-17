using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class  Program
    {

        public static List<PlaneModel> allPlanes = new List<PlaneModel>();
        static void Main(string[] args)
        {
            var MainController = new MainController();
            MainController.Run();

            MainController.Stop();

        }
     
    }
}
