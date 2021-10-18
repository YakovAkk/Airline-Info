using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    enum ClassFromPlane
    {
        None = 0,
        Economy,
        Business,
        First
    }
    class Person
    {
        Passport passport { get; }  // contain all data for this person like
                                    // first name , second name , Nationality, NumOfPassport,DateOfBirthday and Sex
        ClassFromPlane ClassOfplane { get; set; } 
        Purse purse { get; set; }

        // construcors
        public Person()
        {
            passport = null;
            ClassOfplane = ClassFromPlane.None;
            purse = null;
        }
        public Person(Passport passport, Purse purse, ClassFromPlane classFromPlane = ClassFromPlane.None)
        {
            this.passport = passport;
            this.ClassOfplane = classFromPlane;
            this.purse = purse;
        }
        public override string ToString()
        {
            return passport.ToString() + "\n" + $"i will fly {ClassOfplane}\nI have {purse.ToString()}";
        }
        public void ToBuy(Purse OtherPurse)
        {
            if (purse.GetBalance() > OtherPurse.GetBalance())
            {
                purse = purse - OtherPurse;
            } 
        }
        public void SetClassInPlane(ClassFromPlane classFromPlane)
        {
            ClassOfplane = classFromPlane;
        }

        public Purse GetPurse()
        {
            return purse;
        }

    }
}
