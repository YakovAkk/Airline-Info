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
    class TicketOnPlaneModel
    {
        public ClassFromPlane ClassTicket { get; private set; }
        public PurseModel TicketPrice { get; private set; }

        public TicketOnPlaneModel()
        {
            ClassTicket = ClassFromPlane.None;
            TicketPrice = new PurseModel(CurrencyType.UAH, 0);
        }
        public TicketOnPlaneModel(ClassFromPlane ClassTicket , PurseModel TicketPrice)
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
