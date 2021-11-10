using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Airline_info_MainAcademy.Storage;

namespace Project_Airline_info_MainAcademy
{
    class AdminController
    {
        public SingleStorage MyStorage { get; private set; }

        ViewConsole MyViewConsole = new ViewConsole();
        // constructor
        public AdminController()
        {
            MyStorage = SingleStorage.GetInstance();
        }

        public void DepartDepartThePlaneToNextAeroport(int NumOfPlane, AeroportModel TempAeroport)
        {
            if (NumOfPlane < TempAeroport.CountOfPlane() && NumOfPlane > 0)
            {
                var TempPlane = TempAeroport.FindThePlaneWithIndex(NumOfPlane);

                if (TempPlane.StatusOfFly == StatusOfFly.GateClosed)
                {
                    MyViewConsole.ShowArrivedOfPlane();

                    var NumOfAeroport = Initialization("Your choose : ");


                    DepartThePlane(TempPlane, MyStorage.FindTheAeroportWithIndex(NumOfAeroport));

                    TempAeroport.RemovePlaneFromAeroport(TempPlane);

                }
                else
                {
                   MyViewConsole.ShowErrorOfArrived();
                }
            }
            else
            {
                MyViewConsole.ErrorOfPlane();
            }
        }
        private void DepartThePlane(PlaneModel TempPlane, AeroportModel Aeroport)
        {
            Task.Run(() =>
            {
                TempPlane.SetStatusOfFly(StatusOfFly.DepartedAt);
                Task.Delay(200000); // 3 min 20 sec

                Aeroport.AddPlaneToAeroport(TempPlane);
                TempPlane.SetStatusOfFly(StatusOfFly.Arrived);
            });
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
