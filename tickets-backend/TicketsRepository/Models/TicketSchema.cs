using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TicketsRepository.Models
{
    public class TicketSchema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("user")]
        public string UserName { get; set; }

        [BsonElement("creationDate")]
        public DateTime CreationDate { get; set; }

        [BsonElement("updateDate")]
        public DateTime UpdateDate { get; set; }

        [BsonElement("status")]
        public bool Status { get; set; }
    }
}
