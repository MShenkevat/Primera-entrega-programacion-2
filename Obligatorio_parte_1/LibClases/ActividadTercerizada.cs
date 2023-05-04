using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClases
{
    public class ActividadTercerizada : Actividad // Es hija de Actividad
    {
        // LISTA ATRIBUTOS

        // proveedor de la Actividad Tercerizada
        public string? Proveedor { get; set; } // voy a asignar el nombre de un proveedor de la clase Proveedor

        // confirmacion actividad
        private bool Confirmada { get; set; }

        // fecha de la confirmacion
        private DateTime FechaConfirmacion { get; set; }

        // descuento del Proveedor
        public double Descuento { get; set; }

        // CONSTRUCTORES
        public ActividadTercerizada(
            string nombre,
            string descripcion,
            string fecha,
            int cantMax,
            int edadMin,
            string proveedor,
            bool confirmada,
            string fechaConfirmacion,
            double costo = 0,
            double descuento = 0
            )
            :base(nombre, descripcion, fecha, cantMax, edadMin, costo)
        {
            this.EsExterna = true;
            this.Proveedor = proveedor;
            this.Confirmada = confirmada;
            this.FechaConfirmacion = DateTime.Parse(fechaConfirmacion);
            this.Descuento = descuento;
            // Console.WriteLine("La Actividad del Proveedor fue creada");
        }

    }
}
