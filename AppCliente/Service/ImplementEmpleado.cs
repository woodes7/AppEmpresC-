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
        void InterfaceEmpleado.AddEmpleado(List<Empleado> listEmpleado, string ruta){
            bool DniOK=false;
            bool nomOK = false;
            String Dni = "", nombre = "";
                      
                Console.WriteLine("\t\tDime nombre del empleado");
                nombre = Console.ReadLine();
             
            while (DniOK != false)
            {
                Console.WriteLine("\t\tDime numero de Dni del empleado");
                Dni = Console.ReadLine();
                DniOK = CompruebaDni(listEmpleado, Dni);
                if (DniOK == true)
                    Console.WriteLine("\t\tYa hay un empleado registrado con ese Dni");
            }
            DateTime fecha = DateTime.Now;

            string fechaIngreso = fecha.ToString();
            Console.WriteLine("\t\tFecha de ingreso del empleado: " + fechaIngreso);
            string fechaAlta = "-----";
            Empleado empleado = new Empleado();
            Console.WriteLine("\t\tQuieres ingresar al empleado (si= s o S)");
            string respuesta = Console.ReadLine();

            if (respuesta.ToLower() == "s")
            {
                listEmpleado.Add(empleado);
                implFichero.EscribirEnArchivoEmpleado(listEmpleado, ruta);
            }
        }
        private bool CompruebaNombre(List<Empleado> listEmpleado, string nombre)
        {
            // Expresión regular para verificar si el nombre contiene solo letras y no números
            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(nombre))
            {
                return false;
            }
            return true;
        }
        //comprueba que el paciente no este ya ingresado por el telefono
        private bool CompruebaDni(List<Empleado> listaPacientes, string dni)
        {
            Empleado empleadoEncontrado = listaPacientes.Find(empleado => empleado.Dni == dni);
            return empleadoEncontrado;
        }
    }
}
