using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{
    
    class PersonModel
    {
        public PassportModel PersonsPassport { get; private set; }  // contain all data for this person like
                                    // first name , second name , Nationality, NumOfPassport,DateOfBirthday and Sex
        public TicketOnPlaneModel PersonsTicket { get;private set; } // Class which the person will fly to new city
        public PurseModel PersonsPurse { get;private set; } // his/her money
        // construcors
        public PersonModel(PassportModel passport, PurseModel purse, TicketOnPlaneModel ticket)
        {
            PersonsPassport = passport;
            PersonsTicket = ticket;
            PersonsPurse = purse;
        }
        public override string ToString()
        {
            return PersonsPassport.ToString() + "\n" + $"i will fly {PersonsTicket.ClassTicket}\nI have {PersonsPurse.ToString()}";
        }
        public void ToBuy(PurseModel OtherPurse)
        {
            if (PersonsPurse.GetBalance() > OtherPurse.GetBalance())
            {
                PersonsPurse = PersonsPurse - OtherPurse;
            } 
        }

    }
}
