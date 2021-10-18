using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    enum StatusOfFly
    {
        Unknown = 0,
        CheckIn,
        GateClosed,
        Arrived,
        DepartedAt,
        Canceled,
        ExpectedAt,
        Delayed,
        InFlight,
    }
    class Plane // every palne division on 3 part - economy class , business class , and first class
    {
        StatusOfFly StatusOfFly = new StatusOfFly();
        static int CountOfPlane = 0;
        int NumOfPlane = 0;

        string NameOfPlane { get; set; }
        // count of place in every class
        int MaxPlaceFirstClass { get; set; }
        int MaxPlaceBusinessClass { get; set; }
        int MaxPlaceEcomomyClass { get; set; }


        // price for one place in every class
        Purse priceFirst = new Purse(CurrencyType.USD, 200);

        Purse priceBusiness = new Purse(CurrencyType.USD, 100);

        Purse priceEconomy = new Purse(CurrencyType.USD, 30);


        // Get price for classes
        public Purse GetPriceFirstClass()
        {
            return priceFirst;
        }
        public Purse GetPriceBusinessClass()
        {
            return priceBusiness;
        }
        public Purse GetPriceEconomyClass()
        {
            return priceEconomy;
        }

        // lists with person in everyone class
        List<Person> listOfPeopleEconomyClass;
        List<Person> listOfPeopleBusinessClass;
        List<Person> listOfPeopleFirstClass;

        // Get list with people in each class
        public List<Person> GetListWithPeopleInPlaneFirstClass()
        {
            return listOfPeopleFirstClass;
        }
        public List<Person> GetListWithPeopleInPlaneBusinessClass()
        {
            return listOfPeopleBusinessClass;
        }
        public List<Person> GetListWithPeopleInPlaneEconomyClass()
        {
            return listOfPeopleEconomyClass;
        }

        //constructor
        public Plane()
        {
            StatusOfFly = StatusOfFly.Unknown;
            NumOfPlane = ++CountOfPlane;
            MaxPlaceFirstClass = 0;
            MaxPlaceBusinessClass = 0;
            MaxPlaceEcomomyClass = 0;
            listOfPeopleEconomyClass = new List<Person>();
            listOfPeopleBusinessClass = new List<Person>();
            listOfPeopleFirstClass = new List<Person>();
        }
        public Plane(string NameOfPlane , int MaxPlaceEcomomyClass, int MaxPlaceBusinessClass , int MaxPlaceFirstClass)
        {
            StatusOfFly = StatusOfFly.CheckIn;
            this.NameOfPlane = NameOfPlane;
            NumOfPlane = ++CountOfPlane;
            this.MaxPlaceFirstClass = MaxPlaceFirstClass;
            this.MaxPlaceBusinessClass = MaxPlaceBusinessClass;
            this.MaxPlaceEcomomyClass = MaxPlaceEcomomyClass;
            listOfPeopleEconomyClass = new List<Person>();
            listOfPeopleBusinessClass = new List<Person>();
            listOfPeopleFirstClass = new List<Person>();
        }

        // append person in class list 
        public void AddToListEconomy(Person person)
        {
            if(CountOfPassagersEconomy() < MaxPlaceEcomomyClass)
            {
                listOfPeopleEconomyClass.Add(person);
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
                listOfPeopleBusinessClass.Add(person);
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
                listOfPeopleFirstClass.Add(person);
            }
            else
            {
                Console.WriteLine("First class is full");
            }
            
        }

        // remove person in class list 
        public void RemoveFromListEconomy(Person person)
        {
            listOfPeopleEconomyClass.Remove(person);
        }
        public void RemoveFromListBusiness(Person person)
        {
            listOfPeopleBusinessClass.Remove(person);
        }
        public void RemoveFromListFirst(Person person)
        {
            listOfPeopleFirstClass.Remove(person);
        }


        // Number of people in eveyone class
        public int CountOfPassagersEconomy() 
        {
            return listOfPeopleEconomyClass.Count;
        }
        public int CountOfPassagersBusiness()
        {
            return listOfPeopleBusinessClass.Count;
        }
        public int CountOfPassagersFirst()
        {
            return listOfPeopleFirstClass.Count;
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
            foreach (var item in listOfPeopleEconomyClass)
            {
                
                Console.WriteLine(item);
                Console.WriteLine("---------------------");
            }
        }
        void infoListBusiness()
        {
            foreach (var item in listOfPeopleBusinessClass)
            {
                
                Console.WriteLine(item);
                Console.WriteLine("---------------------");
            }
        }
        void infoListFirst()
        {
            foreach (var item in listOfPeopleFirstClass)
            {
                
                Console.WriteLine(item);
                Console.WriteLine("---------------------");
            }
        }
        public void SetStatusOfFly(StatusOfFly StatusOfFly)
        {
            this.StatusOfFly = StatusOfFly;
        }

        public StatusOfFly GetStatusOfFly()
        {
            return StatusOfFly;
        }

        public string GetName()
        {
            return NameOfPlane;
        }
        
        public int GetFreePlaces()
        {
            return MaxPlaceBusinessClass + MaxPlaceEcomomyClass + MaxPlaceFirstClass -
                CountOfPassagersFirst() - CountOfPassagersEconomy() - CountOfPassagersBusiness();
        }
    }
}
