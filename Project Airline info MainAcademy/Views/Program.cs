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
        public static List<AeroportModel> aeroports = new List<AeroportModel>();

        static async void Main(string[] args)
        {
            //var MainController = new MainController();
            //MainController.Run();

            //MainController.Stop();

            string path = @"Aeroports.json";

            aeroports.Add(new AeroportModel("Boryspil airport", 10));
            aeroports.Add(new AeroportModel("Lviv airport", 8));
            aeroports.Add(new AeroportModel("airport Kiev", 6));
            aeroports.Add(new AeroportModel("Odessa airport", 6));
            aeroports.Add(new AeroportModel("Kharkiv airport", 4));


            //string json = JsonConvert.SerializeObject(aeroports.ElementAt(1));
            //WriteToFileJson(json, path);


            var aer = await ReadFromFile(path);
            //foreach (var aeroport in aeroports)
            //{
            //    string json = JsonConvert.SerializeObject(aeroport);
            //    WriteToFileJson(json, path);
            //}

            Console.ReadKey();


        }

        private static async Task<AeroportModel> ReadFromFile(string path)
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                // асинхронное чтение файла
                await fstream.ReadAsync(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);

                AeroportModel aeroport = JsonConvert.DeserializeObject<AeroportModel>(textFromFile);

                return aeroport;
            }
        }
        private static void WriteToFileJson(string json, string path)
        {
            using (FileStream File = new FileStream(path, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(json);
                byte[] array2 = System.Text.Encoding.Default.GetBytes("\n");
                // запись массива байтов в файл
                File.Write(array, 0, array.Length);
                File.Write(array2, 0, array2.Length);
                Console.WriteLine("Текст записан в файл");
            }

        }

    }
}
