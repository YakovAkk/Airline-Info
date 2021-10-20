using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    
    class Plane // every palne division on 3 part - economy class , business class , and first class
    {
        public StatusOfFly StatusOfFly { get; private set; }
        private static int CountOfPlane = 0;
        private int NumOfPlane = 0;

        public string NameOfPlane { get;private set; }
        // count of place in every class
        public int MaxPlaceFirstClass { get; private set; }
        public int MaxPlaceBusinessClass { get; private set; }
        public int MaxPlaceEcomomyClass { get; private set; }


        // price for one place in every class
        public TicketOnPlane PriceFirst { get; private set; }
        public TicketOnPlane PriceBusiness { get; private set; }
        public TicketOnPlane PriceEconomy { get; private set; }


        // lists with person in everyone class
        public List<Person> ListOfPeopleEconomyClass { get; private set; }
        public List<Person> ListOfPeopleBusinessClass { get; private set; }
        public List<Person> ListOfPeopleFirstClass { get; private set; }
        //constructor

        public Plane(string NameOfPlane , int MaxPlaceEcomomyClass, int MaxPlaceBusinessClass , int MaxPlaceFirstClass)
        {
            PriceFirst = new TicketOnPlane(ClassFromPlane.First,new Purse(CurrencyType.USD, 200));
            PriceBusiness = new TicketOnPlane(ClassFromPlane.Business, new Purse(CurrencyType.USD, 100));
            PriceEconomy = new TicketOnPlane(ClassFromPlane.Economy, new Purse(CurrencyType.USD, 30));

            StatusOfFly = StatusOfFly.CheckIn;
            this.NameOfPlane = NameOfPlane;
            NumOfPlane = ++CountOfPlane;
            this.MaxPlaceFirstClass = MaxPlaceFirstClass;
            this.MaxPlaceBusinessClass = MaxPlaceBusinessClass;
            this.MaxPlaceEcomomyClass = MaxPlaceEcomomyClass;
            ListOfPeopleEconomyClass = new List<Person>();
            ListOfPeopleBusinessClass = new List<Person>();
            ListOfPeopleFirstClass = new List<Person>();
        }

        // append person in class list 
        public void AddToListEconomy(Person person)
        {
            if(CountOfPassagersEconomy() < MaxPlaceEcomomyClass)
            {
                ListOfPeopleEconomyClass.Add(person);
            }
            else
            {
                Console.WriteLine("Econom class is full");
            }
        }
        public void AddToListBusiness(Person person)
        {
            if (CountOfPassagersBusiness() < MaxPlaceBusinessClass)
            {
                ListOfPeopleBusinessClass.Add(person);
            }
            else
            {
                Console.WriteLine("Business class is full");
            }
            
        }
        public void AddToListFirst(Person person)
        {

            if (CountOfPassagersFirst() < MaxPlaceFirstClass)
            {
                ListOfPeopleFirstClass.Add(person);
            }
            else
            {
                Console.WriteLine("First class is full");
            }
            
        }

        // remove person in class list 
        public void RemoveFromListEconomy(Person person)
        {
            ListOfPeopleEconomyClass.Remove(person);
        }
        public void RemoveFromListBusiness(Person person)
        {
            ListOfPeopleBusinessClass.Remove(person);
        }
        public void RemoveFromListFirst(Person person)
        {
            ListOfPeopleFirstClass.Remove(person);
        }


        // Number of people in eveyone class
        public int CountOfPassagersEconomy() 
        {
            return ListOfPeopleEconomyClass.Count;
        }
        public int CountOfPassagersBusiness()
        {
            return ListOfPeopleBusinessClass.Count;
        }
        public int CountOfPassagersFirst()
        {
            return ListOfPeopleFirstClass.Count;
        }

        // All info from list classes
        public void AllInfoPassagers()
        {
            if(CountOfPassagersEconomy() > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Economy Class : ");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
                infoListEconomy();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Economy class is empty");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if(CountOfPassagersBusiness() > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Business Class : ");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
                infoListBusiness();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Business class is empty");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if(CountOfPassagersFirst() > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("First Class : ");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
                infoListFirst();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First class is empty");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }
        public override string ToString()
        {
            return $"Plane {NameOfPlane} with Number {NumOfPlane}  Status {StatusOfFly}";
        }

        void infoListEconomy()
        {
            foreach (var PersonFormEconomyClass in ListOfPeopleEconomyClass)
            {
                
                Console.WriteLine(PersonFormEconomyClass);
                Console.WriteLine("---------------------");
            }
        }
        void infoListBusiness()
        {
            foreach (var PersonFormBusinessClass in ListOfPeopleBusinessClass)
            {
                
                Console.WriteLine(PersonFormBusinessClass);
                Console.WriteLine("---------------------");
            }
        }
        void infoListFirst()
        {
            foreach (var PersonFormFirstClass in ListOfPeopleFirstClass)
            {
                
                Console.WriteLine(PersonFormFirstClass);
                Console.WriteLine("---------------------");
            }
        }
        public void SetStatusOfFly(StatusOfFly StatusOfFly)
        {
            this.StatusOfFly = StatusOfFly;
        }    
        public int GetFreePlaces()
        {
            return MaxPlaceBusinessClass + MaxPlaceEcomomyClass + MaxPlaceFirstClass -
                CountOfPassagersFirst() - CountOfPassagersEconomy() - CountOfPassagersBusiness();
        }
    }
}
