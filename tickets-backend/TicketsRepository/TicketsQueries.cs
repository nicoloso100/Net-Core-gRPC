using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var savedTicket = new TicketDTO
            {
                Id = ticket.Id,
                User = ticket.UserName,
                CreationDate = ticket.CreationDate,
                UpdateDate = ticket.UpdateDate,
                Status = ticket.Status
            };

            return savedTicket;
        }
    }
}
