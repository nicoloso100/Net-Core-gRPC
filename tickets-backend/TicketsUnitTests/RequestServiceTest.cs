using NUnit.Framework;
using System;
using TicketsRepository;
using TicketsServices;

namespace TicketsUnitTests
{
    class RequestServiceTest
    {
        private IRequestService _requestService;
        [SetUp]
        public void Setup()
        {
            ITicketsQueries ticketsQueries = new FakeDBRepository();
            _requestService = new RequestService(ticketsQueries);
        }

        [Test]
        public void FindTicket_IdDoesntExists_ThrowException()
        {
            var ticketId = "0000000000000";
            var ex = Assert.Throws<AggregateException>(() => _requestService.FindOneTicket(ticketId).Wait());
            Assert.That(ex.InnerException.Message, Is.EqualTo("The specified ticket was not found."));
        }

        [Test]
        public void FindTicket_IdExists_ReturnTicketInformation()
        {
            var ticketId = "60cd6a7eee1d529c390f66f8";
            var result = _requestService.FindOneTicket(ticketId).Result;
            Assert.That(result.User, Is.EqualTo("Test"));
            Assert.That(result.Status, Is.EqualTo(true));
            Assert.That(result.Id, Is.EqualTo("60cd6a7eee1d529c390f66f8"));
        }

        [Test]
        public void CountTickets_TwoTickets_ReturnTwo()
        {
            var result = _requestService.CountTicketsAmount().Result;
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void TicketsPagination_PageOneRowsTwo_ReturnTwoElements()
        {
            var result = _requestService.FindAllTickets(page: 1, count: 2).Result;
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void TicketsPagination_PageTwoRowsOne_ReturnTwoElements()
        {
            var result = _requestService.FindAllTickets(page: 2, count: 1).Result;
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void TicketsPagination_PageOverflow_ReturnZero()
        {
            var result = _requestService.FindAllTickets(page: 10, count: 1).Result;
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
