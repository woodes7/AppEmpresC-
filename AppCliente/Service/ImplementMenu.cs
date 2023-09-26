using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCliente.Service
{
    internal class ImplementMenu : InterfaceMenu
    {
        public void Menu()
        {
            Console.WriteLine("Elige un opción de Menu");
            Console.WriteLine("---------Menu----------");
            Console.WriteLine("1. Registrar empleado");
            Console.WriteLine("2. Modificar empleado");
            Console.WriteLine("3. Exportar a fichero");
            Console.WriteLine("0. Cerrar");
        }
    }
}

