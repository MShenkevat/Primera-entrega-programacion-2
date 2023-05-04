using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClases
{
    public class Usuario
    {
        // LISTA ATRIBUTOS

        // Mail de registro
        private string Mail { get; set; }

        // Contraseña de usuario
        private string Password { get; set; }

        // CONSTRUCTOR

        public Usuario(string mail, string password)
        {
            // Verifico que el mail contenga el caracter @ y no este al principio ni al final

            bool contieneArroba = false;

            if (mail.Contains("@") && !mail.StartsWith("@") && !mail.EndsWith("@"))
            {
                contieneArroba = true;
            }
            else
            {
                Console.WriteLine("El formato mail no es válido");
            }

            // verifico que la contraseña tenga un mínimo de 8 caracteres

            bool largoPasswordCorrecto = false;

            if(password.Length > 6 )
            {
                largoPasswordCorrecto = true;
            }
            else
            {
                Console.WriteLine("La contraseña debe tener mas de 6 caracteres");
            }


            // Creo la instacia usuario si todo es correcto 

            if (contieneArroba)
            {
                this.Mail = mail;
                this.Password = password;
            }
            else
            {
                Console.WriteLine("Usuario o contraseña no válida");
            }
            
        }
    }
}


