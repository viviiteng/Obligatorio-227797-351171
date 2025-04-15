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
            //sistema.PrecargarDatos();
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
                Console.WriteLine("5- Listado PRUEBAS.");
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

            Cliente clienteOcasional = new ClienteOcasional(cedula, nombre, correo, pass, nacionalidad, esClienteOcasional);
            sistema.AgregarNuevoCliente(clienteOcasional);
            Console.ReadKey();

        }

        public static void MostrarListaPasajesSegunFecha()
        {
            Console.Clear();
            Console.WriteLine("Ingrese fecha de emision del pasaje (AAAA/MM/DD):");
            DateTime fechaIngresada = new DateTime();

            bool esDateTime = false;
            while (!esDateTime)
            {
                bool esNumero = DateTime.TryParse(Console.ReadLine(), out fechaIngresada);
                if (esNumero)
                {
                    esDateTime = true;
                }
                else
                {
                    Console.WriteLine("Formato ingresado incorrecto");
                }
                sistema.FlitraPasajesSegunFecha(fechaIngresada);
            }
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
                Console.WriteLine("6- Listado de ");
                Console.WriteLine("7- Listado de .");
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
