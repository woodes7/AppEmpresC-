using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppCliente.Service
{
    internal class ImplementEmpleado : InterfaceEmpleado
    {
        InterfaceFichero ImplFichero = new ImplementFichero();

        private int contadorNumEmpleado = 1;

        void InterfaceEmpleado.AddEmpleado(List<Empleado> listaEmpleado, string ruta)
        {
            bool DniOK = false;
            string dni = "", nombre = "";

            try
            {
                while (!DniOK)
                {
                    Console.WriteLine("\t\tDime número de DNI del empleado");
                    dni = Console.ReadLine();
                    DniOK = !CompruebaDni(listaEmpleado, dni);
                    if (!DniOK)
                        Console.WriteLine("\t\tYa hay un empleado registrado con ese DNI");
                }

                Console.WriteLine("\t\tDime nombre del empleado");
                nombre = Console.ReadLine();

                Console.WriteLine("\t\tDime apellidos del empleado");
                string apellidos = Console.ReadLine();

                Console.WriteLine("\t\tDime la fecha de nacimiento del empleado");
                string fechaNacimiento = Console.ReadLine();

                Console.WriteLine("\t\tDime la titulación más alta del empleado");
                string titulaciónAlta = Console.ReadLine();

                Console.WriteLine("\t\tDime el número de la seguridad social del empleado");
                string numeroSeguridadSocial = Console.ReadLine();

                Console.WriteLine("\t\tDime el número de la cuenta bancaria del empleado");
                string numeroCuenta = Console.ReadLine();

                int numEmpleado = GenerarNumEmpleado();

                Empleado empleado = new Empleado(dni, nombre, apellidos, fechaNacimiento, titulaciónAlta, numeroSeguridadSocial, numeroCuenta, numEmpleado);
                Console.WriteLine("\t\t¿Quieres ingresar al empleado (si= s o S)?");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() == "s")
                {
                    listaEmpleado.Add(empleado);
                    Console.WriteLine("\t\tEmpleado agregado correctamente.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error: " + ex.Message);

            }
        }
        /// <summary>
        /// Comprueba el dni en la lista para ver si hay o no un empleado ya registrado con ese DNI
        /// </summary>
        /// <param name="listaEmpleados"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        private bool CompruebaDni(List<Empleado> listaEmpleados, string dni)
        {
            Empleado empleadoEncontrado = listaEmpleados.Find(empleado => empleado.Dni == dni);
            return empleadoEncontrado != null;
        }

        /// <summary>
        /// Es un contador que devulve la posicion del contador actual de los empleados,
        /// de esta manera se les genera un número de empleado a cada uno
        /// </summary>
        /// <returns></returns>
        private int GenerarNumEmpleado()
        {

            return contadorNumEmpleado++;
        }

        void InterfaceEmpleado.ModificarEmpleado(List<Empleado> listaEmpleado, string ruta)
        {
            try
            {
                MostrarEmpleados(listaEmpleado);

                Console.WriteLine("¿Qué empleado deseas modificar? Ingresa el número de empleado:");
                int nEmpleado;
                if (int.TryParse(Console.ReadLine(), out nEmpleado))
                {
                    bool empleadoEncontrado = false;

                    foreach (Empleado empleado in listaEmpleado)
                    {
                        if (empleado.NumEmpleado == nEmpleado)
                        {
                            empleadoEncontrado = true;
                            OpcionesModificacion(empleado);
                            break; // Sal del bucle una vez que se ha encontrado el empleado
                        }
                    }

                    if (!empleadoEncontrado)
                    {
                        Console.WriteLine("No se encontró ningún empleado con el número especificado: " + nEmpleado);
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Se produjo un error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public void OpcionesModificacion(Empleado empleado)
        {
            int opcion;
            bool opcionValida = false;

            do
            {
                try
                {
                    // Mostramos el menú
                    MenuModificacion();
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Escribe el nuevo DNI del empleado: ");
                            string nuevoDni = Console.ReadLine();
                            empleado.Dni = nuevoDni;
                            break;
                        case 2:
                            Console.WriteLine("Escribe el nuevo nombre del empleado: ");
                            string nuevoNombre = Console.ReadLine();
                            empleado.Nombre = nuevoNombre;
                            break;
                        case 3:
                            Console.WriteLine("Escribe el nuevo apellido del empleado: ");
                            string nuevosApellidos = Console.ReadLine();
                            empleado.Apellidos = nuevosApellidos;
                            break;
                        case 4:
                            Console.WriteLine("Escribe la nueva fecha de nacimiento (en formato dd/MM/yyyy): ");
                            string nuevaFechaNacimiento = Console.ReadLine();
                            empleado.FechaNacimiento = nuevaFechaNacimiento;
                            break;
                        case 5:
                            Console.WriteLine("Escribe la nueva titulación más alta del empleado: ");
                            string nuevaTitulacion = Console.ReadLine();
                            empleado.TitulaciónAlta = nuevaTitulacion;
                            break;
                        case 6:
                            Console.WriteLine("Escribe el nuevo número de la seguridad social del empleado: ");
                            string nuevoNumSS = Console.ReadLine();
                            empleado.NumeroSeguridadSocial = nuevoNumSS;
                            break;
                        case 7:
                            Console.WriteLine("Escribe el nuevo número de cuenta bancaria del empleado: ");
                            string nuevoNumCB = Console.ReadLine();
                            empleado.NumeroCuenta = nuevoNumCB;
                            break;
                        case 8:
                            Console.WriteLine("Saliendo del Menú de Modificación.");
                            opcionValida = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, introduce un número válido.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Debes introducir un número válido.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Se produjo un error: " + e.Message);
                }
            } while (!opcionValida);
        }
        /// <summary>
        /// Muestra el menu de modificacion de esta manera podremos elegir que queremos modificar
        /// </summary>
        public void MenuModificacion()
        {
            // Mostramos el menú
            Console.WriteLine("Menú de Modificación de Empleado:");
            Console.WriteLine("1. Modificar DNI");
            Console.WriteLine("2. Modificar Nombre");
            Console.WriteLine("3. Modificar Apellidos");
            Console.WriteLine("4. Modificar Fecha de Nacimiento");
            Console.WriteLine("5. Modificar Titulación más Alta");
            Console.WriteLine("6. Modificar Número de Seguridad Social");
            Console.WriteLine("7. Modificar Número de Cuenta Bancaria");
            Console.WriteLine("8. Salir");
        }
        /// <summary>
        /// Muestra los empleados es una lista mediante el metodo to string
        /// </summary>
        /// <param name="listaEmpleado"></param>
        public void MostrarEmpleados(List<Empleado> listaEmpleado)
        {
            try
            {
                if (listaEmpleado.Count > 0)
                {
                    foreach (Empleado empleado in listaEmpleado)
                    {
                        Console.WriteLine(empleado.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("La lista de empleados está vacía.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error: " + ex.Message);

            }
        }

        void InterfaceEmpleado.ExportarEmpleado(List<Empleado> listaEmpleado, string ruta)
        {

            MostrarEmpleados(listaEmpleado);
            Console.WriteLine("Dime el número de empleado que quieres exportar");
            try
            {
                if (listaEmpleado.Count > 0)
                {
                    int nEmpleado;
                    if (int.TryParse(Console.ReadLine(), out nEmpleado))
                    {
                        foreach (Empleado empleado in listaEmpleado)
                        {

                            if (empleado.NumEmpleado == nEmpleado)
                            {
                                // Llama al método para escribir este empleado en el archivo
                                ImplFichero.EscribirFichero(empleado, ruta);

                                Console.WriteLine("Empleado exportado correctamente al archivo " + ruta);
                                return;
                            }
                        }

                        // Si llegamos aquí, significa que no se encontró un empleado con el número especificado
                        Console.WriteLine("No se encontró ningún empleado con el número especificado: " + nEmpleado);
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingresa un número válido.");
                    }
                }
                else
                {
                    Console.WriteLine("La lista de empleados está vacía.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al exportar el empleado: " + ex.Message);
                // Puedes manejar la excepción según tus necesidades, como registrar el error en un archivo de registro.
            }


        }

    }
}

