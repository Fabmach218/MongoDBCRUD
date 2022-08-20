using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBCRUD.Models;
using MongoDBCRUD.Repositories;
using MongoDB.Bson;

namespace MongoDBCRUD.Controllers
{
    public class AlumnoController : Controller
    {
        private IAlumnoDAO alumnoDAO = new AlumnoDAO();
        // GET: AlumnoController
        public ActionResult Index()
        {
            var alumnos = alumnoDAO.GetAllAlumno();
            return View(alumnos);
        }

        // GET: AlumnoController/Details/5
        public ActionResult Details(string id)
        {
            var alumno = alumnoDAO.GetAlumnoById(id);
            return View(alumno);
        }

        // GET: AlumnoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlumnoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, List<IFormFile> files)
        {

            string fileBase64 = "";

            foreach (var file in files)
            {
                Stream str = file.OpenReadStream();
                BinaryReader br = new BinaryReader(str);
                Byte[] fileDet = br.ReadBytes((Int32)str.Length);
                //curso.archivo = fileDet;
                //curso.nombrefile = Path.GetFileName(file.FileName);
                fileBase64 = Convert.ToBase64String(fileDet);
            }

            try
            {

                var alumno = new Alumno()
                {
                    nombres = collection["nombres"],
                    apePat = collection["apePat"],
                    apeMat = collection["apeMat"],
                    sexo = collection["sexo"],
                    fecNac = DateTime.Parse(collection["fecNac"]),
                    nota = double.Parse(collection["nota"]),
                    turno = collection["turno"],
                    fotoBase64 = fileBase64
                };

                alumnoDAO.InsertAlumno(alumno);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnoController/Edit/5
        public ActionResult Edit(string id)
        {
            var alumno = alumnoDAO.GetAlumnoById(id);
            return View(alumno);
        }

        // POST: AlumnoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {

                var alumno = new Alumno()
                {
                    id = new ObjectId(id),
                    nombres = collection["nombres"],
                    apePat = collection["apePat"],
                    apeMat = collection["apeMat"],
                    sexo = collection["sexo"],
                    fecNac = DateTime.Parse(collection["fecNac"]),
                    nota = double.Parse(collection["nota"]),
                    turno = collection["turno"],
                    fotoBase64 = alumnoDAO.GetAlumnoById(id).fotoBase64
                };

                alumnoDAO.UpdateAlumno(alumno);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFotoAlumno(string id, List<IFormFile> files)
        {

            var alumno = alumnoDAO.GetAlumnoById(id);
            string fileBase64 = "";

            foreach (var file in files)
            {
                Stream str = file.OpenReadStream();
                BinaryReader br = new BinaryReader(str);
                Byte[] fileDet = br.ReadBytes((Int32)str.Length);
                //curso.archivo = fileDet;
                //curso.nombrefile = Path.GetFileName(file.FileName);
                fileBase64 = Convert.ToBase64String(fileDet);
            }

            try
            {
                alumnoDAO.UpdateFotoAlumno(id, fileBase64);
                
                return RedirectToAction("Details", new { id = id });
            }
            catch 
            {
                return RedirectToAction("Details", new { id = id });
            }

        }

        public ActionResult DeleteFotoAlumno(string id)
        {
            alumnoDAO.DeleteFotoAlumno(id);
            return RedirectToAction("Details", new { id = id });
        }

        // GET: AlumnoController/Delete/5
        public ActionResult Delete(string id)
        {
            alumnoDAO.DeleteAlumno(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
