using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class TimetableModel
    {
        public static readonly List<TimetableModel> Timetables = new List<TimetableModel>();

        static int CountOFRaces = 0;
        public int NumOfRace { get; private set; }
        public string StartPoint { get; private set; }
        public string EndPoint { get; private set; }
        public string NameOfPlane { get; private set;  }
        public int CountOfFreePlaces { get; private set; }

        public DateTime StartTimeOfDeparture { get; private set; }
        public DateTime EndTimeOfDeparture { get; private set; }

        public TimetableModel(List<AeroportModel> TempAeroports) // for schedule management
        {
            AddToTimetable(TempAeroports);
        }
        public TimetableModel(string NameOfPlane, string StartPoint ,DateTime StartTimeOfDeparture, string EndPoint ,
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

        public static void PrintTimetableForAeroport(AeroportModel TempAeroports)
        {
            foreach (var Timetable in Timetables)
            {
                if (Timetable.StartPoint == TempAeroports.NameOfAeroport || Timetable.EndPoint == TempAeroports.NameOfAeroport)
                {
                    Console.WriteLine(Timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }
        public static void PrintTimetableForPlane(PlaneModel TempPlane)
        {
            foreach (var Timetable in Timetables)
            {
                if (Timetable.NameOfPlane == TempPlane.NameOfPlane)
                {
                    Console.WriteLine(Timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }
        private void AddToTimetable(List<AeroportModel> Tempaeroports)
        {
            foreach (var Aeroport1 in Tempaeroports)
            {
                foreach (var Aeroport2 in Tempaeroports)
                {
                    if (Aeroport1.NameOfAeroport == Aeroport2.NameOfAeroport)
                    {
                        break;
                    }
                    else
                    {
                        foreach (var item in Aeroport2.GetPlanes())
                        {
                            Timetables.Add(new TimetableModel(item.NameOfPlane, Aeroport1.NameOfAeroport, new DateTime().Date.AddDays(1), Aeroport2.NameOfAeroport,
                            new DateTime().Date.AddDays(2), item.GetFreePlaces()));
                        }
                    }


                }
            }
        }
    }
}
