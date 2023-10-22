using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDefinitivoRRHH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al Sistema de Gestión de Empleados");

            Console.Write("Ingrese la capacidad máxima de empleados: ");
            int capacidad = Convert.ToInt32(Console.ReadLine());

            clsMenu menu = new clsMenu(capacidad);

            bool salir = false;
            while (!salir)
            {
                menu.MostrarMenu();
                int opcion = Convert.ToInt32(Console.ReadLine());

            }
        }
    }
}


