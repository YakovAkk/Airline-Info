using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Admin
    {
        public Timetable timetable { get; }
        public readonly List<Aeroport> aeroports = new List<Aeroport>();
        public readonly List<Plane> AllPlanes = new List<Plane>();
        public Admin()
        {
            AddAeroports();
            AddPlaneToList();
            AddPlaneToAeroport();
            timetable = new Timetable(aeroports);
        }
        private void AddAeroports()
        { 
            aeroports.Add(new Aeroport("Boryspil airport", 10));
            aeroports.Add(new Aeroport("Lviv airport", 8));
            aeroports.Add(new Aeroport("airport Kiev", 6));
            aeroports.Add(new Aeroport("Odessa airport", 6));
            aeroports.Add(new Aeroport("Kharkiv airport", 4));
        }
        private void AddPlaneToAeroport()
        {
            int counter = 0;
            foreach (var aeroport in aeroports)
            {
                for (int i = 0; i < aeroport.countOfPlace/2; i++)
                {
                    if(counter < AllPlanes.Count)
                    {
                        aeroport.AddPlaneToAeroport(AllPlanes.ElementAt(counter));
                        counter++;
                    }
                    
                }
                
            }
        }
        private void AddPlaneToList()
        {
            AllPlanes.Add(new Plane("Boeing737", 70, 50, 20));
            AllPlanes.Add(new Plane("Ту104", 75, 50, 30));
            AllPlanes.Add(new Plane("Boeing777Х", 77, 60, 10));
            AllPlanes.Add(new Plane("Boeing747", 80, 40, 10));
            AllPlanes.Add(new Plane("А380", 80, 40, 20));

            AllPlanes.Add(new Plane("Ту104", 75, 50, 30));
            AllPlanes.Add(new Plane("Boeing777Х", 77, 60, 10));
            AllPlanes.Add(new Plane("Boeing747", 80, 40, 10));
            AllPlanes.Add(new Plane("А380", 80, 40, 20));

            AllPlanes.Add(new Plane("Ту104", 75, 50, 30));
            AllPlanes.Add(new Plane("Boeing777Х", 77, 60, 10));
            AllPlanes.Add(new Plane("Ту104", 75, 50, 30));

            AllPlanes.Add(new Plane("Boeing777Х", 77, 60, 10));
            AllPlanes.Add(new Plane("Boeing747", 80, 40, 10));
            AllPlanes.Add(new Plane("Boeing777Х", 77, 60, 10));

            AllPlanes.Add(new Plane("Boeing747", 80, 40, 10));
            AllPlanes.Add(new Plane("Boeing777Х", 77, 60, 10));
            

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

        public Aeroport FindTheAeroportWithIndex(int index)
        {
            return aeroports.ElementAt(index - 1);
        }
    }
}
