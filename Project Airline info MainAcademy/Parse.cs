using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Parse
    {
        public string[] ParseJsonFile(string pathToFile)
        {
            string Allfile = System.IO.File.ReadAllText(pathToFile);
            dynamic json = System.Web.Helpers.Json.Decode(Allfile);
            int W = 0;

            foreach (var item in json.arr)
            {
                W++;
            }

            string[] FileContents = new string[W];
            int counter = 0;
            foreach (var item in json.arr)
            {
                FileContents[counter] = item;
                counter++;
            }
            return FileContents;
        }
    }
}
