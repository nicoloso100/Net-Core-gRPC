using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
