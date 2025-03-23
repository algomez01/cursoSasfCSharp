using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursoSasfCSharp
{
    class ProductoService 
    {
        private List<Producto> Inventario { get; set; }

        public ProductoService()
        {
            Inventario = new List<Producto>();
            //dataDummy
            this.generateDataDummy();
        }

        public void procesa(int opcion)
        {
            bool exitProceso = false;

            //Ciclo que permite mantenerse en la opcion o regresar al menu
            do
            {
                try
                {
                    //Console.WriteLine("Opción seleccionada " + seleccion);
                    switch (opcion)
                    {
                        case 1:
                            Buscar();
                            break;
                        case 2:
                            MostrarTodos();
                            break;
                        case 3:
                            Agregar();
                            break;
                        case 4:
                            Eliminar();
                            break;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Error: Formato no válido");
                }
                catch (ServiceException ex)
                {
                    Console.WriteLine("Alerta: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error General: " + ex.Message);
                }

                Console.WriteLine("\nRegresar al menu? (S/N): ");
                string valor = Console.ReadLine();

                if (valor.ToUpper().Equals("S"))
                {
                    exitProceso = true;
                }

            } while (!exitProceso);
        }

        private void Agregar()
        {
            Console.WriteLine("\n==AGREGAR PRODUCTO==");
            Console.WriteLine("Ingrese el nombre:");
            string nombre = Console.ReadLine();

            if (nombre.Length == 0)
            {
                throw new ServiceException("Debe ingresar un nombre!");
            }

            Console.WriteLine("Ingrese el precio:");
            double precio = Convert.ToDouble(Console.ReadLine());

            if (precio <= 0)
            {
                throw new ServiceException("El valor del precio debe ser mayor a 0");
            }

            Producto producto = new Producto(Guid.NewGuid().ToString(), nombre, precio);
            this.Inventario.Add(producto);

            Console.WriteLine("Producto creado con ID: " + producto.Id);
        }

        private void Eliminar()
        {
            Console.WriteLine("\n==ELIMINAR PRODUCTO==");
            Console.WriteLine("Ingrese el ID:");
            string id = Console.ReadLine();

            if (id.Length == 0)
            {
                throw new ServiceException("Debe ingresar un ID!");
            }

            Producto producto = this.Inventario.FirstOrDefault(p => p.Id.Equals(id));
            if(producto == null)
            {
                throw new ServiceException("No se ha encontrado el producto");
            }

            this.Inventario.Remove(producto);
            Console.WriteLine("Producto eliminado!");
        }

        private void Buscar()
        {
            Console.WriteLine("\n==BUSCAR PRODUCTOS==");

            if (this.Inventario.Count() == 0)
            {
                throw new ServiceException("No existen productos en inventario");
            }

            Console.WriteLine("Ingrese el nombre:");
            string nombre = Console.ReadLine();
            if (nombre.Length == 0)
            {
                throw new ServiceException("Debe ingresar un nombre!");
            }

            var productos = this.Inventario.Where(p => p.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0);

            if (productos.Count() == 0)
            {
                throw new ServiceException("No se encontraron producto!");
            }

            Console.WriteLine("\nTotal de productos encontrados: " + productos.Count());
            Console.WriteLine("ID | DESCRIPCION | PRECIO");
            foreach (Producto producto in productos){
                Console.WriteLine(producto.ToString());
            }
        }

        private void MostrarTodos()
        {
            Console.WriteLine("\n==INVENTARIO DE PRODUCTOS==");

            if (this.Inventario.Count() == 0)
            {
                throw new ServiceException("No existen productos en inventario");
            }

            Console.WriteLine("\nTotal de productos existentes: " + this.Inventario.Count());
            Console.WriteLine("ID | DESCRIPCION | PRECIO");
            foreach (Producto producto in this.Inventario)
            {
                Console.WriteLine(producto.ToString());
            }
        }

        private void generateDataDummy()
        {
            this.Inventario.Add(new Producto(Guid.NewGuid().ToString(), "Cargador", 9));
            this.Inventario.Add(new Producto(Guid.NewGuid().ToString(), "Celular", 650.30));
            this.Inventario.Add(new Producto(Guid.NewGuid().ToString(), "Microfono", 38.35));
            this.Inventario.Add(new Producto(Guid.NewGuid().ToString(), "Cable", 15.5));
            this.Inventario.Add(new Producto(Guid.NewGuid().ToString(), "Monitor", 1150.34));

            Console.WriteLine("\nSe cargo data dummy!!!\n");
        }
    }
}
