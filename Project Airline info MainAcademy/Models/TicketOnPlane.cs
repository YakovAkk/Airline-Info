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
    class TicketOnPlane
    {
        public ClassFromPlane ClassTicket { get; private set; }
        public Purse TicketPrice { get; private set; }

        public TicketOnPlane()
        {
            ClassTicket = ClassFromPlane.None;
            TicketPrice = new Purse(CurrencyType.UAH, 0);
        }
        public TicketOnPlane(ClassFromPlane ClassTicket , Purse TicketPrice)
        {
            this.ClassTicket = ClassTicket;
            this.TicketPrice = TicketPrice;
        }

        public void SetClassTicket(ClassFromPlane ClassTicket)
        {
            this.ClassTicket = ClassTicket;
        }
    }
}
