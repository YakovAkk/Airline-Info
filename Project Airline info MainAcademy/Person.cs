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
        Passport PersonsPassport { get; }  // contain all data for this person like
                                    // first name , second name , Nationality, NumOfPassport,DateOfBirthday and Sex
        ClassFromPlane ClassOfplane { get; set; } 
        Purse PersonsPurse { get; set; }

        // construcors
        public Person()
        {
            PersonsPassport = null;
            ClassOfplane = ClassFromPlane.None;
            PersonsPurse = null;
        }
        public Person(Passport passport, Purse purse, ClassFromPlane classFromPlane = ClassFromPlane.None)
        {
            PersonsPassport = passport;
            ClassOfplane = classFromPlane;
            PersonsPurse = purse;
        }
        public override string ToString()
        {
            return PersonsPassport.ToString() + "\n" + $"i will fly {ClassOfplane}\nI have {PersonsPurse.ToString()}";
        }
        public void ToBuy(Purse OtherPurse)
        {
            if (PersonsPurse.GetBalance() > OtherPurse.GetBalance())
            {
                PersonsPurse = PersonsPurse - OtherPurse;
            } 
        }
        public void SetClassInPlane(ClassFromPlane ClassFromPlane)
        {
            ClassOfplane = ClassFromPlane;
        }

        public Purse GetPurse()
        {
            return PersonsPurse;
        }

    }
}
