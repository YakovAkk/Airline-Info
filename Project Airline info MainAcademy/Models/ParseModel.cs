using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class ParseModel
    {
        public string[] ParseJsonFile(string pathToFile)
        {
            string Allfile = System.IO.File.ReadAllText(pathToFile);
            dynamic Json = System.Web.Helpers.Json.Decode(Allfile);
            int W = 0;

            foreach (var Item in Json.arr)
            {
                W++;
            }

            string[] FileContents = new string[W];
            int Counter = 0;
            foreach (var Item in Json.arr)
            {
                FileContents[Counter] = Item;
                Counter++;
            }
            return FileContents;
        }
    }
}
