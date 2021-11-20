using Project_Airline_info_MainAcademy.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy.Storage
{
    class SingleStorage
    {
        private HttpController _httpController { get; }
        private ParseConrtoller _parseModel { get; }
        public TimetableModel timetable { get; }
        public List<AeroportModel> aeroports { get; private set; }
        public List<PlaneModel> allPlanes { get; private set; }
        private static SingleStorage myStorage;
        private SingleStorage()
        {
            aeroports = new List<AeroportModel>();
            allPlanes = new List<PlaneModel>();
            _parseModel = new ParseConrtoller();
            _httpController = new HttpController();


            //AddAeroportsFromServer();
            //AddPlanesFromServer();


            AddAeroportsFromFile();
            AddPlanesFromFile();


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
        private void AddAeroportsFromFile()
        {
            string path = @"Aeroports.json";

            aeroports = _parseModel.ReadFromFileAeroport(path);
        }
        private void AddPlanesFromFile()
        {
            string path = @"Plane.json";
            allPlanes = _parseModel.ReadFromFilePlane(path);
        }
        private void AddAeroportsFromServer()
        {
            aeroports = _parseModel.ReadFromServerAeroport(_httpController.ParseAeroports());
        }
        private void AddPlanesFromServer()
        {
            allPlanes = _parseModel.ReadFromServerPlane(_httpController.ParsePlanes());
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

        public bool RemovePlaneFromList(PlaneModel plane)
        {
            if(plane != null)
            {
                allPlanes.Remove(plane);
                return true;
            }
            else
            {
                return false;
            }
        }
        public AeroportModel FindTheAeroportWithIndex(int index)
        {
            return myStorage.aeroports.ElementAt(index - 1);
        }
    }
}
