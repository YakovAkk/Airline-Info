using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    enum CurrencyType
    {
        None = 0,
        UAH,
        USD,
        EU
    }
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
        public void ShowBalance(CurrencyType TypeOfMoney = CurrencyType.UAH)
        {
            Console.WriteLine($"Type of money is {TypeOfMoney.ToString()}");
            Console.WriteLine($"Balance is {MoneyConvertor(TypeOfMoney)}");
        }
        public void AddMoney(CurrencyType TypeOfMoney, double Amount)
        {
            double Money = 0;

            if (TypeOfMoney == CurrencyType.UAH)
            {
                Money += Amount;
            }
            if (TypeOfMoney == CurrencyType.USD)
            {
                Money += Amount * 26.55;
            }
            if (TypeOfMoney == CurrencyType.EU)
            {
                Money += Amount * 30.79;
            }
            this.Amount += Money;
        }
        public void RemoveFromBalance(CurrencyType TypeOfMoney, double Amount)
        {
            double Money = 0;

            if (TypeOfMoney == CurrencyType.UAH)
            {
                Money += Amount;
            }
            if (TypeOfMoney == CurrencyType.USD)
            {
                Money += Amount * CourseToUSD;
            }
            if (TypeOfMoney == CurrencyType.EU)
            {
                Money += Amount * CourseToEU;
            }
            this.Amount -= Money;
        }
        public void SetCourse(CurrencyType typeOfMoney, double value)
        {
            if (typeOfMoney == CurrencyType.USD)
            {
                CourseToUSD = value;
            }
            if (typeOfMoney == CurrencyType.EU)
            {
                CourseToEU = value;
            }
        }
        public override string ToString()
        {
            return $"Type of money is {CurrencyType.UAH}. " + $"Balance is {this.Amount}";
        }
        public void setCourseEU(double Value)
        {
            CourseToEU = Value;
        }

        public void setCourseUSD(double value)
        {
            CourseToUSD = value;
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
