using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBCRUD.Models;

namespace MongoDBCRUD.Repositories
{
    public class ArchivoDAO : IArchivoDAO
    {

        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Archivo> Collection;

        public ArchivoDAO()
        {
            Collection = _repository.db.GetCollection<Archivo>("Archivos");
        }

        public void InsertArchivo(Archivo archivo)
        {
            Collection.InsertOneAsync(archivo);
        }
        public void UpdateArchivo(Archivo archivo)
        {
            var filter = Builders<Archivo>.Filter.Eq(a => a.id, archivo.id);

            Collection.ReplaceOneAsync(filter, archivo);
        }
        public void DeleteArchivo(string id)
        {
            var filter = Builders<Archivo>.Filter.Eq(a => a.id, new ObjectId(id));

            Collection.DeleteOneAsync(filter);
        }
        public List<Archivo> GetAllArchivo()
        {
            var query = Collection.Find(new BsonDocument()).ToListAsync();

            return query.Result;
        }
        public Archivo GetArchivoById(string id)
        {
            var archivo = Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
            return archivo;
        }
    }
}
