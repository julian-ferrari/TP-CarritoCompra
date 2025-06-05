using System;

namespace CarritoCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            Tienda tienda = new Tienda();
            Carrito carrito = new Carrito();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n----- Menú Carrito de Compras -----");
                Console.WriteLine("1. Ver todas las categorías");
                Console.WriteLine("2. Ver todos los productos disponibles");
                Console.WriteLine("3. Ver productos filtrados por categoría");
                Console.WriteLine("4. Agregar producto al carrito");
                Console.WriteLine("5. Eliminar producto del carrito");
                Console.WriteLine("6. Ver contenido del carrito");
                Console.WriteLine("7. Ver total a pagar");
                Console.WriteLine("8. Finalizar compra");
                Console.WriteLine("9. Salir");
                Console.Write("Ingrese opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        tienda.MostrarCategorias();
                        break;

                    case "2":
                        tienda.MostrarProductos();
                        break;

                    case "3":
                        Console.Write("Ingrese nombre de la categoría: ");
                        string catNombre = Console.ReadLine();
                        var filtrados = tienda.FiltrarProductosPorCategoria(catNombre);
                        if (filtrados.Count == 0)
                            Console.WriteLine("No se encontraron productos para esa categoría.");
                        else
                            tienda.MostrarProductos(filtrados);
                        break;

                    case "4":
                        Console.Write("Ingrese código del producto a agregar: ");
                        if (!int.TryParse(Console.ReadLine(), out int codigoAgregar))
                        {
                            Console.WriteLine("Código inválido.");
                            break;
                        }
                        Producto prodAgregar = tienda.BuscarProductoPorCodigo(codigoAgregar);
                        if (prodAgregar == null)
                        {
                            Console.WriteLine("Producto no encontrado.");
                            break;
                        }

                        Console.Write("Ingrese cantidad: ");
                        if (!int.TryParse(Console.ReadLine(), out int cantAgregar) || cantAgregar <= 0)
                        {
                            Console.WriteLine("Cantidad inválida.");
                            break;
                        }

                        if (!prodAgregar.HayStock(cantAgregar))
                        {
                            Console.WriteLine($"No hay stock suficiente. Stock disponible: {prodAgregar.Stock}");
                            break;
                        }

                        if (carrito.AgregarProducto(prodAgregar, cantAgregar))
                        {
                            Console.WriteLine("Producto agregado al carrito.");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo agregar el producto (stock insuficiente o cantidad inválida).");
                        }
                        break;

                    case "5":
                        Console.Write("Ingrese código del producto a eliminar del carrito: ");
                        if (!int.TryParse(Console.ReadLine(), out int codigoEliminar))
                        {
                            Console.WriteLine("Código inválido.");
                            break;
                        }
                        if (carrito.EliminarProducto(codigoEliminar))
                        {
                            Console.WriteLine("Producto eliminado del carrito.");
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado en el carrito.");
                        }
                        break;

                    case "6":
                        carrito.MostrarContenido();
                        break;

                    case "7":
                        decimal total = carrito.TotalPagar();
                        Console.WriteLine($"Total a pagar (con IVA incluido): ${total:F2}");
                        break;

                    case "8":
                        if (carrito.Items.Count == 0)
                        {
                            Console.WriteLine("El carrito está vacío. No se puede finalizar la compra.");
                            break;
                        }

                        Console.WriteLine($"Total a pagar: ${carrito.TotalPagar():F2}");
                        Console.Write("Confirmar compra? (s/n): ");
                        string confirmar = Console.ReadLine();
                        if (confirmar.Equals("s", StringComparison.OrdinalIgnoreCase))
                        {
                            tienda.ActualizarStock(carrito);
                            carrito.Vaciar();
                            Console.WriteLine("Compra finalizada. Gracias por su compra!");
                        }
                        else
                        {
                            Console.WriteLine("Compra cancelada.");
                        }
                        break;

                    case "9":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
