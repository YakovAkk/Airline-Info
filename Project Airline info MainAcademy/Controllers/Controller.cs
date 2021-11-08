using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Controller
    {
        private static Admin UserAdmin = new Admin();
        ViewConsole MyViewConsole = new ViewConsole();
        int NumOFAeroport = 0;
        public Controller()
        {
            MyViewConsole.CityAeroportMenu += MyViewConsole_CityAeroportMenu;
        }

        private void MyViewConsole_CityAeroportMenu(int obj)
        {
            NumOFAeroport = obj;
        }

        public Aeroport AnswerControllerOfEventCityAeroportMenu()
        {
            return UserAdmin.FindTheAeroportWithIndex(NumOFAeroport);
        }


    }
}
