using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Tienda
    {
        public List<Categoria> Categorias { get; private set; } = new List<Categoria>();
        public List<Producto> Productos { get; private set; } = new List<Producto>();

        public Tienda()
        {
            // Inicializar algunas categorías y productos para testear
            var cat1 = new Categoria("Electrónica", "Dispositivos electrónicos");
            var cat2 = new Categoria("Ropa", "Indumentaria y accesorios");
            var cat3 = new Categoria("Alimentos", "Productos alimenticios");

            Categorias.AddRange(new[] { cat1, cat2, cat3 });

            Productos.Add(new Producto("Smartphone", 25000m, 10, cat1));
            Productos.Add(new Producto("Televisor", 45000m, 5, cat1));
            Productos.Add(new Producto("Remera", 1500m, 20, cat2));
            Productos.Add(new Producto("Pantalón", 3500m, 15, cat2));
            Productos.Add(new Producto("Arroz", 500m, 50, cat3));
            Productos.Add(new Producto("Leche", 300m, 30, cat3));
        }

        public void MostrarCategorias()
        {
            Console.WriteLine("Categorías disponibles:");
            foreach (var cat in Categorias)
            {
                Console.WriteLine(cat.ToString());
            }
        }

        public void MostrarProductos(List<Producto> productos = null)
        {
            var lista = productos ?? Productos;
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay productos para mostrar.");
                return;
            }

            Console.WriteLine("Productos disponibles:");
            foreach (var prod in lista)
            {
                Console.WriteLine(prod.ToString());
            }
        }

        public List<Producto> FiltrarProductosPorCategoria(string nombreCategoria)
        {
            return Productos.Where(p => p.Categoria.Nombre.Equals(nombreCategoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Producto BuscarProductoPorCodigo(int codigo)
        {
            return Productos.FirstOrDefault(p => p.Codigo == codigo);
        }

        // Actualiza el stock tras finalizar compra
        public void ActualizarStock(Carrito carrito)
        {
            foreach (var item in carrito.Items)
            {
                item.Producto.ReducirStock(item.Cantidad);
            }
        }
    }
}
