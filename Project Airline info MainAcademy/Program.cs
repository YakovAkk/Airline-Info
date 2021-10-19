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
        static Admin UserAdmin = new Admin();
        
        static void Main(string[] args)
        {

            Console.WriteLine("Good afternoon , you are greetings by Yakov's aeroport company. Do you want to choose city with aeroport?");
            Console.WriteLine("1) Choose the city with aeroport");
            Console.WriteLine("2) Exit");

            switch (Initialization("Your choose : "))
            {
                case 1:
                
                    Console.Clear();
                    MenuCityWithAeroport();

                    break;
                
                case 2:
                
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Good Bye! Have a nice day)");
                    Console.ReadKey();
                    break;
                
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
                var NumOfAeroport = Initialization("Your choose : ");

                MenuOfAeroport(UserAdmin.FindTheAeroportWithIndex(NumOfAeroport));

            }
        }
        private static void MenuOfAeroport(Aeroport TempAeroport)
        {
            var FlagAero = true;
            while (FlagAero)
            {
                HeaderMenuOfAeroport(TempAeroport);
                var NumOfPlane = 0; // for contain number of plane
                switch (Initialization("Your choose : "))
                {
                    case 1:
                    
                        Console.Clear();
                        TempAeroport.AllInfoAboutPlane();
                        NumOfPlane = Initialization("Choose The plane : ");

                        if (NumOfPlane < TempAeroport.CountOfPlane() && NumOfPlane > 0)
                        {
                            var TempPlane = TempAeroport.FindThePlaneWithIndex(NumOfPlane);
                            MenuForPlane(TempPlane, TempAeroport);
                        }
                        else
                        {
                            Console.WriteLine("Aeroport doesn't contain this plane ");
                        }

                        break;
                    
                    case 2:
                    
                        Console.Clear();
                        TempAeroport.AllInfoAboutPlane();
                        NumOfPlane = Initialization("Choose The plane : ");

                        if (NumOfPlane < TempAeroport.CountOfPlane() && NumOfPlane > 0)
                        {
                            var TempPlane = TempAeroport.FindThePlaneWithIndex(NumOfPlane);

                            if (TempPlane.GetStatusOfFly() == StatusOfFly.GateClosed)
                            {
                                Console.Clear();
                                Console.WriteLine("Plane will be flown to aeroport, choose it ");
                                Header();

                                var NumOfAeroport = Initialization("Your choose : ");


                                UserAdmin.DepartAtNextAero(TempPlane, UserAdmin.FindTheAeroportWithIndex(NumOfAeroport));

                                TempAeroport.RemovePlaneFromAeroport(TempPlane);

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
                    
                    case 3:
                    
                        Console.WriteLine("===============================");
                        Console.WriteLine(TempAeroport.ToString());
                        Console.WriteLine("===============================");
                        Console.ReadKey();
                        break;
                    
                    case 4:
                    
                        Console.WriteLine("===============================");
                        TempAeroport.AllInfoAboutPlane();
                        Console.WriteLine("===============================");

                        Console.ReadKey();
                        break;
                    
                    case 5:
                    
                        Console.Clear();
                        Timetable.PrintTimetableForAeroport(TempAeroport);
                        Console.WriteLine("Enter something...");
                        Console.ReadKey();

                        break;
                    
                    case 6:
                    
                        FlagAero = false;
                        break;
                    
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
                    
                    case 2:
                    
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
                    
                    case 3:
                    
                        Console.Clear();
                        Timetable.PrintTimetableForPlane(TempPlane);
                        Console.WriteLine("Enter something...");
                        Console.ReadKey();
                        break;
                    
                    case 4: 
                    
                        Console.Clear();
                        TempPlane.AllInfoPassagers();

                        Console.Write("Enter something...");
                        Console.ReadKey();

                        break;
                    
                    case 5:
                    
                        FlagMenuOfPlane = false;
                        break;
                    
                    default:
                    
                        Console.WriteLine("Menu doesn't contain this topic");
                        break;
                    

                }
            }

        }
        private static void HeaderMenuOfAeroport(Aeroport TempAeroport)
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
        private static int Initialization(string Message = "")
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
