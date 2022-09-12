using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace CustomerManagement.Api.Domain.Model
{
    public class Customer
    {
        [BsonId]
        [JsonIgnore]
        public ObjectId Id { get; set; }
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public CustomerStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Customer()
        {

        }
    }
}