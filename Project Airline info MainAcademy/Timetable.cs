using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Timetable
    {
        public static readonly List<Timetable> timetables = new List<Timetable>();

        static int CountOFRaces = 0;
        int NumOfRace { get; set; }
        string StartPoint { get; set; }
        string EndPoint { get; set; }
        string NameOfPlane { get; set;  }
        int CountOfFreePlaces { get; set; }

        DateTime StartTimeOfDeparture = new DateTime();
        DateTime EndTimeOfDeparture = new DateTime();

        public Timetable(List<Aeroport> aeroports) // for schedule management
        {
            AddToTimetable(aeroports);
        }
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

        public static void PrintTimetableForAeroport(Aeroport aeroport)
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
        public static void PrintTimetableForPlane(Plane plane)
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
        private void AddToTimetable(List<Aeroport> aeroports)
        {
            foreach (var aeroport1 in aeroports)
            {
                foreach (var aeroport2 in aeroports)
                {
                    if (aeroport1.GetName() == aeroport2.GetName())
                    {
                        break;
                    }
                    else
                    {
                        foreach (var item in aeroport2.GetPlanes())
                        {
                            timetables.Add(new Timetable(item.GetName(), aeroport1.GetName(), new DateTime().Date.AddDays(1), aeroport2.GetName(),
                            new DateTime().Date.AddDays(2), item.GetFreePlaces()));
                        }
                    }


                }
            }
        }
    }
}
