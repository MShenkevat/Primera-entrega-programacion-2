using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClases
{
    public class Actividad
    {
        // LISTA ATRIBUTOS

        // identificador numérico autogenerado
        private string Identificador { get; set; } // Se autogenera con Guid.NewGuid() y se pasa a string

        // nombre de la actividad
        // Uso "?" porque no puede ser vacío 
        public string? Nombre { get; set; }

        // descripcion actividad
        private string? Descripcion { get; set; }

        // fecha actividad
        // Tiene que ser mayor o igual que la fecha de hoy
        public DateTime Fecha { get; set; }

        // Cantidad maxima personas
        public int CantMax { get; set; }

        // Edad Mínima para la actividad
        public int EdadMin { get; set; }

        // Costo actividad es en dólares
        public double Costo { get; set; }

        // Es del hostal o externa
        public bool EsExterna;

        // CONSTRUCTOR
        public Actividad(
            string nombre,
            string descripcion,
            string fecha,
            int cantMax,
            int edadMin,
            double costo = 0 // se asume el costo es Cero a menos se indique lo contrario
            )
        {   
            // verifico la fecha de la actividad sea mayor o igual a la de hoy
            bool fechaOk = false;
            DateTime fechaFormateada = DateTime.Parse(fecha); // fecha pasa como string formayo dd/mm/yyyy
            DateTime hoy = DateTime.Now.Date; // fecha de hoy
            
            if (fechaFormateada >= hoy)
            {
                fechaOk = true;
            }
            else
            {
                Console.WriteLine("La fecha debe ser mayor o igual a la de hoy");
            }

            // Verifico el nombre no tenga mas de 25 caracteres
            bool largoNombreOk = false;

            if (nombre.Length < 25) 
            {
                largoNombreOk = true;
            }
            else 
            {
                Console.WriteLine("El nombre de la Actividad debe ser menor de 25 caracteres");
            }

            
            // Creo la instancia de la clase Actividad si todo es correcto
            if (fechaOk && largoNombreOk)
            {
                this.Identificador = Guid.NewGuid().ToString(); // Crea identificador unico
                this.Nombre = nombre;
                this.Descripcion = descripcion;
                this.Fecha = fechaFormateada;
                this.CantMax = cantMax;
                this.EdadMin = edadMin; 
                this.Costo = costo;
            } 
            else
            {
                Console.WriteLine("La Actividad no fue creada");
            }
            
        }

        // METODOS

        public override string ToString()
        {
            return $"Actividad numero {Identificador}, nombre  {Nombre}, descripcion {Descripcion}, fecha {Fecha}, maxima capacidad {CantMax}, edad minima {EdadMin} ";
            
        }
    }
}
