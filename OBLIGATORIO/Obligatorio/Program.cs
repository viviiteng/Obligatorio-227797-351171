using Dominio;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Obligatorio
{
    internal class Program
    {
        private static Sistema sistema = new Sistema();
        static void Main(string[] args)
        {
            try
            {
                sistema.PrecargarDatos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("Bienvenidos a ORT airlines");
                Console.WriteLine("Ingrese el numero corresponiente para las siguientes opciones:");

                Console.WriteLine("1- Listado de clientes.");
                Console.WriteLine("2- Listado de vuelos.");
                Console.WriteLine("3- Alta de cliente ocasional.");
                Console.WriteLine("4- Listado de pasajes emitidos.");
                Console.WriteLine("5- Emitir pasaje");
                Console.WriteLine("6- ");
                Console.WriteLine("7- ");
                Console.WriteLine("8- ");
                Console.WriteLine("9- Consulta de listas.");
                Console.WriteLine("0- Salir");

                string opcionIngresada = Console.ReadLine();
                switch (opcionIngresada)
                {
                    case "1":
                        foreach (Cliente unCliente in sistema.Clientes)
                        {
                            Console.WriteLine(unCliente);
                        }
                        Console.ReadKey(); 

                        break;
                    case "2":
                        MostrarListaVuelosSegunCodigo();
                        break;
                    case "3":
                        IngresarClienteOcasional();
                        break;
                    case "4":
                        MostrarListaPasajesSegunFecha();
                        break;
                    case "5":
                        EmitirNuevoPasaje();
                        break;
                    case "6":

                        break;
                    case "7":

                        break;
                    case "8":

                        break;
                    case "9":
                        ListarPruebas();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        break;
                }

            }




        }
        //metodod polimorfico?
        public static void MostrarListaDeClientes()
        {


        }

        public static void MostrarListaVuelosSegunCodigo()
        {
            Console.Clear();
            Console.WriteLine("Ingrese un codigo IATA:");
            string codigoIngresado = Console.ReadLine();
            List<Vuelo> listaFiltrada = sistema.ListarVueloSegunIATA(codigoIngresado);

            foreach (Vuelo unVuelo in listaFiltrada)
            {
                Console.WriteLine(unVuelo);
            }
            Console.ReadKey();

        }

        public static void IngresarClienteOcasional()
        {
            Console.Clear();
            Console.WriteLine("Alta de cliente ocasional.");
            Console.WriteLine("");
            Console.WriteLine("Ingrese numero de cedula (sin punto ni guion):");
            string cedula = Console.ReadLine();

            Console.WriteLine("Ingrese nombre completo:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese correo electroinico:");
            string correo = Console.ReadLine();

            Console.WriteLine("Ingrese contraseña:");
            string pass = Console.ReadLine();

            Console.WriteLine("Ingrese nacionalidad:");
            string nacionalidad = Console.ReadLine();

            bool esClienteOcasional = sistema.GenerarBoolRandom();

            try
            {
                Cliente clienteOcasional = new ClienteOcasional(cedula, nombre, correo, pass, nacionalidad, esClienteOcasional);
                sistema.AgregarNuevoCliente(clienteOcasional);

            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }
            Console.ReadKey();

        }

        public static void MostrarListaPasajesSegunFecha()
        {
            Console.Clear();

            Console.WriteLine("Buscar pasaje dentro de un rango de fechas:");
            Console.WriteLine("Ingrese fecha inicial (AAAA/MM/DD):");
            DateTime fechaIngresadaUno = new DateTime();
            DateTime fechaIngresadaDos = new DateTime();

            bool esDateTime = false;
            while (!esDateTime)
            {
                bool esFechaUno = DateTime.TryParse(Console.ReadLine(), out fechaIngresadaUno);

                Console.WriteLine("Ingrese fecha final (AAAA/MM/DD):");
                bool esFechaDos = DateTime.TryParse(Console.ReadLine(), out fechaIngresadaDos);
                if (esFechaUno && esFechaDos)
                {
                    esDateTime = true;
                }
                else
                {
                    Console.WriteLine("Formato ingresado incorrecto");
                }
                
            }
            List<Pasaje> pasajesFiltrados = new List<Pasaje>();
            pasajesFiltrados = sistema.FlitraPasajesSegunFechas(fechaIngresadaUno, fechaIngresadaDos);
            Console.WriteLine($"Pasajes comprendidos entre {fechaIngresadaUno.ToString("dd/MM/yyyy")} - {fechaIngresadaDos.ToString("dd/MM/yyyy")}:");
            foreach (Pasaje unPasaje in pasajesFiltrados)
            {
                Console.WriteLine(unPasaje);
            }
            Console.ReadKey();

        }

        public static void MostrarListaFiltradaAeropuertos()
        {
            Console.Clear();
            Console.WriteLine("Ingrese un codigo de aeropuerto que desee filtrar:");
            string codigoIngresado = Console.ReadLine().ToUpper();
            try
            {


                //sistema.FiltrarListaAeropuertos(codigoIngresado);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            Console.ReadKey();
        }

        public static void EmitirNuevoPasaje()
        {
            Console.Clear();
            Console.WriteLine("Emitir nuevo pasaje:");
            
            bool salir = false;
            while (!salir) {
                Console.WriteLine($"Ingrese un numero del 1 al {sistema.Vuelos.Count} para seleccionar un vuelo:");
                for (int i = 0; i < sistema.Vuelos.Count; i++)
                {
                    Vuelo unVuelo = sistema.Vuelos[i];
                    Console.WriteLine($"{i + 1}. {unVuelo.NumVuelo}: Origen: {unVuelo.Ruta.AeropuertoSalida.Ciudad}, Destino: {unVuelo.Ruta.AeropuertoLlegada.Ciudad}");
              
                }                
                bool esNum = int.TryParse(Console.ReadLine(), out int opcionIngresada);
                Vuelo vueloSeleccionado = sistema.Vuelos[opcionIngresada - 1];

                Console.WriteLine($"Ingrese una fecha (AAAA/MM/DD):");
                bool esDateTime = false;
                DateTime fechaIngresada = new DateTime();
                while (!esDateTime)
                {
                    bool esFecha = DateTime.TryParse(Console.ReadLine(), out fechaIngresada);
                    if (esFecha)
                    {
                        esDateTime = true;
                    }
                    else
                    {
                        Console.WriteLine("Formato ingresado incorrecto. Vuelve a internarlo.");
                    }

                }
                Pasaje.ValidarFecha();


                if (esNum && esDateTime) { 

                Pasaje nuevoPasaje = new Pasaje(vueloSeleccionado, fechaIngresada, sistema.Clientes[0], TipoEquipaje equipaje, double precioPasaje);
                sistema.AgregarNuevoPasaje(nuevoPasaje);
                }
                Console.ReadKey();
                

            }
        }

        public static void ListarPruebas()
        {

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("1- Listado de Administradores.");
                Console.WriteLine("2- Listado de Aeropuertos.");
                Console.WriteLine("3- Listado de Aviones.");
                Console.WriteLine("4- Listado de Rutas.");
                Console.WriteLine("5- Listado de Vuelos.");
                Console.WriteLine("6- Listado de Clientes.");
                Console.WriteLine("7- Listado de Pasajes.");
                Console.WriteLine("8- Listado de .");
                Console.WriteLine("9- Listado de .");
                Console.WriteLine("0- Salir");

                string opcionIngresada = Console.ReadLine();
                switch (opcionIngresada)
                {
                    case "1":

                        foreach (Administrador unAdmin in sistema.Administradores)
                        {
                            Console.WriteLine(unAdmin);
                        }
                        Console.ReadKey();

                        break;
                    case "2":
                        foreach (Aeropuerto unAeropuerto in sistema.Aeropuertos)
                        {
                            Console.WriteLine(unAeropuerto);
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        foreach (Avion unAvion in sistema.Aviones)
                        {
                            Console.WriteLine(unAvion);
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        foreach (Ruta unaRuta in sistema.Rutas)
                        {
                            Console.WriteLine(unaRuta);
                        }
                        Console.ReadKey();
                        break;
                    case "5":
                        foreach (Vuelo unVuelo in sistema.Vuelos)
                        {
                            Console.WriteLine(unVuelo);
                        }
                        Console.ReadKey();
                        break;
                    case "6":
                        foreach (Cliente unCliente in sistema.Clientes)
                        {
                            Console.WriteLine(unCliente);
                        }
                        Console.ReadKey();
                        break;
                    case "7":
                        foreach (Pasaje unPasaje in sistema.Pasajes)
                        {
                            Console.WriteLine(unPasaje);
                        }
                        Console.ReadKey();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        break;
                       
                }

                
            }
        }
    }
}
