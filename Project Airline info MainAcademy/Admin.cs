using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Admin
    {
        public static readonly List<Timetable> timetables = new List<Timetable>();
        public readonly Aeroport BoryspilAero = new Aeroport("Boryspil airport", 10);
        public readonly Aeroport LvivAero = new Aeroport("Lviv airport", 8);
        public readonly Aeroport KievAero = new Aeroport("airport Kiev", 6);
        public readonly Aeroport OdessaAero = new Aeroport("Odessa airport", 6);
        public readonly Aeroport KharkivAero = new Aeroport("Kharkiv airport", 4);

        public Admin()
        {
            AddPlanesToAeroports();
            AddToListTimetable();
        }

        public async void DepartAtNextAero(Plane TempPlane, Aeroport aeroport)
        {
            await Task.Run(() =>
            {
                TempPlane.SetStatusOfFly(StatusOfFly.DepartedAt);
                Console.Clear();
                Console.WriteLine(TempPlane.ToString() + "Will arrive to " + aeroport.GetName() + "in 3 min 20 sec");
                Task.Delay(200000); // 3 min 20 sec

                aeroport.AddPlaneToAeroport(TempPlane);
                TempPlane.SetStatusOfFly(StatusOfFly.Arrived);
            });
        }
        private  void AddToTimetable(Aeroport aeroport1, Aeroport aeroport2)
        {
            foreach (var item in aeroport1.GetPlanes())
            {
                timetables.Add(new Timetable(item.GetName(), aeroport1.GetName(), new DateTime().Date.AddDays(1), aeroport2.GetName(),
                    new DateTime().Date.AddDays(2), item.GetFreePlaces()));
            }
        }
        public void AddToListTimetable()
        {
            AddToTimetable(BoryspilAero, LvivAero);
            AddToTimetable(BoryspilAero, KievAero);
            AddToTimetable(BoryspilAero, OdessaAero);
            AddToTimetable(BoryspilAero, KharkivAero);
            AddToTimetable(LvivAero, KievAero);
            AddToTimetable(LvivAero, OdessaAero);
            AddToTimetable(LvivAero, KharkivAero);
            AddToTimetable(KievAero, OdessaAero);
            AddToTimetable(KievAero, KharkivAero);
            AddToTimetable(OdessaAero, KharkivAero);
        }
        public void PrintTimetableForAeroport(Aeroport aeroport)
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
        public void PrintTimetableForPlane(Plane plane)
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
        private void AddPlanesToAeroports()
        {
            // Boruspil
            var Boeing737 = new Plane("Boeing737", 70, 50, 20);
            var Ту104 = new Plane("Ту104", 75, 50, 30);
            var Boeing777Х = new Plane("Boeing777Х", 77, 60, 10);
            var Boeing747 = new Plane("Boeing747", 80, 40, 10);
            var А380 = new Plane("А380", 80, 40, 20);

            BoryspilAero.AddPlaneToAeroport(Boeing737);
            BoryspilAero.AddPlaneToAeroport(Ту104);
            BoryspilAero.AddPlaneToAeroport(Boeing777Х);
            BoryspilAero.AddPlaneToAeroport(Boeing747);
            BoryspilAero.AddPlaneToAeroport(А380);

            // Kharkiv
            var Boeing730 = new Plane("Boeing737", 70, 50, 20);
            var Ту100 = new Plane("Ту104", 75, 50, 30);

            KharkivAero.AddPlaneToAeroport(Boeing730);
            KharkivAero.AddPlaneToAeroport(Ту100);

            // Odessa

            var Boeing777 = new Plane("Boeing777Х", 77, 60, 10);
            var Boeing740 = new Plane("Boeing747", 80, 40, 10);
            var А381 = new Plane("А380", 80, 40, 20);

            OdessaAero.AddPlaneToAeroport(Boeing777);
            OdessaAero.AddPlaneToAeroport(Boeing740);
            OdessaAero.AddPlaneToAeroport(А381);

            // Kiev

            var Boeing731 = new Plane("Boeing737", 70, 50, 20);
            var Ту101 = new Plane("Ту104", 75, 50, 30);
            var Boeing666 = new Plane("Boeing777Х", 77, 60, 10);

            KievAero.AddPlaneToAeroport(Boeing731);
            KievAero.AddPlaneToAeroport(Ту101);
            KievAero.AddPlaneToAeroport(Boeing666);

            // Lviv

            var Boeing732 = new Plane("Boeing737", 70, 50, 20);
            var Ту102 = new Plane("Ту104", 75, 50, 30);
            var Boeing444 = new Plane("Boeing777Х", 77, 60, 10);
            var Boeing742 = new Plane("Boeing747", 80, 40, 10);


            LvivAero.AddPlaneToAeroport(Boeing732);
            LvivAero.AddPlaneToAeroport(Ту102);
            LvivAero.AddPlaneToAeroport(Boeing444);
            LvivAero.AddPlaneToAeroport(Boeing742);
        }

    }
}
