namespace TicketsRepository
{
    public class TicketsDatabaseSettings : ITicketsDatabaseSettings
    {
        public string TicketsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
