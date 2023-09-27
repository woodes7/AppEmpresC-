using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCliente
{
    internal class Empleado
    {   //Atributo
        string dni;
        string nombre;
        string apellidos;
        string fechaNacimiento;
        string titulaciónAlta;
        string numeroSeguridadSocial;
        string numeroCuenta;
        int numEmpleado;
        //Constructor
        public Empleado(string nombre, string apellidos, string dni, string fechaNacimiento, string titulaciónAlta, string numeroSeguridadSocial, string numeroCuenta, int numEmpleado)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
            this.titulaciónAlta = titulaciónAlta;
            this.numeroSeguridadSocial = numeroSeguridadSocial;
            this.numeroCuenta = numeroCuenta;
            this.numEmpleado = numEmpleado;
        }

        public Empleado()
        {
        }
        //Getters && Stetters
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Dni { get => dni; set => dni = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string TitulaciónAlta { get => titulaciónAlta; set => titulaciónAlta = value; }
        public string NumeroSeguridadSocial { get => numeroSeguridadSocial; set => numeroSeguridadSocial = value; }
        public string NumeroCuenta { get => numeroCuenta; set => numeroCuenta = value; }
        public int NumEmpleado { get => numEmpleado; set => numEmpleado = value; }

        //To String
        public override string ToString()
        {
            return $"Número de Empleado: {NumEmpleado}, DNI{Dni}, Nombre: {Nombre}, Apellidos: {Apellidos}, Fecha de Nacimiento: {FechaNacimiento}\n Número de Cuenta, {NumeroCuenta}, Número de la Seguridad Social{NumeroSeguridadSocial}, Titulacion mas Alta {TitulaciónAlta}";
        }

    }
}
