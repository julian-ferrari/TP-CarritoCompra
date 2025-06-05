using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class ItemCarrito
    {
        public Producto Producto { get; private set; }
        public int Cantidad { get; private set; }

        public ItemCarrito(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        public void AumentarCantidad(int cantidad)
        {
            if (cantidad > 0)
                Cantidad += cantidad;
        }

        public void ReducirCantidad(int cantidad)
        {
            if (cantidad > 0 && cantidad <= Cantidad)
                Cantidad -= cantidad;
        }

        // Subtotal con descuento 15% si cantidad >=5
        public decimal Subtotal()
        {
            decimal subtotal = Producto.Precio * Cantidad;
            if (Cantidad >= 5)
                subtotal *= 0.85m; // descuento 15%
            return subtotal;
        }

        public override string ToString()
        {
            string descuento = Cantidad >= 5 ? " (15% descuento)" : "";
            return $"{Producto.Nombre} x {Cantidad} = ${Subtotal():F2}{descuento}";
        }
    }
}
