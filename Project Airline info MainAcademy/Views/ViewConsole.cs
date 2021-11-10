using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class ViewConsole
    {
        public event Action<int> MainMenuEvent = delegate { };
        public event Action<int> CityAeroportMenuEvent = delegate { };
        public event Action<int> MenuOfAeroportEvent = delegate { };
        public event Action<int> PlaneEvent = delegate { };
        public event Action<int> MenuOfPlaneEvent = delegate { };
        public event Action<int> MenuOfDepart = delegate { };
        public event Action<AeroportModel> TimeableAeroportEvent = delegate { };
        public event Action<PlaneModel> TimeablePlaneEvent = delegate { };
        public event Action<int> CountOfCustomersEvent = delegate { };
        // Menu 
        public void MenuOfAeroport(AeroportModel TempAeroport)
        {
            HeaderMenuOfAeroport(TempAeroport);
            var NumOfAeroport = Initialization("Your choose : ");
            MenuOfAeroportEvent(NumOfAeroport);
        }
        public void MenuToEachPlaneInAeroport(AeroportModel TempAeroport)
        {
            int NumOfPlane;
            Console.Clear();
            TempAeroport.AllInfoAboutPlane();
            NumOfPlane = Initialization("Choose The plane : ");
            PlaneEvent(NumOfPlane);
        }
        public void MenuCityWithAeroport()
        {
            Console.Clear();

            Header();
            var NumOfAeroport = Initialization("Your choose : ");
            CityAeroportMenuEvent(NumOfAeroport);

        }
        public void MenuForPlane(PlaneModel TempPlane, AeroportModel aeroport)
        {
           Console.Clear();
           Console.WriteLine("===========================================================");
           Console.WriteLine($"Your choose {TempPlane.ToString()}");
           Console.WriteLine("===========================================================");
           HeaderForPlaneMenu();

           var UserNum = (Initialization("Your choose : "));
           MenuOfPlaneEvent(UserNum);
        }

        // Messages To user

        public void ShowErrorOfArrived()
        {
            Console.Clear();
            Console.WriteLine("This plane doesn't ready to fly");
            Console.Write("Enter something ... ");
            Console.ReadKey();
            Console.Clear();
        }
        public void ShowMenu()
        {
            Console.Clear();
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

            return;
        }
        public void ShowArrivedOfPlane()
        {
            Console.Clear();
            Console.WriteLine("Plane will be flown to aeroport, choose it ");
            Header();
        }
        public void ErrorOfPlane()
        {
            Console.WriteLine("Aeroport doesn't contain this plane ");
        }

        //// Show Info
        public void InfoAboutPlane(PlaneModel TempPlane)
        {
            Console.Clear();
            AllInfoPassagers(TempPlane);

            Console.Write("Enter something...");
            Console.ReadKey();
        }
        public void ShowPeopleWhoWantToFly(AeroportModel aeroport)
        {
            Console.Clear();

            var NumberOfPerson = 1;
            foreach (var person in aeroport.GetListWithPeopleInAeroport())
            {
                Console.WriteLine($"{NumberOfPerson++}) {person.ToString()}");
                Console.WriteLine("===============================");
            }
            Console.Write("Enter something...");
            Console.ReadKey();
            Console.Clear();
        }
        public void TimetableAboutPLane(PlaneModel TempPlane)
        {
            Console.Clear();

            TimeablePlaneEvent(TempPlane);
            //Timetable.PrintTimetableForPlane(TempPlane);
            Console.WriteLine("Enter something...");
            Console.ReadKey();

            Console.Clear();
        }
        public void ShowTimetableAboutAeroport(AeroportModel TempAeroport)
        {
            Console.Clear();
            TimeableAeroportEvent(TempAeroport);

            Console.WriteLine("Enter something...");
            Console.ReadKey();
            Console.Clear();
        }
        public void AllInfoAboutPlane(AeroportModel TempAeroport)
        {
            Console.WriteLine("===============================");
            TempAeroport.AllInfoAboutPlane();
            Console.WriteLine("===============================");

            Console.ReadKey();

            Console.Clear();
        }
        public void ShowInfoAboutAeroport(AeroportModel TempAeroport)
        {
            Console.WriteLine("===============================");
            Console.WriteLine(TempAeroport.ToString());
            Console.WriteLine("===============================");
            Console.ReadKey();
        }
        public void PrintTimetableForAeroport(AeroportModel TempAeroports , List<TimetableModel> Timetables)
        {
            foreach (var Timetable in Timetables)
            {
                if (Timetable.StartPoint == TempAeroports.NameOfAeroport || Timetable.EndPoint == TempAeroports.NameOfAeroport)
                {
                    Console.WriteLine(Timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }
        public void PrintTimetableForPlane(PlaneModel TempPlane , List<TimetableModel> Timetables)
        {
            foreach (var Timetable in Timetables)
            {
                if (Timetable.NameOfPlane == TempPlane.NameOfPlane)
                {
                    Console.WriteLine(Timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }

        //// Headers
        private void Header()
        {
            Console.WriteLine("1) Boryspil airport");
            Console.WriteLine("2) Lviv airport");
            Console.WriteLine("3) airport Kiev");
            Console.WriteLine("4) Odessa airport");
            Console.WriteLine("5) Kharkiv airport");
            Console.WriteLine("6) Exit");
        }
        private void HeaderForPlaneMenu()
        {
            Console.WriteLine("1) People who want to buy tickets in plane will be shown");
            Console.WriteLine("2) Sell tickets for people on the plane");
            Console.WriteLine("3) Timetable for this plane will be shown");
            Console.WriteLine("4) Show people who inside the plane");
            Console.WriteLine("5) Exit");
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
        //// other Funk
        public void ViewDepartThePlaneToNextAeroport(AeroportModel TempAeroport)
        {
            int NumOfPlane;
            Console.Clear();
            TempAeroport.AllInfoAboutPlane();
            NumOfPlane = Initialization("Choose The plane : ");

            MenuOfDepart(NumOfPlane);

        }
        public void AllInfoPassagers(PlaneModel plane)
        {
            if (plane.CountPassagersInsideEconomyClass > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Economy Class : ");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
                InfoListAboutClassesFromPlane(plane, ClassFromPlane.Economy);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Economy class is empty");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (plane.CountPassagersInsideBusinessClass > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Business Class : ");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
                InfoListAboutClassesFromPlane(plane,ClassFromPlane.Business);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Business class is empty");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (plane.CountPassagersInsideFirstClass > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("First Class : ");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
                InfoListAboutClassesFromPlane(plane, ClassFromPlane.First);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First class is empty");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        private void InfoListAboutClassesFromPlane(PlaneModel plane , ClassFromPlane classFromPlaneModel )
        {
            foreach (var PersonFormEconomyClass in plane.ListOfPeople)
            {
                if (PersonFormEconomyClass.PersonsTicket.ClassTicket == classFromPlaneModel)
                {
                    Console.WriteLine(PersonFormEconomyClass);
                    Console.WriteLine("---------------------");
                }

            }
        }
        public void SellTicket(PlaneModel TempPlane, AeroportModel aeroport)
        {
            Console.Clear();
            Console.WriteLine("How many people do you want to sell tickets?");
            var countOfCustomers = Initialization("Enter count : ");
            CountOfCustomersEvent(countOfCustomers);

        }

        public void ShowAddedPersonToList(PersonModel person)
        {
            Console.WriteLine("================================");
            Console.WriteLine($"\n{person.ToString()} was append to plane into Business class");
        }
        public void ShowEndedOFSentence()
        {
            Console.Write("Enter something...");
            Console.ReadKey();
        }
        public void ShowErrorOFBuyTicket(int countOfCustomers)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Too many! Aeroport doesn't contain {countOfCustomers} people");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter something...");
            Console.ReadKey();
        }
        public void ShowDepartsTime(PlaneModel TempPlane, AeroportModel Aeroport)
        {
            Console.Clear();
            Console.WriteLine(TempPlane.ToString() + "Will arrive to " + Aeroport.NameOfAeroport + "in 3 min 20 sec");
            Console.Write("Enter Something...");
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


    }
}
