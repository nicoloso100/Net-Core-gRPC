using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDTOs;

namespace TicketsServices
{
    public interface IManagementService
    {
        Task<TicketDTO> CreateTicket(CreateTicketDTO newTicket);
        Task<string> DeleteTicket(string ticketId);
        Task<TicketDTO> EditTicket(EditTicketDTO modifiedTicket);
    }
}
