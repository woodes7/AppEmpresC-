using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCliente.Service
{
    internal interface InterfaceEmpleado {
        public void AddEmpleado(List<Empleado> listPacientes, String ruta);
        private void ModificarEmpleado(List<Empleado> listPacientes, String ruta);
        private void ExportarEmpleado(List<Empleado> listPacientes, String ruta);
    }
}
