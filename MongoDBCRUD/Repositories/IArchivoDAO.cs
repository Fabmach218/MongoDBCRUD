using MongoDBCRUD.Models;

namespace MongoDBCRUD.Repositories
{
    public interface IArchivoDAO
    {
        void InsertArchivo(Archivo archivo);
        void UpdateArchivo(Archivo archivo);
        void DeleteArchivo(string id);
        List<Archivo> GetAllArchivo();
        Archivo GetArchivoById(string id);
    }
}
