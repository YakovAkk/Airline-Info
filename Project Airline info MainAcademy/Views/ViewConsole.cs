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
        public event Action<int> AdminMenuEvent = delegate { };
        public event Action<int> FindRaceByNumEvent = delegate { };
        public event Action<int> FindEndDestinationAirportEvent = delegate { };
        public event Action<int> FindRacesWhichCostLessThanXEvent = delegate { };
        public event Action<string> PasswordEvent = delegate { };
        public event Action<int> MainAdminMenuEvent = delegate { };
        public event Action<int> RemoveEvent = delegate { };
        public event Action<PlaneModel> CreatePlaneEvent = delegate { };
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
        public void MenuCityWithAeroport(List<AeroportModel> aeroports)
        {
            Console.Clear();

            Header(aeroports);
            var NumOfAeroport = Initialization("Your choose : ");
            CityAeroportMenuEvent(NumOfAeroport);

        }
        public void MenuForPlane(PlaneModel TempPlane)
        {
           Console.Clear();
           Console.WriteLine("===========================================================");
           Console.WriteLine($"Your choose {TempPlane.ToString()}");
           Console.WriteLine("===========================================================");
           HeaderForPlaneMenu();

           var UserNum = (Initialization("Your choose : "));
           MenuOfPlaneEvent(UserNum);
        }
        public void MenuAdmin()
        {
            HeaderAdmin();
            var UserNum = (Initialization("Your choose : "));
            AdminMenuEvent(UserNum);
        }
        // Messages To user
        public void ShowErrorDelete()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Plane wasn't deleted");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowSuccessDelete()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Plane was deleted");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowAddPlaneToAeroport()
        {
            Console.WriteLine("Now you must write parameters of plane");
            Console.Write("Name of plane : ");
            var NameOfPlane = Console.ReadLine();
            var AmountEconomy = Initialization("Amount place in Economy class : ");
            var AmountBusiness = Initialization("Amount place in Business class : ");
            var AmountFirst = Initialization("Amount place in First class : ");

            CreatePlaneEvent(new PlaneModel(NameOfPlane, AmountEconomy, AmountBusiness, AmountFirst));
        }
        public void ShowInfoAboutPlaneForDelete(AeroportModel userAeroport)
        {
            Console.WriteLine("===============================");
            userAeroport.AllInfoAboutPlane();
            Console.WriteLine("===============================");
            RemoveEvent(Initialization("Your Choose : "));
        }
        public void PrintTimetableForAeroportByNum(AeroportModel TempAeroports, List<TimetableModel> Timetables, int Num)
        {
            foreach (var Timetable in Timetables)
            {
                if (Timetable.StartPoint == TempAeroports.NameOfAeroport || Timetable.EndPoint == TempAeroports.NameOfAeroport && Timetable.NumOfRace == Num)
                {
                    Console.WriteLine(Timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
            ShowEndedOFSentence();
        }
        public void ShowPersonFirst()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You should fly in first class in any Races");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowPersonBusiness()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You should fly in Business class in any Races");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowPersonEconomy()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You should fly in Economy class in any Races");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowPlaneWhichHaveFreePlaces(List<PlaneModel> planes)
        {
            Console.Clear();
            Console.WriteLine("You can sit on these planes : ");
            foreach (var plane in planes)
            {
                if (plane.isFree())
                {
                    Console.WriteLine(plane.ToString());
                }
            }
        }
        public void EnterLikeAdmin()
        {
            Console.Clear();
            Console.Write("Enter password : ");
            PasswordEvent(Console.ReadLine());
        }
        public void ShowPersonWithoutMoney()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sorry, person without money doesn't serviced");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowRacesWhichCostLessThanX()
        {
            var UserNum = (Initialization("Enter the Sum : "));
            FindRacesWhichCostLessThanXEvent(UserNum);
        }
        public void ShowFindRaceWitnEndPoint(List<AeroportModel> aeroports)
        {
            Header(aeroports);
            var NumOfAeroport = Initialization("Choose name of final destination airport: ");
            FindEndDestinationAirportEvent(NumOfAeroport);
        }
        public void ShowFindRaceByNum()
        {
            var UserNum = (Initialization("Enter The Number : "));
            FindRaceByNumEvent(UserNum);
        }
        public void ShowMenuMainAdmin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome, sir");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("1) Add plane to Aeroport");
            Console.WriteLine("2) Remove plane From Aeroport");
            Console.WriteLine("3) Back");
            MainAdminMenuEvent(Initialization("Your choose : "));
        }
        public void ShowAccessDenied()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Access denied !");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowAeroportWithDestitation(List<TimetableModel> Timetables, AeroportModel TempAeroport)
        {
            Console.Clear();
            foreach (var Timetable in Timetables)
            {
                if (Timetable.EndPoint == TempAeroport.NameOfAeroport)
                {
                    Console.WriteLine(Timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
            ShowEndedOFSentence();
        }
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
        public void ShowArrivedOfPlane(List<AeroportModel> aeroports)
        {
            Console.Clear();
            Console.WriteLine("Plane will be flown to aeroport, choose it ");
            Header(aeroports);
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
        public void ShowPeopleWhoWantToFly(AeroportModel Aeroport)
        {
            Console.Clear();

            var NumberOfPerson = 1;
            foreach (var Person in Aeroport.GetListWithPeopleInAeroport())
            {
                if(Person.PersonsPassport != null)
                {
                    Console.WriteLine($"{NumberOfPerson++}) {Person.ToString()}");
                    Console.WriteLine("===============================");
                }
                else
                {
                    break;
                }
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

        // Headers
        private void HeaderAdmin()
        {
            Console.Clear();
            Console.WriteLine("1) Show all races");
            Console.WriteLine("2) Find a race with number");
            Console.WriteLine("3) Find a flight by your final destination");
            Console.WriteLine("4) Show all rases today");
            Console.WriteLine("5) Show races which will be in the nearest 7 days");
            Console.WriteLine("6) Show races which cost less than x UAH");
            Console.WriteLine("7) Show races which have free place");
            Console.WriteLine("8) Enter Like Administrator");
            Console.WriteLine("9) Exit");
        }
        private void Header(List<AeroportModel> aeroports)
        {
            int i = 1;
            foreach (var aeroport in aeroports)
            {
                Console.WriteLine($"{i}) {aeroport.NameOfAeroport}");
                i++;
            }
            Console.WriteLine($"{i}) Exit");
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
            Console.WriteLine("6) Admin");
            Console.WriteLine("7) Show to other aeroport");

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
        public void AllInfoPassagers(PlaneModel Plane)
        {
            if (Plane.CountPassagersInsideEconomyClass > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Economy Class : ");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
                InfoListAboutClassesFromPlane(Plane, ClassFromPlane.Economy);
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
            if (Plane.CountPassagersInsideBusinessClass > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Business Class : ");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
                InfoListAboutClassesFromPlane(Plane,ClassFromPlane.Business);
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
            if (Plane.CountPassagersInsideFirstClass > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("First Class : ");
                Console.WriteLine("===========================================================");
                Console.ForegroundColor = ConsoleColor.White;
                InfoListAboutClassesFromPlane(Plane, ClassFromPlane.First);
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
        private void InfoListAboutClassesFromPlane(PlaneModel Plane , ClassFromPlane ClassFromPlaneModel )
        {
            foreach (var PersonFormEconomyClass in Plane.ListOfPeople)
            {
                if (PersonFormEconomyClass.PersonsTicket.ClassTicket == ClassFromPlaneModel)
                {
                    Console.WriteLine(PersonFormEconomyClass);
                    Console.WriteLine("---------------------");
                }

            }
        }
        public void SellTicket()
        {
            Console.Clear();
            Console.WriteLine("How many people do you want to sell tickets?");
            var countOfCustomers = Initialization("Enter count : ");
            CountOfCustomersEvent(countOfCustomers);

        }

        public void ShowAddedPersonToList(PersonModel Person)
        {
            if(Person.PersonsTicket.ClassTicket == ClassFromPlane.First)
            {
                Console.WriteLine("================================");
                Console.WriteLine($"\n{Person.ToString()} was append to plane into First class");
            }
            if (Person.PersonsTicket.ClassTicket == ClassFromPlane.Business)
            {
                Console.WriteLine("================================");
                Console.WriteLine($"\n{Person.ToString()} was append to plane into Business class");
            }
            if (Person.PersonsTicket.ClassTicket == ClassFromPlane.Economy)
            {
                Console.WriteLine("================================");
                Console.WriteLine($"\n{Person.ToString()} was append to plane into Economy class");
            }
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
