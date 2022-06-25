using MongoDBCRUD.Models;

namespace MongoDBCRUD.Repositories
{
    public interface IAlumnoDAO
    {
        void InsertAlumno(Alumno alumno);
        void UpdateAlumno(Alumno alumno);
        void DeleteAlumno(string id);
        List<Alumno> GetAllAlumno();
        Alumno GetAlumnoById(string id);
    }
}
