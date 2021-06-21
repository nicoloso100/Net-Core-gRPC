using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsDTOs;

namespace TicketsServices
{
    public interface IRequestService
    {
        Task<TicketDTO> FindOneTicket(string ticketId);
        Task<List<TicketDTO>> FindAllTickets(int page, int count);
        Task<int> CountTicketsAmount();
    }
}
