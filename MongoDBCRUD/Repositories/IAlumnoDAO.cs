using MongoDBCRUD.Models;

namespace MongoDBCRUD.Repositories
{
    public interface IAlumnoDAO
    {
        void InsertAlumno(Alumno alumno);
        void UpdateAlumno(Alumno alumno);
        void DeleteAlumno(string id);
        void UpdateFotoAlumno(string id, string foto);
        void DeleteFotoAlumno(string id);
        List<Alumno> GetAllAlumno();
        Alumno GetAlumnoById(string id);
    }
}
