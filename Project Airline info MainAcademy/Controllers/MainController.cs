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
        
       
        public MainController()
        {
            MyViewConsole.MainMenuEvent += MyViewConsole_MainMenu;
            MyViewConsole.CityAeroportMenuEvent += MyViewConsole_CityAeroportMenuMenu;
            MyViewConsole.MenuOfAeroportEvent += MyViewConsole_MenuOfAeroportEvent;

        }

        private void MyViewConsole_MenuOfAeroportEvent(int UsersNum)
        {


                //switch (UsersNum)
                //{
                //    case 1:
                //        NumOfPlane = MenuToEachPlane(TempAeroport);

                //        break;

                //    case 2:

                //        NumOfPlane = DepartThePlaneToNextAeroport(TempAeroport);

                //        break;

                //    case 3:

                //        ShowInfoAboutAeroport(TempAeroport);

                //        break;

                //    case 4:

                //        AllInfoAboutPlane(TempAeroport);
                //        break;

                //    case 5:

                //        ShowTimetableAboutAeroport(TempAeroport);

                //        break;

                //    case 6:
                //        Console.Clear();
                //        FlagAero = false;
                //        break;

                //    default:
                //        break;
                //}
            
        }

        internal void Stop()
        {
            MyViewConsole.MainMenuEvent -= MyViewConsole_MainMenu;
            MyViewConsole.CityAeroportMenuEvent -= MyViewConsole_CityAeroportMenuMenu;
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
           MyViewConsole.MenuOfAeroport(UserAdmin.FindTheAeroportWithIndex(UsersNumber));
        }

        
        public void Run()
        {
            MyViewConsole.ShowMenu();

        }

        
    }
}
