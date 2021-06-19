using System;
using System.Threading.Tasks;
using TicketsDomain;
using TicketsDTOs;
using TicketsRepository;

namespace TicketsServices
{
    public class ManagementService : IManagementService
    {
        private readonly ITicketsQueries _ticketsQueries;
        public ManagementService(ITicketsQueries ticketsQueries)
        {
            _ticketsQueries = ticketsQueries;
        }
        public async Task<TicketDTO> CreateTicket(CreateTicketDTO newTicket)
        {
            var ticket = new Ticket(user: newTicket.User, status: newTicket.Status);
            var savedTicket = await _ticketsQueries.Insert(ticket);

            return savedTicket;
        }
    }
}
