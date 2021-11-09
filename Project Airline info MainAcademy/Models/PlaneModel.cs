using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    
    class PlaneModel // every palne division on 3 part - economy class , business class , and first class
    {
        public StatusOfFlyModel StatusOfFly { get; private set; }
        private static int CountOfPlane = 0;
        private int NumOfPlane = 0;

        public string NameOfPlane { get;private set; }
        // count of place in every class
        public int MaxPlaceFirstClass { get; private set; }
        public int MaxPlaceBusinessClass { get; private set; }
        public int MaxPlaceEcomomyClass { get; private set; }

        // Count of passagers

        public int CountPassagersInsideFirstClass { get; private set; }
        public int CountPassagersInsideBusinessClass { get; private set; }
        public int CountPassagersInsideEconomyClass { get; private set; }

        // price for one place in every class
        public TicketOnPlaneModel PriceFirst { get; private set; }
        public TicketOnPlaneModel PriceBusiness { get; private set; }
        public TicketOnPlaneModel PriceEconomy { get; private set; }


        // lists with person in everyone class
        public List<PersonModel> ListOfPeople { get; private set; }
        //constructor

        public PlaneModel(string NameOfPlane , int MaxPlaceEcomomyClass, int MaxPlaceBusinessClass , int MaxPlaceFirstClass)
        {
            PriceFirst = new TicketOnPlaneModel(ClassFromPlaneModel.First,new PurseModel(CurrencyTypeModel.USD, 200));
            PriceBusiness = new TicketOnPlaneModel(ClassFromPlaneModel.Business, new PurseModel(CurrencyTypeModel.USD, 100));
            PriceEconomy = new TicketOnPlaneModel(ClassFromPlaneModel.Economy, new PurseModel(CurrencyTypeModel.USD, 30));

            StatusOfFly = StatusOfFlyModel.CheckIn;
            this.NameOfPlane = NameOfPlane;
            NumOfPlane = ++CountOfPlane;
            this.MaxPlaceFirstClass = MaxPlaceFirstClass;
            this.MaxPlaceBusinessClass = MaxPlaceBusinessClass;
            this.MaxPlaceEcomomyClass = MaxPlaceEcomomyClass;
            ListOfPeople = new List<PersonModel>();
          
        }

        // append person in class list 
        public void AddToList(PersonModel person)
        {
            if(CountPassagersInsideEconomyClass < MaxPlaceEcomomyClass && person.PersonsTicket.ClassTicket == ClassFromPlaneModel.Economy)
            {
                ListOfPeople.Add(person);
                CountPassagersInsideEconomyClass++;
            }
           

            if (CountPassagersInsideBusinessClass < MaxPlaceEcomomyClass && person.PersonsTicket.ClassTicket == ClassFromPlaneModel.Business)
            {
                ListOfPeople.Add(person);
                CountPassagersInsideBusinessClass++;
            }
            

            if (CountPassagersInsideFirstClass < MaxPlaceEcomomyClass && person.PersonsTicket.ClassTicket == ClassFromPlaneModel.First)
            {
                ListOfPeople.Add(person);
                CountPassagersInsideFirstClass++;
            }
            
        }


        // remove person in class list 
        public void RemoveFromList(PersonModel person)
        {
            ListOfPeople.Remove(person);
        }

        // Number of people in eveyone class

        // All info from list classes
        public void AllInfoPassagers()
        {
            if(CountPassagersInsideEconomyClass > 0)
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
            if(CountPassagersInsideBusinessClass > 0)
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
            if(CountPassagersInsideFirstClass > 0)
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

        private void infoListEconomy()
        {
            foreach (var PersonFormEconomyClass in ListOfPeople)
            {
                if(PersonFormEconomyClass.PersonsTicket.ClassTicket == ClassFromPlaneModel.Economy)
                {
                    Console.WriteLine(PersonFormEconomyClass);
                    Console.WriteLine("---------------------");
                }
                
            }
        }
        private void infoListBusiness()
        {
            foreach (var PersonFormBusinessClass in ListOfPeople)
            {
                if(PersonFormBusinessClass.PersonsTicket.ClassTicket == ClassFromPlaneModel.Business)
                {
                    Console.WriteLine(PersonFormBusinessClass);
                    Console.WriteLine("---------------------");
                }
                
            }
        }
        private void infoListFirst()
        {
            foreach (var PersonFormFirstClass in ListOfPeople)
            {
                if(PersonFormFirstClass.PersonsTicket.ClassTicket == ClassFromPlaneModel.First)
                {
                    Console.WriteLine(PersonFormFirstClass);
                    Console.WriteLine("---------------------");
                }
                
            }
        }
        public void SetStatusOfFly(StatusOfFlyModel StatusOfFly)
        {
            this.StatusOfFly = StatusOfFly;
        }    
        public int GetFreePlaces()
        {
            return MaxPlaceBusinessClass + MaxPlaceEcomomyClass + MaxPlaceFirstClass -
                CountPassagersInsideEconomyClass - CountPassagersInsideBusinessClass - CountPassagersInsideFirstClass;
        }
    }
}
