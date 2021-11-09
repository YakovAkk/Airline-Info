using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Airline_info_MainAcademy
{ 

    enum ClassFromPlaneModel
    {
        None = 0,
        Economy,
        Business,
        First
    }
    class TicketOnPlaneModel
    {
        public ClassFromPlaneModel ClassTicket { get; private set; }
        public PurseModel TicketPrice { get; private set; }

        public TicketOnPlaneModel()
        {
            ClassTicket = ClassFromPlaneModel.None;
            TicketPrice = new PurseModel(CurrencyTypeModel.UAH, 0);
        }
        public TicketOnPlaneModel(ClassFromPlaneModel ClassTicket , PurseModel TicketPrice)
        {
            this.ClassTicket = ClassTicket;
            this.TicketPrice = TicketPrice;
        }

        public void SetClassTicket(ClassFromPlaneModel ClassTicket)
        {
            this.ClassTicket = ClassTicket;
        }
    }
}
