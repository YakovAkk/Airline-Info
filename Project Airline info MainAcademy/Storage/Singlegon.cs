using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy.Storage
{
    class SingleStorage
    {
        public TimetableModel timetable { get; }
        public List<AeroportModel> aeroports { get; }
        public List<PlaneModel> allPlanes { get; }
        private static SingleStorage myStorage { get; set; }
        private SingleStorage()
        {
            aeroports = new List<AeroportModel>();
            allPlanes = new List<PlaneModel>();
            AddAeroports();
            AddPlaneToList();
            AddPlaneToAeroport();
            timetable = new TimetableModel(aeroports);
        }
        public static SingleStorage GetInstance()
        {
            if(myStorage == null)
            {
                myStorage = new SingleStorage();
            }

            return myStorage;
        }
        private void AddAeroports()
        {
            aeroports.Add(new AeroportModel("Boryspil airport", 10));
            aeroports.Add(new AeroportModel("Lviv airport", 8));
            aeroports.Add(new AeroportModel("airport Kiev", 6));
            aeroports.Add(new AeroportModel("Odessa airport", 6));
            aeroports.Add(new AeroportModel("Kharkiv airport", 4));
        }
        private void AddPlaneToAeroport()
        {
            int counter = 0;
            foreach (var aeroport in aeroports)
            {
                for (int i = 0; i < aeroport.CountOfPlace / 2; i++)
                {
                    if (counter < allPlanes.Count)
                    {
                        aeroport.AddPlaneToAeroport(allPlanes.ElementAt(counter));
                        counter++;
                    }

                }

            }
        }
        private void AddPlaneToList()
        {
            allPlanes.Add(new PlaneModel("Boeing737", 70, 50, 20));
            allPlanes.Add(new PlaneModel("Ту104", 75, 50, 30));
            allPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));
            allPlanes.Add(new PlaneModel("Boeing747", 80, 40, 10));
            allPlanes.Add(new PlaneModel("А380", 80, 40, 20));

            allPlanes.Add(new PlaneModel("Ту104", 75, 50, 30));
            allPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));
            allPlanes.Add(new PlaneModel("Boeing747", 80, 40, 10));
            allPlanes.Add(new PlaneModel("А380", 80, 40, 20));

            allPlanes.Add(new PlaneModel("Ту104", 75, 50, 30));
            allPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));
            allPlanes.Add(new PlaneModel("Ту104", 75, 50, 30));

            allPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));
            allPlanes.Add(new PlaneModel("Boeing747", 80, 40, 10));
            allPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));

            allPlanes.Add(new PlaneModel("Boeing747", 80, 40, 10));
            allPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));


        }
        public AeroportModel FindTheAeroportWithIndex(int index)
        {
            return myStorage.aeroports.ElementAt(index - 1);
        }
    }
}
