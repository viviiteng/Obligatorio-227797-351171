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
                Console.ReadKey();
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
                Console.WriteLine("9- Consulta de listas.");
                Console.WriteLine("0- Salir");

                string opcionIngresada = Console.ReadLine();
                switch (opcionIngresada)
                {
                    case "1":
                        MostrarListaDeClientes();
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
                    case "9":
                        ListarPruebas();
                        break;
                    case "0":
                        salir = true;
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Error: Ingrese un valor del 0 al 5.");
                        Console.WriteLine("Presione cualquier tecla para intentarlo de nuevo...");
                        Console.ReadKey();
                        break;
                }

            }
        }
        public static void MostrarListaDeClientes()
        {
            Console.Clear();
            Console.WriteLine("Clientes Registrados:\n");
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                clientes = sistema.ObtenerListadoDeClientes();
                foreach (Cliente unCliente in clientes)
                {
                    Console.WriteLine(unCliente.ObtenerDatosUsuario());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPresione cualquier tecla para volver...");
            Console.ReadKey();

        }

        public static void MostrarListaVuelosSegunCodigo()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("Ingrese un codigo IATA:\n");
                string codigoIngresado = Console.ReadLine();
                List<Vuelo> listaFiltrada = new List<Vuelo>();
                try
                {
                    listaFiltrada = sistema.ListarVueloSegunIATA(codigoIngresado);
                    foreach (Vuelo unVuelo in listaFiltrada)
                    {
                        Console.WriteLine(unVuelo);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    salir = true;
                }

                Console.WriteLine("\nPresione cualquier tecla para volver...");
                Console.ReadKey();
            }
        }

        public static void IngresarClienteOcasional()
        {
            Console.Clear();
            Console.WriteLine("Alta de cliente ocasional.\n");
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

            bool esElegibleRegalo = sistema.GenerarBoolRandom();

            try
            {
                Usuario clienteOcasional = new ClienteOcasional(cedula, nombre, correo, pass, nacionalidad, esElegibleRegalo);
                sistema.AgregarNuevoUsuario(clienteOcasional);
                Console.WriteLine("Cliente creado exitosamente. Presione cualquier tecla para volver...");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            Console.WriteLine("\nPresione cualquier tecla para volver...");

            Console.ReadKey();
        }

        public static void MostrarListaPasajesSegunFecha()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();

                Console.WriteLine("Buscar pasaje dentro de un rango de fechas:\n");

                DateTime fechaIngresadaUno = new DateTime();
                DateTime fechaIngresadaDos = new DateTime();


                Console.WriteLine("Ingrese fecha inicial (AAAA/MM/DD):");
                bool esFechaUno = DateTime.TryParse(Console.ReadLine(), out fechaIngresadaUno);

                Console.WriteLine("Ingrese fecha final (AAAA/MM/DD):");
                bool esFechaDos = DateTime.TryParse(Console.ReadLine(), out fechaIngresadaDos);
                if (esFechaUno && esFechaDos)
                {

                    salir = true;
                    List<Pasaje> pasajesFiltrados = new List<Pasaje>();
                    try
                    {

                        pasajesFiltrados = sistema.FlitrarPasajesSegunFechas(fechaIngresadaUno, fechaIngresadaDos);
                        Console.WriteLine($"\nPasajes comprendidos entre {fechaIngresadaUno.ToString("dd/MM/yyyy")} - {fechaIngresadaDos.ToString("dd/MM/yyyy")}:\n");
                        foreach (Pasaje unPasaje in pasajesFiltrados)
                        {
                            Console.WriteLine(unPasaje);
                        }
                        Console.WriteLine("\nPresiones cualquier tecla para volver...");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        salir = false;
                        Console.ReadKey();
                    }


                }
                else
                {
                    Console.WriteLine("Formato ingresado incorrecto. Presione cualquier tecla para intentarlo de nuevo...");
                    Console.ReadKey();
                }
            }
        }

        public static void EmitirNuevoPasaje()
        {
            Console.Clear();
            Console.WriteLine("Emitir nuevo pasaje:\n");
            Vuelo vueloSeleccionado = null;
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine($"Ingrese un numero del 1 al {sistema.Vuelos.Count} para seleccionar un vuelo:");
                for (int i = 0; i < sistema.Vuelos.Count; i++)
                {
                    Vuelo unVuelo = sistema.Vuelos[i];
                    Console.WriteLine($"{i + 1}. {unVuelo.NumVuelo}: Origen: {unVuelo.Ruta.AeropuertoSalida.Ciudad}, Destino: {unVuelo.Ruta.AeropuertoLlegada.Ciudad}");

                }
                bool esNum = int.TryParse(Console.ReadLine(), out int opcionIngresada);
                vueloSeleccionado = sistema.Vuelos[opcionIngresada - 1];
                if (opcionIngresada > 0 && opcionIngresada < sistema.Vuelos.Count)
                {
                    salir = true;
                }
                else
                {
                    Console.WriteLine("\n Ingrese un numero dentro del rango. Vuelve a intentarlo.");
                }
            }

            bool esDateTime = false;
            DateTime fechaIngresada = new DateTime();
            while (!esDateTime)
            {
                Console.WriteLine($"Ingrese una fecha (AAAA/MM/DD):");
                bool esFecha = DateTime.TryParse(Console.ReadLine(), out fechaIngresada);
                if (esFecha)
                {
                    esDateTime = true;
                }
                else
                {
                    Console.WriteLine("\n Formato ingresado incorrecto. Vuelve a intentarlo.");
                }
            }

            Console.WriteLine($"Ingrese un numero del 1 al 3 para seleccionar un tipo de equipaje:");

            TipoEquipaje[] equipajes = (TipoEquipaje[])Enum.GetValues(typeof(TipoEquipaje));

            for (int i = 0; i < equipajes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {equipajes[i]}");
            }
            bool esNumEquipaje = false;
            int equipajeIngresado;
            TipoEquipaje equipajeSeleccionado = 0;
            while (!esNumEquipaje)
            {
                bool esNumero = int.TryParse(Console.ReadLine(), out equipajeIngresado);
                if (esNumero && equipajeIngresado > 0 && equipajeIngresado <= 3)
                {
                    equipajeSeleccionado = equipajes[equipajeIngresado - 1];
                    esNumEquipaje = true;
                    Console.WriteLine(equipajeSeleccionado);
                }
                else
                {
                    Console.WriteLine("\n Formato ingresado incorrecto. Vuelve a internarlo.");
                }
            }

            try
            {
                Pasaje nuevoPasaje = new Pasaje(vueloSeleccionado, fechaIngresada, sistema.Usuarios[0], equipajeSeleccionado, 15000);   
                
                sistema.AgregarNuevoPasaje(nuevoPasaje);
                Console.WriteLine("Pasaje emitido exitosamente.");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("Presiones cualquier tecla para volver.\n");
            Console.ReadKey();
        }

        //----------------------BORRAR VV
        public static void ListarPruebas()
        {

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("1- Listado de Usuarios.");
                Console.WriteLine("2- Listado de Aeropuertos.");
                Console.WriteLine("3- Listado de Aviones.");
                Console.WriteLine("4- Listado de Rutas.");
                Console.WriteLine("5- Listado de Vuelos.");
                Console.WriteLine("6- Listado de Pasajes.");
                Console.WriteLine("7- Listado de Clientes.");
                Console.WriteLine("8- Listado de .");
                Console.WriteLine("0- Salir");

                string opcionIngresada = Console.ReadLine();
                switch (opcionIngresada)
                {
                    case "1":

                        foreach (Usuario unUsuario in sistema.Usuarios)
                        {
                            Console.WriteLine(unUsuario);
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
