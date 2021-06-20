using Google.Protobuf.Collections;
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
        private readonly IRequestService _requestService;

        public TicketsService(ILogger<TicketsService> logger, IManagementService managementService, IRequestService requestService)
        {
            _logger = logger;
            _managementService = managementService;
            _requestService = requestService;
        }

        public async override Task<TicketReply> GetTicket(TicketRequestId request, ServerCallContext context)
        {
            try
            {
                var result = await _requestService.FindOneTicket(request.Id);
                var reply = new TicketReply
                {
                    Id = result.Id,
                    User = result.User,
                    CreationDate = Timestamp.FromDateTime(result.CreationDate.ToUniversalTime()),
                    UpdateDate = Timestamp.FromDateTime(result.UpdateDate.ToUniversalTime()),
                    Status = result.Status
                };

                return reply;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, $"An error ocurred while getting the ticket information: {ex.Message}"));
            }
        }

        public async override Task<TicketsReply> GetAllTickets(AllTicketsRequest request, ServerCallContext context)
        {
            try
            {
                var result = await _requestService.FindAllTickets(page: request.Page, count: request.Count);
                var reply = new TicketsReply();
                reply.Tickets.AddRange(result.Select(ticket => new TicketReply
                {
                    Id = ticket.Id,
                    User = ticket.User,
                    CreationDate = Timestamp.FromDateTime(ticket.CreationDate.ToUniversalTime()),
                    UpdateDate = Timestamp.FromDateTime(ticket.UpdateDate.ToUniversalTime()),
                    Status = ticket.Status
                }));
                reply.Rows = result.Count;

                return reply;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, $"An error ocurred while getting the ticket information: {ex.Message}"));
            }
        }

        public async override Task<TicketReply> AddTicket(AddTicketRequest request, ServerCallContext context)
        {
            try
            {
                var newTicket = new CreateTicketDTO
                {
                    User = request.User,
                    Status = request.Status
                };
                var result = await _managementService.CreateTicket(newTicket);
                var reply = new TicketReply
                {
                    Id = result.Id,
                    User = result.User,
                    CreationDate = Timestamp.FromDateTime(result.CreationDate.ToUniversalTime()),
                    UpdateDate = Timestamp.FromDateTime(result.UpdateDate.ToUniversalTime()),
                    Status = result.Status
                };

                return reply;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, $"An error ocurred while creating the ticket: {ex.Message}"));
            }
        }

        public async override Task<TicketRequestId> DeleteTicket(TicketRequestId request, ServerCallContext context)
        {
            try
            {
                var result = await _managementService.DeleteTicket(request.Id);
                var reply = new TicketRequestId
                {
                    Id = result,
                };

                return reply;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, $"An error ocurred while deleting the ticket: {ex.Message}"));
            }
        }

        public async override Task<TicketReply> EditTicket(EditTicketRequest request, ServerCallContext context)
        {
            try
            {
                var ticket = new EditTicketDTO
                {
                    Id = request.Id,
                    User = request.User,
                    Status = request.Status
                };
                var result = await _managementService.EditTicket(ticket);
                var reply = new TicketReply
                {
                    Id = result.Id,
                    User = result.User,
                    CreationDate = Timestamp.FromDateTime(result.CreationDate.ToUniversalTime()),
                    UpdateDate = Timestamp.FromDateTime(result.UpdateDate.ToUniversalTime()),
                    Status = result.Status
                };

                return reply;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, $"An error ocurred while modifying the ticket: {ex.Message}"));
            }
        }
    }
}
