using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class PurseModel
    {
        private static Random UserRandom = new Random(); // Amount in Person's pusre is randomed by the variable 
        private const int RandAmountMax = 10000;
        private const int RandAmountMin = 2000;
        public CurrencyTypeModel TypeOfMoney { get; private set; }
        public double Amount { get;private set; }

        public static double CourseToUSD { get; private set; }
        public static double CourseToEU { get; private set; }


        // Constructors
        public PurseModel()
        {
            TypeOfMoney = CurrencyTypeModel.UAH;
            Amount = UserRandom.Next(RandAmountMin, RandAmountMax);
            CourseToUSD = 26.55;
            CourseToEU = 30.51;
        }
        public PurseModel(CurrencyTypeModel typeOfMoney, double Amount)
        {
            this.TypeOfMoney = typeOfMoney;
            this.Amount = Amount;
            this.Amount = this.MoneyExchange();
            CourseToUSD = 26.55;
            CourseToEU = 30.51;
        }
        //Methoods
        private double MoneyExchange()
        {
            if (TypeOfMoney == CurrencyTypeModel.UAH)
            {
                return Amount;
            }
            if (TypeOfMoney == CurrencyTypeModel.USD)
            {
                TypeOfMoney = CurrencyTypeModel.UAH;
                return Amount * CourseToUSD;
            }
            if (TypeOfMoney == CurrencyTypeModel.EU)
            {
                TypeOfMoney = CurrencyTypeModel.UAH;
                return Amount * CourseToEU;
            }
            else
            {
                return 0;
            }
        }
        private double MoneyConvertor(CurrencyTypeModel TypeOfMoney)
        {
            if (TypeOfMoney == CurrencyTypeModel.UAH)
            {
                return Amount;
            }
            if (TypeOfMoney == CurrencyTypeModel.USD)
            {
                return Amount / CourseToUSD;
            }
            if (TypeOfMoney == CurrencyTypeModel.EU)
            {
                return Amount / CourseToEU;
            }
            else
            {
                return 0;
            }
        }
        public double GetBalance(CurrencyTypeModel TypeOfMoney = CurrencyTypeModel.UAH)
        {
            return MoneyConvertor(TypeOfMoney);
        }

        public override string ToString()
        {
            return $"Type of money is {CurrencyTypeModel.UAH}. " + $"Balance is {this.Amount}";
        }
        public static PurseModel operator +(PurseModel one, PurseModel two)
        {
            return new PurseModel(CurrencyTypeModel.UAH, one.Amount + two.Amount);
        }
        public static PurseModel operator -(PurseModel one, PurseModel two)
        {
            return new PurseModel(CurrencyTypeModel.UAH, one.Amount - two.Amount);
        }
        public static bool operator < (PurseModel one, PurseModel two)
        {
            if(one.GetBalance() < two.GetBalance())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator > (PurseModel one, PurseModel two)
        {
            if (one.GetBalance() < two.GetBalance())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
