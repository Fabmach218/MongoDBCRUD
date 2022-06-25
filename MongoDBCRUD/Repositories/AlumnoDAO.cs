using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBCRUD.Models;

namespace MongoDBCRUD.Repositories
{
    public class AlumnoDAO : IAlumnoDAO
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Alumno> Collection;

        public AlumnoDAO()
        {
            Collection = _repository.db.GetCollection<Alumno>("Alumnos");
        }
        public void InsertAlumno(Alumno alumno)
        {
            Collection.InsertOneAsync(alumno);
        }

        public void UpdateAlumno(Alumno alumno)
        {

            var filter = Builders<Alumno>.Filter.Eq(a => a.id, alumno.id);

            Collection.ReplaceOneAsync(filter, alumno);
        }

        public void DeleteAlumno(string id)
        {
            var filter = Builders<Alumno>.Filter.Eq(a => a.id, new ObjectId(id));

            Collection.DeleteOneAsync(filter);
        }

        public List<Alumno> GetAllAlumno()
        {
            var query = Collection.Find(new BsonDocument()).ToListAsync();

            return query.Result;
        }

        public Alumno GetAlumnoById(string id)
        {
            var alumno = Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
            return alumno;
        }
    }
}
