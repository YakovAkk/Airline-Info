using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    
    class PlaneModel // every palne division on 3 part - economy class , business class , and first class
    {
        public StatusOfFly StatusOfFly { get; private set; }
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
            PriceFirst = new TicketOnPlaneModel(ClassFromPlane.First,new PurseModel(CurrencyType.USD, 200));
            PriceBusiness = new TicketOnPlaneModel(ClassFromPlane.Business, new PurseModel(CurrencyType.USD, 100));
            PriceEconomy = new TicketOnPlaneModel(ClassFromPlane.Economy, new PurseModel(CurrencyType.USD, 30));

            StatusOfFly = StatusOfFly.CheckIn;
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
            if(CountPassagersInsideEconomyClass < MaxPlaceEcomomyClass && person.PersonsTicket.ClassTicket == ClassFromPlane.Economy)
            {
                ListOfPeople.Add(person);
                CountPassagersInsideEconomyClass++;
            }
           

            if (CountPassagersInsideBusinessClass < MaxPlaceEcomomyClass && person.PersonsTicket.ClassTicket == ClassFromPlane.Business)
            {
                ListOfPeople.Add(person);
                CountPassagersInsideBusinessClass++;
            }
            

            if (CountPassagersInsideFirstClass < MaxPlaceEcomomyClass && person.PersonsTicket.ClassTicket == ClassFromPlane.First)
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
        
        public override string ToString()
        {
            return $"Plane {NameOfPlane} with Number {NumOfPlane}  Status {StatusOfFly}";
        }

      
        public void SetStatusOfFly(StatusOfFly StatusOfFly)
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
