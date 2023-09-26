using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCliente.Service
{
    internal interface InterfaceEmpleado {
         void AddEmpleado(List<Empleado> listaEmpleado, String ruta);
         void ModificarEmpleado(List<Empleado> listaEmpleado, String ruta);
         void ExportarEmpleado(List<Empleado> listPacientes, String ruta);
    }
}
