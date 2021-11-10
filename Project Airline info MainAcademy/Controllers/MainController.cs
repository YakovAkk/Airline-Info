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
        private readonly SingleStorage _myStorage;
        private static AdminController _userAdmin;
        private ViewConsole _myViewConsole;
        private PlaneModel UserPlane { get; set; }
        private AeroportModel UserAeroport { get; set; } 
        public MainController()
        {
            _userAdmin = new AdminController();
            _myStorage  = SingleStorage.GetInstance();
            _myViewConsole = new ViewConsole();
        }
        public void Run()
        {
            _myViewConsole.TimeableAeroportEvent += MyViewConsoleTimeableAeroportEvent;
            _myViewConsole.MainMenuEvent += MyViewConsoleMainMenu;
            _myViewConsole.CityAeroportMenuEvent += MyViewConsoleCityAeroportMenuMenu;
            _myViewConsole.MenuOfAeroportEvent += MyViewConsoleMenuOfAeroportEvent;
            _myViewConsole.PlaneEvent += MyViewConsolePlaneEvent;
            _myViewConsole.MenuOfDepart += MyViewConsoleMenuOfDepart;
            _myViewConsole.MenuOfPlaneEvent += MyViewConsoleMenuOfPlaneEvent;
            _myViewConsole.TimeablePlaneEvent += MyViewConsoleTimeablePlaneEvent;
            _myViewConsole.CountOfCustomersEvent += MyViewConsoleCountOfCustomersEvent;
            _myViewConsole.ShowMenu();
        }
        public void Stop()
        {
            _myViewConsole.MenuOfDepart -= MyViewConsoleMenuOfDepart;
            _myViewConsole.TimeableAeroportEvent -= MyViewConsoleTimeableAeroportEvent;
            _myViewConsole.MainMenuEvent -= MyViewConsoleMainMenu;
            _myViewConsole.CityAeroportMenuEvent -= MyViewConsoleCityAeroportMenuMenu;
            _myViewConsole.MenuOfAeroportEvent -= MyViewConsoleMenuOfAeroportEvent;
            _myViewConsole.PlaneEvent -= MyViewConsolePlaneEvent;
            _myViewConsole.MenuOfPlaneEvent -= MyViewConsoleMenuOfPlaneEvent;
            _myViewConsole.CountOfCustomersEvent -= MyViewConsoleCountOfCustomersEvent;
            _myViewConsole.TimeablePlaneEvent -= MyViewConsoleTimeablePlaneEvent;
        }
        private void MyViewConsoleCountOfCustomersEvent(int countOfCustomers)                                                                     
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

                        _myViewConsole.ShowAddedPersonToList(person);
                    }
                    else if (person.PersonsPurse > UserPlane.PriceBusiness.TicketPrice)
                    {
                        person.ToBuy(UserPlane.PriceBusiness.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlane.Business);

                        UserPlane.AddToList(person);

                        _myViewConsole.ShowAddedPersonToList(person);
                    }
                    else if (person.PersonsPurse > UserPlane.PriceEconomy.TicketPrice)
                    {
                        person.ToBuy(UserPlane.PriceEconomy.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlane.Economy);

                        UserPlane.AddToList(person);

                        _myViewConsole.ShowAddedPersonToList(person);
                    }
                    countOfCustomers--;
                }
                UserAeroport.RemoveFromListWithPeople(UserPlane.ListOfPeople);

                _myViewConsole.ShowEndedOFSentence();
                UserPlane.SetStatusOfFly(StatusOfFly.GateClosed);
            }
            else
            {
                _myViewConsole.ShowErrorOFBuyTicket(countOfCustomers);
            }
        }
        private void MyViewConsoleMenuOfPlaneEvent(int UserNumber)
        {
            switch (UserNumber)
            {
                case 1:
                    _myViewConsole.ShowPeopleWhoWantToFly(UserAeroport);
                    _myViewConsole.MenuForPlane(UserPlane);
                    break;
                case 2:
                    _myViewConsole.SellTicket();
                    //SellTicket(TempPlane, aeroport);

                    _myViewConsole.MenuForPlane(UserPlane);
                    break;

                case 3:

                    _myViewConsole.TimetableAboutPLane(UserPlane);
                    _myViewConsole.MenuForPlane(UserPlane);
                    break;

                case 4:
                    _myViewConsole.InfoAboutPlane(UserPlane);
                    _myViewConsole.MenuForPlane(UserPlane);

                    break;

                case 5:
                    _myViewConsole.MenuOfAeroport(UserAeroport);
                    break;

                default:
                    break;


            }
        }
        private void MyViewConsoleMenuOfDepart(int Num)
        {
            _userAdmin.DepartDepartThePlaneToNextAeroport(Num,UserAeroport);
            _myViewConsole.ShowDepartsTime(UserPlane, UserAeroport);
        }
        private void MyViewConsoleTimeableAeroportEvent(AeroportModel TempAeroport)
        {
            _myViewConsole.PrintTimetableForAeroport(TempAeroport, TimetableModel.Timetables);
        }
        private void MyViewConsoleTimeablePlaneEvent(PlaneModel plane)
        {
            _myViewConsole.PrintTimetableForPlane(plane, TimetableModel.Timetables);
        }
        private void MyViewConsolePlaneEvent(int NumOfPlane)
        {
            UserPlane = UserAeroport.FindThePlaneWithIndex(NumOfPlane);
            if(UserPlane == null)
            {
                _myViewConsole.ErrorOfPlane();
            }
            else
            {
                _myViewConsole.MenuForPlane(UserPlane);
            }
           
            
        } 
        private void MyViewConsoleMenuOfAeroportEvent(int UsersNum)
        {
            switch (UsersNum)
            {
                case 1:
                    UserAeroport = _myStorage.FindTheAeroportWithIndex(UsersNum);
                    _myViewConsole.MenuToEachPlaneInAeroport(UserAeroport);
                    break;

                case 2:
                    _myViewConsole.ViewDepartThePlaneToNextAeroport(UserAeroport);
                    _myViewConsole.MenuOfAeroport(UserAeroport);
                    break;

                case 3:
                    _myViewConsole.ShowInfoAboutAeroport(UserAeroport);
                    _myViewConsole.MenuOfAeroport(UserAeroport);
                    break;

                case 4:

                    _myViewConsole.AllInfoAboutPlane(UserAeroport);
                    _myViewConsole.MenuOfAeroport(UserAeroport);
                    break;

                case 5:
                    _myViewConsole.ShowTimetableAboutAeroport(UserAeroport);
                    _myViewConsole.MenuOfAeroport(UserAeroport);
                    break;

                case 6:
                    _myViewConsole.MenuCityWithAeroport();
                    break;
                default:
                    break;
            }

          

        }
        private void MyViewConsoleMainMenu(int UsersChoise)
        {
            switch (UsersChoise)
            {
                case 1:

                    _myViewConsole.MenuCityWithAeroport();
                    break;

                case 2:
                    _myViewConsole.SayBye();
                    break;

                default:
                    break;
            }
        }
        private void MyViewConsoleCityAeroportMenuMenu(int UsersNumber)
        {
            if(UsersNumber < _myStorage.aeroports.Count)
            {
                UserAeroport = _myStorage.FindTheAeroportWithIndex(UsersNumber);
                _myViewConsole.MenuOfAeroport(UserAeroport);
            }
            else
            {
                _myViewConsole.ShowMenu();
            }
        }
    }
}
