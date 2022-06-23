


using System;
using System.Collections.Generic;
using System.Linq;
using autentifAuthorized.Models;
using System.Data.Entity;
using libreriaAuth.Models.libro;
using libreriaAuth.Models;

namespace autentifAuthorized.Services
{
    public class LibroRepository
    {
        public List<Libro> FindAllLibros()
        {
            using (var db = new ApplicationDbContext())
            {
                var libros = db.Libros.Include(x => x.Autor).Include(x => x.Formato).Include(x => x.Genero)
                    .Include(x => x.Editorial).Include(x => x.Estado).ToList();
                return libros;
            }
        }

        public List<Formato> FindAllFormato()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Formatos.ToList();
            }
        }

        public List<Autor> FindAllAutor()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Autores.ToList();
            }
        }

        public List<Tematica> FindAllTematica()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Generos.ToList();
            }
        }
        public List<Editorial> FindAllEditoriales()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Editoriales.ToList();
            }
        }
        public List<Estado> FindAllEstados()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Estados.ToList();
            }
        }

        public Libro findById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Libros.Include(x => x.Autor).Include(x => x.Formato)
                    .Include(x => x.Genero).Include(x => x.Editorial).Include(x => x.Estado).FirstOrDefault(x => x.Id == id); ;
            }
        }

        public Autor findByIdAutor(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Autores.Find(id);
            }
        }

        public Editorial findByIdEditorial(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Editoriales.Find(id);
            }
        }

        public Tematica findByIdGenero(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Generos.Find(id);
            }
        }

        public Formato findByIdFormato(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Formatos.Find(id);
            }
        }

        internal void Crear(Libro model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Libros.Add(model);
                db.SaveChanges();
            }
        }

        public string isbnExists(string isbn)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Libros.Any(x=>x.Isbn==isbn))
                {
                    return "El ISBN ya existe";
                }
                else
                {
                   return "";
                }
            }
        }

        public void Edit(Libro model)
        {
            using (var db = new ApplicationDbContext())
            {
                Libro actualizar = db.Libros.Find(model.Id);
                db.Entry(actualizar).CurrentValues.SetValues(model);
                db.SaveChanges();
            }
        }
        public void EditAutor(Autor model)
        {
            using (var db = new ApplicationDbContext())
            {
                Autor actualizar = db.Autores.Find(model.id);
                db.Entry(actualizar).CurrentValues.SetValues(model);
                db.SaveChanges();
            }
        }
        public void EditEditorial(Editorial model)
        {
            using (var db = new ApplicationDbContext())
            {
                Editorial actualizar = db.Editoriales.Find(model.id);
                db.Entry(actualizar).CurrentValues.SetValues(model);
                db.SaveChanges();
            }
        }
        public int CountLibrosEditorial(String editorial)
        {
            using (var db = new ApplicationDbContext())
            {
                var idEditorial = db.Editoriales.FirstOrDefault(x => x.nombre == editorial).id;
                return db.Libros.Count(libro => libro.EditorialId == idEditorial);
            }
        }
        public List<Libro> FindLibrosEditorial(String editorial)
        {
            using (var db = new ApplicationDbContext())
            {
                Editorial editorialObj = db.Editoriales.FirstOrDefault(ed => ed.nombre == editorial);
                var idEditorial = 0;
                if (editorialObj != null)
                {
                    idEditorial = editorialObj.id;
                }
                return db.Libros.Include(x => x.Autor).Include(x => x.Formato)
                    .Include(x => x.Genero).Include(x => x.Editorial).Include(x => x.Estado)
                    .Where(libro => libro.EditorialId == idEditorial).ToList();
            }
        }

        public int CountLibrosAutor(String autor)
        {
            using (var db = new ApplicationDbContext())
            {
                var idAutor = db.Autores.FirstOrDefault(x => x.nombre == autor).id;
                return db.Libros.Count(libro => libro.AutorId == idAutor);
            }
        }
        public List<Libro> FindLibrosAutor(String autor)
        {
            using (var db = new ApplicationDbContext())
            {
                Autor autorObj = db.Autores.FirstOrDefault(ed => ed.nombre == autor);
                var idAutor = 0;
                if (autorObj != null)
                {
                    idAutor = autorObj.id;
                }
                return db.Libros.Include(x => x.Autor).Include(x => x.Formato)
                    .Include(x => x.Genero).Include(x => x.Editorial).Include(x => x.Estado)
                    .Where(libro => libro.AutorId == idAutor).ToList();
            }
        }

        //public Direccion FindDireccion(int id)
        //{
        //    using (var db = new ApplicationDbContext())
        //    {
        //        //return db.Direccions.Find(id);
        //    }
        //}
        internal void CrearFormato(Formato model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Formatos.Add(model);
                db.SaveChanges();
            }
        }

        internal void CrearEstado(Estado model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Estados.Add(model);
                db.SaveChanges();
            }
        }

        internal void CrearAutor(Autor model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Autores.Add(model);
                db.SaveChanges();
            }
        }

        internal void CrearGenero(Tematica model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Generos.Add(model);
                db.SaveChanges();
            }
        }

        internal void CrearEditorial(Editorial model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Editoriales.Add(model);
                db.SaveChanges();
            }
        }

        public bool deleteAutor(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Libros.Any(x => x.AutorId == id))
                {
                    return false;
                }
                else
                {
                    Autor autor = db.Autores.Find(id);
                    db.Autores.Remove(autor);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public bool deleteEditorial(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Libros.Any(x => x.EditorialId == id))
                {
                    return false;
                }
                else
                {
                    Editorial editorial = db.Editoriales.Find(id);
                    db.Editoriales.Remove(editorial);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public bool deleteLibro(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                try{

                Libro libro = db.Libros.Find(id);
                db.Libros.Remove(libro);
                db.SaveChanges();
                }catch
                {
                    return false;
                }
                return true;
            }
        }
    }
}
