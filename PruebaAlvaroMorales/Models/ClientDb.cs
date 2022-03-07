﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PruebaAlvaroMorales.Models
{
    [BsonIgnoreExtraElements]
    public class ClientDb
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
