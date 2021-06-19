using NUnit.Framework;
using System;
using TicketsDTOs;
using TicketsRepository;
using TicketsServices;

namespace TicketsUnitTests
{
    public class ManagementServiceTest
    {
        private IManagementService _managementService;
        [SetUp]
        public void Setup()
        {
            ITicketsQueries ticketsQueries = new FakeDBRepository();
            _managementService = new ManagementService(ticketsQueries);
        }

        [Test]
        public void CreateTicket_EmptyObject_ThrowException()
        {
            var newTicket = new CreateTicketDTO();
            var ex = Assert.Throws<AggregateException>(() => _managementService.CreateTicket(newTicket).Wait());
            Assert.That(ex.InnerException.Message, Is.EqualTo("You must enter a user name."));
        }

        [Test]
        public void CreateTicket_ShortUserName_ThrowException()
        {
            var newTicket = new CreateTicketDTO
            {
                User = "shr",
                Status = true
            };
            var ex = Assert.Throws<AggregateException>(() => _managementService.CreateTicket(newTicket).Wait());
            Assert.That(ex.InnerException.Message, Is.EqualTo("The user name length cannot be less than 4 characters."));
        }

        [Test]
        public void CreateTicket_CompleteTicket_ReturnCreatedTicket()
        {
            var newTicket = new CreateTicketDTO
            {
                User = "test",
                Status = true
            };
            var result = _managementService.CreateTicket(newTicket).Result;
            Assert.That(result.User, Is.EqualTo(newTicket.User));
            Assert.That(result.Status, Is.EqualTo(newTicket.Status));
            Assert.That(result.Id, Is.Not.Null);
        }

        [Test]
        public void DeleteTicket_IdDoesntExists_ThrowException()
        {
            var ticketId = "0000000000000";
            var ex = Assert.Throws<AggregateException>(() => _managementService.DeleteTicket(ticketId).Wait());
            Assert.That(ex.InnerException.Message, Is.EqualTo("The specified ticket was not found."));
        }

        [Test]
        public void DeleteTicket_IdExists_ReturnTicketId()
        {
            var ticketId = "60cd6a7eee1d529c390f66f8";
            var result = _managementService.DeleteTicket(ticketId).Result;
            Assert.That(result, Is.EqualTo("60cd6a7eee1d529c390f66f8"));
        }

        [Test]
        public void EditTicket_NotSendingTicketId_ThrowException()
        {
            var editTicket = new EditTicketDTO
            {
                User = "test",
                Status = false
            };
            var ex = Assert.Throws<AggregateException>(() => _managementService.EditTicket(editTicket).Wait());
            Assert.That(ex.InnerException.Message, Is.EqualTo("You must enter a user name and ticket id."));
        }

        [Test]
        public void EditTicket_ShortUserName_ThrowException()
        {
            var editTicket = new EditTicketDTO
            {
                Id = "60cd6a7eee1d529c390f66f8",
                User = "shr",
                Status = false
            };
            var ex = Assert.Throws<AggregateException>(() => _managementService.EditTicket(editTicket).Wait());
            Assert.That(ex.InnerException.Message, Is.EqualTo("The user name length cannot be less than 4 characters."));
        }

        [Test]
        public void EditTicket_IdDoesntExist_ThrowException()
        {
            var editTicket = new EditTicketDTO
            {
                Id = "00000000000000",
                User = "test",
                Status = false
            };
            var ex = Assert.Throws<AggregateException>(() => _managementService.EditTicket(editTicket).Wait());
            Assert.That(ex.InnerException.Message, Is.EqualTo("The specified ticket was not found."));
        }

        [Test]
        public void EditTicket_CorrectObject_ReturnTicketObject()
        {
            var editTicket = new EditTicketDTO
            {
                Id = "60cd6a7eee1d529c390f66f8",
                User = "test",
                Status = false
            };
            var result = _managementService.EditTicket(editTicket).Result;
            Assert.That(result.User, Is.EqualTo(editTicket.User));
            Assert.That(result.Status, Is.EqualTo(editTicket.Status));
            Assert.That(result.Id, Is.EqualTo(editTicket.Id));
        }
    }
}