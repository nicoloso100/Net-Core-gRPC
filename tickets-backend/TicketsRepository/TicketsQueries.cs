using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsDomain;
using TicketsDTOs;
using TicketsRepository.Models;

namespace TicketsRepository
{
    public class TicketsQueries : ITicketsQueries
    {
        private readonly IMongoCollection<TicketSchema> _tickets;
        public TicketsQueries(ITicketsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tickets = database.GetCollection<TicketSchema>(settings.TicketsCollectionName);
        }

        public async Task<List<TicketDTO>> FindAll(int page, int count)
        {
            var skip = (page - 1) * count;
            var ticketsQuery = await _tickets.Find(ticket => true)
                .Skip(skip)
                .Limit(count)
                .ToListAsync();

            var tickets = ticketsQuery.Select(ticket => MapTicketDTO(ticket)).ToList();

            return tickets;
        }

        public async Task<TicketDTO> FindById(string ticketId)
        {
            var existingTicketQuery = await _tickets.FindAsync(ticket => ticket.Id.Equals(ticketId));
            var existingTicket = existingTicketQuery.FirstOrDefault();

            if (existingTicket is not null)
            {
                var ticket = MapTicketDTO(existingTicket);

                return ticket;
            }

            return null;
        }

        public async Task<TicketDTO> Insert(Ticket newTicket)
        {
            var ticket = new TicketSchema
            {
                UserName = newTicket.User,
                CreationDate = newTicket.CreationDate,
                UpdateDate = newTicket.UpdateDate,
                Status = newTicket.Status
            };
            await _tickets.InsertOneAsync(ticket);
            var savedTicket = MapTicketDTO(ticket);

            return savedTicket;
        }

        public async Task<string> Delete(string ticketId)
        {
            var existingTicketQuery = await _tickets.FindAsync(ticket => ticket.Id.Equals(ticketId));
            var existingTicket = existingTicketQuery.FirstOrDefault();

            if (existingTicket is not null)
            {
                await _tickets.DeleteOneAsync(ticket => ticket.Id.Equals(ticketId));

                return ticketId;
            }

            return null;
        }

        public async Task<TicketDTO> Edit(Ticket newTicket)
        {
            var existingTicketQuery = await _tickets.FindAsync(ticket => ticket.Id.Equals(newTicket.Id));
            var existingTicket = existingTicketQuery.FirstOrDefault();

            if (existingTicket is not null)
            {
                existingTicket.UserName = newTicket.User;
                existingTicket.Status = newTicket.Status;
                existingTicket.UpdateDate = newTicket.UpdateDate;
                await _tickets.ReplaceOneAsync(ticket => ticket.Id.Equals(newTicket.Id), existingTicket);
                var modifiedTicket = MapTicketDTO(existingTicket);

                return modifiedTicket;
            }

            return null;
        }

        public async Task<int> TotalAmount()
        {
            var ticketsQuery = await _tickets.FindAsync(ticket => true);
            var amount = ticketsQuery.ToEnumerable().Count();

            return amount;
        }

        private TicketDTO MapTicketDTO(TicketSchema ticket)
        {
            return new TicketDTO
            {
                Id = ticket.Id,
                User = ticket.UserName,
                CreationDate = ticket.CreationDate,
                UpdateDate = ticket.UpdateDate,
                Status = ticket.Status
            };
        }
    }
}
