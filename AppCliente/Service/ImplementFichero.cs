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
                    // Aquí defines cómo deseas formatear y escribir los datos del empleado en el archivo
                    string empleadoString = $"{empleado.Dni}, {empleado.Nombre}, {empleado.Apellidos}, {empleado.FechaNacimiento}, {empleado.TitulaciónAlta}.";
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
