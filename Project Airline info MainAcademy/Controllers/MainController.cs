using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class MainController
    {
        
        private static AdminController UserAdmin = new AdminController();
        ViewConsole MyViewConsole = new ViewConsole();
        private PlaneModel UserPlane { get; set; }
        private AeroportModel UserAeroport { get; set; } 
        public MainController()
        {
            MyViewConsole.TimeableAeroportEvent += MyViewConsole_TimeableAeroportEvent;
            MyViewConsole.MainMenuEvent += MyViewConsole_MainMenu;
            MyViewConsole.CityAeroportMenuEvent += MyViewConsole_CityAeroportMenuMenu;
            MyViewConsole.MenuOfAeroportEvent += MyViewConsole_MenuOfAeroportEvent;
            MyViewConsole.PlaneEvent += MyViewConsole_PlaneEvent;
            MyViewConsole.MenuOfDepart += MyViewConsole_MenuOfDepart;
        }
        public void Stop()
        {
            MyViewConsole.MenuOfDepart -= MyViewConsole_MenuOfDepart;
            MyViewConsole.TimeableAeroportEvent -= MyViewConsole_TimeableAeroportEvent;
            MyViewConsole.MainMenuEvent -= MyViewConsole_MainMenu;
            MyViewConsole.CityAeroportMenuEvent -= MyViewConsole_CityAeroportMenuMenu;
            MyViewConsole.MenuOfAeroportEvent -= MyViewConsole_MenuOfAeroportEvent;
            MyViewConsole.PlaneEvent -= MyViewConsole_PlaneEvent;
        }
        private void MyViewConsole_MenuOfDepart(int Num)
        {
            UserAdmin.DepartDepartThePlaneToNextAeroport(Num,UserAeroport);
        }
        private void MyViewConsole_TimeableAeroportEvent(AeroportModel TempAeroport)
        {
            MyViewConsole.PrintTimetableForAeroport(TempAeroport, TimetableModel.Timetables);
        }
        private void MyViewConsole_PlaneEvent(int NumOfPlane)
        {
            UserPlane = UserAeroport.FindThePlaneWithIndex(NumOfPlane);
            if (NumOfPlane <= UserAeroport.CountOfPlane() && NumOfPlane > 0)
            {
                var TempPlane = UserAeroport.FindThePlaneWithIndex(NumOfPlane);
                MyViewConsole.MenuForPlane(TempPlane, UserAeroport);
            }
            else
            {
                MyViewConsole.ErrorOfPlane();
            }
        } 
        private void MyViewConsole_MenuOfAeroportEvent(int UsersNum)
        {

            switch (UsersNum)
            {
                case 1:
                    UserAeroport = UserAdmin.FindTheAeroportWithIndex(UsersNum);
                    MyViewConsole.MenuToEachPlaneInAeroport(UserAeroport);
                    break;

                case 2:
                    MyViewConsole.ViewDepartThePlaneToNextAeroport(UserAeroport);
                    
                    break;

                case 3:
                    MyViewConsole.ShowInfoAboutAeroport(UserAeroport);
                    break;

                case 4:

                    MyViewConsole.AllInfoAboutPlane(UserAeroport);
                    break;

                case 5:
                    MyViewConsole.ShowTimetableAboutAeroport(UserAeroport);
                    break;

                case 6:
                    MyViewConsole.MenuCityWithAeroport();
                    break;

                default:
                    break;
            }

        }
        private void MyViewConsole_MainMenu(int UsersChoise)
        {
            switch (UsersChoise)
            {
                case 1:
                    Console.Clear();
                    MyViewConsole.MenuCityWithAeroport();
                    break;

                case 2:
                    MyViewConsole.SayBye();
                    break;

                default:
                    break;
            }
        }
        private void MyViewConsole_CityAeroportMenuMenu(int UsersNumber)
        {
            UserAeroport = UserAdmin.FindTheAeroportWithIndex(UsersNumber);
           MyViewConsole.MenuOfAeroport(UserAeroport);
        }
        public void Run()
        {
            MyViewConsole.ShowMenu();
        }
    }
}
