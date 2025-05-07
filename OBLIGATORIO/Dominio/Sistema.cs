using System.Linq;
using System.Linq.Expressions;

namespace Dominio
{
    public class Sistema
    {
        public List<Usuario> Usuarios { get; set; }
        public List<Pasaje> Pasajes { get; set; }
        public List<Vuelo> Vuelos { get; set; }
        public List<Ruta> Rutas { get; set; }
        public List<Avion> Aviones { get; set; }
        public List<Aeropuerto> Aeropuertos { get; set; }


        public Sistema()
        {
            Usuarios = new List<Usuario>();
            Aviones = new List<Avion>();
            Aeropuertos = new List<Aeropuerto>();
            Rutas = new List<Ruta>();
            Pasajes = new List<Pasaje>();
            Vuelos = new List<Vuelo>();

            
        }

        

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
            AgregarNuevaRuta(new Ruta(Aeropuertos[0], Aeropuertos[1], 1500.0));     // MVD -> SCL
            AgregarNuevaRuta(new Ruta(Aeropuertos[0], Aeropuertos[2], 2100.0));     // MVD -> EZE
            AgregarNuevaRuta(new Ruta(Aeropuertos[1], Aeropuertos[3], 2600.0));     // SCL -> GRU
            AgregarNuevaRuta(new Ruta(Aeropuertos[2], Aeropuertos[4], 8500.0));     // EZE -> JFK
            AgregarNuevaRuta(new Ruta(Aeropuertos[3], Aeropuertos[5], 9800.0));     // GRU -> LAX
            AgregarNuevaRuta(new Ruta(Aeropuertos[4], Aeropuertos[6], 5850.0));     // JFK -> CDG
            AgregarNuevaRuta(new Ruta(Aeropuertos[5], Aeropuertos[7], 8750.0));     // LAX -> LHR
            AgregarNuevaRuta(new Ruta(Aeropuertos[6], Aeropuertos[8], 1050.0));     // CDG -> MAD
            AgregarNuevaRuta(new Ruta(Aeropuertos[7], Aeropuertos[9], 1030.0));     // LHR -> FRA
            AgregarNuevaRuta(new Ruta(Aeropuertos[8], Aeropuertos[10], 1480.0));    // MAD -> AMS
            AgregarNuevaRuta(new Ruta(Aeropuertos[9], Aeropuertos[11], 1330.0));    // FRA -> BCN
            AgregarNuevaRuta(new Ruta(Aeropuertos[10], Aeropuertos[12], 7800.0));   // AMS -> MIA
            AgregarNuevaRuta(new Ruta(Aeropuertos[11], Aeropuertos[13], 7800.0));   // BCN -> YYZ
            AgregarNuevaRuta(new Ruta(Aeropuertos[12], Aeropuertos[14], 11000.0));  // MIA -> NRT
            AgregarNuevaRuta(new Ruta(Aeropuertos[13], Aeropuertos[15], 15500.0));  // YYZ -> SYD
            AgregarNuevaRuta(new Ruta(Aeropuertos[14], Aeropuertos[16], 8200.0));   // NRT -> DXB
            AgregarNuevaRuta(new Ruta(Aeropuertos[15], Aeropuertos[17], 12100.0));  // SYD -> DOH
            AgregarNuevaRuta(new Ruta(Aeropuertos[16], Aeropuertos[18], 14600.0));  // DXB -> LIM
            AgregarNuevaRuta(new Ruta(Aeropuertos[17], Aeropuertos[19], 13800.0));  // DOH -> BOG
            AgregarNuevaRuta(new Ruta(Aeropuertos[1], Aeropuertos[0], 1500.0));     // SCL -> MVD
            AgregarNuevaRuta(new Ruta(Aeropuertos[4], Aeropuertos[0], 8500.0));     // JFK -> MVD
            AgregarNuevaRuta(new Ruta(Aeropuertos[3], Aeropuertos[6], 9400.0));     // GRU -> CDG
            AgregarNuevaRuta(new Ruta(Aeropuertos[5], Aeropuertos[2], 9900.0));     // LAX -> EZE
            AgregarNuevaRuta(new Ruta(Aeropuertos[6], Aeropuertos[0], 10800.0));    // CDG -> MVD
            AgregarNuevaRuta(new Ruta(Aeropuertos[7], Aeropuertos[5], 8750.0));     // LHR -> LAX
            AgregarNuevaRuta(new Ruta(Aeropuertos[8], Aeropuertos[3], 10200.0));    // MAD -> GRU
            AgregarNuevaRuta(new Ruta(Aeropuertos[9], Aeropuertos[2], 11200.0));    // FRA -> EZE
            AgregarNuevaRuta(new Ruta(Aeropuertos[10], Aeropuertos[0], 11400.0));   // AMS -> MVD
            AgregarNuevaRuta(new Ruta(Aeropuertos[11], Aeropuertos[14], 11700.0));  // BCN -> NRT
            AgregarNuevaRuta(new Ruta(Aeropuertos[18], Aeropuertos[0], 3200.0));    // LIM -> MVD   
        }
        private void precargarVuelos()
        {
            AgregarNuevoVuelo(new Vuelo("AR101", Rutas[0], Aviones[0], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("UX309", Rutas[2], Aviones[2], new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AF450", Rutas[3], Aviones[1], new List<Frecuencia> { Frecuencia.jueves, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("IB333", Rutas[4], Aviones[0], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.martes }));
            AgregarNuevoVuelo(new Vuelo("DL220", Rutas[5], Aviones[1], new List<Frecuencia> { Frecuencia.viernes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("UA875", Rutas[6], Aviones[2], new List<Frecuencia> { Frecuencia.jueves, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("LA203", Rutas[1], Aviones[1], new List<Frecuencia> { Frecuencia.martes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("LH708", Rutas[7], Aviones[3], new List<Frecuencia> { Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("KL110", Rutas[8], Aviones[0], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.martes, Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("AZ556", Rutas[9], Aviones[1], new List<Frecuencia> { Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("AC990", Rutas[10], Aviones[2], new List<Frecuencia> { Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("JJ777", Rutas[11], Aviones[3], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("NH852", Rutas[12], Aviones[0], new List<Frecuencia> { Frecuencia.martes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("QF908", Rutas[13], Aviones[1], new List<Frecuencia> { Frecuencia.lunes }));
            AgregarNuevoVuelo(new Vuelo("EK202", Rutas[14], Aviones[2], new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("QR118", Rutas[15], Aviones[3], new List<Frecuencia> { Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("LA515", Rutas[16], Aviones[0], new List<Frecuencia> { Frecuencia.viernes, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AV300", Rutas[17], Aviones[1], new List<Frecuencia> { Frecuencia.lunes }));
            AgregarNuevoVuelo(new Vuelo("AR132", Rutas[18], Aviones[2], new List<Frecuencia> { Frecuencia.martes }));
            AgregarNuevoVuelo(new Vuelo("IB440", Rutas[19], Aviones[3], new List<Frecuencia> { Frecuencia.miercoles, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("DL155", Rutas[20], Aviones[0], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("AF621", Rutas[21], Aviones[1], new List<Frecuencia> { Frecuencia.jueves, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("KL205", Rutas[22], Aviones[2], new List<Frecuencia> { Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("BA775", Rutas[23], Aviones[3], new List<Frecuencia> { Frecuencia.martes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("JJ803", Rutas[24], Aviones[0], new List<Frecuencia> { Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AZ313", Rutas[25], Aviones[1], new List<Frecuencia> { Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("AC499", Rutas[26], Aviones[2], new List<Frecuencia> { Frecuencia.lunes, Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("NH404", Rutas[27], Aviones[3], new List<Frecuencia> { Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("QF878", Rutas[28], Aviones[0], new List<Frecuencia> { Frecuencia.martes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("EK301", Rutas[29], Aviones[1], new List<Frecuencia> { Frecuencia.domingo, Frecuencia.jueves }));
        }
        private void precagarPasajes()
        {
            AgregarNuevoPasaje(new Pasaje(Vuelos[0], new DateTime(2025, 5, 5), Usuarios[0], TipoEquipaje.CABINA, 350.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[1], new DateTime(2025, 5, 11), Usuarios[5], TipoEquipaje.LIGHT, 280.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[2], new DateTime(2025, 5, 8), Usuarios[1], TipoEquipaje.BODEGA, 410.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[3], new DateTime(2025, 5, 13), Usuarios[6], TipoEquipaje.CABINA, 360.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[4], new DateTime(2025, 5, 16), Usuarios[2], TipoEquipaje.LIGHT, 290.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[5], new DateTime(2025, 5, 16), Usuarios[7], TipoEquipaje.BODEGA, 430.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[6], new DateTime(2025, 5, 17), Usuarios[3], TipoEquipaje.CABINA, 375.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[7], new DateTime(2025, 5, 14), Usuarios[8], TipoEquipaje.LIGHT, 300.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[8], new DateTime(2025, 5, 19), Usuarios[4], TipoEquipaje.BODEGA, 450.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[9], new DateTime(2025, 5, 17), Usuarios[9], TipoEquipaje.CABINA, 360.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[10], new DateTime(2025, 5, 18), Usuarios[0], TipoEquipaje.LIGHT, 320.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[11], new DateTime(2025, 5, 21), Usuarios[5], TipoEquipaje.BODEGA, 390.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[12], new DateTime(2025, 5, 23), Usuarios[1], TipoEquipaje.CABINA, 355.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[13], new DateTime(2025, 5, 26), Usuarios[6], TipoEquipaje.LIGHT, 295.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[14], new DateTime(2025, 5, 24), Usuarios[2], TipoEquipaje.BODEGA, 460.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[15], new DateTime(2025, 5, 22), Usuarios[7], TipoEquipaje.CABINA, 370.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[16], new DateTime(2025, 5, 25), Usuarios[3], TipoEquipaje.LIGHT, 310.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[17], new DateTime(2025, 5, 26), Usuarios[8], TipoEquipaje.BODEGA, 440.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[18], new DateTime(2025, 5, 27), Usuarios[4], TipoEquipaje.CABINA, 385.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[19], new DateTime(2025, 5, 31), Usuarios[9], TipoEquipaje.LIGHT, 305.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[20], new DateTime(2025, 6, 2), Usuarios[0], TipoEquipaje.BODEGA, 470.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[21], new DateTime(2025, 6, 1), Usuarios[5], TipoEquipaje.CABINA, 365.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[22], new DateTime(2025, 6, 7), Usuarios[1], TipoEquipaje.LIGHT, 315.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[23], new DateTime(2025, 6, 3), Usuarios[6], TipoEquipaje.BODEGA, 425.00));
            AgregarNuevoPasaje(new Pasaje(Vuelos[24], new DateTime(2025, 6, 8), Usuarios[2], TipoEquipaje.CABINA, 380.00));
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
            List <Cliente> clientes = new List <Cliente>();
            foreach (Usuario unUsuario in this.Usuarios)
            {
                if (unUsuario is Cliente unCliente)
                {
                    clientes.Add(unCliente);
                }
            }
            if(clientes.Count == 0)
            {
                throw new Exception("Error: no existe ningun cliente registrado.");
            }
            return clientes;
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
                throw new Exception("El pasaje ingresado ya existe.");
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
            
            if(listaSegunFecha.Count == 0)
            {
                throw new Exception("No se ha encontrado ningun pasaje dentro de las fechas ingresadas. Intente de nuevo...");
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
                throw new Exception("El vuelo ingresado ya existe.");
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

            if(listaSegunIata.Count == 0)
            {
                throw new Exception("El codigo IATA ingresado no existe. Intente de nuevo.");
            }
            return listaSegunIata;
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
                throw new Exception("El avion ingresado ya existe.");
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
                throw new Exception("La ruta ingresado ya existe.");
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
                throw new Exception("El aeropuerto ingresado ya existe.");
            }
        }
        #endregion
    }

}
