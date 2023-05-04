using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LibClases
{
    public class Huesped : Usuario // Es hijo de Usuario
    {
        // LISTA DE ATRIBUTOS 

        // Tipo de documento, puede ser CI, PASAPORTE, OTROS
        private string? TipoDocumento { get; set; }
        
        // Este es el numero de documento 
        private string? NumeroDocumento { get; set; }

        // Par Tipo y Numero Documento
        public string? ParTipoNumeroDoc { get; set; } 
         
        // Nombre del huesped
        public string? Nombre { get; set; }

        // Appellido de huesped 
        public string? Apellido { get; set; }

        // Habitacion 
        private string? Habitacion { get; set; }

        // Fecha de nacimiento 
        private DateTime FechaNacimiento { get; set; } 
        
        // Nivel de fidelizacion entre 1 y 4
        public int NivelFidelizacion { get; set; }

        // Edad de la persona, la calculamos en el constructor
        public int Edad { get; set; } 

        // El tipo de usuario es huesped
        private string? TipoUsuario { get; set; }

        // CONSTRUCTORES 

        public Huesped(
            string mail,
            string password,
            string tipoDocumento,
            string numeroDocumento,
            string nombre,
            string apellido,
            string habitacion,
            string fechaNacimiento,
            int nivelFidelizacion
            )
            : base(mail, password)
        {   
           
            // Nombre y Apellidos no Vacios
            bool nombreApellidoOk = false;

            if (nombre != "" && apellido != "")
            {
                nombreApellidoOk = true;
            }

            if (!nombreApellidoOk)
            {
                Console.WriteLine("Nombre y Apellido no pueden ser campos vacíos");
            }

            // Verifico el tipo de Documento sea CI, PASAPORTE, OTROS
            bool tipoDocOk = false;
            
            // tipos documento válidos
            ArrayList tiposDocumentoValidos = new ArrayList();
            tiposDocumentoValidos.Add("CI");
            tiposDocumentoValidos.Add("PASAPORTE");
            tiposDocumentoValidos.Add("OTROS");

            // paso a mayuscula para comparar
            string tipoDocMayus = tipoDocumento.ToUpper();

            // reviso mi tipo doc perteneza a los aceptados
            int i = 0;

            while (i < tiposDocumentoValidos.Count && !tipoDocOk) 
            {
                if (tipoDocMayus.Equals(tiposDocumentoValidos[i]))
                {
                    tipoDocOk = true;
                }
                i++;
            }
            if (!tipoDocOk) 
            {
                Console.WriteLine("Tipo de Documento no Valido"); 
                Console.WriteLine("Solo son válidos CI, PASAPORTE, OTROS");
            }

            // Verifico que si el tipo de doc es CI, entonces sea una CI valida
            bool numeroCIOk = false;

            if (tipoDocMayus.Equals("CI"))
            {
                bool verificado = ValidarCi(numeroDocumento);

                if (verificado)
                {
                    numeroCIOk = true;
                } 
                else
                {
                    Console.WriteLine("Numero CI no válido");
                }
            }
            else
            {
                numeroCIOk = true;
            }

            // Calculo la edad del Huesped
            DateTime fechaNac = DateTime.Parse(fechaNacimiento);
            TimeSpan dias = DateTime.Now - fechaNac;
            int edad = (int)(dias.Days / 365.25);
            // Console.WriteLine(edad);

            // Creo la instancia de Huesped
            if (tipoDocOk && numeroCIOk && nombreApellidoOk)
            {   
                this.TipoDocumento = tipoDocMayus;
                this.NumeroDocumento = numeroDocumento;
                this.ParTipoNumeroDoc = tipoDocMayus + numeroDocumento;
                this.Nombre = nombre;
                this.Apellido = apellido;
                this.Habitacion = habitacion;
                this.FechaNacimiento = DateTime.Parse(fechaNacimiento);
                this.NivelFidelizacion = nivelFidelizacion;
                this.Edad = edad;
                this.TipoUsuario = "huesped";

                // Console.WriteLine("Huesped Registrado");
            }
            else 
            {
                Console.WriteLine("Huesped no registrado");
                Console.WriteLine(nombre);
            }
            
        }

        // METODOS

        public static bool VerificarCIUruguay(string ci)
        {
            // Verificar que la CI tenga 8 dígitos 
            if (ci.Length != 8)
            {
                return false;
            }

            // Convertir la CI a un arreglo de caracteres 
            char[] ciArray = ci.ToCharArray();

            // Obtener los primeros 7 dígitos de la CI 
            int[] digitos = new int[7];
            for (int i = 0; i < 7; i++)
            {
                digitos[i] = int.Parse(ciArray[i].ToString());
            }

            // Calcular la suma de los productos 
            int suma = 0;
            for (int i = 0; i < 7; i++)
            {
                suma += digitos[i] * (i == 6 ? 4 : (7 - i));
            }

            // Obtener el residuo de la división por 10 
            int residuo = suma % 10;

            // Obtener el octavo dígito de la CI 
            int digitoVerificador = int.Parse(ciArray[7].ToString());

            // Verificar si la CI es válida 
            return residuo == digitoVerificador;
        }

        // Metodo para validar digito verificador
        public int ObtengoDigitoValidador(int ci)
        {
            int a = 0;
            int i = 0;
            if (ci.ToString().Length <= 6)
            {
                for (i = ci.ToString().Length; i < 7; i++)
                {
                    ci = int.Parse("0" + ci.ToString());
                }
            }
            for (i = 0; i < 7; i++)
            {
                a += (int.Parse("2987634"[i].ToString()) * int.Parse(ci.ToString()[i].ToString())) % 10;
            }
            if (a % 10 == 0)
            {
                return 0;
            }
            else
            {
                return 10 - a % 10;
            }
        }

        // Metodo para limpiar puntos y guiones de la CI
        public int LimpiarCi(string ci)
        {
            return  int.Parse(ci.Replace("-", "").Replace(".", ""));
        }

        // Metodo para validar CI
        public bool ValidarCi(string ci)
        {
            int cin = LimpiarCi(ci);
            int dig = int.Parse(cin.ToString()[cin.ToString().Length - 1].ToString());
            return dig == ObtengoDigitoValidador(cin);
        }

        // Agendar Actividad

        public Agenda AgendarActividad()
        {
            return null;
        }

    }

}

