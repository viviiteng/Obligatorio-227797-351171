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
                //Console.WriteLine("4- Listado de pasajes emitidos.");
                Console.WriteLine("4- Listado PRUEBAS.");
                Console.WriteLine("0- Salir");

                string opcionIngresada = Console.ReadLine();
                switch (opcionIngresada)
                {
                    case "1":
                        ListarTodosLosClientes();

                        break;
                    case "2":
                        MostrarListaFiltradaAeropuertos();
                        break;
                    case "3":

                        break;
                    case "4":
                        ListarPruebas();
                        break;
                    case "5":
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
        public static void ListarTodosLosClientes()
        {

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
            catch(Exception error)
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
                Console.WriteLine("4- Listado de .");
                Console.WriteLine("5- Listado de .");
                Console.WriteLine("6- Listado de .");
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

                        break;
                    case "5":
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
