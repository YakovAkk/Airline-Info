using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class AeroportModel
    {
        private static Random UsersRandom = new Random();
        public int CountOfPeopleInArroport { get;private set; }
        private const int MinPeople = 200;
        private const int MaxPeople = 300;
        public string NameOfAeroport { get; private set; }
        public int CountOfPlace { get; private set; }
        public List<PlaneModel> PlaceForPlane { get; private set; }
        public List<PersonModel> PeopleInAeroport { get; private set; }

        //constructor
        public AeroportModel(string NameOfAeroport, int CountOfPlace)
        {
            PlaceForPlane = new List<PlaneModel>();
            PeopleInAeroport = new List<PersonModel>();
            CountOfPeopleInArroport = UsersRandom.Next(MinPeople, MaxPeople);
            this.NameOfAeroport = NameOfAeroport;
            this.CountOfPlace = CountOfPlace;
            PeopleInAeroport = GetSomePeople();

        }
        // methoods List people
        public List<PersonModel> GetListWithPeopleInAeroport()
        {
            return PeopleInAeroport;
        }
        private List<PersonModel> GetSomePeople()
        {
            List<PersonModel> People = new List<PersonModel>();

            for (int i = 0; i < CountOfPeopleInArroport; i++)
            {
                People.Add(new PersonModel(new PassportModel(), new PurseModel(),new TicketOnPlaneModel()));
            }

            return People;
        }
        public List<PlaneModel> GetPlanes()
        {
            return PlaceForPlane;
        }
        public void RemoveFromListWithPeople(List<PersonModel> People)
        {
            foreach (var Person in People)
            {
                PeopleInAeroport.Remove(Person);
            }
        }
        public int GetCountOfLitsWithPeopleInAeroport()
        {
            return PeopleInAeroport.Count();
        }
        public PlaneModel FindThePlaneWithIndex(int Index)
        {
            if (Index <= CountOfPlane() && Index > 0)
            {
                return PlaceForPlane.ElementAt(Index - 1);
                
            }
            else
            {
                return null;
            }
            
        }

        // methoods Listvwith plane
        public void AddPlaneToAeroport(PlaneModel Plane)
        {
            if(CountOfPlane() < CountOfPlace)
            {
                PlaceForPlane.Add(Plane);
            }
            else
            {
                Console.WriteLine("Aerodrome is full");
            }
            
        }
        public void RemovePlaneFromAeroport(PlaneModel Plane)
        {      
            if(CountOfPlane() == 0)
            {
                Console.WriteLine("We have any plane");
            }
            else
            {
                if (PlaceForPlane.Contains(Plane))
                {
                    PlaceForPlane.Remove(Plane);
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
            int Count = 1;
            foreach (var Plane in PlaceForPlane)
            {
                Console.WriteLine( $"{Count}) " + Plane.ToString());
                Count++;
            }
        }
        public override string ToString()
        {
            return $"Name {NameOfAeroport} \nIn the aerodrome {CountOfPlace} places \nOccupied places {CountOfPlane()} \nFree places {CountOfPlace - CountOfPlane()}";
        }
        
    }
}
