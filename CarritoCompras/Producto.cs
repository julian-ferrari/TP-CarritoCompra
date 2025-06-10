using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Producto
    {
        private static int contadorCodigo = 1; // Para generar código único secuencial

        public int Codigo { get; private set; }
        public string Nombre { get; private set; }
        public decimal Precio { get; private set; }
        public int Stock { get; private set; }
        public Categoria Categoria { get; private set; }

        public Producto(string nombre, decimal precio, int stock, Categoria categoria)
        {
            Codigo = contadorCodigo++;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;
        }

        public bool HayStock(int cantidad)
        {
            return cantidad > 0 && cantidad <= Stock;
        }

        public void ReducirStock(int cantidad)
        {
            if (cantidad <= Stock && cantidad > 0)
                Stock -= cantidad;
        }

        public void AumentarStock(int cantidad)
        {
            if (cantidad > 0)
                Stock += cantidad;
        }

        public override string ToString()
        {
            return $"[{Codigo}] {Nombre} - Precio: ${Precio:F2} - Stock: {Stock} - Categoria: {Categoria.Nombre}";
        }
    }
}