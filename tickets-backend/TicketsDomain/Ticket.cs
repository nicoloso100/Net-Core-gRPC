using System;

namespace TicketsDomain
{
    public class Ticket
    {
        public string Id { get; }
        public string User { get; }
        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }
        public bool Status { get; }

        //If id is NOT null means the ticket is being modified
        //If id is null means the ticket is being created
        public Ticket(string user, bool status, string id = null)
        {
            if (user.Length < 4)
            {
                throw new Exception("The user name length cannot be less than 4 characters.");
            }

            if (id is null)
            {
                CreationDate = DateTime.Now;
            }
            Id = id;
            User = user;
            UpdateDate = DateTime.Now;
            Status = status;
        }
    }
}