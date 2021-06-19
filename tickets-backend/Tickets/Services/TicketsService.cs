using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsDTOs;
using TicketsServices;

namespace Tickets.Services
{
    public class TicketsService : Tickets.TicketsBase
    {
        private readonly ILogger<TicketsService> _logger;
        private readonly IManagementService _managementService;

        public TicketsService(ILogger<TicketsService> logger, IManagementService managementService)
        {
            _logger = logger;
            _managementService = managementService;
        }

        public async override Task<AddTicketReply> AddTicket(AddTicketRequest request, ServerCallContext context)
        {
            try
            {
                var newTicket = new CreateTicketDTO
                {
                    User = request.User,
                    Status = request.Status
                };
                var result = await _managementService.CreateTicket(newTicket);
                return new AddTicketReply
                {
                    Id = result.Id,
                    User = result.User,
                    CreationDate = Timestamp.FromDateTime(result.CreationDate),
                    UpdateDate = Timestamp.FromDateTime(result.UpdateDate),
                    Status = result.Status
                };
            } catch(Exception ex)
            {
                var metadata = new Metadata
                {
                    { "Details", ex.Message }
                };
                _logger.LogError(ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, "An error has ocurred while creating the ticket"), metadata);
            }
        }
    }
}
