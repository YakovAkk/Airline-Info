using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Aeroport
    {
        static Random random = new Random();
        int CountOfPeopleInArroport { get; set; }
        int MinPeople = 200;
        int MaxPeople = 300;
        string NameOfAeroport { get; }
        int countOfPlace { get; }
        List<Plane> placeForPlane = new List<Plane>();
        List<Person> peopleInAeroport = new List<Person>();
       
        public void RemoveFromListWithPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                peopleInAeroport.Remove(person);
            }
        }
        public List<Person> GetListWithPeopleInAeroport()
        {
            return peopleInAeroport;
        }
        public int GetCountOfLitsWithPeopleInAeroport()
        {
            return peopleInAeroport.Count();
        }
        public Aeroport(string NameOfAeroport, int countOfPlace)
        {
            CountOfPeopleInArroport = random.Next(MinPeople, MaxPeople);
            this.NameOfAeroport = NameOfAeroport; 
            this.countOfPlace = countOfPlace;
            peopleInAeroport = GetSomePeople();

        }
        public Plane FindThePlaneWithIndex(int index)
        {
            return placeForPlane.ElementAt(index - 1);
        }
        public void AddPlaneToAeroport(Plane plane)
        {
            if(CountOfPlane() < countOfPlace)
            {
                placeForPlane.Add(plane);
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
                if (placeForPlane.Contains(plane))
                {
                    placeForPlane.Remove(plane);
                }
                else
                {
                    Console.WriteLine("We don't have this plane in aerodrome");
                }
                
            }
                
        }
        public int CountOfPlane()
        {
            return placeForPlane.Count;
        }
        public void AllInfoAboutPlane()
        {
            int count = 1;
            foreach (var plane in placeForPlane)
            {
                Console.WriteLine( $"{count}) " + plane.ToString());
                count++;
            }
        }
        public override string ToString()
        {
            return $"Name {NameOfAeroport} \nIn the aerodrome {countOfPlace} places \nOccupied places {CountOfPlane()} \nFree places {countOfPlace - CountOfPlane()}";
        }

        public string GetName()
        {
            return NameOfAeroport;
        }
        private List<Person> GetSomePeople()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < CountOfPeopleInArroport; i++)
            {
                people.Add(new Person(new Passport(), new Purse()));
            }

            return people;
        }
        
        public List<Plane> GetPlanes()
        {
            return placeForPlane;
        }
        
    }
}
