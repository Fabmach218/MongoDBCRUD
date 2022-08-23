using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBCRUD.Models;
using MongoDBCRUD.Repositories;

namespace MongoDBCRUD.Controllers
{
    public class ArchivoController : Controller
    {
        private IArchivoDAO archivoDAO = new ArchivoDAO();
        // GET: ArchivoController
        public ActionResult Index()
        {
            var archivos = archivoDAO.GetAllArchivo();
            return View(archivos);
        }

        // GET: ArchivoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArchivoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArchivoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, List<IFormFile> files)
        {
            var archivo = new Archivo();

            foreach (var file in files)
            {
                Stream str = file.OpenReadStream();
                BinaryReader br = new BinaryReader(str);
                Byte[] fileDet = br.ReadBytes((Int32)str.Length);
                archivo.nombre = Path.GetFileName(file.FileName);
                archivo.extension = Path.GetExtension(file.FileName).Substring(1);
                archivo.fileBase64 = Convert.ToBase64String(fileDet);
            }

            try
            {

                archivoDAO.InsertArchivo(archivo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArchivoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArchivoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArchivoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArchivoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
