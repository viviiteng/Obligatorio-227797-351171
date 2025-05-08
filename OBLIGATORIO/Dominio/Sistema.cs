using System.Linq;
using System.Linq.Expressions;

namespace Dominio
{
    public class Sistema
    {
        #region Atributos
        public List<Usuario> Usuarios { get; set; }
        public List<Pasaje> Pasajes { get; set; }
        public List<Vuelo> Vuelos { get; set; }
        public List<Ruta> Rutas { get; set; }
        public List<Avion> Aviones { get; set; }
        public List<Aeropuerto> Aeropuertos { get; set; }
        #endregion

        #region Constructor      
        public Sistema()
        {
            Usuarios = new List<Usuario>();
            Aviones = new List<Avion>();
            Aeropuertos = new List<Aeropuerto>();
            Rutas = new List<Ruta>();
            Pasajes = new List<Pasaje>();
            Vuelos = new List<Vuelo>();
        }
        #endregion

        #region Metodos
        
        #region Precargas
        public void PrecargarDatos()
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
            AgregarNuevoUsuario(new ClientePremium("12345678", "Martín Pérez", "martin.perez@gmail.com", "pass123", "Uruguaya", 1500));
            AgregarNuevoUsuario(new ClientePremium("23456789", "Laura Gómez", "laura.gomez@hotmail.com", "laura456", "Argentina", 3200));
            AgregarNuevoUsuario(new ClientePremium("34567890", "Carlos Silva", "carlos.silva@yahoo.com", "silva2023", "Chilena", 2100));
            AgregarNuevoUsuario(new ClientePremium("45678901", "Ana Torres", "ana.torres@gmail.com", "torres321", "Uruguaya", 2750));
            AgregarNuevoUsuario(new ClientePremium("56789012", "Diego Fernández", "diego.fernandez@outlook.com", "dfpass789", "Brasilera", 3900));

            AgregarNuevoUsuario(new ClienteOcasional("67890123", "Valentina Suárez", "valesuarez@gmail.com", "vale123", "Paraguaya"));
            AgregarNuevoUsuario(new ClienteOcasional("78901234", "Rodrigo López", "rodrilopez@hotmail.com", "rodri456", "Uruguaya"));
            AgregarNuevoUsuario(new ClienteOcasional("89012345", "María Rivas", "maria.rivas@yahoo.com", "rivas789", "Peruana"));
            AgregarNuevoUsuario(new ClienteOcasional("90123456", "Nicolás Méndez", "nico.mendez@gmail.com", "nicolas321", "Colombiana"));
            AgregarNuevoUsuario(new ClienteOcasional("01234567", "Lucía Figueroa", "lucia.fig@outlook.com", "figpass852", "Boliviana"));

