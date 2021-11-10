using Project_Airline_info_MainAcademy.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class MainController
    {
        public SingleStorage MyStorage { get; private set; }
        private static AdminController UserAdmin = new AdminController();
        ViewConsole MyViewConsole = new ViewConsole();
        private PlaneModel UserPlane { get; set; }
        private AeroportModel UserAeroport { get; set; } 
        public MainController()
        {
           MyStorage  = SingleStorage.GetInstance();
        }
        public void Run()
        {
            MyViewConsole.TimeableAeroportEvent += MyViewConsole_TimeableAeroportEvent;
            MyViewConsole.MainMenuEvent += MyViewConsole_MainMenu;
            MyViewConsole.CityAeroportMenuEvent += MyViewConsole_CityAeroportMenuMenu;
            MyViewConsole.MenuOfAeroportEvent += MyViewConsole_MenuOfAeroportEvent;
            MyViewConsole.PlaneEvent += MyViewConsole_PlaneEvent;
            MyViewConsole.MenuOfDepart += MyViewConsole_MenuOfDepart;
            MyViewConsole.MenuOfPlaneEvent += MyViewConsole_MenuOfPlaneEvent;
            MyViewConsole.TimeablePlaneEvent += MyViewConsole_TimeablePlaneEvent;
            MyViewConsole.CountOfCustomersEvent += MyViewConsole_CountOfCustomersEvent;
            MyViewConsole.ShowMenu();
        }
        public void Stop()
        {
            MyViewConsole.MenuOfDepart -= MyViewConsole_MenuOfDepart;
            MyViewConsole.TimeableAeroportEvent -= MyViewConsole_TimeableAeroportEvent;
            MyViewConsole.MainMenuEvent -= MyViewConsole_MainMenu;
            MyViewConsole.CityAeroportMenuEvent -= MyViewConsole_CityAeroportMenuMenu;
            MyViewConsole.MenuOfAeroportEvent -= MyViewConsole_MenuOfAeroportEvent;
            MyViewConsole.PlaneEvent -= MyViewConsole_PlaneEvent;
            MyViewConsole.MenuOfPlaneEvent -= MyViewConsole_MenuOfPlaneEvent;
            MyViewConsole.CountOfCustomersEvent -= MyViewConsole_CountOfCustomersEvent;
        }
        private void MyViewConsole_CountOfCustomersEvent(int countOfCustomers)                                                                     
        {
            if (countOfCustomers < UserAeroport.GetCountOfLitsWithPeopleInAeroport())
            {

                foreach (var person in UserAeroport.GetListWithPeopleInAeroport())
                {
                    if (countOfCustomers == 0)
                    {
                        break;
                    }
                    if (person.PersonsPurse > UserPlane.PriceFirst.TicketPrice)
                    {
                        person.ToBuy(UserPlane.PriceFirst.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlane.First);

                        UserPlane.AddToList(person);

                        MyViewConsole.ShowAddedPersonToList(person);
                    }
                    else if (person.PersonsPurse > UserPlane.PriceBusiness.TicketPrice)
                    {
                        person.ToBuy(UserPlane.PriceBusiness.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlane.Business);

                        UserPlane.AddToList(person);

                        MyViewConsole.ShowAddedPersonToList(person);
                    }
                    else if (person.PersonsPurse > UserPlane.PriceEconomy.TicketPrice)
                    {
                        person.ToBuy(UserPlane.PriceEconomy.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlane.Economy);

                        UserPlane.AddToList(person);

                        MyViewConsole.ShowAddedPersonToList(person);
                    }
                    countOfCustomers--;
                }
                UserAeroport.RemoveFromListWithPeople(UserPlane.ListOfPeople);

                MyViewConsole.ShowEndedOFSentence();
                UserPlane.SetStatusOfFly(StatusOfFly.GateClosed);
            }
            else
            {
                MyViewConsole.ShowErrorOFBuyTicket(countOfCustomers);
            }
        }
        private void MyViewConsole_MenuOfPlaneEvent(int UserNumber)
        {
            switch (UserNumber)
            {
                case 1:
                    MyViewConsole.ShowPeopleWhoWantToFly(UserAeroport);
                    MyViewConsole.MenuForPlane(UserPlane , UserAeroport);
                    break;
                case 2:
                    MyViewConsole.SellTicket(UserPlane, UserAeroport);
                    //SellTicket(TempPlane, aeroport);

                    MyViewConsole.MenuForPlane(UserPlane, UserAeroport);
                    break;

                case 3:

                    MyViewConsole.TimetableAboutPLane(UserPlane);
                    MyViewConsole.MenuForPlane(UserPlane, UserAeroport);
                    break;

                case 4:
                    MyViewConsole.InfoAboutPlane(UserPlane);
                    MyViewConsole.MenuForPlane(UserPlane, UserAeroport);

                    break;

                case 5:
                    MyViewConsole.MenuOfAeroport(UserAeroport);
                    break;

                default:
                    break;


            }
        }
        private void MyViewConsole_MenuOfDepart(int Num)
        {
            UserAdmin.DepartDepartThePlaneToNextAeroport(Num,UserAeroport);
            MyViewConsole.ShowDepartsTime(UserPlane, UserAeroport);
        }
        private void MyViewConsole_TimeableAeroportEvent(AeroportModel TempAeroport)
        {
            MyViewConsole.PrintTimetableForAeroport(TempAeroport, TimetableModel.Timetables);
        }
        private void MyViewConsole_TimeablePlaneEvent(PlaneModel plane)
        {
            MyViewConsole.PrintTimetableForPlane(plane, TimetableModel.Timetables);
        }
        private void MyViewConsole_PlaneEvent(int NumOfPlane)
        {
            UserPlane = UserAeroport.FindThePlaneWithIndex(NumOfPlane);
            if(UserPlane == null)
            {
                MyViewConsole.ErrorOfPlane();
            }
            else
            {
                MyViewConsole.MenuForPlane(UserPlane, UserAeroport);
            }
           
            
        } 
        private void MyViewConsole_MenuOfAeroportEvent(int UsersNum)
        {
            switch (UsersNum)
            {
                case 1:
                    UserAeroport = MyStorage.FindTheAeroportWithIndex(UsersNum);
                    MyViewConsole.MenuToEachPlaneInAeroport(UserAeroport);
                    break;

                case 2:
                    MyViewConsole.ViewDepartThePlaneToNextAeroport(UserAeroport);
                    MyViewConsole.MenuOfAeroport(UserAeroport);
                    break;

                case 3:
                    MyViewConsole.ShowInfoAboutAeroport(UserAeroport);
                    MyViewConsole.MenuOfAeroport(UserAeroport);
                    break;

                case 4:

                    MyViewConsole.AllInfoAboutPlane(UserAeroport);
                    MyViewConsole.MenuOfAeroport(UserAeroport);
                    break;

                case 5:
                    MyViewConsole.ShowTimetableAboutAeroport(UserAeroport);
                    MyViewConsole.MenuOfAeroport(UserAeroport);
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
            if(UsersNumber < MyStorage.Aeroports.Count)
            {
                UserAeroport = MyStorage.FindTheAeroportWithIndex(UsersNumber);
                MyViewConsole.MenuOfAeroport(UserAeroport);
            }
            else
            {
                MyViewConsole.ShowMenu();
            }
        }
    }
}
