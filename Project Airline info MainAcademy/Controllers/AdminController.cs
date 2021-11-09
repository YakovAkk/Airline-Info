﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class AdminController
    {
        public TimetableModel Timetable { get; private set; }
        public List<AeroportModel> Aeroports { get; private set; }
        public List<PlaneModel> AllPlanes { get; private set; }
        ViewConsole MyViewConsole = new ViewConsole();
        // constructor
        public AdminController()
        {
            Aeroports = new List<AeroportModel>();
            AllPlanes = new List<PlaneModel>();
            AddAeroports();
            AddPlaneToList();
            AddPlaneToAeroport();
            Timetable = new TimetableModel(Aeroports);
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

        public void DepartDepartThePlaneToNextAeroport(int NumOfPlane, AeroportModel TempAeroport)
        {
            if (NumOfPlane < TempAeroport.CountOfPlane() && NumOfPlane > 0)
            {
                var TempPlane = TempAeroport.FindThePlaneWithIndex(NumOfPlane);

                if (TempPlane.StatusOfFly == StatusOfFlyModel.GateClosed)
                {
                    MyViewConsole.ShowArrivedOfPlane();

                    var NumOfAeroport = Initialization("Your choose : ");


                    DepartThePlane(TempPlane, FindTheAeroportWithIndex(NumOfAeroport));

                    TempAeroport.RemovePlaneFromAeroport(TempPlane);

                }
                else
                {
                   MyViewConsole.ShowErrorOfArrived();
                }
            }
            else
            {
                MyViewConsole.ErrorOfPlane();
            }
        }
        private void DepartThePlane(PlaneModel TempPlane, AeroportModel Aeroport)
        {
            Task.Run(() =>
            {
                TempPlane.SetStatusOfFly(StatusOfFlyModel.DepartedAt);
                Console.Clear();
                Console.WriteLine(TempPlane.ToString() + "Will arrive to " + Aeroport.NameOfAeroport + "in 3 min 20 sec");
                Task.Delay(200000); // 3 min 20 sec

                Aeroport.AddPlaneToAeroport(TempPlane);
                TempPlane.SetStatusOfFly(StatusOfFlyModel.Arrived);
            });
        }
        public AeroportModel FindTheAeroportWithIndex(int index)
        {
            return Aeroports.ElementAt(index - 1);
        }
        private int Initialization(string Message = "")
        {
            int valueUser;
            while (true)
            {
                Console.Write(Message);

                try // ВЫНЕСТИ в ОТдельный метод
                {
                    valueUser = int.Parse(Console.ReadLine());

                    break;
                }
                catch (Exception)
                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("You enter INCORRECT data, try again");

                    Console.ForegroundColor = ConsoleColor.White;


                }
            }

            return valueUser;
        }
    }
}
