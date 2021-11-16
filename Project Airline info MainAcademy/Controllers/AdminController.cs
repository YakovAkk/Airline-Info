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
        private readonly SingleStorage _myStorage;

        private ViewConsole _myViewConsole;
        // constructor
        public AdminController()
        {
            _myViewConsole = new ViewConsole();
            _myStorage = SingleStorage.GetInstance();
        }
        public void DepartDepartThePlaneToNextAeroport(int NumOfPlane, AeroportModel TempAeroport)
        {
            if (NumOfPlane < TempAeroport.CountOfPlane() && NumOfPlane > 0)
            {
                var TempPlane = TempAeroport.FindThePlaneWithIndex(NumOfPlane);

                if (TempPlane.StatusOfFly == StatusOfFly.GateClosed)
                {
                    _myViewConsole.ShowArrivedOfPlane();

                    var NumOfAeroport = Initialization("Your choose : ");


                    DepartThePlane(TempPlane, _myStorage.FindTheAeroportWithIndex(NumOfAeroport));

                    TempAeroport.RemovePlaneFromAeroport(TempPlane);

                }
                else
                {
                   _myViewConsole.ShowErrorOfArrived();
                }
            }
            else
            {
                _myViewConsole.ErrorOfPlane();
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
