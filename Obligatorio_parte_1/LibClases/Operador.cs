using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClases
{
    public class Operador : Usuario // Es hijo de Usuario
    {
        // ATRIBUTOS
        // El tipo de usuario es operador
        private string TipoUsuario { get; set; }

        // CONSTRUCTORES
        public Operador(string mail, string password)
            : base(mail, password)
        {
            this.TipoUsuario = "operador";
        }

        // METODO
        public void ConfirmarPago()
        {
            return;
        }
    }
}
