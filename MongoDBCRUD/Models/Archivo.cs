using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBCRUD.Models
{
    public class Archivo
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string nombre { get; set; }
        public string extension { get; set; }
        public string fileBase64 { get; set; }
    }
}
