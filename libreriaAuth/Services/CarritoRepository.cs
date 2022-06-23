
using autentifAuthorized.Models;
using Microsoft.AspNet.Identity;
using libreriaAuth.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace libreriaAuth.Services
{
    public class CarritoRepository
    {
        public void addCarrito(Carrito carrito)
        {
            using (var db = new ApplicationDbContext())
            {

                foreach (var item in carrito.productos)
                {
                    db.Vendibles.Attach(item.articulo);
                }
                db.Carritos.Add(carrito);
                db.SaveChanges();
            }
        }

        public Carrito findCarrito(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var carrito = db.Carritos.Include(x => x.productos.Select(y => y.articulo)).FirstOrDefault(x => x.Id==id);
                return carrito;
            }
        }

        public Carrito findCarritoByUserId(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                var cosa = db.Carritos.Include(x=>x.User).Include(x=>x.User.Direcciones).Include(x => x.productos.Select(y => y.articulo)).FirstOrDefault(x => x.UserId == id && x.active);
                return cosa;
            }
        }

        public void deleteArticuloInCarrito(int id, int productoId)
        {
            using (var db = new ApplicationDbContext())
            {
                Carrito carrito = db.Carritos.Include(x => x.productos).FirstOrDefault(x => x.Id == id);
                carrito.productos.Remove(db.Productos.Find(productoId));
                db.Productos.Remove(db.Productos.Find(productoId));
                db.SaveChanges();
            }
        }

        public void addArticuloToCarrito(string userId, int vendibleId, int cantidad)
        {
            using (var db = new ApplicationDbContext())
            {
                Carrito carrito = db.Carritos.Include(x => x.productos).FirstOrDefault(x => x.UserId == userId && x.active);
                Producto producto = new Producto();
                producto.articulo = db.Vendibles.Find(vendibleId);
                producto.cantidad = cantidad;
                var repetido = carrito.productos.Find(x => x.articuloId == vendibleId);
                if (repetido != null)
                {
                    producto = repetido;
                    producto.cantidad += cantidad;
                }
                carrito.productos.Add(producto);
                db.SaveChanges();
            }
        }
        public void editCantidadProducto(int productoId, int cantidad)
        {
            using (var db = new ApplicationDbContext())
            {
                Producto producto = db.Productos.Find(productoId);
                if (producto != null)
                {
                    producto.cantidad = cantidad;
                    db.SaveChanges();
                }

            }
        }

        public Factura finalizarCarrito(int id,int idDireccion)
        {
            using (var db = new ApplicationDbContext())
            {
                var carrito = db.Carritos.Include(x => x.productos.Select(y => y.articulo)).FirstOrDefault(x=>x.Id == id);
                carrito.active = false;
                var direccion = db.Direccions.Find(idDireccion);
                foreach (var item in carrito.productos)
                {
                    item.articulo.Cantidad -= item.cantidad;
                }
                Factura factura = new Factura(carrito, DateTime.Now, carrito.calcularTotal(),direccion);
                db.Facturas.Add(factura);
                db.SaveChanges();
                return factura;
            }
        }

        public bool ComprobarStock(int idCarrito)
        {
            using (var db = new ApplicationDbContext())
            {
                var carrito = db.Carritos.Include(x => x.productos.Select(y => y.articulo)).FirstOrDefault(x => x.Id == idCarrito);
                return carrito.productos.Any(x => x.articulo.Cantidad < x.cantidad);
            }
        }

        public string MensajeStockInsuficiente(int idCarrito)
        {
            using (var db = new ApplicationDbContext())
            {
                var carrito = db.Carritos.Include(x => x.productos.Select(y => y.articulo)).FirstOrDefault(x => x.Id == idCarrito);
                string error = "";
                foreach (var item in carrito.productos)
                {
                    if (item.cantidad>item.articulo.Cantidad)
                    {
                        error += "<li>Stock insuficiente en "+item.articulo.Titulo+" cantidad solicitada: "+item.cantidad+", stock actual:"+item.articulo.Cantidad+"</li>";
                    }
                }
                return error;
            }
        }

        public Factura findFactura(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Facturas.Include(x=>x.Carrito).Include(x=>x.Carrito.productos.Select(p => p.articulo)).Include(x => x.Direccion).Include(x=>x.Carrito.User).FirstOrDefault(x=>x.Id==id);
            }
        }

        public List<Factura> findFacturasUsuario(String userId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Facturas.Include(x => x.Carrito).Include(x=>x.Direccion).Where(x => x.Carrito.UserId == userId).OrderByDescending(x=>x.Fecha).ToList();
            }
        }

        public void addDireccionUsuario(Direccion direccion,String userId)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Direccions.Add(direccion);
                db.SaveChanges();
                db.Direccions.Attach(direccion);
                db.Users.Include(x => x.Direcciones).FirstOrDefault(x => x.Id == userId).Direcciones.Add(direccion);
                db.SaveChanges();
            }
        }

        public List<Direccion> findDireccionUsuario(string userId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Users.Include(x => x.Direcciones).FirstOrDefault(x => x.Id == userId).Direcciones;
            }
        }
    }
}