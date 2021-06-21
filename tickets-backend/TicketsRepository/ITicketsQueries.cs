using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsDomain;
using TicketsDTOs;

namespace TicketsRepository
{
    public interface ITicketsQueries
    {
        Task<List<TicketDTO>> FindAll(int page, int count);
        Task<TicketDTO> FindById(string ticketId);
        Task<TicketDTO> Insert(Ticket newTicket);
        Task<string> Delete(string ticketId);
        Task<TicketDTO> Edit(Ticket ticket);
        Task<int> TotalAmount();
    }
}
