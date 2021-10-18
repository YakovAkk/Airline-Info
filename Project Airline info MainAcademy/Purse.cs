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
        static Random random = new Random(); // Amount in Person's pusre is randomed by the variable 
        int RandAmountMax = 10000;
        int RandAmountMin = 2000;
        CurrencyType typeOfMoney { get; set; }
        double Amount { get; set; }

        static double CourseToUSD { get; set; }
        static double CourseToEU { get; set; }


        // Constructors
        public Purse()
        {
            typeOfMoney = CurrencyType.UAH;
            Amount = random.Next(RandAmountMin, RandAmountMax);
            CourseToUSD = 26.55;
            CourseToEU = 30.51;
        }
        public Purse(CurrencyType typeOfMoney, double Amount)
        {
            this.typeOfMoney = typeOfMoney;
            this.Amount = Amount;
            this.Amount = this.MoneyExchange();
            CourseToUSD = 26.55;
            CourseToEU = 30.51;
        }
        //Methoods
        private double MoneyExchange()
        {
            if (typeOfMoney == CurrencyType.UAH)
            {
                return Amount;
            }
            if (typeOfMoney == CurrencyType.USD)
            {
                typeOfMoney = CurrencyType.UAH;
                return Amount * CourseToUSD;
            }
            if (typeOfMoney == CurrencyType.EU)
            {
                typeOfMoney = CurrencyType.UAH;
                return Amount * CourseToEU;
            }
            else
            {
                return 0;
            }
        }
        private double MoneyConvertor(CurrencyType typeOfMoney)
        {
            if (typeOfMoney == CurrencyType.UAH)
            {
                return Amount;
            }
            if (typeOfMoney == CurrencyType.USD)
            {
                return Amount / CourseToUSD;
            }
            if (typeOfMoney == CurrencyType.EU)
            {
                return Amount / CourseToEU;
            }
            else
            {
                return 0;
            }
        }
        public double GetBalance(CurrencyType typeOfMoney = CurrencyType.UAH)
        {
            return MoneyConvertor(typeOfMoney);
        }
        public void ShowBalance(CurrencyType typeOfMoney = CurrencyType.UAH)
        {
            Console.WriteLine($"Type of money is {typeOfMoney.ToString()}");
            Console.WriteLine($"Balance is {MoneyConvertor(typeOfMoney)}");
        }
        public void AddMoney(CurrencyType typeOfMoney, double Amount)
        {
            double Money = 0;

            if (typeOfMoney == CurrencyType.UAH)
            {
                Money += Amount;
            }
            if (typeOfMoney == CurrencyType.USD)
            {
                Money += Amount * 26.55;
            }
            if (typeOfMoney == CurrencyType.EU)
            {
                Money += Amount * 30.79;
            }
            this.Amount += Money;
        }
        public void RemoveFromBalance(CurrencyType typeOfMoney, double Amount)
        {
            double Money = 0;

            if (typeOfMoney == CurrencyType.UAH)
            {
                Money += Amount;
            }
            if (typeOfMoney == CurrencyType.USD)
            {
                Money += Amount * CourseToUSD;
            }
            if (typeOfMoney == CurrencyType.EU)
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
        public string GetCurrencyType()
        {
            return typeOfMoney.ToString();
        }
        public override string ToString()
        {
            return $"Type of money is {CurrencyType.UAH}. " + $"Balance is {this.Amount}";
        }
        public void setCourseEU(double value)
        {
            CourseToEU = value;
        }

        public void setCourseUSD(double value)
        {
            CourseToUSD = value;
        }
        public double getCourseEU()
        {
            return CourseToEU;
        }

        public double getCourseUSD()
        {
            return CourseToUSD;
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
