using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using Dominio.comparer;

namespace Dominio
{
    public class Sistema
    {
        private static Sistema instancia;
        public static Sistema ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }
        #region Atributos   
        private List<Usuario> Usuarios { get; set; }
        private List<Pasaje> pasajes { get; set; }
        private List<Vuelo> Vuelos { get; set; }
        private List<Ruta> Rutas { get; set; }
        private List<Avion> Aviones { get; set; }
        private List<Aeropuerto> Aeropuertos { get; set; }
        #endregion

        #region Constructor      
        public Sistema()
        {
            Usuarios = new List<Usuario>();
            Aviones = new List<Avion>();
            Aeropuertos = new List<Aeropuerto>();
            Rutas = new List<Ruta>();
            pasajes = new List<Pasaje>();
            Vuelos = new List<Vuelo>();
            precargarDatos();
        }
        #endregion

        #region Metodos


        #region Precargas
        private void precargarDatos()
        {
            precargarUsuarios();
            precargarAviones();
            precargaAeropuertos();
            precargarRutas();
            precargarVuelos();
            precagarPasajes();
        }
        private void precargarUsuarios()
        {
            AgregarNuevoUsuario(new ClientePremium("12345678", "Martín Pérez", "martin.perez@gmail.com", "pass1234", "Uruguaya", 1500));
            AgregarNuevoUsuario(new ClientePremium("23456789", "Laura Gómez", "laura.gomez@hotmail.com", "laura456", "Argentina", 3200));
            AgregarNuevoUsuario(new ClientePremium("34567890", "Carlos Silva", "carlos.silva@yahoo.com", "silva2023", "Chilena", 2100));
            AgregarNuevoUsuario(new ClientePremium("45678901", "Ana Torres", "ana.torres@gmail.com", "torres321", "Uruguaya", 2750));
            AgregarNuevoUsuario(new ClientePremium("56789012", "Diego Fernández", "diego.fernandez@outlook.com", "dfpass789", "Brasilera", 3900));

            AgregarNuevoUsuario(new ClienteOcasional("67890123", "Valentina Suárez", "valesuarez@gmail.com", "vale1234", "Paraguaya"));
            AgregarNuevoUsuario(new ClienteOcasional("78901234", "Rodrigo López", "rodrilopez@hotmail.com", "rodri456", "Uruguaya"));
            AgregarNuevoUsuario(new ClienteOcasional("89012345", "María Rivas", "maria.rivas@yahoo.com", "rivas789", "Peruana"));
            AgregarNuevoUsuario(new ClienteOcasional("90123456", "Nicolás Méndez", "nico.mendez@gmail.com", "nicolas321", "Colombiana"));
            AgregarNuevoUsuario(new ClienteOcasional("01234567", "Lucía Figueroa", "lucia.fig@outlook.com", "figpass852", "Boliviana"));

            AgregarNuevoUsuario(new Administrador("Agustin", "agustin@gmail.com", "admin1234"));
            AgregarNuevoUsuario(new Administrador("Viviana", "viviana@gmail.com", "admin4321"));
        }
        private void precargarAviones()
        {
            AgregarNuevoAvion(new Avion("Boeing", "737 MAX", 178, 16000.0, 20.00));
            AgregarNuevoAvion(new Avion("Airbus", "A320neo", 180, 16500.0, 7.00));
            AgregarNuevoAvion(new Avion("Embraer", "E195-E2", 132, 17200.0, 4.50));
            AgregarNuevoAvion(new Avion("Bombardier", "CRJ900", 90, 16300.0, 3.3));

        }
        private void precargaAeropuertos()
        {
            AgregarNuevoAeropuerto(new Aeropuerto("MVD", "Montevideo", 1200.50, 300.75));
            AgregarNuevoAeropuerto(new Aeropuerto("SCL", "Santiago", 1350.00, 280.40));
            AgregarNuevoAeropuerto(new Aeropuerto("EZE", "Buenos Aires", 1450.25, 310.00));
            AgregarNuevoAeropuerto(new Aeropuerto("GRU", "São Paulo", 1600.00, 330.80));
            AgregarNuevoAeropuerto(new Aeropuerto("JFK", "Nueva York", 2000.75, 400.00));
            AgregarNuevoAeropuerto(new Aeropuerto("LAX", "Los Ángeles", 1950.60, 390.20));
            AgregarNuevoAeropuerto(new Aeropuerto("CDG", "París", 2100.80, 420.35));
            AgregarNuevoAeropuerto(new Aeropuerto("LHR", "Londres", 2150.30, 410.90));
            AgregarNuevoAeropuerto(new Aeropuerto("MAD", "Madrid", 1750.40, 370.00));
            AgregarNuevoAeropuerto(new Aeropuerto("FRA", "Frankfurt", 1850.75, 385.60));
            AgregarNuevoAeropuerto(new Aeropuerto("AMS", "Ámsterdam", 1780.20, 365.10));
            AgregarNuevoAeropuerto(new Aeropuerto("BCN", "Barcelona", 1700.00, 355.00));
            AgregarNuevoAeropuerto(new Aeropuerto("MIA", "Miami", 1900.25, 395.75));
            AgregarNuevoAeropuerto(new Aeropuerto("YYZ", "Toronto", 1800.50, 370.20));
            AgregarNuevoAeropuerto(new Aeropuerto("NRT", "Tokio", 2200.60, 430.45));
            AgregarNuevoAeropuerto(new Aeropuerto("SYD", "Sídney", 2300.10, 440.00));
            AgregarNuevoAeropuerto(new Aeropuerto("DXB", "Dubái", 2250.30, 425.90));
            AgregarNuevoAeropuerto(new Aeropuerto("DOH", "Doha", 2150.80, 415.60));
            AgregarNuevoAeropuerto(new Aeropuerto("LIM", "Lima", 1400.00, 290.00));
            AgregarNuevoAeropuerto(new Aeropuerto("BOG", "Bogotá", 1380.90, 295.50));
        }
        private void precargarRutas()
        {        
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MVD"), obtenerAeropuertoSegunIATA("SCL"), 1370.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MVD"), obtenerAeropuertoSegunIATA("EZE"), 205.0));    
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("SCL"), obtenerAeropuertoSegunIATA("GRU"), 2615.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("EZE"), obtenerAeropuertoSegunIATA("JFK"), 8520.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("GRU"), obtenerAeropuertoSegunIATA("LAX"), 9900.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("JFK"), obtenerAeropuertoSegunIATA("CDG"), 5840.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LAX"), obtenerAeropuertoSegunIATA("LHR"), 8755.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("CDG"), obtenerAeropuertoSegunIATA("MAD"), 1050.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LHR"), obtenerAeropuertoSegunIATA("FRA"), 655.0));    
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MAD"), obtenerAeropuertoSegunIATA("AMS"), 1480.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("FRA"), obtenerAeropuertoSegunIATA("BCN"), 1135.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("AMS"), obtenerAeropuertoSegunIATA("MIA"), 7470.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("BCN"), obtenerAeropuertoSegunIATA("YYZ"), 6360.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MIA"), obtenerAeropuertoSegunIATA("NRT"), 11750.0));  
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("YYZ"), obtenerAeropuertoSegunIATA("SYD"), 15500.0));  
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("NRT"), obtenerAeropuertoSegunIATA("DXB"), 7930.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("SYD"), obtenerAeropuertoSegunIATA("DOH"), 12140.0));  
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("DXB"), obtenerAeropuertoSegunIATA("LIM"), 14560.0));  
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("DOH"), obtenerAeropuertoSegunIATA("BOG"), 13470.0));  
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("SCL"), obtenerAeropuertoSegunIATA("MVD"), 1370.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("JFK"), obtenerAeropuertoSegunIATA("MVD"), 8480.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("GRU"), obtenerAeropuertoSegunIATA("CDG"), 8750.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LAX"), obtenerAeropuertoSegunIATA("EZE"), 9860.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("CDG"), obtenerAeropuertoSegunIATA("MVD"), 10830.0));  
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LHR"), obtenerAeropuertoSegunIATA("LAX"), 8755.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MAD"), obtenerAeropuertoSegunIATA("GRU"), 8180.0));   
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("FRA"), obtenerAeropuertoSegunIATA("EZE"), 11330.0));  
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("AMS"), obtenerAeropuertoSegunIATA("MVD"), 11370.0));  
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("BCN"), obtenerAeropuertoSegunIATA("NRT"), 10790.0));  
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LIM"), obtenerAeropuertoSegunIATA("MVD"), 3130.0));   
        }
        private void precargarVuelos()
        {
            AgregarNuevoVuelo(new Vuelo("AR101", obtenerRutaSegunId(0), obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("UX309", obtenerRutaSegunId(2), obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AF450", obtenerRutaSegunId(3), obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.jueves, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("IB333", obtenerRutaSegunId(4), obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.martes }));
            AgregarNuevoVuelo(new Vuelo("DL220", obtenerRutaSegunId(5), obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.viernes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("UA875", obtenerRutaSegunId(6), obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.jueves, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("LA203", obtenerRutaSegunId(1), obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.martes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("LH708", obtenerRutaSegunId(7), obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("KL110", obtenerRutaSegunId(8), obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.martes, Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("AZ556", obtenerRutaSegunId(9), obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("AC990", obtenerRutaSegunId(10), obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("JJ777", obtenerRutaSegunId(11), obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("NH852", obtenerRutaSegunId(12), obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.martes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("QF908", obtenerRutaSegunId(13), obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.lunes }));
            AgregarNuevoVuelo(new Vuelo("EK202", obtenerRutaSegunId(14), obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("QR118", obtenerRutaSegunId(15), obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("LA515", obtenerRutaSegunId(16), obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.viernes, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AV300", obtenerRutaSegunId(17), obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.lunes }));
            AgregarNuevoVuelo(new Vuelo("AR132", obtenerRutaSegunId(18), obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.martes }));
            AgregarNuevoVuelo(new Vuelo("IB440", obtenerRutaSegunId(19), obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("DL155", obtenerRutaSegunId(20), obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("AF621", obtenerRutaSegunId(21), obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.jueves, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("KL205", obtenerRutaSegunId(22), obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("BA775", obtenerRutaSegunId(23), obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.martes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("JJ803", obtenerRutaSegunId(24), obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AZ313", obtenerRutaSegunId(25), obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("AC499", obtenerRutaSegunId(26), obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("NH404", obtenerRutaSegunId(27), obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("QF878", obtenerRutaSegunId(28), obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.martes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("EK301", obtenerRutaSegunId(29), obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.domingo, Frecuencia.jueves }));
        }
        private void precagarPasajes()
        {
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("UX309"), new DateTime(2025, 5, 11), obtenerClienteSegunCedula("67890123"), TipoEquipaje.LIGHT));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("AR101"), new DateTime(2025, 5, 5), obtenerClienteSegunCedula("12345678"), TipoEquipaje.CABINA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("AF450"), new DateTime(2025, 5, 8), obtenerClienteSegunCedula("23456789"), TipoEquipaje.BODEGA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("IB333"), new DateTime(2025, 5, 13), obtenerClienteSegunCedula("78901234"), TipoEquipaje.CABINA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("DL220"), new DateTime(2025, 5, 16), obtenerClienteSegunCedula("34567890"), TipoEquipaje.LIGHT));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("UA875"), new DateTime(2025, 5, 16), obtenerClienteSegunCedula("89012345"), TipoEquipaje.BODEGA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("LA203"), new DateTime(2025, 5, 17), obtenerClienteSegunCedula("45678901"), TipoEquipaje.CABINA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("LH708"), new DateTime(2025, 5, 14), obtenerClienteSegunCedula("90123456"), TipoEquipaje.LIGHT));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("KL110"), new DateTime(2025, 5, 19), obtenerClienteSegunCedula("56789012"), TipoEquipaje.BODEGA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("AZ556"), new DateTime(2025, 5, 17), obtenerClienteSegunCedula("90123456"), TipoEquipaje.CABINA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("AC990"), new DateTime(2025, 5, 18), obtenerClienteSegunCedula("12345678"), TipoEquipaje.LIGHT));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("JJ777"), new DateTime(2025, 5, 21), obtenerClienteSegunCedula("67890123"), TipoEquipaje.BODEGA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("NH852"), new DateTime(2025, 5, 23), obtenerClienteSegunCedula("23456789"), TipoEquipaje.CABINA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("QF908"), new DateTime(2025, 5, 26), obtenerClienteSegunCedula("78901234"), TipoEquipaje.LIGHT));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("EK202"), new DateTime(2025, 5, 24), obtenerClienteSegunCedula("34567890"), TipoEquipaje.BODEGA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("QR118"), new DateTime(2025, 5, 22), obtenerClienteSegunCedula("89012345"), TipoEquipaje.CABINA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("LA515"), new DateTime(2025, 5, 25), obtenerClienteSegunCedula("45678901"), TipoEquipaje.LIGHT));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("AV300"), new DateTime(2025, 5, 26), obtenerClienteSegunCedula("90123456"), TipoEquipaje.BODEGA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("AR132"), new DateTime(2025, 5, 27), obtenerClienteSegunCedula("56789012"), TipoEquipaje.CABINA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("IB440"), new DateTime(2025, 5, 31), obtenerClienteSegunCedula("90123456"), TipoEquipaje.LIGHT));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("DL155"), new DateTime(2025, 6, 2), obtenerClienteSegunCedula("12345678"), TipoEquipaje.BODEGA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("AF621"), new DateTime(2025, 6, 1), obtenerClienteSegunCedula("67890123"), TipoEquipaje.CABINA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("KL205"), new DateTime(2025, 6, 7), obtenerClienteSegunCedula("23456789"), TipoEquipaje.LIGHT));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("BA775"), new DateTime(2025, 6, 3), obtenerClienteSegunCedula("78901234"), TipoEquipaje.BODEGA));
            AgregarNuevoPasaje(new Pasaje(ObtenerVueloSegunNumVuelo("JJ803"), new DateTime(2025, 6, 8), obtenerClienteSegunCedula("34567890"), TipoEquipaje.CABINA));
        }

        #endregion

        #region Usuario
        public void AgregarNuevoUsuario(Usuario unUsuario)
        {
            unUsuario.Validar();
            validarExistenciaUsuario(unUsuario);
            this.Usuarios.Add(unUsuario);
        }
        private void validarExistenciaUsuario(Usuario unUsuario)
        {
            if (Usuarios.Contains(unUsuario))
            {
                throw new Exception("El usuario ya existe.");
            }
        }

        public Usuario? ObtenerUsuarioSegunCorreo(string correo)
        {
            foreach (Usuario unUsuario in this.Usuarios)
            {
                if (correo == unUsuario.Correo)
                {
                    return unUsuario;
                }
            }
            return null;
        }


        public Cliente? ObtenerClienteSegunCorreo(string correo)
        {
            foreach (Usuario unUsuario in this.Usuarios)
            {
                if (unUsuario.Correo == correo)
                {
                    if(unUsuario is Cliente unCliente)
                    { 
                        return unCliente;
                    }
                    else
                    {
                        throw new Exception("Este usuario no es un cliente");
                    }
                }
            }
            return null;
        }

        public void ModificarCliente(ClienteOcasional clienteOcasionalExt)
        {
            Cliente unCliente = this.ObtenerClienteSegunCorreo(clienteOcasionalExt.Correo);
            if (unCliente is ClienteOcasional clienteOcasional)
            {
                if (clienteOcasional.EsElegibleRegalo)
                {
                    clienteOcasional.EsElegibleRegalo = false;
                }
                else
                {
                    clienteOcasional.EsElegibleRegalo = true;
                }
            }   
        }


        public void ModificarCliente(ClientePremium clientePremiumExt)
        {
            if (clientePremiumExt.PuntosAcumulados >= 0) { 
                Cliente unCliente = this.ObtenerClienteSegunCorreo(clientePremiumExt.Correo);

                if (unCliente is ClientePremium clientePremium) {

                clientePremium.PuntosAcumulados = clientePremiumExt.PuntosAcumulados;

                }
            }
            else 
            { 
                throw new Exception("Error: No se puede ingresar puntos menores a 0.");
            }

        }

        public List<Cliente> ObtenerListadoDeClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            foreach (Usuario unUsuario in this.Usuarios)
            {
                if (unUsuario is Cliente unCliente)
                {
                    clientes.Add(unCliente);
                }
            }
            return clientes;
        }
        private Cliente obtenerClienteSegunCedula(string cedula)
        {
            List<Cliente> clientes = ObtenerListadoDeClientes();
            foreach (Cliente unCliente in clientes)
            {
                if (unCliente.Cedula == cedula)
                {
                    return unCliente;
                }
            }
            throw new Exception($"Error: No existe un cliente con cedula [{cedula}]");
        }
        public void ValidarPassDeUsuario(Usuario unUsuario, string pass)
        {
            if (unUsuario==null || pass != unUsuario.Pass) { 
            throw new Exception("Error: Usuario o contraseña inválido");
            }
        }
        #endregion

        #region Pasaje
        public void AgregarNuevoPasaje(Pasaje unPasaje)
        {
            unPasaje.Validar();
            validarExistenciaPasaje(unPasaje);
            pasajes.Add(unPasaje);
        }

        private void validarExistenciaPasaje(Pasaje unPasaje)
        {
            if (pasajes.Contains(unPasaje))
            {
                throw new Exception("Error: El pasaje ingresado ya existe.");
            }
        }
        public List<Pasaje> FlitrarPasajesSegunFechas(DateTime fechaUno, DateTime fechaDos)
        {
            List<Pasaje> listaSegunFecha = new List<Pasaje>();

            if (fechaUno > fechaDos)
            {
                throw new Exception("Error: la fecha final debe ser mayor o igual a inicial. Intente de nuevo...");
            }

            foreach (Pasaje unPasaje in pasajes)
            {
                if (fechaUno <= unPasaje.FechaDeVuelo && fechaDos >= unPasaje.FechaDeVuelo)
                {
                    listaSegunFecha.Add(unPasaje);
                }
            }
            return listaSegunFecha;
        }


        public List<Pasaje> ObtenerListadoPasajesSegunUsuario(Usuario unUsuario)
        {
            List<Pasaje> pasajesUsuario = new List<Pasaje>();

            foreach (Pasaje unPasaje in pasajes)
            {
                if (unPasaje.Pasajero == unUsuario)
                {
                    pasajesUsuario.Add(unPasaje);
                }
            }
            pasajesUsuario.Sort();
            return pasajesUsuario;
        }


        public List<Pasaje> ObtenerListadoPasajesOrdenadoPrecio(Usuario unUsuario)
        {
            List<Pasaje> pasajesUsuario = new List<Pasaje>();

            foreach (Pasaje unPasaje in pasajes)
            {
                if (unPasaje.Pasajero == unUsuario)
                {
                    pasajesUsuario.Add(unPasaje);
                }
            }
            pasajesUsuario.Sort(new PasajeComparer());
            return pasajesUsuario;
        }

        public List <Pasaje> ObtenerListadoPasajesAdmin()
        {
            List<Pasaje> pasajeCopia = new List<Pasaje>();
            foreach (Pasaje unPasaje in pasajes)
            {
                pasajeCopia.Add(unPasaje);
            }
            pasajeCopia.Sort();
            return pasajeCopia;
        }

        #endregion

        #region Vuelo
        public void AgregarNuevoVuelo(Vuelo unVuelo)
        {
            unVuelo.Validar();
            validarExistenciaVuelo(unVuelo);
            Vuelos.Add(unVuelo);
        }
        private void validarExistenciaVuelo(Vuelo unVuelo)
        {
            if (Vuelos.Contains(unVuelo))
            {
                throw new Exception("Error: El vuelo ingresado ya existe.");
            }
        }

        public List<Vuelo> ListarVueloSegunIATA(string? codigoIataOrigen, string? codigoIataDestino)
        {

            List<Vuelo> listaFinal = new List<Vuelo>();
            
            if (codigoIataOrigen == "" && codigoIataDestino == "" || codigoIataOrigen == null && codigoIataDestino == null)
            {
                listaFinal = this.Vuelos;
            }
            else
            {
                
                if (codigoIataOrigen != null)
                {
                    if (codigoIataOrigen.Length != 3)
                    {
                        throw new Exception("Error: Codigo IATA ingresado no cumple con el formato de 3 letras");
                    }
                    codigoIataOrigen = codigoIataOrigen.ToUpper();

                }
                if (codigoIataDestino != null)
                {
                    if (codigoIataDestino.Length != 3)
                    {
                        throw new Exception("Error: Codigo IATA ingresado no cumple con el formato de 3 letras");
                    }
                    codigoIataDestino = codigoIataDestino.ToUpper();
                }
                foreach (Vuelo unVuelo in this.Vuelos)
                {
                    if (codigoIataOrigen == unVuelo.Ruta.AeropuertoSalida.CodigoIATA || codigoIataOrigen == "" || codigoIataOrigen == null)
                    {
                        if (codigoIataDestino == unVuelo.Ruta.AeropuertoLlegada.CodigoIATA || codigoIataDestino == "" || codigoIataDestino == null)
                        {
                            listaFinal.Add(unVuelo);
                        }
                    }
                }
            }
            return listaFinal;
        }
        public Vuelo ObtenerVueloSegunNumVuelo(string numVuelo)
        {
            foreach (Vuelo unVuelo in this.Vuelos)
            {
                if (unVuelo.NumVuelo == numVuelo)
                {
                    return unVuelo;
                }
            }
            throw new Exception($"Error: No existe un vuelo con numero [{numVuelo}]");
        }
        #endregion

        #region Avion
        public void AgregarNuevoAvion(Avion unAvion)
        {
            unAvion.Validar();
            validarExistenciaAvion(unAvion);
            Aviones.Add(unAvion);
        }

        private void validarExistenciaAvion(Avion unAvion)
        {
            if (Aviones.Contains(unAvion))
            {
                throw new Exception("Error: El avion ingresado ya existe.");
            }
        }
        private Avion obtenerAvionSegunModelo(string modelo)
        {
            foreach (Avion unAvion in this.Aviones)
            {
                if (unAvion.Modelo == modelo)
                {
                    return unAvion;
                }
            }
            throw new Exception($"Error: No existe un avion con modelo [{modelo}]");

        }
        #endregion

        #region Ruta
        public void AgregarNuevaRuta(Ruta unaRuta)
        {
            validarExistenciaRuta(unaRuta);
            unaRuta.Validar();
            Rutas.Add(unaRuta);
        }
        private void validarExistenciaRuta(Ruta unaRuta)
        {
            if (Rutas.Contains(unaRuta))
            {
                throw new Exception("Error: La ruta ingresado ya existe.");
            }
        }
        private Ruta obtenerRutaSegunId(int idRuta)
        {
            foreach (Ruta unaRuta in this.Rutas)
            {
                if (unaRuta.IdRuta == idRuta)
                {
                    return unaRuta;
                }
            }
            throw new Exception($"Error: No existe una ruta con Id [{idRuta}]");
        }
        #endregion

        #region Aeropuerto
        public void AgregarNuevoAeropuerto(Aeropuerto unAeropuerto)
        {
            unAeropuerto.Validar();
            validarExistenciaAeropuerto(unAeropuerto);
            Aeropuertos.Add(unAeropuerto);
        }
        private void validarExistenciaAeropuerto(Aeropuerto unAeropuerto)
        {
            if (Aeropuertos.Contains(unAeropuerto))
            {
                throw new Exception("Error: El aeropuerto ingresado ya existe.");
            }
        }

        private Aeropuerto obtenerAeropuertoSegunIATA(string codigoIATA)
        {
            foreach (Aeropuerto unAeropuerto in this.Aeropuertos)
            {
                if (unAeropuerto.CodigoIATA == codigoIATA)
                {
                    return unAeropuerto;
                }
            }
            throw new Exception($"Error: No existe un aeropuerto con codigo IATA [{codigoIATA}]");

        }
        #endregion

        #endregion
    }

}
