using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCliente.Service
{
    internal interface InterfaceFichero
    {
        /// <summary>
        /// Escribe los datos de un empleado en un archivo.
        /// </summary>
        /// <param name="empleado">El empleado cuyos datos se escribirán en el archivo.</param>
        /// <param name="ruta">La ruta del archivo donde se guardarán los datos.</param>
        void EscribirFichero(Empleado empleado, string ruta);
    }

}

