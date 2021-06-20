using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<TicketDTO>> FindAll(int page, int count)
        {
            var skip = (page - 1) * count;
            var list = new List<TicketDTO>();
            list.Add(new TicketDTO
            {
                Id = "60cd6a7eee1d529c390f66f8",
                User = "Test1",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Status = true
            });
            list.Add(new TicketDTO
            {
                Id = "60cfa4c4ee517219ed26a908",
                User = "Test2",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Status = true
            });
            list.Add(new TicketDTO
            {
                Id = "60cfa4bfee517219ed26a904",
                User = "Test3",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Status = true
            });
            var paginated = list.Skip(skip).Take(count).ToList();
            return Task.FromResult(paginated);
        }

        public Task<int> TotalAmount()
        {
            var list = new List<TicketDTO>();
            list.Add(new TicketDTO
            {
                Id = "60cd6a7eee1d529c390f66f8",
                User = "Test1",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Status = true
            });
            list.Add(new TicketDTO
            {
                Id = "60cfa4c4ee517219ed26a908",
                User = "Test2",
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Status = true
            });
            return Task.FromResult(list.Count);
        }
    }
}
