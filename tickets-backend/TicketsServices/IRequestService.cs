using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDTOs;

namespace TicketsServices
{
    public interface IRequestService
    {
        Task<TicketDTO> FindOneTicket(string ticketId);
        Task<List<TicketDTO>> FindAllTickets(int page, int count);
    }
}
