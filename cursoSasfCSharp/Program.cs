using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursoSasfCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            bool exitMenu = false;
            ProductoService service = new ProductoService();
            Dictionary<int, string> opciones = new Dictionary<int, string>
            {
                { 1, "Buscar" },
                { 2, "Visualizar" },
                { 3, "Ingreso" },
                { 4, "Eliminación" },
                { 5, "Salir" }
            };

            //Ciclo que permite mantenerse en el menu
            do
            {
                try
                {
                    Console.WriteLine("\n****MENU - INVENTARIO DE PRODUCTOS****");

                    foreach (var opcion in opciones)
                    {
                        Console.WriteLine(opcion.Key + ". " + opcion.Value);
                    }
                    Console.WriteLine("\nIngrese una opción");
                    int seleccion = Convert.ToInt32(Console.ReadLine());

                    if (seleccion < 0 || seleccion > 5)
                    {
                        Console.WriteLine("Alerta: Opción no válida");
                    }
                    else if(seleccion == 5)
                    {
                        exitMenu = true;
                    }
                    else
                    {
                        service.procesa(seleccion);
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Error: Formato no válido");
                }
                catch(ServiceException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error General: " + ex.Message);
                }

            } while (!exitMenu);
        }
    }
}
