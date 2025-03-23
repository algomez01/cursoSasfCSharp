using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursoSasfCSharp
{
    class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto() { }

        public Producto(string id, string nombre, double precio)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
        }

        public override string ToString()
        {
            return Id + " | " + Nombre + " | " + Precio;
        }
    }
}
