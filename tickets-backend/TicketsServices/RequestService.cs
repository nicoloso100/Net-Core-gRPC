using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsDTOs;
using TicketsRepository;

namespace TicketsServices
{
    public class RequestService : IRequestService
    {
        private readonly ITicketsQueries _ticketsQueries;
        public RequestService(ITicketsQueries ticketsQueries)
        {
            _ticketsQueries = ticketsQueries;
        }

        public async Task<TicketDTO> FindOneTicket(string ticketId)
        {
            var foundTicket = await _ticketsQueries.FindById(ticketId);
            if (foundTicket is null)
            {
                throw new Exception("The specified ticket was not found.");
            }

            return foundTicket;
        }

        public async Task<List<TicketDTO>> FindAllTickets(int page, int count)
        {
            var tickets = await _ticketsQueries.FindAll(page: page, count: count);

            return tickets;
        }

        public async Task<int> CountTicketsAmount()
        {
            var ticketsAmount = await _ticketsQueries.TotalAmount();

            return ticketsAmount;
        }
    }
}
