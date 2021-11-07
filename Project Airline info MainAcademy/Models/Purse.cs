using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    class Purse
    {
        private static Random UserRandom = new Random(); // Amount in Person's pusre is randomed by the variable 
        private const int RandAmountMax = 10000;
        private const int RandAmountMin = 2000;
        public CurrencyType TypeOfMoney { get; private set; }
        public double Amount { get;private set; }

        public static double CourseToUSD { get; private set; }
        public static double CourseToEU { get; private set; }


        // Constructors
        public Purse()
        {
            TypeOfMoney = CurrencyType.UAH;
            Amount = UserRandom.Next(RandAmountMin, RandAmountMax);
            CourseToUSD = 26.55;
            CourseToEU = 30.51;
        }
        public Purse(CurrencyType typeOfMoney, double Amount)
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
            if (TypeOfMoney == CurrencyType.UAH)
            {
                return Amount;
            }
            if (TypeOfMoney == CurrencyType.USD)
            {
                TypeOfMoney = CurrencyType.UAH;
                return Amount * CourseToUSD;
            }
            if (TypeOfMoney == CurrencyType.EU)
            {
                TypeOfMoney = CurrencyType.UAH;
                return Amount * CourseToEU;
            }
            else
            {
                return 0;
            }
        }
        private double MoneyConvertor(CurrencyType TypeOfMoney)
        {
            if (TypeOfMoney == CurrencyType.UAH)
            {
                return Amount;
            }
            if (TypeOfMoney == CurrencyType.USD)
            {
                return Amount / CourseToUSD;
            }
            if (TypeOfMoney == CurrencyType.EU)
            {
                return Amount / CourseToEU;
            }
            else
            {
                return 0;
            }
        }
        public double GetBalance(CurrencyType TypeOfMoney = CurrencyType.UAH)
        {
            return MoneyConvertor(TypeOfMoney);
        }

        public override string ToString()
        {
            return $"Type of money is {CurrencyType.UAH}. " + $"Balance is {this.Amount}";
        }
        public static Purse operator +(Purse one, Purse two)
        {
            return new Purse(CurrencyType.UAH, one.Amount + two.Amount);
        }
        public static Purse operator -(Purse one, Purse two)
        {
            return new Purse(CurrencyType.UAH, one.Amount - two.Amount);
        }
        public static bool operator < (Purse one, Purse two)
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
        public static bool operator > (Purse one, Purse two)
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
