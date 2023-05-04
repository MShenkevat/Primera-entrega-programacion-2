using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClases
{
    public class Proveedor
    {
        // LISTA ATRIBUTOS

        // Nombre que debe ser único
        public string Nombre;

        // Numero contacto telefónico
        private int NumeroContactoTelefonico;

        // Direccion
        private string Direccion;

        // Descuento fijo puede ofrecerce o no
        public double Descuento;

        // CONSTRUCTORES

        public Proveedor(string nombre, int numTel, string direccion, double descuento = 0.0)
        {
            this.Nombre = nombre;
            this.NumeroContactoTelefonico = numTel;
            this.Direccion = direccion;
            this.Descuento = descuento;
        }

        // METODOS

        // Crear una Actividad
        public Actividad CrearActividad()
        {
            return null;
        }

        public override string ToString()
        {
            return $"Proveedor nombre {Nombre}, numero {NumeroContactoTelefonico}, dirección {Direccion}, descuento {Descuento}";
        }
    }
}
