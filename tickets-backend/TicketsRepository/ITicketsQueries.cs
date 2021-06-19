using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDomain;
using TicketsDTOs;

namespace TicketsRepository
{
    public interface ITicketsQueries
    {
        Task<TicketDTO> Insert(Ticket newTicket);
    }
}
