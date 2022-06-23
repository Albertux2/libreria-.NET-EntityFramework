using libreriaAuth.Models;
using libreriaAuth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RazorPDF;
using Rotativa;

namespace libreriaAuth.Controllers
{
    public class CarritoController : Controller
    {



        private CarritoRepository carritoRepo;

        public CarritoController()
        {
            this.carritoRepo = new CarritoRepository();
        }


        // GET: Carrito
        public ActionResult Index()
        {
            Carrito carrito = carritoRepo.findCarritoByUserId(User.Identity.GetUserId());
            if (carrito == null)
            {
                carrito = new Carrito();
                carrito.UserId = User.Identity.GetUserId();
                carrito.productos = new List<Producto>();
                carrito.active = true;
                new CarritoRepository().addCarrito(carrito);
            }
            return View("../Shared/_Carrito", carrito);
        }


        public ActionResult DeleteProducto(int id, int productoId)
        {
            carritoRepo.deleteArticuloInCarrito(id, productoId);
            return new EmptyResult();
        }


        public void editCantidadProducto(int idProducto, int cantidad)
        {
            carritoRepo.editCantidadProducto(idProducto, cantidad);
        }
        public ActionResult addProducto(int vendibleId, int cantidad)
        {
            var id = User.Identity.GetUserId();
            carritoRepo.addArticuloToCarrito(id, vendibleId, cantidad);
            return View("../Shared/_Carrito");
        }

        // POST: Carrito/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carrito/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult FinalizarCompra(int idCarrito, int idDireccion)
        {
            var stockInsuficiente = carritoRepo.ComprobarStock(idCarrito);
            if (stockInsuficiente)
            {
                var error = carritoRepo.MensajeStockInsuficiente(idCarrito);
                return Json(new { error = error, stockInsuficiente = stockInsuficiente }, JsonRequestBehavior.AllowGet);
            }
            var factura = carritoRepo.finalizarCarrito(idCarrito, idDireccion);
            return Json(new { idFactura = factura.Id, stockInsuficiente = stockInsuficiente }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PdfFactura(int idFactura)
        {
            string _headerUrl = Url.Action("HeaderPDF", "Carrito", null, "https");
            string _footerUrl = Url.Action("FooterPDF", "Carrito", null, "https");
            var factura = carritoRepo.findFactura(idFactura);
            return new ViewAsPdf("Factura", factura)
            {
                FileName = "Factura.pdf",
                PageMargins = new Rotativa.Options.Margins(40, 10, 10, 10),
                CustomSwitches = "--header-html " + _headerUrl + " --header-spacing 0 " +
                                 "--footer-html " + _footerUrl + " --footer-spacing 0"
            };
        }

        public ActionResult addDireccionUser(string calle, string CodigoPostal, string numero, string poblacion)
        {
            var userId = HttpContext.User.Identity.GetUserId();
            Direccion direccion = new Direccion(CodigoPostal, calle, numero, poblacion);
            carritoRepo.addDireccionUsuario(direccion, userId);
            var direcciones = carritoRepo.findDireccionUsuario(HttpContext.User.Identity.GetUserId());
            return View("../Carrito/SeleccionarDireccion", direcciones);
        }

        public ActionResult HeaderPDF()
        {
            return View("HeaderPDF");
        }

        public ActionResult FooterPDF()
        {
            return View("FooterPDF");
        }

        public ActionResult CreateDireccion()
        {
            return View("../Carrito/DireccionCreate");
        }

        public ActionResult SeleccionarDireccion()
        {
            var direcciones = carritoRepo.findDireccionUsuario(HttpContext.User.Identity.GetUserId());
            return View("../Carrito/SeleccionarDireccion", direcciones);
        }
    }
}
