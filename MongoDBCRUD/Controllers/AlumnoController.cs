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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlumnoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlumnoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
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
                    turno = collection["turno"]
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
                    turno = collection["turno"]
                };

                alumnoDAO.UpdateAlumno(alumno);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnoController/Delete/5
        public ActionResult Delete(string id)
        {
            alumnoDAO.DeleteAlumno(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
