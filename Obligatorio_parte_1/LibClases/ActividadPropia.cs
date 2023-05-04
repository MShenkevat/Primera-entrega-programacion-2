using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibClases
{
    public class ActividadPropia : Actividad // Es hija de Actividad
    {
        // LISTA ATRIBUTOS

        // Nombre de la persona responsable de la acividad propia del Hostal
        // No puede ser vacio
        private string? Responsable { get; set; }

        // La actividad es al aire libre o no
        public bool AireLibre { get; set; }

        // CONSTRUCTORES
        public ActividadPropia(
            string nombre,
            string descripcion,
            string fecha,
            int cantMax,
            int edadMin,
            string responsable,
            bool aireLibre,
            double costo = 0
            )
            :base(nombre,descripcion,fecha,cantMax,edadMin,costo)
        {
            this.EsExterna = false;
            this.Responsable = responsable;
            this.AireLibre = aireLibre;
            // Console.WriteLine("La Actividad del Hostel fue creada");
        }



    }
}