            AgregarNuevoUsuario(new Administrador("Agustin", "agustin@gmail.com", "1234"));
            AgregarNuevoUsuario(new Administrador("Viviana", "viviana@gmail.com", "4321"));
        }
        private void precargarAviones()
        {
            AgregarNuevoAvion(new Avion("Boeing", "737 MAX", 178, 65700.0, 8500.00));
            AgregarNuevoAvion(new Avion("Airbus", "A320neo", 180, 63000.0, 8200.00));
            AgregarNuevoAvion(new Avion("Embraer", "E195-E2", 132, 48000.0, 7200.00));
            AgregarNuevoAvion(new Avion("Bombardier", "CRJ900", 90, 29560.0, 5400.00));

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
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MVD"), obtenerAeropuertoSegunIATA("SCL"), 1500.0));   // MVD -> SCL
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MVD"), obtenerAeropuertoSegunIATA("EZE"), 2100.0));   // MVD -> EZE
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("SCL"), obtenerAeropuertoSegunIATA("GRU"), 2600.0));   // SCL -> GRU
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("EZE"), obtenerAeropuertoSegunIATA("JFK"), 8500.0));   // EZE -> JFK
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("GRU"), obtenerAeropuertoSegunIATA("LAX"), 9800.0));   // GRU -> LAX
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("JFK"), obtenerAeropuertoSegunIATA("CDG"), 5850.0));   // JFK -> CDG
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LAX"), obtenerAeropuertoSegunIATA("LHR"), 8750.0));   // LAX -> LHR
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("CDG"), obtenerAeropuertoSegunIATA("MAD"), 1050.0));   // CDG -> MAD
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LHR"), obtenerAeropuertoSegunIATA("FRA"), 1030.0));   // LHR -> FRA
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MAD"), obtenerAeropuertoSegunIATA("AMS"), 1480.0));   // MAD -> AMS
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("FRA"), obtenerAeropuertoSegunIATA("BCN"), 1330.0));   // FRA -> BCN
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("AMS"), obtenerAeropuertoSegunIATA("MIA"), 7800.0));   // AMS -> MIA
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("BCN"), obtenerAeropuertoSegunIATA("YYZ"), 7800.0));   // BCN -> YYZ
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MIA"), obtenerAeropuertoSegunIATA("NRT"), 11000.0));  // MIA -> NRT
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("YYZ"), obtenerAeropuertoSegunIATA("SYD"), 15500.0));  // YYZ -> SYD
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("NRT"), obtenerAeropuertoSegunIATA("DXB"), 8200.0));   // NRT -> DXB
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("SYD"), obtenerAeropuertoSegunIATA("DOH"), 12100.0));  // SYD -> DOH
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("DXB"), obtenerAeropuertoSegunIATA("LIM"), 14600.0));  // DXB -> LIM
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("DOH"), obtenerAeropuertoSegunIATA("BOG"), 13800.0));  // DOH -> BOG
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("SCL"), obtenerAeropuertoSegunIATA("MVD"), 1500.0));   // SCL -> MVD
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("JFK"), obtenerAeropuertoSegunIATA("MVD"), 8500.0));   // JFK -> MVD
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("GRU"), obtenerAeropuertoSegunIATA("CDG"), 9400.0));   // GRU -> CDG
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LAX"), obtenerAeropuertoSegunIATA("EZE"), 9900.0));   // LAX -> EZE
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("CDG"), obtenerAeropuertoSegunIATA("MVD"), 10800.0));  // CDG -> MVD
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LHR"), obtenerAeropuertoSegunIATA("LAX"), 8750.0));   // LHR -> LAX
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("MAD"), obtenerAeropuertoSegunIATA("GRU"), 10200.0));  // MAD -> GRU
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("FRA"), obtenerAeropuertoSegunIATA("EZE"), 11200.0));  // FRA -> EZE
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("AMS"), obtenerAeropuertoSegunIATA("MVD"), 11400.0));  // AMS -> MVD
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("BCN"), obtenerAeropuertoSegunIATA("NRT"), 11700.0));  // BCN -> NRT
            AgregarNuevaRuta(new Ruta(obtenerAeropuertoSegunIATA("LIM"), obtenerAeropuertoSegunIATA("MVD"), 3200.0));   // LIM -> MVD   


            //AgregarNuevaRuta(new Ruta(Aeropuertos[0], Aeropuertos[1], 1500.0));     // MVD -> SCL
            //AgregarNuevaRuta(new Ruta(Aeropuertos[0], Aeropuertos[2], 2100.0));     // MVD -> EZE
            //AgregarNuevaRuta(new Ruta(Aeropuertos[1], Aeropuertos[3], 2600.0));     // SCL -> GRU
            //AgregarNuevaRuta(new Ruta(Aeropuertos[2], Aeropuertos[4], 8500.0));     // EZE -> JFK
            //AgregarNuevaRuta(new Ruta(Aeropuertos[3], Aeropuertos[5], 9800.0));     // GRU -> LAX
            //AgregarNuevaRuta(new Ruta(Aeropuertos[4], Aeropuertos[6], 5850.0));     // JFK -> CDG
            //AgregarNuevaRuta(new Ruta(Aeropuertos[5], Aeropuertos[7], 8750.0));     // LAX -> LHR
            //AgregarNuevaRuta(new Ruta(Aeropuertos[6], Aeropuertos[8], 1050.0));     // CDG -> MAD
            //AgregarNuevaRuta(new Ruta(Aeropuertos[7], Aeropuertos[9], 1030.0));     // LHR -> FRA
            //AgregarNuevaRuta(new Ruta(Aeropuertos[8], Aeropuertos[10], 1480.0));    // MAD -> AMS
            //AgregarNuevaRuta(new Ruta(Aeropuertos[9], Aeropuertos[11], 1330.0));    // FRA -> BCN
            //AgregarNuevaRuta(new Ruta(Aeropuertos[10], Aeropuertos[12], 7800.0));   // AMS -> MIA
            //AgregarNuevaRuta(new Ruta(Aeropuertos[11], Aeropuertos[13], 7800.0));   // BCN -> YYZ
            //AgregarNuevaRuta(new Ruta(Aeropuertos[12], Aeropuertos[14], 11000.0));  // MIA -> NRT
            //AgregarNuevaRuta(new Ruta(Aeropuertos[13], Aeropuertos[15], 15500.0));  // YYZ -> SYD
            //AgregarNuevaRuta(new Ruta(Aeropuertos[14], Aeropuertos[16], 8200.0));   // NRT -> DXB
            //AgregarNuevaRuta(new Ruta(Aeropuertos[15], Aeropuertos[17], 12100.0));  // SYD -> DOH
            //AgregarNuevaRuta(new Ruta(Aeropuertos[16], Aeropuertos[18], 14600.0));  // DXB -> LIM
            //AgregarNuevaRuta(new Ruta(Aeropuertos[17], Aeropuertos[19], 13800.0));  // DOH -> BOG
            //AgregarNuevaRuta(new Ruta(Aeropuertos[1], Aeropuertos[0], 1500.0));     // SCL -> MVD
            //AgregarNuevaRuta(new Ruta(Aeropuertos[4], Aeropuertos[0], 8500.0));     // JFK -> MVD
            //AgregarNuevaRuta(new Ruta(Aeropuertos[3], Aeropuertos[6], 9400.0));     // GRU -> CDG
            //AgregarNuevaRuta(new Ruta(Aeropuertos[5], Aeropuertos[2], 9900.0));     // LAX -> EZE
            //AgregarNuevaRuta(new Ruta(Aeropuertos[6], Aeropuertos[0], 10800.0));    // CDG -> MVD
            //AgregarNuevaRuta(new Ruta(Aeropuertos[7], Aeropuertos[5], 8750.0));     // LHR -> LAX
            //AgregarNuevaRuta(new Ruta(Aeropuertos[8], Aeropuertos[3], 10200.0));    // MAD -> GRU
            //AgregarNuevaRuta(new Ruta(Aeropuertos[9], Aeropuertos[2], 11200.0));    // FRA -> EZE
            //AgregarNuevaRuta(new Ruta(Aeropuertos[10], Aeropuertos[0], 11400.0));   // AMS -> MVD
            //AgregarNuevaRuta(new Ruta(Aeropuertos[11], Aeropuertos[14], 11700.0));  // BCN -> NRT
            //AgregarNuevaRuta(new Ruta(Aeropuertos[18], Aeropuertos[0], 3200.0));    // LIM -> MVD 
        }
        private void precargarVuelos()
        {
            AgregarNuevoVuelo(new Vuelo("AR101",obtenerRutaSegunId(0) , obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("UX309",obtenerRutaSegunId(2) , obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AF450",obtenerRutaSegunId(3) , obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.jueves, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("IB333",obtenerRutaSegunId(4) , obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.martes }));
            AgregarNuevoVuelo(new Vuelo("DL220",obtenerRutaSegunId(5) , obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.viernes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("UA875",obtenerRutaSegunId(6) , obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.jueves, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("LA203",obtenerRutaSegunId(1) , obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.martes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("LH708",obtenerRutaSegunId(7) , obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("KL110",obtenerRutaSegunId(8) , obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.martes, Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("AZ556",obtenerRutaSegunId(9) , obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("AC990",obtenerRutaSegunId(10) ,obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("JJ777",obtenerRutaSegunId(11) ,obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("NH852",obtenerRutaSegunId(12) ,obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.martes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("QF908",obtenerRutaSegunId(13) ,obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.lunes }));
            AgregarNuevoVuelo(new Vuelo("EK202",obtenerRutaSegunId(14), obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("QR118",obtenerRutaSegunId(15) ,obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("LA515",obtenerRutaSegunId(16) ,obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.viernes, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AV300",obtenerRutaSegunId(17) ,obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.lunes }));
            AgregarNuevoVuelo(new Vuelo("AR132",obtenerRutaSegunId(18) ,obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.martes }));
            AgregarNuevoVuelo(new Vuelo("IB440",obtenerRutaSegunId(19) ,obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("DL155",obtenerRutaSegunId(20) ,obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("AF621",obtenerRutaSegunId(21) ,obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.jueves, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("KL205",obtenerRutaSegunId(22) ,obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("BA775",obtenerRutaSegunId(23) ,obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.martes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("JJ803",obtenerRutaSegunId(24) ,obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AZ313",obtenerRutaSegunId(25) ,obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("AC499",obtenerRutaSegunId(26) ,obtenerAvionSegunModelo("E195-E2"), new List<Frecuencia> { Frecuencia.lunes, Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("NH404",obtenerRutaSegunId(27) ,obtenerAvionSegunModelo("CRJ900"), new List<Frecuencia> { Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("QF878",obtenerRutaSegunId(28) ,obtenerAvionSegunModelo("737 MAX"), new List<Frecuencia> { Frecuencia.martes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("EK301",obtenerRutaSegunId(29) ,obtenerAvionSegunModelo("A320neo"), new List<Frecuencia> { Frecuencia.domingo, Frecuencia.jueves }));

            //AgregarNuevoVuelo(new Vuelo("AR101", Rutas[0], Aviones[0], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.viernes }));
            //AgregarNuevoVuelo(new Vuelo("UX309", Rutas[2], Aviones[2], new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.domingo }));
            //AgregarNuevoVuelo(new Vuelo("AF450", Rutas[3], Aviones[1], new List<Frecuencia> { Frecuencia.jueves, Frecuencia.domingo }));
            //AgregarNuevoVuelo(new Vuelo("IB333", Rutas[4], Aviones[0], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.martes }));
            //AgregarNuevoVuelo(new Vuelo("DL220", Rutas[5], Aviones[1], new List<Frecuencia> { Frecuencia.viernes, Frecuencia.sabado }));
            //AgregarNuevoVuelo(new Vuelo("UA875", Rutas[6], Aviones[2], new List<Frecuencia> { Frecuencia.jueves, Frecuencia.viernes }));
            //AgregarNuevoVuelo(new Vuelo("LA203", Rutas[1], Aviones[1], new List<Frecuencia> { Frecuencia.martes, Frecuencia.sabado }));
            //AgregarNuevoVuelo(new Vuelo("LH708", Rutas[7], Aviones[3], new List<Frecuencia> { Frecuencia.miercoles }));
            //AgregarNuevoVuelo(new Vuelo("KL110", Rutas[8], Aviones[0], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.martes, Frecuencia.jueves }));
            //AgregarNuevoVuelo(new Vuelo("AZ556", Rutas[9], Aviones[1], new List<Frecuencia> { Frecuencia.sabado }));
            //AgregarNuevoVuelo(new Vuelo("AC990", Rutas[10], Aviones[2], new List<Frecuencia> { Frecuencia.domingo }));
            //AgregarNuevoVuelo(new Vuelo("JJ777", Rutas[11], Aviones[3], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.miercoles }));
            //AgregarNuevoVuelo(new Vuelo("NH852", Rutas[12], Aviones[0], new List<Frecuencia> { Frecuencia.martes, Frecuencia.viernes }));
            //AgregarNuevoVuelo(new Vuelo("QF908", Rutas[13], Aviones[1], new List<Frecuencia> { Frecuencia.lunes }));
            //AgregarNuevoVuelo(new Vuelo("EK202", Rutas[14], Aviones[2], new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.sabado }));
            //AgregarNuevoVuelo(new Vuelo("QR118", Rutas[15], Aviones[3], new List<Frecuencia> { Frecuencia.jueves }));
            //AgregarNuevoVuelo(new Vuelo("LA515", Rutas[16], Aviones[0], new List<Frecuencia> { Frecuencia.viernes, Frecuencia.domingo }));
            //AgregarNuevoVuelo(new Vuelo("AV300", Rutas[17], Aviones[1], new List<Frecuencia> { Frecuencia.lunes }));
            //AgregarNuevoVuelo(new Vuelo("AR132", Rutas[18], Aviones[2], new List<Frecuencia> { Frecuencia.martes }));
            //AgregarNuevoVuelo(new Vuelo("IB440", Rutas[19], Aviones[3], new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.sabado }));
            //AgregarNuevoVuelo(new Vuelo("DL155", Rutas[20], Aviones[0], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.viernes }));
            //AgregarNuevoVuelo(new Vuelo("AF621", Rutas[21], Aviones[1], new List<Frecuencia> { Frecuencia.jueves, Frecuencia.domingo }));
            //AgregarNuevoVuelo(new Vuelo("KL205", Rutas[22], Aviones[2], new List<Frecuencia> { Frecuencia.sabado }));
            //AgregarNuevoVuelo(new Vuelo("BA775", Rutas[23], Aviones[3], new List<Frecuencia> { Frecuencia.martes, Frecuencia.viernes }));
            //AgregarNuevoVuelo(new Vuelo("JJ803", Rutas[24], Aviones[0], new List<Frecuencia> { Frecuencia.domingo }));
            //AgregarNuevoVuelo(new Vuelo("AZ313", Rutas[25], Aviones[1], new List<Frecuencia> { Frecuencia.miercoles }));
            //AgregarNuevoVuelo(new Vuelo("AC499", Rutas[26], Aviones[2], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.jueves }));
            //AgregarNuevoVuelo(new Vuelo("NH404", Rutas[27], Aviones[3], new List<Frecuencia> { Frecuencia.viernes }));
            //AgregarNuevoVuelo(new Vuelo("QF878", Rutas[28], Aviones[0], new List<Frecuencia> { Frecuencia.martes, Frecuencia.sabado }));
            //AgregarNuevoVuelo(new Vuelo("EK301", Rutas[29], Aviones[1], new List<Frecuencia> { Frecuencia.domingo, Frecuencia.jueves }));
        }
        private void precagarPasajes()
        {
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("AR101"), new DateTime(2025, 5, 5), obtenerClienteSegunCedula("12345678") , TipoEquipaje.CABINA, 350.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("UX309"), new DateTime(2025, 5, 11), obtenerClienteSegunCedula("67890123") , TipoEquipaje.LIGHT, 280.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("AF450"), new DateTime(2025, 5, 8), obtenerClienteSegunCedula("23456789") , TipoEquipaje.BODEGA, 410.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("IB333"), new DateTime(2025, 5, 13), obtenerClienteSegunCedula("78901234") , TipoEquipaje.CABINA, 360.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("DL220"), new DateTime(2025, 5, 16), obtenerClienteSegunCedula("34567890") , TipoEquipaje.LIGHT, 290.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("UA875"), new DateTime(2025, 5, 16), obtenerClienteSegunCedula("89012345") , TipoEquipaje.BODEGA, 430.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("LA203"), new DateTime(2025, 5, 17), obtenerClienteSegunCedula("45678901") , TipoEquipaje.CABINA, 375.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("LH708"), new DateTime(2025, 5, 14), obtenerClienteSegunCedula("90123456") , TipoEquipaje.LIGHT, 300.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("KL110"), new DateTime(2025, 5, 19), obtenerClienteSegunCedula("56789012") , TipoEquipaje.BODEGA, 450.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("AZ556"), new DateTime(2025, 5, 17), obtenerClienteSegunCedula("90123456") , TipoEquipaje.CABINA, 360.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("AC990"), new DateTime(2025, 5, 18), obtenerClienteSegunCedula("12345678") , TipoEquipaje.LIGHT, 320.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("JJ777"), new DateTime(2025, 5, 21), obtenerClienteSegunCedula("67890123") , TipoEquipaje.BODEGA, 390.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("NH852"), new DateTime(2025, 5, 23), obtenerClienteSegunCedula("23456789") , TipoEquipaje.CABINA, 355.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("QF908"), new DateTime(2025, 5, 26), obtenerClienteSegunCedula("78901234") , TipoEquipaje.LIGHT, 295.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("EK202"), new DateTime(2025, 5, 24), obtenerClienteSegunCedula("34567890") , TipoEquipaje.BODEGA, 460.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("QR118"), new DateTime(2025, 5, 22), obtenerClienteSegunCedula("89012345") , TipoEquipaje.CABINA, 370.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("LA515"), new DateTime(2025, 5, 25), obtenerClienteSegunCedula("45678901") , TipoEquipaje.LIGHT, 310.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("AV300"), new DateTime(2025, 5, 26), obtenerClienteSegunCedula("90123456") , TipoEquipaje.BODEGA, 440.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("AR132"), new DateTime(2025, 5, 27), obtenerClienteSegunCedula("56789012") , TipoEquipaje.CABINA, 385.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("IB440"), new DateTime(2025, 5, 31), obtenerClienteSegunCedula("90123456") , TipoEquipaje.LIGHT, 305.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("DL155"), new DateTime(2025, 6, 2), obtenerClienteSegunCedula("12345678") , TipoEquipaje.BODEGA, 470.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("AF621"), new DateTime(2025, 6, 1), obtenerClienteSegunCedula("67890123") , TipoEquipaje.CABINA, 365.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("KL205"), new DateTime(2025, 6, 7), obtenerClienteSegunCedula("23456789") , TipoEquipaje.LIGHT, 315.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("BA775"), new DateTime(2025, 6, 3), obtenerClienteSegunCedula("78901234") , TipoEquipaje.BODEGA, 425.00));
            AgregarNuevoPasaje(new Pasaje(obtenerVueloSegunNumVuelo("JJ803"), new DateTime(2025, 6, 8), obtenerClienteSegunCedula("34567890") , TipoEquipaje.CABINA, 380.00));

            //AgregarNuevoPasaje(new Pasaje(Vuelos[0], new DateTime(2025, 5, 5), Usuarios[0], TipoEquipaje.CABINA, 350.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[1], new DateTime(2025, 5, 11), Usuarios[5], TipoEquipaje.LIGHT, 280.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[2], new DateTime(2025, 5, 8), Usuarios[1], TipoEquipaje.BODEGA, 410.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[3], new DateTime(2025, 5, 13), Usuarios[6], TipoEquipaje.CABINA, 360.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[4], new DateTime(2025, 5, 16), Usuarios[2], TipoEquipaje.LIGHT, 290.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[5], new DateTime(2025, 5, 16), Usuarios[7], TipoEquipaje.BODEGA, 430.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[6], new DateTime(2025, 5, 17), Usuarios[3], TipoEquipaje.CABINA, 375.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[7], new DateTime(2025, 5, 14), Usuarios[8], TipoEquipaje.LIGHT, 300.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[8], new DateTime(2025, 5, 19), Usuarios[4], TipoEquipaje.BODEGA, 450.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[9], new DateTime(2025, 5, 17), Usuarios[9], TipoEquipaje.CABINA, 360.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[10], new DateTime(2025, 5, 18), Usuarios[0], TipoEquipaje.LIGHT, 320.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[11], new DateTime(2025, 5, 21), Usuarios[5], TipoEquipaje.BODEGA, 390.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[12], new DateTime(2025, 5, 23), Usuarios[1], TipoEquipaje.CABINA, 355.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[13], new DateTime(2025, 5, 26), Usuarios[6], TipoEquipaje.LIGHT, 295.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[14], new DateTime(2025, 5, 24), Usuarios[2], TipoEquipaje.BODEGA, 460.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[15], new DateTime(2025, 5, 22), Usuarios[7], TipoEquipaje.CABINA, 370.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[16], new DateTime(2025, 5, 25), Usuarios[3], TipoEquipaje.LIGHT, 310.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[17], new DateTime(2025, 5, 26), Usuarios[8], TipoEquipaje.BODEGA, 440.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[18], new DateTime(2025, 5, 27), Usuarios[4], TipoEquipaje.CABINA, 385.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[19], new DateTime(2025, 5, 31), Usuarios[9], TipoEquipaje.LIGHT, 305.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[20], new DateTime(2025, 6, 2), Usuarios[0], TipoEquipaje.BODEGA, 470.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[21], new DateTime(2025, 6, 1), Usuarios[5], TipoEquipaje.CABINA, 365.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[22], new DateTime(2025, 6, 7), Usuarios[1], TipoEquipaje.LIGHT, 315.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[23], new DateTime(2025, 6, 3), Usuarios[6], TipoEquipaje.BODEGA, 425.00));
            //AgregarNuevoPasaje(new Pasaje(Vuelos[24], new DateTime(2025, 6, 8), Usuarios[2], TipoEquipaje.CABINA, 380.00));
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
            if (clientes.Count == 0)
            {
                throw new Exception("Error: no existe ningun cliente registrado.");
            }
            return clientes;
        }
        private Usuario obtenerClienteSegunCedula(string cedula)
        {
            List<Cliente> clientes = ObtenerListadoDeClientes();
            Usuario clienteEncontrado = null;
            foreach (Cliente unCliente in clientes)
            {
                if (unCliente.Cedula == cedula)
                {
                    clienteEncontrado = unCliente;
                }
            }
            if (clienteEncontrado == null)
            {
                throw new Exception($"Error: No existe un cliente con cedula [{cedula}]");
            }
            else
            {
                return clienteEncontrado;
            }

        }
        #endregion

        #region Pasaje
        public void AgregarNuevoPasaje(Pasaje unPasaje)
        {
            unPasaje.Validar();
            validarExistenciaPasaje(unPasaje);
            Pasajes.Add(unPasaje);
        }

        private void validarExistenciaPasaje(Pasaje unPasaje)
        {
            if (Pasajes.Contains(unPasaje))
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

            foreach (Pasaje unPasaje in Pasajes)
            {
                if (fechaUno <= unPasaje.FechaDeVuelo && fechaDos >= unPasaje.FechaDeVuelo)
                {
                    listaSegunFecha.Add(unPasaje);
                }
            }

            if (listaSegunFecha.Count == 0)
            {
                throw new Exception("Error: No se ha encontrado ningun pasaje dentro de las fechas ingresadas. Intente de nuevo...");
            }
            return listaSegunFecha;
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
        public List<Vuelo> ListarVueloSegunIATA(string codigoIata)
        {
            string codigoMayus = codigoIata.ToUpper();
            List<Vuelo> listaSegunIata = new List<Vuelo>();

            foreach (Vuelo unVuelo in Vuelos)
            {
                if (codigoMayus == unVuelo.Ruta.AeropuertoSalida.CodigoIATA || codigoMayus == unVuelo.Ruta.AeropuertoLlegada.CodigoIATA)
                {
                    listaSegunIata.Add(unVuelo);
                }
            }

            if (listaSegunIata.Count == 0)
            {
                throw new Exception("Error: El codigo IATA ingresado no existe. Intente de nuevo.");
            }
            return listaSegunIata;
        }
        private Vuelo obtenerVueloSegunNumVuelo(string numVuelo)
        {
            Vuelo vueloEncontrado = null;
            foreach (Vuelo unVuelo in this.Vuelos)
            {
                if (unVuelo.NumVuelo == numVuelo)
                {
                    vueloEncontrado = unVuelo;
                }
            }
            if (vueloEncontrado == null)
            {
                throw new Exception($"Error: No existe un vuelo con numero [{numVuelo}]");
            }
            else
            {
                return vueloEncontrado;
            }

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
            Avion avionEncontrado = null;
            foreach (Avion unAvion in this.Aviones)
            {
                if (unAvion.Modelo == modelo)
                {
                    avionEncontrado = unAvion;
                }
            }
            if (avionEncontrado == null)
            {
                throw new Exception($"Error: No existe un avion con modelo [{modelo}]");
            }
            else
            {
                return avionEncontrado;
            }

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
            Ruta rutaEncontrada = null;
            foreach (Ruta unaRuta in this.Rutas)
            {
                if (unaRuta.IdRuta == idRuta)
                {
                    rutaEncontrada = unaRuta;
                }
            }
            if (rutaEncontrada == null)
            {
                throw new Exception($"Error: No existe una ruta con Id [{idRuta}]");
            }
            else
            {
                return rutaEncontrada;
            }

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
            Aeropuerto aeropuertoEncontrado = null;
            foreach (Aeropuerto unAeropuerto in this.Aeropuertos)
            {
                if (unAeropuerto.CodigoIATA == codigoIATA)
                {
                    aeropuertoEncontrado = unAeropuerto;  
                }   
            }
            if (aeropuertoEncontrado == null)
            {
                throw new Exception($"Error: No existe un aeropuerto con codigo IATA [{codigoIATA}]");
            }
            else 
            {
                return aeropuertoEncontrado;
            }
                
        }
        #endregion

        #endregion
    }

}
