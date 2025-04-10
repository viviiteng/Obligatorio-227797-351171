namespace Dominio
{
    public class Sistema
    {
        public List<Cliente> Clientes { get; set; }
        public List<Administrador> Administradores { get; set; }
        public List<Pasaje> Pasajes { get; set; }
        public List<Vuelo> Vuelos { get; set; }
        public List<Ruta> Rutas { get; set; }
        public List<Avion> Aviones { get; set; }
        public List<Aeropuerto> Aeropuertos { get; set; }


        public Sistema()
        {
            Clientes = new List<Cliente>();
            Administradores = new List<Administrador>();
            Aviones = new List<Avion>();
            Aeropuertos = new List<Aeropuerto>();
            Rutas = new List<Ruta>();
            Pasajes = new List<Pasaje>();
            Vuelos = new List<Vuelo>();

            PrecargarDatos();
        }

        

        #region Precargas
        public void PrecargarDatos()
        {

            PrecargarAdministradores();
            PrecargarAviones();
            PrecargaAeropuertos();
            PrecargarRutas(); 
            PrecargarVuelos();
            

        }

        private void PrecargarAdministradores()
        {
            AgregarNuevoAdministrador(new Administrador("Agustin", "agustin@gmail.com", "1234"));
            AgregarNuevoAdministrador(new Administrador("Viviana", "viviana@gmail.com", "4321"));
        }

        private void PrecargarAviones()
        {
            AgregarNuevoAvion(new Avion("Boeing", "737 MAX", 178, 6570.0, 8500.00));
            AgregarNuevoAvion(new Avion("Airbus", "A320neo", 180, 6300.0, 8200.00));
            AgregarNuevoAvion(new Avion("Embraer", "E195-E2", 132, 4800.0, 7200.00));
            AgregarNuevoAvion(new Avion("Bombardier", "CRJ900", 90, 2956.0, 5400.00));

        }

        private void PrecargaAeropuertos()
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

        private void PrecargarRutas()
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
        private void PrecargarVuelos()
        {
            AgregarNuevoVuelo(new Vuelo("AR101", Rutas[0], Aviones[0], new Frecuencia[] { Frecuencia.lunes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("LA203", Rutas[1], Aviones[1], new Frecuencia[] { Frecuencia.martes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("UX309", Rutas[2], Aviones[2], new Frecuencia[] { Frecuencia.miercoles, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AF450", Rutas[3], Aviones[3], new Frecuencia[] { Frecuencia.jueves, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("IB333", Rutas[4], Aviones[0], new Frecuencia[] { Frecuencia.lunes, Frecuencia.martes }));
            AgregarNuevoVuelo(new Vuelo("DL220", Rutas[5], Aviones[1], new Frecuencia[] { Frecuencia.viernes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("UA875", Rutas[6], Aviones[2], new Frecuencia[] { Frecuencia.jueves, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("LH708", Rutas[7], Aviones[3], new Frecuencia[] { Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("KL110", Rutas[8], Aviones[0], new Frecuencia[] { Frecuencia.lunes, Frecuencia.martes, Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("AZ556", Rutas[9], Aviones[1], new Frecuencia[] { Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("AC990", Rutas[10], Aviones[2], new Frecuencia[] { Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("JJ777", Rutas[11], Aviones[3], new Frecuencia[] { Frecuencia.lunes, Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("NH852", Rutas[12], Aviones[0], new Frecuencia[] { Frecuencia.martes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("QF908", Rutas[13], Aviones[1], new Frecuencia[] { Frecuencia.lunes }));
            AgregarNuevoVuelo(new Vuelo("EK202", Rutas[14], Aviones[2], new Frecuencia[] { Frecuencia.miercoles, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("QR118", Rutas[15], Aviones[3], new Frecuencia[] { Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("LA515", Rutas[16], Aviones[0], new Frecuencia[] { Frecuencia.viernes, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AV300", Rutas[17], Aviones[1], new Frecuencia[] { Frecuencia.lunes }));
            AgregarNuevoVuelo(new Vuelo("AR132", Rutas[18], Aviones[2], new Frecuencia[] { Frecuencia.martes }));
            AgregarNuevoVuelo(new Vuelo("IB440", Rutas[19], Aviones[3], new Frecuencia[] { Frecuencia.miercoles, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("DL155", Rutas[20], Aviones[0], new Frecuencia[] { Frecuencia.lunes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("AF621", Rutas[21], Aviones[1], new Frecuencia[] { Frecuencia.jueves, Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("KL205", Rutas[22], Aviones[2], new Frecuencia[] { Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("BA775", Rutas[23], Aviones[3], new Frecuencia[] { Frecuencia.martes, Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("JJ803", Rutas[24], Aviones[0], new Frecuencia[] { Frecuencia.domingo }));
            AgregarNuevoVuelo(new Vuelo("AZ313", Rutas[25], Aviones[1], new Frecuencia[] { Frecuencia.miercoles }));
            AgregarNuevoVuelo(new Vuelo("AC499", Rutas[26], Aviones[2], new Frecuencia[] { Frecuencia.lunes, Frecuencia.jueves }));
            AgregarNuevoVuelo(new Vuelo("NH404", Rutas[27], Aviones[3], new Frecuencia[] { Frecuencia.viernes }));
            AgregarNuevoVuelo(new Vuelo("QF878", Rutas[28], Aviones[0], new Frecuencia[] { Frecuencia.martes, Frecuencia.sabado }));
            AgregarNuevoVuelo(new Vuelo("EK301", Rutas[29], Aviones[1], new Frecuencia[] { Frecuencia.domingo, Frecuencia.jueves }));
        }
        #endregion

        #region Cliente
        public void AgregarNuevoCliente()
        {
            Cliente unCliente = new Cliente();
            Clientes.Add(unCliente);
        }
        #endregion


        #region Administrador
        public void AgregarNuevoAdministrador(Administrador administrador)
        {
            Administrador unAdministrador = new Administrador();
            this.Administradores.Add(administrador);
        }
        #endregion


        #region Pasaje
        public void AgregarNuevoPasaje(Pasaje unPasaje)
        {
            Pasajes.Add(unPasaje);
        }
        #endregion


        #region Vuelo
        public void AgregarNuevoVuelo(Vuelo unVuelo)
        {

            Vuelos.Add(unVuelo);
        }
        #endregion


        #region Avion
        public void AgregarNuevoAvion(Avion unAvion)
        {
            Aviones.Add(unAvion);
        }
        #endregion


        #region Ruta
        public void AgregarNuevaRuta(Ruta unaRuta)
        {
            Rutas.Add(unaRuta);
        }
        #endregion


        #region Aeropuerto
        public void AgregarNuevoAeropuerto(Aeropuerto unAeropuerto)
        {
            Aeropuertos.Add(unAeropuerto);
        }
        #endregion




    }

}
