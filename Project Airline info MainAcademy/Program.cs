using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Program
    {
        static List<Timetable> timetables = new List<Timetable>();
        static Aeroport BoryspilAero = new Aeroport("Boryspil airport", 10);
        static Aeroport LvivAero = new Aeroport("Lviv airport", 8);
        static Aeroport KievAero = new Aeroport("airport Kiev", 6);
        static Aeroport OdessaAero = new Aeroport("Odessa airport", 6);
        static Aeroport KharkivAero = new Aeroport("Kharkiv airport", 4);

        static void Main(string[] args)
        {
            AddPlanesToAeroports();
            AddToListTimetable();


            Console.WriteLine("Good afternoon , you are greetings by Yakov's aeroport company. Do you want to choose city with aeroport?");
            Console.WriteLine("1) Choose the city with aeroport");
            Console.WriteLine("2) Exit");

            switch (Initialization("Your choose : "))
            {
                case 1:
                {
                    Console.Clear();
                    MenuCityWithAeroport();

                    break;
                }
                case 2:
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Good Bye! Have a nice day)");
                    Console.ReadKey();
                    break;
                }
                default:
                break;
            }
        }

        private static void MenuCityWithAeroport()
        {
            var FlagMain = true;
            while (FlagMain)
            {
                Header();
                switch (Initialization("Your choose : "))
                {
                    case 1:
                    {
                        MenuOfAeroport(BoryspilAero);

                        break;
                    }
                    case 2:
                    {
                        
                        MenuOfAeroport(LvivAero);

                        break;
                    }
                    case 3:
                    {
                        MenuOfAeroport(KievAero);

                        break;
                    }
                    case 4:
                    {
                        MenuOfAeroport(OdessaAero);

                        break;
                    }
                    case 5:
                    {
                        MenuOfAeroport(KharkivAero);

                        break;
                    }
                    case 6:
                    {
                        FlagMain = false;
                        break;
                    }
                    default:
                    break;
                }

            }
        }
        private static void MenuOfAeroport(Aeroport aeroport)
        {
            var FlagAero = true;
            while (FlagAero)
            {
                HeaderMenuOfAeroport(aeroport);

                switch (Initialization("Your choose : "))
                {
                    case 1:
                    {
                        Console.Clear();
                        aeroport.AllInfoAboutPlane();
                        var NumOfPlane = Initialization("Choose The plane : ");

                        if (NumOfPlane < aeroport.CountOfPlane() && NumOfPlane > 0)
                        {
                            var TempPlane = aeroport.FindThePlaneWithIndex(NumOfPlane);
                            MenuForPlane(TempPlane, aeroport);
                        }
                        else
                        {
                            Console.WriteLine("Aeroport doesn't contain this plane ");
                        }

                        break;
                    }
                    case 2:
                    {
                        Console.Clear();
                        aeroport.AllInfoAboutPlane();
                        var NumOfPlane = Initialization("Choose The plane : ");

                        if (NumOfPlane < aeroport.CountOfPlane() && NumOfPlane > 0)
                        {
                            var TempPlane = aeroport.FindThePlaneWithIndex(NumOfPlane);

                            if (TempPlane.GetStatusOfFly() == StatusOfFly.GateClosed)
                            {
                                Console.Clear();
                                Console.WriteLine("Plane will be flown to aeroport, choose it ");
                                Header();
                                switch (Initialization("Your choose : "))
                                {
                                    case 1:
                                    {
                                        DepartAtNextAero(TempPlane , BoryspilAero);
                                        break;
                                    }
                                    case 2:
                                    {
                                        DepartAtNextAero(TempPlane, LvivAero);
                                        break;
                                    }
                                    case 3:
                                    {
                                        DepartAtNextAero(TempPlane, KievAero);
                                        break;
                                    }
                                    case 4:
                                    {
                                        DepartAtNextAero(TempPlane, OdessaAero);
                                        break;
                                    }
                                    case 5:
                                    {
                                        DepartAtNextAero(TempPlane, KharkivAero);
                                        break;
                                    }
                                    default:
                                    break;
                                }
                                aeroport.RemovePlaneFromAeroport(TempPlane);

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("This plane doesn't ready to fly");
                                Console.Write("Enter something ... ");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aeroport doesn't contain this plane ");
                        }

                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("===============================");
                        Console.WriteLine(aeroport.ToString());
                        Console.WriteLine("===============================");
                        Console.ReadKey();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("===============================");
                        aeroport.AllInfoAboutPlane();
                        Console.WriteLine("===============================");

                        Console.ReadKey();
                        break;
                    }
                    case 5:
                    {
                        Console.Clear();
                        PrintTimetableForAeroport(aeroport);
                        Console.WriteLine("Enter something...");
                        Console.ReadKey();
                        
                        break;
                    }
                    case 6:
                    {
                        FlagAero = false;
                        break;
                    }
                    default:
                    break;
                }
            }
        }
        private static void MenuForPlane(Plane TempPlane , Aeroport aeroport)
        {
            var FlagMenuOfPlane = true;
            while (FlagMenuOfPlane)
            {
                Console.Clear();
                Console.WriteLine("===========================================================");
                Console.WriteLine($"Your choose {TempPlane.ToString()}");
                Console.WriteLine("===========================================================");
                HeaderForPlaneMenu();
                
                switch (Initialization("Your choose : "))
                {
                    case 1:
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
                        
                        break;
                    }
                    case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("How many people do you want to sell tickets?");
                        var countOfCustomers = Initialization("Enter count : ");

                        if(countOfCustomers < aeroport.GetCountOfLitsWithPeopleInAeroport())
                        {
                            
                            foreach (var person in aeroport.GetListWithPeopleInAeroport())
                            {
                                if (countOfCustomers == 0)
                                {
                                    break;
                                }
                                if (person.GetPurse() > TempPlane.GetPriceFirstClass())
                                {
                                    person.ToBuy(TempPlane.GetPriceFirstClass());
                                    person.SetClassInPlane(ClassFromPlane.First);

                                    TempPlane.AddToListFirst(person);

                                    Console.WriteLine("================================");
                                    Console.WriteLine($"\n{person.ToString()} was append to plane into First class");
                                }
                                else if (person.GetPurse() > TempPlane.GetPriceBusinessClass())
                                {
                                    person.ToBuy(TempPlane.GetPriceBusinessClass());
                                    person.SetClassInPlane(ClassFromPlane.Business);

                                    TempPlane.AddToListBusiness(person);

                                    Console.WriteLine("================================");
                                    Console.WriteLine($"\n{person.ToString()} was append to plane into Business class");
                                }
                                else if (person.GetPurse() > TempPlane.GetPriceEconomyClass())
                                {
                                    person.ToBuy(TempPlane.GetPriceEconomyClass());
                                    person.SetClassInPlane(ClassFromPlane.Economy);
                                  
                                    TempPlane.AddToListEconomy(person);

                                    Console.WriteLine("================================");
                                    Console.WriteLine($"\n{person.ToString()} was append to plane into Economy class");
                                }
                                countOfCustomers--;
                            }
                            aeroport.RemoveFromListWithPeople(TempPlane.GetListWithPeopleInPlaneFirstClass());
                            aeroport.RemoveFromListWithPeople(TempPlane.GetListWithPeopleInPlaneBusinessClass());
                            aeroport.RemoveFromListWithPeople(TempPlane.GetListWithPeopleInPlaneEconomyClass());

                            Console.Write("Enter something...");
                            Console.ReadKey();
                            TempPlane.SetStatusOfFly(StatusOfFly.GateClosed);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Too many! Aeroport doesn't contain {countOfCustomers} people");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Enter something...");
                            Console.ReadKey();
                        }
                        break;
                    }
                    case 3:
                    {
                        Console.Clear();
                        PrintTimetableForPlane(TempPlane);
                        Console.WriteLine("Enter something...");
                        Console.ReadKey();
                        break;
                    }
                    case 4: 
                    {
                        Console.Clear();
                        TempPlane.AllInfoPassagers();

                        Console.Write("Enter something...");
                        Console.ReadKey();

                        break;
                    }
                    case 5:
                    {
                        FlagMenuOfPlane = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Menu doesn't contain this topic");
                        break;
                    }

                }
            }

        }
        private static void AddPlanesToAeroports()
        {
            // Boruspil
            var Boeing737 = new Plane("Boeing737", 70, 50, 20);
            var Ту104 = new Plane("Ту104", 75, 50, 30);
            var Boeing777Х = new Plane("Boeing777Х", 77, 60, 10);
            var Boeing747 = new Plane("Boeing747", 80, 40, 10);
            var А380 = new Plane("А380", 80, 40, 20);

            BoryspilAero.AddPlaneToAeroport(Boeing737);
            BoryspilAero.AddPlaneToAeroport(Ту104);
            BoryspilAero.AddPlaneToAeroport(Boeing777Х);
            BoryspilAero.AddPlaneToAeroport(Boeing747);
            BoryspilAero.AddPlaneToAeroport(А380);

            // Kharkiv
            var Boeing730 = new Plane("Boeing737", 70, 50, 20);
            var Ту100 = new Plane("Ту104", 75, 50, 30);

            KharkivAero.AddPlaneToAeroport(Boeing730);
            KharkivAero.AddPlaneToAeroport(Ту100);

            // Odessa

            var Boeing777 = new Plane("Boeing777Х", 77, 60, 10);
            var Boeing740 = new Plane("Boeing747", 80, 40, 10);
            var А381 = new Plane("А380", 80, 40, 20);

            OdessaAero.AddPlaneToAeroport(Boeing777);
            OdessaAero.AddPlaneToAeroport(Boeing740);
            OdessaAero.AddPlaneToAeroport(А381);

            // Kiev

            var Boeing731 = new Plane("Boeing737", 70, 50, 20);
            var Ту101 = new Plane("Ту104", 75, 50, 30);
            var Boeing666 = new Plane("Boeing777Х", 77, 60, 10);

            KievAero.AddPlaneToAeroport(Boeing731);
            KievAero.AddPlaneToAeroport(Ту101);
            KievAero.AddPlaneToAeroport(Boeing666);

            // Lviv

            var Boeing732 = new Plane("Boeing737", 70, 50, 20);
            var Ту102 = new Plane("Ту104", 75, 50, 30);
            var Boeing444 = new Plane("Boeing777Х", 77, 60, 10);
            var Boeing742 = new Plane("Boeing747", 80, 40, 10);


            LvivAero.AddPlaneToAeroport(Boeing732);
            LvivAero.AddPlaneToAeroport(Ту102);
            LvivAero.AddPlaneToAeroport(Boeing444);
            LvivAero.AddPlaneToAeroport(Boeing742);
        }
        private static void HeaderMenuOfAeroport(Aeroport aeroport)
        {
            Console.Clear();
            Console.WriteLine(aeroport.ToString());
            Console.WriteLine();
            Console.WriteLine("1) Go to menu of each plane");
            Console.WriteLine("2) Run a plane to next aeroport");
            Console.WriteLine("3) Aeroport Info");
            Console.WriteLine("4) List of plane");
            Console.WriteLine("5) Timetable for this Aeroport will be shown");
            Console.WriteLine("6) Show to other aeroport");
        }
        private static void HeaderForPlaneMenu()
        {
            Console.WriteLine("1) People who want to buy tickets in plane will be shown");
            Console.WriteLine("2) Sell tickets for people on the plane");
            Console.WriteLine("3) Timetable for this plane will be shown");
            Console.WriteLine("4) Show people who inside the plane");
            Console.WriteLine("5) Exit");
        }
        private static void Header()
        {
            Console.WriteLine("1) Boryspil airport");
            Console.WriteLine("2) Lviv airport");
            Console.WriteLine("3) airport Kiev");
            Console.WriteLine("4) Odessa airport");
            Console.WriteLine("5) Kharkiv airport");
            Console.WriteLine("6) Exit");
        }
        private static int Initialization(string message = "")
        {
            int valueUser;
            while (true)
            {
                Console.Write(message);

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
        private async static void DepartAtNextAero(Plane TempPlane , Aeroport aeroport)
        {
            await Task.Run(() =>
            {
                TempPlane.SetStatusOfFly(StatusOfFly.DepartedAt);
                Console.Clear();
                Console.WriteLine(TempPlane.ToString() + "Will arrive to " + aeroport.GetName() + "in 3 min 20 sec");
                Task.Delay(200000); // 3 min 20 sec

                aeroport.AddPlaneToAeroport(TempPlane);
                TempPlane.SetStatusOfFly(StatusOfFly.Arrived);
            });
        }
        private static void AddToTimetable(Aeroport aeroport1, Aeroport aeroport2)
        {
            foreach (var item in aeroport1.GetPlanes())
            {
                timetables.Add(new Timetable(item.GetName(), aeroport1.GetName(), new DateTime().Date.AddDays(1), aeroport2.GetName(),
                    new DateTime().Date.AddDays(2), item.GetFreePlaces()));
            }
        }
        private static void AddToListTimetable()
        {
            AddToTimetable(BoryspilAero, LvivAero);
            AddToTimetable(BoryspilAero, KievAero);
            AddToTimetable(BoryspilAero, OdessaAero);
            AddToTimetable(BoryspilAero, KharkivAero);
            AddToTimetable(LvivAero, KievAero);
            AddToTimetable(LvivAero, OdessaAero);
            AddToTimetable(LvivAero, KharkivAero);
            AddToTimetable(KievAero, OdessaAero);
            AddToTimetable(KievAero, KharkivAero);
            AddToTimetable(OdessaAero, KharkivAero);
        }
        private static void PrintTimetableForAeroport(Aeroport aeroport)
        {
            foreach (var timetable in timetables)
            {
                if (timetable.GetStartPoint() == aeroport.GetName() || timetable.GetEndPoint() == aeroport.GetName())
                {
                    Console.WriteLine(timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }
        private static void PrintTimetableForPlane(Plane plane)
        {
            foreach (var timetable in timetables)
            {
                if (timetable.GetNameOfPlane() == plane.GetName())
                {
                    Console.WriteLine(timetable.ToString());
                    Console.WriteLine("================================================");
                }
            }
        }
    }
}
