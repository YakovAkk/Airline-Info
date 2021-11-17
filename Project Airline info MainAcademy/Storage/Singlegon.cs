using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy.Storage
{
    class SingleStorage
    {
        private ParseModel _parseModel { get; }
        public TimetableModel timetable { get; }
        public List<AeroportModel> aeroports { get; private set; }
        public List<PlaneModel> allPlanes { get; private set; }
        private static SingleStorage myStorage;
        private SingleStorage()
        {
            aeroports = new List<AeroportModel>();
            allPlanes = new List<PlaneModel>();
            _parseModel = new ParseModel();

            AddAeroports();
            AddPlanes();
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
        private async void AddAeroports()
        {
            string path = @"Aeroports.json";

            aeroports = await _parseModel.ReadFromFileAeroport(path);
        }

        private async void AddPlanes()
        {
            string path = @"Plane.json";
            allPlanes = await _parseModel.ReadFromFilePlane(path);
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
     
        public AeroportModel FindTheAeroportWithIndex(int index)
        {
            return myStorage.aeroports.ElementAt(index - 1);
        }
    }
}
