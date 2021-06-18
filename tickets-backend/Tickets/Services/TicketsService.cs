using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Services
{
    public class TicketsService : Tickets.TicketsBase
    {
        private readonly ILogger<TicketsService> _logger;

        public TicketsService(ILogger<TicketsService> logger)
        {
            _logger = logger;
        }

        public override Task<AddTicketReply> AddTicket(AddTicketRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AddTicketReply
            {
            });
        }
    }
}
