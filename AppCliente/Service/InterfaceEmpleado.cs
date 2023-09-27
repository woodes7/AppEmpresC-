using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCliente.Service
{
    internal interface InterfaceEmpleado
    {
        /// <summary>
        /// Resgistro de Empleados
        /// </summary>
        /// <param name="listaEmpleado"></param>
        /// <param name="ruta"></param>
        void AddEmpleado(List<Empleado> listaEmpleado, String ruta);
        /// <summary>
        /// Modificacion de Empleados, selecionando lo mediante su número de empleado
        /// </summary>
        /// <param name="listaEmpleado"></param>
        /// <param name="ruta"></param>
        void ModificarEmpleado(List<Empleado> listaEmpleado, String ruta);
        /// <summary>
        /// Extrae al empleado que queremos y lo exporta a un fichero mediante un metodo fichero
        /// </summary>
        /// <param name="listPacientes"></param>
        /// <param name="ruta"></param>
        void ExportarEmpleado(List<Empleado> listPacientes, String ruta);
    }
}
