using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace MongoDBCRUD.Models
{
    public class Alumno
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string nombres { get; set; }
        public string apePat { get; set; }
        public string apeMat { get; set; }
        public string sexo { get; set; }
        public DateTime fecNac { get; set; }
        public double nota { get; set; }
        public string turno { get; set; }
        public string fotoBase64 { get; set; } = "";

    }
}
