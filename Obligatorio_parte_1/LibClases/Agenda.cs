using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibClases
{
    public class Agenda
    {
        // VARIABLE DE CLASE. Es el mismo valor para todas las instancias.
        public DateTime fechaCreacionAgenda = DateTime.Now;
        
        // LISTA ATRIBUTOS

        // nombre y apellido del huesped
        private string NombreApellidoHuesped { get; set; }

        // nombre de la actividad
        private string NombreActividad { get; set; }

        // fecha de la actividad
        public DateTime FechaActividad { get; set; }

        // lugar de la actividad
        private string LugarActividad { get; set; }

        // Costo Actividad, si tiene se muestra, sino muestra Actividad Gratuita
        private string CostoActividad { get; set; }

        // Estado de la Agenda PENDIENTE_PAGO o CONFIRMADA
        private string EstadoAgenda { get; set; }

        // CONSTRUCTOR

        public Agenda(Huesped huesped, ActividadPropia actividad)
        {
            // Valido disponibilidad
            bool disponible = ValidoDisponibilidad(huesped, actividad);

            // Valido Edad
            bool edadValida = ValidoEdad(huesped, actividad);

            // Defino costo final
            double costo = actividad.Costo;
            if (!actividad.EsExterna)
            {
                if (huesped.NivelFidelizacion == 4)
                {
                    costo = costo - costo * 0.2;
                }
                else if (huesped.NivelFidelizacion == 3)
                {
                    costo = costo - costo * 0.15;
                }
                else if (huesped.NivelFidelizacion == 2)
                {
                    costo = costo - costo * 0.1;
                }
            }
            string costoFinal;
            string pago;
            if(costo == 0)
            {
                costoFinal = "Actividad Gratuita";
                pago = "CONFIRMADA";
            }
            else
            {
                costoFinal = costo.ToString();
                pago = "PENDIENTE_PAGO";
            }

            // Verifico si es al aire libre
            bool aireLibre = ValidarAireLibre(actividad);
            string lugar;
            if (aireLibre)
            {
                lugar = "Al aire libre";
            }
            else
            {
                lugar = "Actividad dentro del Hostal";
            }

            this.NombreApellidoHuesped = huesped.Nombre + " " + huesped.Apellido;
            this.NombreActividad = actividad.Nombre;
            this.FechaActividad = actividad.Fecha;
            this.LugarActividad = lugar;
            this.CostoActividad = costoFinal;
            this.EstadoAgenda = pago;

        }

        public Agenda(Huesped huesped, ActividadTercerizada actividad, Hotel hotel)
        {
            // Valido disponibilidad
            bool disponible = ValidoDisponibilidad(huesped, actividad);

            // Valido Edad
            bool edadValida = ValidoEdad(huesped, actividad);

            // Defino costo final
            double costo = actividad.Costo;

            double descuento = actividad.Descuento;

            costo = costo - costo * descuento;

            string costoFinal;
            string pago;
            if (costo == 0)
            {
                costoFinal = "Actividad Gratuita";
                pago = "CONFIRMADA";
            }
            else
            {
                costoFinal = costo.ToString();
                pago = "PENDIENTE_PAGO";
            }

            
            string lugar = "A definir por Proveedor";

          

            this.NombreApellidoHuesped = huesped.Nombre + " " + huesped.Apellido;
            this.NombreActividad = actividad.Nombre;
            this.FechaActividad = actividad.Fecha;
            this.LugarActividad = lugar;
            this.CostoActividad = costoFinal;
            this.EstadoAgenda = pago;

        }


        private bool ValidoDisponibilidad(Huesped huesped, Actividad actividad)
        {
            bool actividadDisponible = false;
            if (actividad.CantMax != 0)
            {
                actividadDisponible = true;
                actividad.CantMax--;
            }
            else
            {
                Console.WriteLine("No hay cupos para esta actividad");
            }

            return actividadDisponible;
        }

        private static bool ValidoEdad(Huesped huesped, Actividad actividad)
        {
            bool edadApropiada = false;
            if (huesped.Edad > actividad.EdadMin)
            {
                edadApropiada |= true;
            }
            else
            {
                Console.WriteLine("El huesped no tiene la edad apropiada para esta actividad");
            }
            return edadApropiada;
        }

        private static bool ValidarAireLibre(Actividad actividad)
        {
            return actividad.EsExterna;
        }


    }
}
