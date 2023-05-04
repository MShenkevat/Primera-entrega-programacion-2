using LibClases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio_parte_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inicio la clase Sistema
            Hotel hotel = new Hotel();


            // Muestro Menu
            MostrarMenu();

            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                foreach (Actividad actividad in hotel.ActividadesTercerizadas)
                {
                    Console.WriteLine(actividad.ToString());
                    
                }
            }
            else if (opcion == "2")
            {
                var proveedoresOrdenados = hotel.Proveedores.OrderBy(o => o.Nombre);
                foreach (Proveedor proveedor in proveedoresOrdenados)
                {
                    Console.WriteLine(proveedor.ToString());

                }
            }
            else if(opcion == "3")
            {
                Console.WriteLine("Ingresar Fecha Inicio");
                DateTime fechaIni = DateTime.Parse(Console.ReadLine()); 
                Console.WriteLine("Ingresar Fecha Fin");
                DateTime fechaFin = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingresas Costo Tope");
                double costo = double.Parse(Console.ReadLine());

                // filtro por fechas
                List<ActividadPropia> filtroFechaPropia = hotel.ActividadesPropias.Where(o => o.Fecha >= fechaIni && o.Fecha <= fechaFin).ToList();
                List<ActividadTercerizada> filtroFechaTercerizada = hotel.ActividadesTercerizadas.Where(o => o.Fecha >= fechaIni && o.Fecha <= fechaFin).ToList();
                // agrego todas a unica lista
                List<Actividad> todas = new List<Actividad>();
                todas.AddRange(filtroFechaPropia);
                todas.AddRange(filtroFechaTercerizada);
                // ordeno la lista por costo descendientemente
                var actividadOrdenada = todas.OrderByDescending(o => o.Costo);
                // Muestro filtrando con costo
                foreach (Actividad actividad in actividadOrdenada)
                {
                    if (actividad.Costo <= costo)
                    {
                        Console.WriteLine(actividad.ToString());
                    }
                }
            }
            else if(opcion == "4")
            {
                Console.WriteLine("Ingresar Nombre Proveedor");
                string nombreP = Console.ReadLine();
                Console.WriteLine("Ingresar nuevo Descuento");
                double desc = double.Parse(Console.ReadLine());

                foreach (Proveedor proveedor in hotel.Proveedores)
                {
                    if (proveedor.Nombre.Equals(nombreP))
                    {
                        proveedor.Descuento = desc;
                    }

                }

            }
            else if(opcion == "5")
            {
                Console.WriteLine("Dar de alta nuevo huesped");
                Console.WriteLine("Ingesar Mail");
                string mail = Console.ReadLine();
                Console.WriteLine("Ingresar Contraseña");
                string pass = Console.ReadLine();
                Console.WriteLine("Ingresar Tipo Documento");
                string tipoDoc = Console.ReadLine();
                Console.WriteLine("Ingresar Numero Documento");
                string numDoc = Console.ReadLine();
                Console.WriteLine("Ingresar Nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingresar Apellido");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingresar Habitacion");
                string hab = Console.ReadLine();
                Console.WriteLine("Ingresar Fecha Nacimiento");
                string fecha = Console.ReadLine();
                Console.WriteLine("Ingresar Nivel Fidelizacion");
                int fid = int.Parse(Console.ReadLine());

                hotel.AltaHuesped(new Huesped(mail, pass, tipoDoc, numDoc, nombre, apellido, hab, fecha, 4));
            }
        }

        public static void MostrarMenu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("Elegir Opcion");
            Console.WriteLine("1 - Mostrar Actividades");
            Console.WriteLine("2 - Mostrar Proveedores");
            Console.WriteLine("3- Mostrar Actividades Filtrado Costo y Fecha");
            Console.WriteLine("4 - Establecer descuento Proveedor");
            Console.WriteLine("5 - Dar de Alta a un Huesped");
        }


    }
}