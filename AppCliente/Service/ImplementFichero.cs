using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppCliente.Service.InterfaceFichero;

namespace AppCliente.Service
{
    internal class ImplementFichero : InterfaceFichero
    {
        void InterfaceFichero.EscribirFichero(Empleado empleado, string ruta)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta))
                {
                    // Encabezado
                    string encabezado = "nombre, apellidos, dni, fechaNacimiento, titulaciónAlta, numeroSeguridadSocial, numeroCuenta";
                    writer.WriteLine(encabezado);

                    // Datos del empleado
                    string empleadoString = $"{empleado.Dni}, {empleado.Nombre}, {empleado.Apellidos}, {empleado.FechaNacimiento}, {empleado.TitulaciónAlta}, {empleado.NumeroSeguridadSocial}, {empleado.NumeroCuenta}";
                    writer.WriteLine(empleadoString);
                }

                Console.WriteLine("Datos del empleado exportados exitosamente al archivo " + ruta);
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("Error al exportar los datos del empleado: " + e.Message);
            }


        }
    }
}
