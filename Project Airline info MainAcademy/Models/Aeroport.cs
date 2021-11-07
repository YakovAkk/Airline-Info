using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Aeroport
    {
        private static Random UsersRandom = new Random();
        public int CountOfPeopleInArroport { get;private set; }
        private const int MinPeople = 200;
        private const int MaxPeople = 300;
        public string NameOfAeroport { get; private set; }
        public int CountOfPlace { get; private set; }
        public List<Plane> PlaceForPlane { get; private set; }
        public List<Person> PeopleInAeroport { get; private set; }

        //constructor
        public Aeroport(string NameOfAeroport, int countOfPlace)
        {
            PlaceForPlane = new List<Plane>();
            PeopleInAeroport = new List<Person>();
            CountOfPeopleInArroport = UsersRandom.Next(MinPeople, MaxPeople);
            this.NameOfAeroport = NameOfAeroport;
            this.CountOfPlace = countOfPlace;
            PeopleInAeroport = GetSomePeople();

        }
        // methoods List people
        public List<Person> GetListWithPeopleInAeroport()
        {
            return PeopleInAeroport;
        }
        private List<Person> GetSomePeople()
        {
            List<Person> People = new List<Person>();

            for (int i = 0; i < CountOfPeopleInArroport; i++)
            {
                People.Add(new Person(new Passport(), new Purse(),new TicketOnPlane()));
            }

            return People;
        }
        public List<Plane> GetPlanes()
        {
            return PlaceForPlane;
        }
        public void RemoveFromListWithPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                PeopleInAeroport.Remove(person);
            }
        }
        public int GetCountOfLitsWithPeopleInAeroport()
        {
            return PeopleInAeroport.Count();
        }
        public Plane FindThePlaneWithIndex(int index)
        {
            return PlaceForPlane.ElementAt(index - 1);
        }

        // methoods Listvwith plane
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
        
    }
}
