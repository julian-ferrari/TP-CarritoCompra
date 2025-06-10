using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Categoria
    {
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }

        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Descripcion}";
        }
    }
}