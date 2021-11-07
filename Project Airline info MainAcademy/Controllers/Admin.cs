using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Admin
    {
        public Timetable Timetable { get; private set; }
        public List<Aeroport> Aeroports { get; private set; }
        public List<Plane> AllPlanes { get; private set; }

        // constructor
        public Admin()
        {
            Aeroports = new List<Aeroport>();
            AllPlanes = new List<Plane>();
            AddAeroports();
            AddPlaneToList();
            AddPlaneToAeroport();
            Timetable = new Timetable(Aeroports);
        }
        private void AddAeroports()
        { 
            Aeroports.Add(new Aeroport("Boryspil airport", 10));
            Aeroports.Add(new Aeroport("Lviv airport", 8));
            Aeroports.Add(new Aeroport("airport Kiev", 6));
            Aeroports.Add(new Aeroport("Odessa airport", 6));
            Aeroports.Add(new Aeroport("Kharkiv airport", 4));
        }
        private void AddPlaneToAeroport()
        {
            int counter = 0;
            foreach (var aeroport in Aeroports)
            {
                for (int i = 0; i < aeroport.CountOfPlace/2; i++)
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
        public void DepartAtNextAero(Plane TempPlane, Aeroport Aeroport)
        {
            Task.Run(() =>
            {
                TempPlane.SetStatusOfFly(StatusOfFly.DepartedAt);
                Console.Clear();
                Console.WriteLine(TempPlane.ToString() + "Will arrive to " + Aeroport.NameOfAeroport + "in 3 min 20 sec");
                Task.Delay(200000); // 3 min 20 sec

                Aeroport.AddPlaneToAeroport(TempPlane);
                TempPlane.SetStatusOfFly(StatusOfFly.Arrived);
            });
        }
        public Aeroport FindTheAeroportWithIndex(int index)
        {
            return Aeroports.ElementAt(index - 1);
        }
    }
}
