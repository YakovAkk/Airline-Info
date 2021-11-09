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
            MyViewConsole.MenuOfPlaneEvent += MyViewConsole_MenuOfPlaneEvent;
            MyViewConsole.TimeablePlaneEvent += MyViewConsole_TimeablePlaneEvent;
            MyViewConsole.CountOfCustomersEvent += MyViewConsole_CountOfCustomersEvent;
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

        private void MyViewConsole_CountOfCustomersEvent(int countOfCustomers) // в ответ на событие я купил пасажирам билеты, нужно реализовать
                                                                              // это функцией
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
                        person.PersonsTicket.SetClassTicket(ClassFromPlaneModel.First);

                        UserPlane.AddToList(person);

                        Console.WriteLine("================================");
                        Console.WriteLine($"\n{person.ToString()} was append to plane into First class");
                    }
                    else if (person.PersonsPurse > UserPlane.PriceBusiness.TicketPrice)
                    {
                        person.ToBuy(UserPlane.PriceBusiness.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlaneModel.Business);

                        UserPlane.AddToList(person);

                        Console.WriteLine("================================");
                        Console.WriteLine($"\n{person.ToString()} was append to plane into Business class");
                    }
                    else if (person.PersonsPurse > UserPlane.PriceEconomy.TicketPrice)
                    {
                        person.ToBuy(UserPlane.PriceEconomy.TicketPrice);
                        person.PersonsTicket.SetClassTicket(ClassFromPlaneModel.Economy);

                        UserPlane.AddToList(person);

                        Console.WriteLine("================================");
                        Console.WriteLine($"\n{person.ToString()} was append to plane into Economy class");
                    }
                    countOfCustomers--;
                }
                UserAeroport.RemoveFromListWithPeople(UserPlane.ListOfPeople);

                Console.Write("Enter something...");
                Console.ReadKey();
                UserPlane.SetStatusOfFly(StatusOfFlyModel.GateClosed);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Too many! Aeroport doesn't contain {countOfCustomers} people");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter something...");
                Console.ReadKey();
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
                    
                    SellTicket(TempPlane, aeroport);

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
            if(UsersNumber < UserAdmin.Aeroports.Count)
            {
                UserAeroport = UserAdmin.FindTheAeroportWithIndex(UsersNumber);
                MyViewConsole.MenuOfAeroport(UserAeroport);
            }
            else
            {
                MyViewConsole.ShowMenu();
            }
        }
        public void Run()
        {
            MyViewConsole.ShowMenu();
        }
    }
}
