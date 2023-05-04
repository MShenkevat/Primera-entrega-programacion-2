using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibClases
{
    public class Hotel
    {
        // LISTA ATRIBUTOS

        public List<ActividadPropia> ActividadesPropias = new List<ActividadPropia>();
        public List<ActividadTercerizada> ActividadesTercerizadas = new List<ActividadTercerizada>();
        private List<Agenda> Agendas = new List<Agenda>();
        private List<Huesped> Huespedes = new List<Huesped>();
        private List<Operador> Operadores = new List<Operador>();
        public List<Proveedor> Proveedores = new List<Proveedor>();

        // CONSTRUCTORES
        public Hotel()
        {
            Console.WriteLine("Bienvendio al Hostal Dickens");
          
            // Precargo datos Proveedores
            AltaProveedor(new Proveedor("DreamWorks S.R.L.", 23048549, "Suarez 3380 Apto 304", 10));
            AltaProveedor(new Proveedor("Estela Umpierrez S.A.", 33459678, "Lima 2456", 7));
            AltaProveedor(new Proveedor("TravelFun", 29152020, "Misiones 1140", 9));
            AltaProveedor(new Proveedor("Rekreation S.A.", 29162019, "Bacacay 1211", 11));
            AltaProveedor(new Proveedor("Alonso & Umpierrez", 24051920, "18 de Julio 1956 Apto 4", 10));
            AltaProveedor(new Proveedor("Electric Blue", 26018945, "Cooper 678", 5));
            AltaProveedor(new Proveedor("Lúdica S.A.", 26142967, "Dublin 560", 4));
            AltaProveedor(new Proveedor("Gimenez S.R.L.", 29001010, "Andes 1190", 7));
            AltaProveedor(new Proveedor("", 22041120, "Agraciada 2512 Apto. 1", 8));
            AltaProveedor(new Proveedor("Norberto Molina", 22001189, "Paraguay 2100", 9));
            // dan error
            AltaProveedor(new Proveedor("Norberto Molina", 885456, "Colonia 2100", 9));
        
            
            // Precargo Datos Actividades del Hostal
            AltaActividadHostal(new ActividadPropia("Paseo", "Paseo en bicicleta", "5/4/2025", 4, 10, "Pablo Guiterrez Animador del Hostal", true, 10));
            AltaActividadHostal(new ActividadPropia("Esquí", "Paseo en Esquí", "4/4/2025", 20, 18, "Pablo Guiterrez Animador del Hostal", true, 20));
            AltaActividadHostal(new ActividadPropia("Cabalgata", "Paseo en Caballo", "3/4/2025", 5, 18, "Pablo Guiterrez Animador del Hostal", true, 50));
            AltaActividadHostal(new ActividadPropia("Zumba", "Clase Zumba", "2/3/2025", 20, 15, "Pablo Guiterrez Animador del Hostal", false));
            AltaActividadHostal(new ActividadPropia("Sauna", "Uso del Sauna", "1/1/2024", 20, 17, "Pablo Agostini Encargado Sauna", false));
            AltaActividadHostal(new ActividadPropia("Crossfit", "Clase de Crossfit", "2/1/2025", 5, 15, "Daniel Perez Instructor", false, 10));
            AltaActividadHostal(new ActividadPropia("Teatro", "Obra de teatro", "6/4/2025", 50, 5, "Luis Trochon", false, 10));
            AltaActividadHostal(new ActividadPropia("Esgrima", "Clase de Esgrima", "8/1/2024", 6, 18, "Alejandro Lopez", false, 100));
            AltaActividadHostal(new ActividadPropia("Cocina contemporanea", "Clase de Cocina contemporanea", "9/2/2025", 9, 10, "Gato Dumas", false));
            AltaActividadHostal(new ActividadPropia("Cocina Oriental", "Clase de cocina de la India", "10/2/2025", 9, 10, "Gato Dumas", false));
            // dan error
            AltaActividadHostal(new ActividadPropia(
                "Actividad cuyo nombre tiene más de 25 caracteres y debería dar error",
                "da error",
                "10/2/2025",
                9,
                10,
                "Gato Dumas",
                false
                )
                );
            AltaActividadHostal(new ActividadPropia(
                "Actividad con fecha mal",
                "da error",
                "10/2/2022",
                9,
                10,
                "Gato Dumas",
                false
                )
                );
         



            // Precargo datos Actividades Tercerizadas
            AltaActividadTercerizada(new ActividadTercerizada("Excursión al volcán", "Visita guiada al volcán", "15/6/2024", 20, 18, "Norberto Molina", true, "15/6/2024", 30.5));
            AltaActividadTercerizada(new ActividadTercerizada("Cata de vinos", "Degustación de vinos de la región", "20/07/2023", 15, 21, "Estela Umpierrez S.A.", false, "20/07/2023", 25.0));
            AltaActividadTercerizada(new ActividadTercerizada("Tour en bicicleta", "Recorrido en bicicleta por el centro histórico", "5/8/2023", 10, 16, "Estela Umpierrez S.A.", true, "01/07/2023", 15.99));
            AltaActividadTercerizada(new ActividadTercerizada("Paseo en velero", "Navegación por la costa con guía experto", "30/07/2023", 8, 25, "Lúdica S.A.", false, "30/07/2023", 50.0));
            AltaActividadTercerizada(new ActividadTercerizada("Clase de surf", "Curso intensivo de surf con instructor profesional", "10/08/2023", 12, 18, "Electric Blue", true, "10/07/2023", 40.0));
            AltaActividadTercerizada(new ActividadTercerizada("Paintball", "Juego de equipos en el bosque", "15/06/2024", 20, 18, "DreamWorks S.R.L.", true, "15/06/2024", 25.0));
            AltaActividadTercerizada(new ActividadTercerizada("Tirolesa", "Deslizamiento en una cuerda sobre un bosque", "10/07/2024", 15, 12, "Rekreation S.A.", false, "10/07/2024", 12.5));
            AltaActividadTercerizada(new ActividadTercerizada("Bungee Jumping", "Salto desde un puente con una cuerda", "20/08/2024", 10, 21, "TravelFun", true, "20/08/2024", 45.0));
            AltaActividadTercerizada(new ActividadTercerizada("Vuelo en parapente", "Vuelo en parapente desde una montaña", "01/09/2024", 5, 16, "Gimenez S.R.L.", false, "01/09/2024", 75.0));
            AltaActividadTercerizada(new ActividadTercerizada("Kayak", "Paseo en kayak por un río", "15/06/2024", 8, 14, "Lúdica S.A.", true, "15/06/2024", 20.0));
            AltaActividadTercerizada(new ActividadTercerizada("Paseo en bote", "Paseo en bote por el mar", "10/07/2024", 12, 10, "DreamWorks S.R.L.", true, "10/07/2024", 30.0));
            AltaActividadTercerizada(new ActividadTercerizada("Paseo en cuatriciclo", "Paseo en cuatriciclo por las dunas", "20/08/2024", 6, 18, "Rekreation S.A.", false, "20/08/2024", 55.0));
            AltaActividadTercerizada(new ActividadTercerizada("Paseo en catamarán", "Paseo en catamarán por el río", "01/09/2024", 20, 16, "TravelFun", true, "01/09/2024", 40.0));
            AltaActividadTercerizada(new ActividadTercerizada("Senderismo", "Paseo por la montaña", "30/06/2024", 15, 12, "Gimenez S.R.L.", true, "30/06/2024", 15.0));
            AltaActividadTercerizada(new ActividadTercerizada("Paseo en velero", "Paseo en velero por el mar", "10/08/2023", 4, 21, "Lúdica S.A.", false, "10/08/2023", 100.0));


            // Precargo datos Huespedes
            AltaHuesped(new Huesped("juan@gmail.com", "1234567", "CI", "86073990", "Juan", "Perez", "101", "1/1/1990", 2));
            AltaHuesped(new Huesped("maria@hotmail.com", "7654321", "CI", "12777633", "Maria", "Garcia", "202", "20/5/1995", 3));
            AltaHuesped(new Huesped("pedro@yahoo.com", "qwertyu", "PASAPORTE", "AB123456", "Pedro", "Rodriguez", "303", "15/10/1988", 1));
            AltaHuesped(new Huesped("ana@gmail.com", "abcdefg", "CI", "81852418", "Ana", "Lopez", "404", "31/12/1998", 4));
            // da error
            AltaHuesped(new Huesped("ana@gmail.com", "abcdefg", "CI", "81852418", "Ana", "Lopez", "404", "31/12/1998", 4));
     
            // Precargo datos Operadores
            AltaOperador( new Operador("operador1@gmail.com", "password1"));
            AltaOperador( new Operador("operador2@gmail.com", "password2"));
            AltaOperador( new Operador("operador3@gmail.com", "password3"));
        }

        public void AltaProveedor(Proveedor proveedor)
        {   try
            {
                // Validar nombre proveedor es único
                string idNuevoProveedor = proveedor.Nombre;
                bool noRepetido = true;
                foreach (Proveedor unProveedor in Proveedores)
                {
                    if (unProveedor.Nombre.Equals(idNuevoProveedor))
                    {
                        noRepetido = false;
                    }
                }

                if (noRepetido)
                {
                    Proveedores.Add(proveedor);
                }
                else
                {
                    Console.WriteLine("Ya existe un Proveedor con ese Nombre");
                    Console.WriteLine(proveedor.Nombre);
                }
            }
            catch
            {
                throw;
            }   
        }

        public void AltaActividadHostal(ActividadPropia actividad)
        {
            try
            {
                ActividadesPropias.Add(actividad);
            }
            catch
            {
                throw;
            }
        }

        public void AltaActividadTercerizada(ActividadTercerizada actividad)
        {
            try
            {
                ActividadesTercerizadas.Add(actividad);
            }
            catch
            {
                throw;
            }
        }

        public void AltaHuesped(Huesped huesped)
        {
            try
            {
                // Verifico que el par tipo documento y numero documento sea único

                string idNuevoHuesped = huesped.ParTipoNumeroDoc;
                bool noRepetido = true;
                foreach (Huesped hospedado in Huespedes)
                {
                    if (idNuevoHuesped.Equals(hospedado.ParTipoNumeroDoc))
                    {
                        noRepetido = false;
                    }  
                }

                if (noRepetido)
                {
                    Huespedes.Add(huesped);
                }
                else
                {
                    Console.WriteLine("Ya existe un Huesped con este documento");
                }
            }
            catch
            {
                throw;
            }
            
        }

        public void AltaOperador(Operador operador)
        {
            try
            {
                Operadores.Add(operador);
            }
            catch
            {
                throw;
            }
        }
    }
}
