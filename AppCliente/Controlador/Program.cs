using AppCliente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creamos instancias de las clases en 
            InterfaceEmpleado empleado = new ImplementEmpleado();
            InterfaceMenu implMenu = new ImplementMenu();
            InterfaceFichero implFile = new ImplementFichero();

            // Creamos variables que vamos a usar
            int opcion;
            bool opcionValida = false;
            string archivoRuta = "BasedeDatosEmpleados.txt";
            // Lista de Empleados
            List<Empleado> listaEmpleado = new List<Empleado>();


            //Menu de opciones
            do
            {
                try
                {
                    // Mostramos el menú
                    implMenu.Menu();
                    //Opciones del Menu
                    opcion = int.Parse(Console.ReadLine());
                    Console.WriteLine("[INFO] - Has seleccionado la opcion " + opcion);

                    switch (opcion)
                    {
                        case 0:
                            opcionValida = true;
                            break;
                        case 1:
                            empleado.AddEmpleado(listaEmpleado, archivoRuta);
                            break;
                        case 2:
                            empleado.ModificarEmpleado(listaEmpleado, archivoRuta);
                            break;
                        case 3:
                            empleado.ExportarEmpleado(listaEmpleado, archivoRuta);
                            break;
                        case 4:
                            Console.WriteLine("Saliendo del Programa. Adiós...");
                            opcionValida = true;
                            break;
                        default:
                            Console.WriteLine("Error: Opción inválida. Por favor, introduce un número válido.");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: Opción inválida. Por favor, introduce un número válido.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Se produjo un error: " + e.Message);
                }
            } while (!opcionValida);
        }
    }

}


