using System;

namespace TicketsDomain
{
    public class Ticket
    {
        public string User { get; }
        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }
        public bool Status { get; }

        public Ticket(string user, bool status)
        {
            if(user.Length < 4)
            {
                throw new Exception("The user name length cannot be less than 4 characters");
            }

            User = user;
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Status = status;
        }
    }
}