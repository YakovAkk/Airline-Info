using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Timetable
    {
        static List<Timetable> timetables = new List<Timetable>();

        static int CountOFRaces = 0;
        int NumOfRace { get; set; }
        string StartPoint { get; set; }
        string EndPoint { get; set; }
        string NameOfPlane { get; set;  }
        int CountOfFreePlaces { get; set; }

        DateTime StartTimeOfDeparture = new DateTime();
        DateTime EndTimeOfDeparture = new DateTime();
        public Timetable(string NameOfPlane, string StartPoint ,DateTime StartTimeOfDeparture, string EndPoint ,
            DateTime EndTimeOfDeparture , int CountOfFreePlaces)
        {
            NumOfRace = CountOFRaces++;
            this.NameOfPlane = NameOfPlane;
            this.StartPoint = StartPoint;
            this.StartTimeOfDeparture = StartTimeOfDeparture;
            this.EndPoint = EndPoint;
            this.EndTimeOfDeparture = EndTimeOfDeparture;
            this.CountOfFreePlaces = CountOfFreePlaces;
        }
        public override string ToString()
        {
            return $"Num : {NumOfRace} \nName : {NameOfPlane} \nStart : {StartPoint} {StartTimeOfDeparture}" +
                $" \nEnd : {EndPoint} {EndTimeOfDeparture} " +
                $" \nFree Place : {CountOfFreePlaces}";
        }

        public string GetStartPoint()
        {
            return StartPoint;
        }
        public string GetEndPoint()
        {
            return EndPoint;
        }
        public string GetNameOfPlane()
        {
            return NameOfPlane;
        }

        private void PrintTimetableForAeroport(Aeroport aeroport)
        {
            foreach (var timetable in timetables)
            {
                if (timetable.GetStartPoint() == aeroport.GetName() || timetable.GetEndPoint() == aeroport.GetName())
                {
                    Console.WriteLine(timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }
        private void PrintTimetableForPlane(Plane plane)
        {
            foreach (var timetable in timetables)
            {
                if (timetable.GetNameOfPlane() == plane.GetName())
                {
                    Console.WriteLine(timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }

        private void AddToTimetable(Aeroport aeroport1, Aeroport aeroport2)
        {
            foreach (var item in aeroport1.GetPlanes())
            {
                timetables.Add(new Timetable(item.GetName(), aeroport1.GetName(), new DateTime().Date.AddDays(1), aeroport2.GetName(),
                    new DateTime().Date.AddDays(2), item.GetFreePlaces()));
            }
        }
    }
}
