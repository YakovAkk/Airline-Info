﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Passport
    {
        private static string[] ArrFirstName = new Parse().ParseJsonFile("First Name.json");
        private static string[] ArrSecondName = new Parse().ParseJsonFile("Second Name.json");
        private static string[] ArrNationality = new Parse().ParseJsonFile("Nationality.json");

        private static Random UsersRandom = new Random();
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Nationality { get; private set; }
        private static int CountOfPassport { get; set; }
        public int NumOfPassport { get;private set; }
        public DateTime DateOfBirthday { get; private set; }
        public string Sex { get; private set; }
        
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
        public override string ToString()
        {
            return $"My name is {SecondName} {FirstName}  , i am {Sex} {Nationality}." +
                $"\nNumber of passport is {NumOfPassport}. I was born {DateOfBirthday.ToString()}";
        }
        private string RandFirstName()
        {
            return ArrFirstName[UsersRandom.Next(0, ArrFirstName.Length)];
        }
        private string RandSecondName()
        {
            return ArrSecondName[UsersRandom.Next(0, ArrSecondName.Length)];
        }
        private string RandNationality()
        {
            return ArrNationality[UsersRandom.Next(0, ArrNationality.Length)];
        }
        public DateTime RandDateOfBirthday()
        {
            int range = 100;
            return new DateTime().AddDays(UsersRandom.Next(range)).AddHours(UsersRandom.Next(0, 24)).AddMinutes(UsersRandom.Next(0, 60)).AddSeconds(UsersRandom.Next(0, 60));
        }
        private string RandSex()
        {
            string[] sex = new[] { "Male", "Female" };
            return sex[UsersRandom.Next(0, 2)];
        }
    }
}