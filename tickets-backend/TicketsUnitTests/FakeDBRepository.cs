using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDomain;
using TicketsDTOs;
using TicketsRepository;

namespace TicketsUnitTests
{
    public class FakeDBRepository : ITicketsQueries
    {
        public Task<TicketDTO> Insert(Ticket newTicket)
        {
            return Task.FromResult(new TicketDTO
            {
                Id = "60cd6a7eee1d529c390f66f8",
                User = newTicket.User,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Status = newTicket.Status
            });
        }
        public Task<string> Delete(string ticketId)
        {
            if (!ticketId.Equals("60cd6a7eee1d529c390f66f8"))
            {
                return Task.FromResult<string>(null);
            }
            else
            {
                return Task.FromResult(ticketId);
            }
        }

        public Task<TicketDTO> Edit(Ticket ticket)
        {
            if (!ticket.Id.Equals("60cd6a7eee1d529c390f66f8"))
            {
                return Task.FromResult<TicketDTO>(null);
            }
            else
            {
                return Task.FromResult(new TicketDTO
                {
                    Id = ticket.Id,
                    User = ticket.User,
                    CreationDate = ticket.CreationDate,
                    UpdateDate = ticket.UpdateDate,
                    Status = ticket.Status
                });
            }
        }

        public Task<List<TicketDTO>> FindAll(int page, int count)
        {
            throw new NotImplementedException();
        }

        public Task<TicketDTO> FindById(string ticketId)
        {
            if (!ticketId.Equals("60cd6a7eee1d529c390f66f8"))
            {
                return Task.FromResult<TicketDTO>(null);
            }
            else
            {
                return Task.FromResult(new TicketDTO
                {
                    Id = "60cd6a7eee1d529c390f66f8",
                    User = "Test",
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Status = true
                });
            }
        }
    }
}
