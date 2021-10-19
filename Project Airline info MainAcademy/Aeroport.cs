using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Aeroport
    {

        static Random UsersRandom = new Random();
        int CountOfPeopleInArroport { get; set; }
        int MinPeople = 200;
        int MaxPeople = 300;
        string NameOfAeroport { get; }
        public int CountOfPlace { get; }
        List<Plane> PlaceForPlane = new List<Plane>();
        List<Person> PeopleInAeroport = new List<Person>();
       
        public void RemoveFromListWithPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                PeopleInAeroport.Remove(person);
            }
        }
        public List<Person> GetListWithPeopleInAeroport()
        {
            return PeopleInAeroport;
        }
        public int GetCountOfLitsWithPeopleInAeroport()
        {
            return PeopleInAeroport.Count();
        }
        public Aeroport(string NameOfAeroport, int countOfPlace)
        {
            CountOfPeopleInArroport = UsersRandom.Next(MinPeople, MaxPeople);
            this.NameOfAeroport = NameOfAeroport; 
            this.CountOfPlace = countOfPlace;
            PeopleInAeroport = GetSomePeople();

        }
        public Plane FindThePlaneWithIndex(int index)
        {
            return PlaceForPlane.ElementAt(index - 1);
        }

        
        public void AddPlaneToAeroport(Plane plane)
        {
            if(CountOfPlane() < CountOfPlace)
            {
                PlaceForPlane.Add(plane);
            }
            else
            {
                Console.WriteLine("Aerodrome is full");
            }
            
        }
        public void RemovePlaneFromAeroport(Plane plane)
        {      
            if(CountOfPlane() == 0)
            {
                Console.WriteLine("We have any plane");
            }
            else
            {
                if (PlaceForPlane.Contains(plane))
                {
                    PlaceForPlane.Remove(plane);
                }
                else
                {
                    Console.WriteLine("We don't have this plane in aerodrome");
                }
                
            }
                
        }
        public int CountOfPlane()
        {
            return PlaceForPlane.Count;
        }
        public void AllInfoAboutPlane()
        {
            int count = 1;
            foreach (var plane in PlaceForPlane)
            {
                Console.WriteLine( $"{count}) " + plane.ToString());
                count++;
            }
        }
        public override string ToString()
        {
            return $"Name {NameOfAeroport} \nIn the aerodrome {CountOfPlace} places \nOccupied places {CountOfPlane()} \nFree places {CountOfPlace - CountOfPlane()}";
        }

        public string GetName()
        {
            return NameOfAeroport;
        }
        private List<Person> GetSomePeople()
        {
            List<Person> People = new List<Person>();

            for (int i = 0; i < CountOfPeopleInArroport; i++)
            {
                People.Add(new Person(new Passport(), new Purse()));
            }

            return People;
        }
        
        public List<Plane> GetPlanes()
        {
            return PlaceForPlane;
        }
        
    }
}
