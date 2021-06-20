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
            if (newTicket.User is null)
            {
                throw new Exception("You must enter a user name.");
            }
            var ticket = new Ticket(user: newTicket.User, status: newTicket.Status);
            var savedTicket = await _ticketsQueries.Insert(ticket);

            return savedTicket;
        }

        public async Task<string> DeleteTicket(string ticketId)
        {
            var deletedId = await _ticketsQueries.Delete(ticketId);
            if (deletedId is null)
            {
                throw new Exception("The specified ticket was not found.");
            }

            return deletedId;
        }

        public async Task<TicketDTO> EditTicket(EditTicketDTO modifiedTicket)
        {
            if (modifiedTicket.User is null || modifiedTicket.Id is null)
            {
                throw new Exception("You must enter a user name and ticket id.");
            }
            var ticket = new Ticket(user: modifiedTicket.User, status: modifiedTicket.Status, id: modifiedTicket.Id);
            var resultTicket = await _ticketsQueries.Edit(ticket);
            if (resultTicket is null)
            {
                throw new Exception("The specified ticket was not found.");
            }

            return resultTicket;
        }
    }
}
