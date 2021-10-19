using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Timetable
    {
        public static readonly List<Timetable> Timetables = new List<Timetable>();

        static int CountOFRaces = 0;
        int NumOfRace { get; set; }
        string StartPoint { get; set; }
        string EndPoint { get; set; }
        string NameOfPlane { get; set;  }
        int CountOfFreePlaces { get; set; }

        DateTime StartTimeOfDeparture = new DateTime();
        DateTime EndTimeOfDeparture = new DateTime();

        public Timetable(List<Aeroport> TempAeroports) // for schedule management
        {
            AddToTimetable(TempAeroports);
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

        public static void PrintTimetableForAeroport(Aeroport TempAeroports)
        {
            foreach (var Timetable in Timetables)
            {
                if (Timetable.GetStartPoint() == TempAeroports.GetName() || Timetable.GetEndPoint() == TempAeroports.GetName())
                {
                    Console.WriteLine(Timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }
        public static void PrintTimetableForPlane(Plane TempPlane)
        {
            foreach (var Timetable in Timetables)
            {
                if (Timetable.GetNameOfPlane() == TempPlane.GetName())
                {
                    Console.WriteLine(Timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }
        private void AddToTimetable(List<Aeroport> Tempaeroports)
        {
            foreach (var Aeroport1 in Tempaeroports)
            {
                foreach (var Aeroport2 in Tempaeroports)
                {
                    if (Aeroport1.GetName() == Aeroport2.GetName())
                    {
                        break;
                    }
                    else
                    {
                        foreach (var item in Aeroport2.GetPlanes())
                        {
                            Timetables.Add(new Timetable(item.GetName(), Aeroport1.GetName(), new DateTime().Date.AddDays(1), Aeroport2.GetName(),
                            new DateTime().Date.AddDays(2), item.GetFreePlaces()));
                        }
                    }


                }
            }
        }
    }
}
