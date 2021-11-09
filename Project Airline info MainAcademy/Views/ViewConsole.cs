using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class ViewConsole
    {
        private static AdminController UserAdmin = new AdminController();
        public event Action<int> MainMenuEvent = delegate { };
        public event Action<int> CityAeroportMenuEvent = delegate { };
        public event Action<int> MenuOfAeroportEvent = delegate { };

        public void ShowMenu()
        {
            Console.WriteLine("Good afternoon , you are greetings by Yakov's aeroport company. Do you want to choose city with aeroport?");
            Console.WriteLine("1) Choose the city with aeroport");
            Console.WriteLine("2) Exit");

            var UserNum = Initialization("Your Choose: ");

            MainMenuEvent(UserNum);
        }

        public void SayBye()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Good Bye! Have a nice day)");
            Console.ReadKey();
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

        // Menu 
        public void MenuCityWithAeroport()
        {
            var FlagMain = true;
            while (FlagMain)
            {
                Header();
                var NumOfAeroport = Initialization("Your choose : ");
                CityAeroportMenuEvent(NumOfAeroport);  
            }
        }
        private void Header()
        {
            Console.WriteLine("1) Boryspil airport");
            Console.WriteLine("2) Lviv airport");
            Console.WriteLine("3) airport Kiev");
            Console.WriteLine("4) Odessa airport");
            Console.WriteLine("5) Kharkiv airport");
            Console.WriteLine("6) Exit");
        }

        private void HeaderMenuOfAeroport(AeroportModel TempAeroport)
        {
            Console.Clear();
            Console.WriteLine(TempAeroport.ToString());
            Console.WriteLine();
            Console.WriteLine("1) Go to menu of each plane");
            Console.WriteLine("2) Run a plane to next aeroport");
            Console.WriteLine("3) Aeroport Info");
            Console.WriteLine("4) List of plane");
            Console.WriteLine("5) Timetable for this Aeroport will be shown");
            Console.WriteLine("6) Show to other aeroport");
        }
        public void MenuOfAeroport(AeroportModel TempAeroport)
        {

            HeaderMenuOfAeroport(TempAeroport);
            var NumOfAeroport = Initialization("Your choose : ");
            MenuOfAeroportEvent(NumOfAeroport);
            
        }


        //private  int MenuToEachPlane(Aeroport TempAeroport)
        //{
        //    int NumOfPlane;
        //    Console.Clear();
        //    TempAeroport.AllInfoAboutPlane();
        //    NumOfPlane = Initialization("Choose The plane : ");

        //    if (NumOfPlane <= TempAeroport.CountOfPlane() && NumOfPlane > 0)
        //    {
        //        var TempPlane = TempAeroport.FindThePlaneWithIndex(NumOfPlane);
        //        MenuForPlane(TempPlane, TempAeroport);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aeroport doesn't contain this plane ");
        //    }

        //    return NumOfPlane;
        //}
        //private void MenuForPlane(Plane TempPlane, Aeroport aeroport)
        //{
        //    var FlagMenuOfPlane = true;
        //    while (FlagMenuOfPlane)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("===========================================================");
        //        Console.WriteLine($"Your choose {TempPlane.ToString()}");
        //        Console.WriteLine("===========================================================");
        //        HeaderForPlaneMenu();

        //        switch (Initialization("Your choose : "))
        //        {
        //            case 1:

        //                ShowPeopleWhoWantToFly(aeroport);

        //                break;

        //            case 2:

        //                SellTicket(TempPlane, aeroport);
        //                break;

        //            case 3:

        //                TimetableAboutPLane(TempPlane);
        //                break;

        //            case 4:

        //                InfoAboutPlane(TempPlane);

        //                break;

        //            case 5:

        //                FlagMenuOfPlane = false;
        //                break;

        //            default:

        //                Console.WriteLine("Menu doesn't contain this topic");
        //                break;


        //        }
        //    }

        //}

        //// Show Info
        //private void InfoAboutPlane(Plane TempPlane)
        //{
        //    Console.Clear();
        //    TempPlane.AllInfoPassagers();

        //    Console.Write("Enter something...");
        //    Console.ReadKey();
        //}
        //private  void ShowPeopleWhoWantToFly(Aeroport aeroport)
        //{
        //    Console.Clear();

        //    var NumberOfPerson = 1;
        //    foreach (var person in aeroport.GetListWithPeopleInAeroport())
        //    {
        //        Console.WriteLine($"{NumberOfPerson++}) {person.ToString()}");
        //        Console.WriteLine("===============================");
        //    }
        //    Console.Write("Enter something...");
        //    Console.ReadKey();
        //    Console.Clear();
        //}
        //private  void TimetableAboutPLane(Plane TempPlane)
        //{
        //    Console.Clear();
        //    Timetable.PrintTimetableForPlane(TempPlane);
        //    Console.WriteLine("Enter something...");
        //    Console.ReadKey();
        //}
        //private void ShowTimetableAboutAeroport(Aeroport TempAeroport)
        //{
        //    Console.Clear();
        //    Timetable.PrintTimetableForAeroport(TempAeroport);
        //    Console.WriteLine("Enter something...");
        //    Console.ReadKey();
        //}
        //private void AllInfoAboutPlane(Aeroport TempAeroport)
        //{
        //    Console.WriteLine("===============================");
        //    TempAeroport.AllInfoAboutPlane();
        //    Console.WriteLine("===============================");

        //    Console.ReadKey();
        //}
        //private  void ShowInfoAboutAeroport(Aeroport TempAeroport)
        //{
        //    Console.WriteLine("===============================");
        //    Console.WriteLine(TempAeroport.ToString());
        //    Console.WriteLine("===============================");
        //    Console.ReadKey();
        //}


        //// Headers
        
        //private  void HeaderForPlaneMenu()
        //{
        //    Console.WriteLine("1) People who want to buy tickets in plane will be shown");
        //    Console.WriteLine("2) Sell tickets for people on the plane");
        //    Console.WriteLine("3) Timetable for this plane will be shown");
        //    Console.WriteLine("4) Show people who inside the plane");
        //    Console.WriteLine("5) Exit");
        //}


        //// other Funk
        //private  int DepartThePlaneToNextAeroport(Aeroport TempAeroport)
        //{
        //    int NumOfPlane;
        //    Console.Clear();
        //    TempAeroport.AllInfoAboutPlane();
        //    NumOfPlane = Initialization("Choose The plane : ");

        //    if (NumOfPlane < TempAeroport.CountOfPlane() && NumOfPlane > 0)
        //    {
        //        var TempPlane = TempAeroport.FindThePlaneWithIndex(NumOfPlane);

        //        if (TempPlane.StatusOfFly == StatusOfFly.GateClosed)
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Plane will be flown to aeroport, choose it ");
        //            Header();

        //            var NumOfAeroport = Initialization("Your choose : ");


        //            UserAdmin.DepartAtNextAero(TempPlane, UserAdmin.FindTheAeroportWithIndex(NumOfAeroport));

        //            TempAeroport.RemovePlaneFromAeroport(TempPlane);

        //        }
        //        else
        //        {
        //            Console.Clear();
        //            Console.WriteLine("This plane doesn't ready to fly");
        //            Console.Write("Enter something ... ");
        //            Console.ReadKey();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aeroport doesn't contain this plane ");
        //    }

        //    return NumOfPlane;
        //}
        //private  void SellTicket(Plane TempPlane, Aeroport aeroport)
        //{
        //    Console.Clear();
        //    Console.WriteLine("How many people do you want to sell tickets?");
        //    var countOfCustomers = Initialization("Enter count : ");

        //    if (countOfCustomers < aeroport.GetCountOfLitsWithPeopleInAeroport())
        //    {

        //        foreach (var person in aeroport.GetListWithPeopleInAeroport())
        //        {
        //            if (countOfCustomers == 0)
        //            {
        //                break;
        //            }
        //            if (person.PersonsPurse > TempPlane.PriceFirst.TicketPrice)
        //            {
        //                person.ToBuy(TempPlane.PriceFirst.TicketPrice);
        //                person.PersonsTicket.SetClassTicket(ClassFromPlane.First);

        //                TempPlane.AddToList(person);

        //                Console.WriteLine("================================");
        //                Console.WriteLine($"\n{person.ToString()} was append to plane into First class");
        //            }
        //            else if (person.PersonsPurse > TempPlane.PriceBusiness.TicketPrice)
        //            {
        //                person.ToBuy(TempPlane.PriceBusiness.TicketPrice);
        //                person.PersonsTicket.SetClassTicket(ClassFromPlane.Business);

        //                TempPlane.AddToList(person);

        //                Console.WriteLine("================================");
        //                Console.WriteLine($"\n{person.ToString()} was append to plane into Business class");
        //            }
        //            else if (person.PersonsPurse > TempPlane.PriceEconomy.TicketPrice)
        //            {
        //                person.ToBuy(TempPlane.PriceEconomy.TicketPrice);
        //                person.PersonsTicket.SetClassTicket(ClassFromPlane.Economy);

        //                TempPlane.AddToList(person);

        //                Console.WriteLine("================================");
        //                Console.WriteLine($"\n{person.ToString()} was append to plane into Economy class");
        //            }
        //            countOfCustomers--;
        //        }
        //        aeroport.RemoveFromListWithPeople(TempPlane.ListOfPeople);

        //        Console.Write("Enter something...");
        //        Console.ReadKey();
        //        TempPlane.SetStatusOfFly(StatusOfFly.GateClosed);
        //    }
        //    else
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine($"Too many! Aeroport doesn't contain {countOfCustomers} people");
        //        Console.ForegroundColor = ConsoleColor.White;
        //        Console.Write("Enter something...");
        //        Console.ReadKey();
        //    }
        //}

    }
}
