using autentifAuthorized.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace libreriaAuth.Models
{
    public class Carrito
    {
        public int Id { get; set; }
        public virtual List<Producto> productos { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool active { get; set; }
        public string calcularTotalConFormato()
        {
            float total = 0;
            this.productos.ForEach((prod) => total += prod.articulo.Precio * prod.cantidad);
            return total.ToString("0.00");
        }
        public float calcularTotal()
        {
            float total = 0;
            this.productos.ForEach((prod) => total += prod.articulo.Precio * prod.cantidad);
            return total;
        }

        public int productosTotales()
        {
            int total = 0;
            this.productos.ForEach((prod) => total += prod.cantidad);
            return total;
        }
    }

}