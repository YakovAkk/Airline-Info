using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class ParseConrtoller
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
        public List<AeroportModel> ReadFromFileAeroport(string path)
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                // асинхронное чтение файла
                fstream.Read(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);

                List<AeroportModel> aeroport = JsonConvert.DeserializeObject<List<AeroportModel>>(textFromFile);

                return aeroport;
            }
        }
        public List<PlaneModel> ReadFromFilePlane(string path)
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                // асинхронное чтение файла
                fstream.Read(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);

                List<PlaneModel> planes = JsonConvert.DeserializeObject<List<PlaneModel>>(textFromFile);

                return planes;
            }
        }
        public void WriteToFileJson(string json, string path)
        {
            using (FileStream File = new FileStream(path, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(json);

                // запись массива байтов в файл
                File.Write(array, 0, array.Length);

                Console.WriteLine("Текст записан в файл");
            }

        }
        public List<AeroportModel> ReadFromServerAeroport(string content)
        {
             List<AeroportModel> aeroport = JsonConvert.DeserializeObject<List<AeroportModel>>(content);
             return aeroport;
        }
        public List<PlaneModel> ReadFromServerPlane(string content)
        {
            List<PlaneModel> planes = JsonConvert.DeserializeObject<List<PlaneModel>>(content);
            return planes;
        }
    }
}
