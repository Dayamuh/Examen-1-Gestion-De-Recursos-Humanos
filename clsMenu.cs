using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDefinitivoRRHH
{
    internal class clsMenu
    {
            private clsEmpleado[] empleados;

            public clsMenu(int NumEmpleados)
            {
                empleados = new clsEmpleado[NumEmpleados];
            }

            public void MostrarMenu()
            {
                int opcion;
                do
                {
                    Console.WriteLine("Menú Principal");
                    Console.WriteLine("1. Agregar Empleados");
                    Console.WriteLine("2. Consultar Empleados");
                    Console.WriteLine("3. Modificar Empleados");
                    Console.WriteLine("4. Borrar Empleados");
                    Console.WriteLine("5. Inicializar Arreglos");
                    Console.WriteLine("6. Reportes");
                    Console.WriteLine("7. Salir");
                    Console.Write("Seleccione una opción: ");

                    if (int.TryParse(Console.ReadLine(), out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                Agregar();
                                break;
                            case 2:
                                Consultar();
                                break;
                            case 3:
                                Modificar();
                                break;
                            case 4:
                                Borrar();
                                break;
                            case 5:
                                InicializarArreglos();
                                break;
                            case 6:
                                Reportes();
                                break;
                            case 7:
                                Console.WriteLine("Saliendo del programa.");
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    }
                } while (opcion != 7);
            }

            private void Agregar()
            {
                for (int i = 0; i < empleados.Length; i++)
                {
                    if (empleados[i] == null)
                    {
                        Console.Write("Cédula: ");
                        string cedula = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Dirección: ");
                        string direccion = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        string telefono = Console.ReadLine();
                        Console.Write("Salario: ");

                        if (double.TryParse(Console.ReadLine(), out double salario))
                        {
                            empleados[i] = new clsEmpleado(cedula, nombre, direccion, telefono, salario);
                            Console.WriteLine("Empleado agregado exitosamente.");
                            return;
                        }
                    }
                }
                Console.WriteLine("No hay espacio para más empleados.");
            }

            private void Consultar()
            {
                Console.WriteLine("Consultar Empleados");
                Console.Write("Ingrese la cédula del empleado: ");
                string cedula = Console.ReadLine();
                clsEmpleado empleado = ConsultarEmpleadoPorCedula(cedula);
                if (empleado != null)
                {
                    Console.WriteLine("Información del empleado:");
                    MostrarInformacionEmpleado(empleado);
                }
                else
                {
                    Console.WriteLine("Empleado no encontrado.");
                }
            }

            private clsEmpleado ConsultarEmpleadoPorCedula(string cedula)
            {
                return empleados.FirstOrDefault(e => e != null && e.Cedula == cedula);
            }

            private void Modificar()
            {
                Console.WriteLine("\nModificar Empleados");
                Console.Write("Ingrese la cédula del empleado a modificar: ");
                string cedula = Console.ReadLine();
                clsEmpleado empleado = ConsultarEmpleadoPorCedula(cedula);
                if (empleado != null)
                {
                    Console.WriteLine("\nInformación actual del empleado:");
                    MostrarInformacionEmpleado(empleado);

                    Console.WriteLine("\nIngrese los nuevos datos:");
                    Console.Write("Nombre: ");
                    empleado.Nombre = Console.ReadLine();
                    Console.Write("Dirección: ");
                    empleado.Direccion = Console.ReadLine();
                    Console.Write("Teléfono: ");
                    empleado.Telefono = Console.ReadLine();
                    Console.Write("Salario: ");

                    if (double.TryParse(Console.ReadLine(), out double salario))
                    {
                        empleado.Salario = salario;
                        Console.WriteLine("Empleado modificado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Salario no válido. No se realizó la modificación.");
                    }
                }
                else
                {
                    Console.WriteLine("Empleado no encontrado. No se realizó la modificación.");
                }
            }

            private void Borrar()
            {
                Console.WriteLine("\nBorrar Empleados");
                Console.Write("Ingrese la cédula del empleado a borrar: ");
                string cedula = Console.ReadLine();
                clsEmpleado empleado = ConsultarEmpleadoPorCedula(cedula);
                if (empleado != null)
                {
                    for (int i = 0; i < empleados.Length; i++)
                    {
                        if (empleados[i] != null && empleados[i].Cedula == cedula)
                        {
                            empleados[i] = null;
                            Console.WriteLine("Empleado borrado exitosamente.");
                            return;
                        }
                    }
                }
                Console.WriteLine("Empleado no encontrado. No se realizó la eliminación.");
            }

            private void InicializarArreglos()
            {
                Console.WriteLine("\nInicializar Arreglo");
                Console.Write("Ingrese la cantidad de empleados: ");
                if (int.TryParse(Console.ReadLine(), out int cantidadEmpleados))
                {
                    empleados = new clsEmpleado[cantidadEmpleados];
                    Console.WriteLine($"Arreglo inicializado con {cantidadEmpleados} empleados.");
                }
                else
                {
                    Console.WriteLine("Cantidad no válida. Inténtelo de nuevo.");
                }
            }

            private void Reportes()
            {
                int opcion;
                do
                {
                    Console.WriteLine("\nMenú de Reportes");
                    Console.WriteLine("1. Consultar empleados con número de cédula");
                    Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
                    Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
                    Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo");
                    Console.WriteLine("0. Volver al Menú Principal");
                    Console.Write("Seleccione una opción: ");
                    if (int.TryParse(Console.ReadLine(), out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                Consultar();
                                break;
                            case 2:
                                ListarEmpleadosOrdenadosPorNombre();
                                break;
                            case 3:
                                CalcularPromedioSalarios();
                                break;
                            case 4:
                                CalcularSalarioMaximoMinimo();
                                break;
                            case 5:
                                Console.WriteLine("Volviendo al Menú Principal.");
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    }
                } while (opcion != 5);
            }

            private void ListarEmpleadosOrdenadosPorNombre()
            {
                Console.WriteLine("\nListar Empleados Ordenados por Nombre");

                var empleadosOrdenados = empleados.Where(e => e != null)
                                                  .OrderBy(e => e.Nombre, StringComparer.OrdinalIgnoreCase)
                                                  .ToList();

                foreach (var empleado in empleadosOrdenados)
                {
                    MostrarInformacionEmpleado(empleado);
                }
            }

            private void CalcularPromedioSalarios()
            {
                Console.WriteLine("\nCalcular Promedio de Salarios");

                double totalSalarios = empleados.Where(e => e != null).Sum(e => e.Salario);
                int contador = empleados.Count(e => e != null);

                if (contador > 0)
                {
                    double promedio = totalSalarios / contador;
                    Console.WriteLine($"El promedio de salarios es: {promedio:C}");
                }
                else
                {
                    Console.WriteLine("No hay empleados registrados para calcular el promedio.");
                }
            }

            private void CalcularSalarioMaximoMinimo()
            {
                Console.WriteLine("\nCalcular Salario Máximo y Mínimo");

                var empleadosValidos = empleados.Where(e => e != null).ToList();

                if (empleadosValidos.Count > 0)
                {
                    double salarioMaximo = empleadosValidos.Max(e => e.Salario);
                    double salarioMinimo = empleadosValidos.Min(e => e.Salario);

                    Console.WriteLine($"Salario más alto: {salarioMaximo:C}");
                    Console.WriteLine($"Salario más bajo: {salarioMinimo:C}");
                }
                else
                {
                    Console.WriteLine("No hay empleados registrados para calcular salarios.");
                }
            }

            private void MostrarInformacionEmpleado(clsEmpleado empleado)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario:C}");
            }
        }
    }


