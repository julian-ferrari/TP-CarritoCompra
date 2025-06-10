using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Carrito
    {
        private List<ItemCarrito> items = new List<ItemCarrito>();

        public IReadOnlyList<ItemCarrito> Items => items.AsReadOnly();

        public bool AgregarProducto(Producto producto, int cantidad)
        {
            if (producto == null || cantidad <= 0 || !producto.HayStock(cantidad))
                return false;

            var itemExistente = items.FirstOrDefault(i => i.Producto.Codigo == producto.Codigo);

            if (itemExistente != null)
            {
                // Chequea si se puede agregar esa cantidad sin superar stock
                int cantidadTotal = itemExistente.Cantidad + cantidad;
                if (!producto.HayStock(cantidadTotal))
                    return false;

                itemExistente.AumentarCantidad(cantidad);
            }
            else
            {
                items.Add(new ItemCarrito(producto, cantidad));
            }

            return true;
        }

        public bool EliminarProducto(int codigoProducto)
        {
            var item = items.FirstOrDefault(i => i.Producto.Codigo == codigoProducto);
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        public void MostrarContenido()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }
            Console.WriteLine("Contenido del carrito:");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public decimal TotalPagar()
        {
            decimal subtotal = items.Sum(i => i.Subtotal());
            decimal totalConIVA = subtotal * 1.21m; // IVA 21%
            return totalConIVA;
        }

        public void Vaciar()
        {
            items.Clear();
        }
    }
}
