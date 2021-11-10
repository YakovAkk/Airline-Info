﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy.Storage
{
    class SingleStorage
    {
        public TimetableModel Timetable { get; private set; }
        public List<AeroportModel> Aeroports { get; private set; }
        public List<PlaneModel> AllPlanes { get; private set; }
        private static SingleStorage MyStorage { get; set; }
        private SingleStorage()
        {
            Aeroports = new List<AeroportModel>();
            AllPlanes = new List<PlaneModel>();
            AddAeroports();
            AddPlaneToList();
            AddPlaneToAeroport();
            Timetable = new TimetableModel(Aeroports);
        }
        public static SingleStorage GetInstance()
        {
            if(MyStorage == null)
            {
                MyStorage = new SingleStorage();
            }

            return MyStorage;
        }
        private void AddAeroports()
        {
            Aeroports.Add(new AeroportModel("Boryspil airport", 10));
            Aeroports.Add(new AeroportModel("Lviv airport", 8));
            Aeroports.Add(new AeroportModel("airport Kiev", 6));
            Aeroports.Add(new AeroportModel("Odessa airport", 6));
            Aeroports.Add(new AeroportModel("Kharkiv airport", 4));
        }
        private void AddPlaneToAeroport()
        {
            int counter = 0;
            foreach (var aeroport in Aeroports)
            {
                for (int i = 0; i < aeroport.CountOfPlace / 2; i++)
                {
                    if (counter < AllPlanes.Count)
                    {
                        aeroport.AddPlaneToAeroport(AllPlanes.ElementAt(counter));
                        counter++;
                    }

                }

            }
        }
        private void AddPlaneToList()
        {
            AllPlanes.Add(new PlaneModel("Boeing737", 70, 50, 20));
            AllPlanes.Add(new PlaneModel("Ту104", 75, 50, 30));
            AllPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));
            AllPlanes.Add(new PlaneModel("Boeing747", 80, 40, 10));
            AllPlanes.Add(new PlaneModel("А380", 80, 40, 20));

            AllPlanes.Add(new PlaneModel("Ту104", 75, 50, 30));
            AllPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));
            AllPlanes.Add(new PlaneModel("Boeing747", 80, 40, 10));
            AllPlanes.Add(new PlaneModel("А380", 80, 40, 20));

            AllPlanes.Add(new PlaneModel("Ту104", 75, 50, 30));
            AllPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));
            AllPlanes.Add(new PlaneModel("Ту104", 75, 50, 30));

            AllPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));
            AllPlanes.Add(new PlaneModel("Boeing747", 80, 40, 10));
            AllPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));

            AllPlanes.Add(new PlaneModel("Boeing747", 80, 40, 10));
            AllPlanes.Add(new PlaneModel("Boeing777Х", 77, 60, 10));


        }
        public AeroportModel FindTheAeroportWithIndex(int index)
        {
            return MyStorage.Aeroports.ElementAt(index - 1);
        }
    }
}