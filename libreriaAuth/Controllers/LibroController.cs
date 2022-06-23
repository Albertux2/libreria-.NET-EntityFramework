using autentifAuthorized.Models;
using autentifAuthorized.Services;
using libreriaAuth.Models.libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autentifAuthorized.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        // GET: Libro

        public LibroRepository libroRepo;
        private Dictionary<string, Func<string, List<Libro>>> busquedas = new Dictionary<string, Func<string, List<Libro>>>();

        public LibroController()
        {
            busquedas["libros"] = (value) => { return libroRepo.FindAllLibros(); };
            busquedas["editoriales"] = (value) => { return libroRepo.FindLibrosEditorial(value); };
            busquedas["autores"] = (value) => { return libroRepo.FindLibrosAutor(value); };
            libroRepo = new LibroRepository();
        }
        public ActionResult Index(string tabla = "libros", string busqueda = "", int pagina = 1, string filtro = "")
        {
            ListPaginator<Libro> paginator = new ListPaginator<Libro>(0, 0, 12);
            var filtrados = busquedas[tabla](busqueda).FindAll(libro => libro.Titulo.ToUpper().Contains(filtro.ToUpper()));
            paginator.SetPaginatedList(pagina, filtrados);
            return View(paginator);
        }

        public ActionResult IndexEditorial(int pagina = 1)
        {
            ListPaginator<Editorial> paginator = new ListPaginator<Editorial>(0, 0, 7);
            paginator.SetPaginatedList(pagina, libroRepo.FindAllEditoriales());
            return View(paginator);
        }

        public ActionResult IndexAutor(int pagina = 1)
        {
            ListPaginator<Autor> paginator = new ListPaginator<Autor>(0, 0, 7);
            paginator.SetPaginatedList(pagina, libroRepo.FindAllAutor());
            return View(paginator);
        }

        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            return View(libroRepo.findById(id));
        }

        // GET: Libro/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            DropDownLists();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public ActionResult Create(Libro model, FormCollection coleccion)
        {
            try
            {
                DropDownLists();
                string formatoSelect = coleccion["formatos"].ToString();
                model.FormatoId = Int32.Parse(formatoSelect);
                string temaSelect = coleccion["generos"].ToString();
                model.GeneroId = Int32.Parse(temaSelect);
                string autorSelect = coleccion["autores"].ToString();
                model.AutorId = Int32.Parse(autorSelect);
                string editorialSelect = coleccion["editoriales"].ToString();
                model.EditorialId = Int32.Parse(editorialSelect);
                string estadoSelect = coleccion["estados"].ToString();
                model.EstadoId = Int32.Parse(estadoSelect);
                libroRepo.Crear(model);
                return RedirectToAction("Index");
            }
            catch(Exception error)
            {
                ViewBag.Error = libroRepo.isbnExists(model.Isbn);
                return View("Create");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateFormato()
        {
            return View("CreateFormato");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateFormato(Formato model)
        {
            libroRepo.CrearFormato(model);
            return Content("<script>window.history.go(-2)</script>");
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id)
        {
            DropDownLists();
            return View(libroRepo.findById(id));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateAutor()
        {
            return View("CreateAutor");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateAutor(Autor model)
        {
            libroRepo.CrearAutor(model);
            return Content("<script>window.history.go(-2)</script>");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateEstado()
        {
            return View("CreateEstado");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateEstado(Estado model)
        {
            libroRepo.CrearEstado(model);
            return Content("<script>window.history.go(-2)</script>");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateEditorial()
        {
            return View("CreateEditorial");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateEditorial(Editorial model)
        {
            libroRepo.CrearEditorial(model);
            return Content("<script>window.history.go(-2)</script>");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGenero()
        {
            return View("CreateGenero");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGenero(Tematica tematica)
        {
            libroRepo.CrearGenero(tematica);
            return Content("<script>window.history.go(-2)</script>");
        }


        // POST: Libro/Edit/5
        [HttpPost]
        public ActionResult Edit(Libro model, FormCollection coleccion)
        {
            try
            {
                DropDownLists();
                string formatoSelect = coleccion["formatos"].ToString();
                model.FormatoId = Int32.Parse(formatoSelect);
                string temaSelect = coleccion["generos"].ToString();
                model.GeneroId = Int32.Parse(temaSelect);
                string autorSelect = coleccion["autores"].ToString();
                model.AutorId = Int32.Parse(autorSelect);
                string editorialSelect = coleccion["editoriales"].ToString();
                model.EditorialId = Int32.Parse(editorialSelect);
                string estadoSelect = coleccion["estados"].ToString();
                model.EstadoId = Int32.Parse(estadoSelect);
                libroRepo.Edit(model);
                return Content("<script>window.history.go(-2)</script>");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public JsonResult DeleteAutor(int id)
        {
            return Json(new { result = libroRepo.deleteAutor(id) }, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Admin")]
        public JsonResult DeleteEditorial(int id)
        {
            return Json(new { result = libroRepo.deleteEditorial(id) }, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteLibro(int id)
        {
            return Json(new { result = libroRepo.deleteLibro(id) }, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditAutor(int id)
        {
            return View(libroRepo.findByIdAutor(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditAutor(Autor model, FormCollection coleccion)
        {
            libroRepo.EditAutor(model);
            return Content("<script>window.history.go(-2)</script>");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditEditorial(int id)
        {
            return View(libroRepo.findByIdEditorial(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditEditorial(Editorial model, FormCollection coleccion)
        {
            libroRepo.EditEditorial(model);
            return Content("<script>window.history.go(-2)</script>");
        }


        public void DropDownLists()
        {
            List<SelectListItem> formatos = new List<SelectListItem>();
            foreach (var formato in libroRepo.FindAllFormato())
            {
                formatos.Add(new SelectListItem { Text = formato.nombre, Value = formato.id.ToString() });
            }
            formatos.Add(new SelectListItem { Text = "Añadir un nuevo formato", Value = "0" });
            List<SelectListItem> generos = new List<SelectListItem>();
            foreach (var genero in libroRepo.FindAllTematica())
            {
                generos.Add(new SelectListItem { Text = genero.nombre, Value = genero.id.ToString() });
            }
            generos.Add(new SelectListItem { Text = "Añadir un nuevo género", Value = "0" });

            List<SelectListItem> autores = new List<SelectListItem>();
            foreach (var autor in libroRepo.FindAllAutor())
            {
                autores.Add(new SelectListItem { Text = autor.nombre, Value = autor.id.ToString(), });
            }
            autores.Add(new SelectListItem { Text = "Añadir un nuevo autor", Value = "0" });

            List<SelectListItem> editoriales = new List<SelectListItem>();
            foreach (var editorial in libroRepo.FindAllEditoriales())
            {
                editoriales.Add(new SelectListItem { Text = editorial.nombre, Value = editorial.id.ToString() });
            }
            editoriales.Add(new SelectListItem { Text = "Añadir una nueva editorial ", Value = "0" });

            List<SelectListItem> estados = new List<SelectListItem>();
            foreach (var estado in libroRepo.FindAllEstados())
            {
                estados.Add(new SelectListItem { Text = estado.nombre, Value = estado.id.ToString() });
            }
            estados.Add(new SelectListItem { Text = "Añadir un nuevo estado", Value = "0" });

            ViewBag.Tema = generos;
            ViewBag.Formato = formatos;
            ViewBag.Autores = autores;
            ViewBag.Editoriales = editoriales;
            ViewBag.Estados = estados;
        }

    }
}
