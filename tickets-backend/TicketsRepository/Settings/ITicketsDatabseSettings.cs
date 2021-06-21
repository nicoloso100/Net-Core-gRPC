namespace TicketsRepository
{
    public interface ITicketsDatabaseSettings
    {
        string TicketsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
