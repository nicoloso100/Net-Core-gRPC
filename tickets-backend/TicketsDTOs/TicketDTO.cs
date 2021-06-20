using System;

namespace TicketsDTOs
{
    public class TicketDTO
    {
        public string Id { get; set; }
        public string User { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
    }
}
