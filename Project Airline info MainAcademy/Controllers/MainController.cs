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
        private readonly AdminController _userAdmin;
        private readonly ViewConsole _myViewConsole;
        private PlaneModel _userPlane;
        private AeroportModel _userAeroport;
        public MainController()
        {
            _userAdmin = new AdminController();
            _myStorage  = SingleStorage.GetInstance();
            _myViewConsole = new ViewConsole();
        }
        public void Run()
        {

            //_userPlane = new PlaneModel();
            //_userAeroport = new AeroportModel();

            _userPlane = _myStorage.allPlanes.First();
            _myViewConsole.TimeableAeroportEvent += MyViewConsoleTimeableAeroportEvent;
            _myViewConsole.MainMenuEvent += MyViewConsoleMainMenu;
            _myViewConsole.CityAeroportMenuEvent += MyViewConsoleCityAeroportMenuMenu;
            _myViewConsole.MenuOfAeroportEvent += MyViewConsoleMenuOfAeroportEvent;
            _myViewConsole.PlaneEvent += MyViewConsolePlaneEvent;
            _myViewConsole.MenuOfDepart += MyViewConsoleMenuOfDepart;
            _myViewConsole.MenuOfPlaneEvent += MyViewConsoleMenuOfPlaneEvent;
            _myViewConsole.TimeablePlaneEvent += MyViewConsoleTimeablePlaneEvent;
            _myViewConsole.CountOfCustomersEvent += MyViewConsoleCountOfCustomersEvent;
            _myViewConsole.AdminMenuEvent += MyViewConsoleAdminMenuEvent;
            _myViewConsole.FindRaceByNumEvent += MyViewConsoleFindRaceByNumEvent;
            _myViewConsole.FindEndDestinationAirportEvent += MyViewConsoleFindEndDestinationAirport;
            _myViewConsole.FindRacesWhichCostLessThanXEvent += MyViewConsoleFindRacesWhichCostLessThanXEvent;
            _myViewConsole.PasswordEvent += MyViewConsolePasswordEvent;
            _myViewConsole.MainAdminMenuEvent += MyViewConsoleMainAdminMenuEvent;
            _myViewConsole.RemoveEvent += MyViewConsoleRemoveEvent;
            _myViewConsole.CreatePlaneEvent += MyViewConsoleCreateEvent;
            _myViewConsole.ShowMenu();
        }
        public void Stop()
        {
            _myViewConsole.TimeableAeroportEvent -= MyViewConsoleTimeableAeroportEvent;
            _myViewConsole.MainMenuEvent -= MyViewConsoleMainMenu;
            _myViewConsole.CityAeroportMenuEvent -= MyViewConsoleCityAeroportMenuMenu;
            _myViewConsole.MenuOfAeroportEvent -= MyViewConsoleMenuOfAeroportEvent;
            _myViewConsole.PlaneEvent -= MyViewConsolePlaneEvent;
            _myViewConsole.MenuOfDepart -= MyViewConsoleMenuOfDepart;
            _myViewConsole.MenuOfPlaneEvent -= MyViewConsoleMenuOfPlaneEvent;
            _myViewConsole.TimeablePlaneEvent -= MyViewConsoleTimeablePlaneEvent;
            _myViewConsole.CountOfCustomersEvent -= MyViewConsoleCountOfCustomersEvent;
            _myViewConsole.AdminMenuEvent -= MyViewConsoleAdminMenuEvent;
            _myViewConsole.FindRaceByNumEvent += MyViewConsoleFindRaceByNumEvent;
            _myViewConsole.FindEndDestinationAirportEvent -= MyViewConsoleFindEndDestinationAirport;
            _myViewConsole.FindRacesWhichCostLessThanXEvent -= MyViewConsoleFindRacesWhichCostLessThanXEvent;
            _myViewConsole.PasswordEvent -= MyViewConsolePasswordEvent;
            _myViewConsole.MainAdminMenuEvent -= MyViewConsoleMainAdminMenuEvent;
            _myViewConsole.RemoveEvent -= MyViewConsoleRemoveEvent;
            _myViewConsole.CreatePlaneEvent -= MyViewConsoleCreateEvent;
        }
        private void MyViewConsoleCreateEvent(PlaneModel obj)
        {
            _userAeroport.AddPlaneToAeroport(obj);
        }
        private void MyViewConsoleRemoveEvent(int UserNum)
        {
            if (_myStorage.RemovePlaneFromList(_userAeroport.FindThePlaneWithIndex(UserNum)))
            {
                _userAeroport.RemovePlaneFromAeroport(_userAeroport.FindThePlaneWithIndex(UserNum));
                _myViewConsole.ShowSuccessDelete();
                _myViewConsole.ShowEndedOFSentence();
            }
            else
            {
                _myViewConsole.ShowErrorDelete();
                _myViewConsole.ShowEndedOFSentence();
            }
            
        }
        private void MyViewConsoleMainAdminMenuEvent(int UserNum)
        {
            switch (UserNum)
            {
                case 1:
                    _myViewConsole.ShowAddPlaneToAeroport();
                    _myViewConsole.ShowMenuMainAdmin();
                    break;
                case 2:
                    _myViewConsole.ShowInfoAboutPlaneForDelete(_userAeroport);
                    _myViewConsole.ShowMenuMainAdmin();
                    break;
                case 3:
                    _myViewConsole.MenuAdmin(); ;
                    break;
                default:
                    break;
            }
        }
        private void MyViewConsolePasswordEvent(string UserPassword)
        {
            string AdminPassword = "qwerty";

            if (AdminPassword == UserPassword)
            {
                _myViewConsole.ShowMenuMainAdmin();
            }
            else
            {
                _myViewConsole.ShowAccessDenied();
                _myViewConsole.ShowEndedOFSentence();
                _myViewConsole.MenuAdmin();
            }
        }
        private void MyViewConsoleFindRacesWhichCostLessThanXEvent(int UsersNum)
        {
            if(UsersNum >= _userPlane.PriceFirst.TicketPrice.Amount)
            {
                _myViewConsole.ShowPersonFirst();
                _myViewConsole.ShowEndedOFSentence();
            }
            else if(UsersNum >= _userPlane.PriceBusiness.TicketPrice.Amount)
            {
                _myViewConsole.ShowPersonBusiness();
                _myViewConsole.ShowEndedOFSentence();
            }
            else if(UsersNum >= _userPlane.PriceEconomy.TicketPrice.Amount)
            {
                _myViewConsole.ShowPersonEconomy();
                _myViewConsole.ShowEndedOFSentence();
            }
            else
            {
                _myViewConsole.ShowPersonWithoutMoney();
                _myViewConsole.ShowEndedOFSentence();
            }
        }
        private void MyViewConsoleFindEndDestinationAirport(int Num)
        {
            var TempAero = _myStorage.FindTheAeroportWithIndex(Num);

            _myViewConsole.ShowAeroportWithDestitation(TimetableModel.Timetables, TempAero);
        }
        private void MyViewConsoleFindRaceByNumEvent(int obj)
        {
            _myViewConsole.PrintTimetableForAeroportByNum(_userAeroport, TimetableModel.Timetables,obj);
        }
        private void MyViewConsoleAdminMenuEvent(int num)
        {
            switch (num)
            {
                case 1:
                    _myViewConsole.ShowTimetableAboutAeroport(_userAeroport);
                    break;
                case 2:
                    _myViewConsole.ShowFindRaceByNum();
                    break;
                case 3:
                    _myViewConsole.ShowFindRaceWitnEndPoint(_myStorage.aeroports);
                    break;
                case 4:
                    _myViewConsole.ShowTimetableAboutAeroport(_userAeroport);
                    break;
                case 5:
                    _myViewConsole.ShowTimetableAboutAeroport(_userAeroport);
                    break;
                case 6:
                    _myViewConsole.ShowRacesWhichCostLessThanX();
                    break;
                case 7:
                    _myViewConsole.ShowPlaneWhichHaveFreePlaces(_userAeroport.GetPlanes());
                    _myViewConsole.ShowEndedOFSentence();
                    break;
                case 8:
                    _myViewConsole.EnterLikeAdmin();
                    break;
                case 9:
                    _myViewConsole.MenuOfAeroport(_userAeroport);
                    break;
                default:
                    break;
            }
        }
        private void MyViewConsoleCountOfCustomersEvent(int countOfCustomers)
        {
            if (countOfCustomers < _userAeroport.GetCountOfLitsWithPeopleInAeroport())
            {

                foreach (var person in _userAeroport.GetListWithPeopleInAeroport())
                {
                    if (countOfCustomers == 0)
                    {
                        break;
                    }
                    if (person.PersonsPurse > _userPlane.PriceFirst.TicketPrice)
                    {
                        person.ToBuy(_userPlane.PriceFirst.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlane.First);

                        _userPlane.AddToList(person);

                        _myViewConsole.ShowAddedPersonToList(person);
                    }
                    else if (person.PersonsPurse > _userPlane.PriceBusiness.TicketPrice)
                    {
                        person.ToBuy(_userPlane.PriceBusiness.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlane.Business);

                        _userPlane.AddToList(person);

                        _myViewConsole.ShowAddedPersonToList(person);
                    }
                    else if (person.PersonsPurse > _userPlane.PriceEconomy.TicketPrice)
                    {
                        person.ToBuy(_userPlane.PriceEconomy.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlane.Economy);

                        _userPlane.AddToList(person);

                        _myViewConsole.ShowAddedPersonToList(person);
                    }
                    countOfCustomers--;
                }
                _userAeroport.RemoveFromListWithPeople(_userPlane.ListOfPeople);

                _myViewConsole.ShowEndedOFSentence();
                _userPlane.SetStatusOfFly(StatusOfFly.GateClosed);
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
                    _myViewConsole.ShowPeopleWhoWantToFly(_userAeroport);
                    _myViewConsole.MenuForPlane(_userPlane);
                    break;
                case 2:
                    _myViewConsole.SellTicket();
                    //SellTicket(TempPlane, aeroport);

                    _myViewConsole.MenuForPlane(_userPlane);
                    break;

                case 3:

                    _myViewConsole.TimetableAboutPLane(_userPlane);
                    _myViewConsole.MenuForPlane(_userPlane);
                    break;

                case 4:
                    _myViewConsole.InfoAboutPlane(_userPlane);
                    _myViewConsole.MenuForPlane(_userPlane);

                    break;

                case 5:
                    _myViewConsole.MenuOfAeroport(_userAeroport);
                    break;

                default:
                    break;


            }
        }
        private void MyViewConsoleMenuOfDepart(int Num)
        {
            _userAdmin.DepartDepartThePlaneToNextAeroport(Num, _userAeroport);
            _myViewConsole.ShowDepartsTime(_userPlane, _userAeroport);
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
            _userPlane = _userAeroport.FindThePlaneWithIndex(NumOfPlane);
            if(_userPlane == null)
            {
                _myViewConsole.ErrorOfPlane();
            }
            else
            {
                _myViewConsole.MenuForPlane(_userPlane);
            }
           
            
        } 
        private void MyViewConsoleMenuOfAeroportEvent(int UsersNum)
        {
            switch (UsersNum)
            {
                case 1:
                    _userAeroport = _myStorage.FindTheAeroportWithIndex(UsersNum);
                    _myViewConsole.MenuToEachPlaneInAeroport(_userAeroport);
                    break;

                case 2:
                    _myViewConsole.ViewDepartThePlaneToNextAeroport(_userAeroport);
                    _myViewConsole.MenuOfAeroport(_userAeroport);
                    break;

                case 3:
                    _myViewConsole.ShowInfoAboutAeroport(_userAeroport);
                    _myViewConsole.MenuOfAeroport(_userAeroport);
                    break;

                case 4:
                    _myViewConsole.AllInfoAboutPlane(_userAeroport);
                    _myViewConsole.MenuOfAeroport(_userAeroport);
                    break;

                case 5:
                    _myViewConsole.ShowTimetableAboutAeroport(_userAeroport);
                    _myViewConsole.MenuOfAeroport(_userAeroport);
                    break;
                case 6:
                    _myViewConsole.MenuAdmin();
                    _myViewConsole.MenuOfAeroport(_userAeroport);
                    break;
                case 7:
                    _myViewConsole.MenuCityWithAeroport(_myStorage.aeroports);
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
                    _myViewConsole.MenuCityWithAeroport(_myStorage.aeroports);
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
            if(UsersNumber <= _myStorage.aeroports.Count)
            {
                _userAeroport = _myStorage.FindTheAeroportWithIndex(UsersNumber);
                _myViewConsole.MenuOfAeroport(_userAeroport);
            }
            else
            {
                _myViewConsole.ShowMenu();
            }
        }
    }
}
