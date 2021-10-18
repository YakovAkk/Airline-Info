using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Passport
    {
        static string[] ArrFirstName = ParseJsonFile("First Name.json");
        static string[] ArrSecondName = ParseJsonFile("Second Name.json");
        static string[] ArrNationality = ParseJsonFile("Nationality.json");

        static Random random = new Random();
        string FirstName { get; }
        string SecondName { get; }
        string Nationality { get; }
        static int CountOfPassport { get; set; }
        int NumOfPassport { get; set; }
        DateTime DateOfBirthday { get; }
        string Sex { get; }
        
        public Passport()
        {
            FirstName = RandFirstName();
            SecondName = RandSecondName();
            Nationality = RandNationality();
            DateOfBirthday = RandDateOfBirthday();
            Sex = RandSex();

            NumOfPassport = CountOfPassport;
            CountOfPassport++;
        }
        public Passport(string FirstName, string SecondName, string Nationality,
            DateTime DateOfBirthday, string Sex)
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Nationality = Nationality;
            this.DateOfBirthday = DateOfBirthday;
            this.Sex = Sex;

            NumOfPassport = CountOfPassport;
            CountOfPassport++;
        }


        public static string[] ParseJsonFile(string pathToFile)
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
        public override string ToString()
        {
            return $"My name is {SecondName} {FirstName}  , i am {Sex} {Nationality}." +
                $"\nNumber of passport is {NumOfPassport}. I was born {DateOfBirthday.ToString()}";
        }
        private static string RandFirstName()
        {
            return ArrFirstName[random.Next(0, ArrFirstName.Length)];
        }
        private static string RandSecondName()
        {
            return ArrSecondName[random.Next(0, ArrSecondName.Length)];
        }
        private static string RandNationality()
        {
            return ArrNationality[random.Next(0, ArrNationality.Length)];
        }
        public static DateTime RandDateOfBirthday()
        {
            int range = 100;
            return new DateTime().AddDays(random.Next(range)).AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60)).AddSeconds(random.Next(0, 60));
        }

        private static string RandSex()
        {
            string[] sex = new[] { "Male", "Female" };
            return sex[random.Next(0, 2)];
        }
    }
}
