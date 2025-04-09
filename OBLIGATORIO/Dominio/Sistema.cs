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
            Administradores = new List<Administrador>()
            {
                new Administrador("Agustin", "agustin@gmail.com", "1234"),
                new Administrador("Viviana", "viviana@gmail.com", "4321")
            };
            Aviones = new List<Avion>()
            {
                new Avion("Boeing", "737 MAX", 178, 6570.0, 8500.00),
                new Avion("Airbus", "A320neo", 180, 6300.0, 8200.00),
                new Avion("Embraer", "E195-E2", 132, 4800.0, 7200.00),
                new Avion("Bombardier", "CRJ900", 90, 2956.0, 5400.00)
            };
            Aeropuertos = new List<Aeropuerto>(){
                new Aeropuerto("MVD", "Montevideo", 1200.50, 300.75),
                new Aeropuerto("SCL", "Santiago", 1350.00, 280.40),
                new Aeropuerto("EZE", "Buenos Aires", 1450.25, 310.00),
                new Aeropuerto("GRU", "São Paulo", 1600.00, 330.80),
                new Aeropuerto("JFK", "Nueva York", 2000.75, 400.00),
                new Aeropuerto("LAX", "Los Ángeles", 1950.60, 390.20),
                new Aeropuerto("CDG", "París", 2100.80, 420.35),
                new Aeropuerto("LHR", "Londres", 2150.30, 410.90),
                new Aeropuerto("MAD", "Madrid", 1750.40, 370.00),
                new Aeropuerto("FRA", "Frankfurt", 1850.75, 385.60),
                new Aeropuerto("AMS", "Ámsterdam", 1780.20, 365.10),
                new Aeropuerto("BCN", "Barcelona", 1700.00, 355.00),
                new Aeropuerto("MIA", "Miami", 1900.25, 395.75),
                new Aeropuerto("YYZ", "Toronto", 1800.50, 370.20),
                new Aeropuerto("NRT", "Tokio", 2200.60, 430.45),
                new Aeropuerto("SYD", "Sídney", 2300.10, 440.00),
                new Aeropuerto("DXB", "Dubái", 2250.30, 425.90),
                new Aeropuerto("DOH", "Doha", 2150.80, 415.60),
                new Aeropuerto("LIM", "Lima", 1400.00, 290.00),
                new Aeropuerto("BOG", "Bogotá", 1380.90, 295.50)
            };
            Rutas = new List<Ruta>()
            {
                new Ruta(Aeropuertos[0], Aeropuertos[1], 1500.0),   // MVD -> SCL
                new Ruta(Aeropuertos[0], Aeropuertos[2], 2100.0),   // MVD -> EZE
                new Ruta(Aeropuertos[1], Aeropuertos[3], 2600.0),   // SCL -> GRU
                new Ruta(Aeropuertos[2], Aeropuertos[4], 8500.0),   // EZE -> JFK
                new Ruta(Aeropuertos[3], Aeropuertos[5], 9800.0),   // GRU -> LAX
                new Ruta(Aeropuertos[4], Aeropuertos[6], 5850.0),   // JFK -> CDG
                new Ruta(Aeropuertos[5], Aeropuertos[7], 8750.0),   // LAX -> LHR
                new Ruta(Aeropuertos[6], Aeropuertos[8], 1050.0),   // CDG -> MAD
                new Ruta(Aeropuertos[7], Aeropuertos[9], 1030.0),   // LHR -> FRA
                new Ruta(Aeropuertos[8], Aeropuertos[10], 1480.0),  // MAD -> AMS
                new Ruta(Aeropuertos[9], Aeropuertos[11], 1330.0),  // FRA -> BCN
                new Ruta(Aeropuertos[10], Aeropuertos[12], 7800.0), // AMS -> MIA
                new Ruta(Aeropuertos[11], Aeropuertos[13], 7800.0), // BCN -> YYZ
                new Ruta(Aeropuertos[12], Aeropuertos[14], 11000.0),// MIA -> NRT
                new Ruta(Aeropuertos[13], Aeropuertos[15], 15500.0),// YYZ -> SYD
                new Ruta(Aeropuertos[14], Aeropuertos[16], 8200.0), // NRT -> DXB
                new Ruta(Aeropuertos[15], Aeropuertos[17], 12100.0),// SYD -> DOH
                new Ruta(Aeropuertos[16], Aeropuertos[18], 14600.0),// DXB -> LIM
                new Ruta(Aeropuertos[17], Aeropuertos[19], 13800.0),// DOH -> BOG
                new Ruta(Aeropuertos[1], Aeropuertos[0], 1500.0),   // SCL -> MVD
                new Ruta(Aeropuertos[4], Aeropuertos[0], 8500.0),   // JFK -> MVD
                new Ruta(Aeropuertos[5], Aeropuertos[2], 9900.0),   // LAX -> EZE
                new Ruta(Aeropuertos[3], Aeropuertos[6], 9400.0),   // GRU -> CDG
                new Ruta(Aeropuertos[6], Aeropuertos[0], 10800.0),  // CDG -> MVD
                new Ruta(Aeropuertos[7], Aeropuertos[5], 8750.0),   // LHR -> LAX
                new Ruta(Aeropuertos[8], Aeropuertos[3], 10200.0),  // MAD -> GRU
                new Ruta(Aeropuertos[9], Aeropuertos[2], 11200.0),  // FRA -> EZE
                new Ruta(Aeropuertos[10], Aeropuertos[0], 11400.0), // AMS -> MVD
                new Ruta(Aeropuertos[11], Aeropuertos[14], 11700.0),// BCN -> NRT
                new Ruta(Aeropuertos[18], Aeropuertos[0], 3200.0),  // LIM -> MVD    

            };
            Pasajes = new List<Pasaje>();
            Vuelos = new List<Vuelo>()
            {
                    new Vuelo("UX101", Rutas[0], Aviones[0], Frecuencia.lunes),
                    new Vuelo("UX102", Rutas[1], Aviones[1], Frecuencia.martes),
                    new Vuelo("UX103", Rutas[2], Aviones[2], Frecuencia.miercoles),
                    new Vuelo("UX104", Rutas[3], Aviones[3], Frecuencia.jueves),
                    new Vuelo("UX105", Rutas[4], Aviones[0], Frecuencia.viernes),
                    new Vuelo("UX106", Rutas[5], Aviones[1], Frecuencia.sabado),
                    new Vuelo("UX107", Rutas[6], Aviones[2], Frecuencia.domingo),
                    new Vuelo("UX108", Rutas[7], Aviones[3], Frecuencia.lunes),
                    new Vuelo("UX109", Rutas[8], Aviones[0], Frecuencia.martes),
                    new Vuelo("UX110", Rutas[9], Aviones[1], Frecuencia.miercoles),
                    new Vuelo("UX111", Rutas[10], Aviones[2], Frecuencia.jueves),
                    new Vuelo("UX112", Rutas[11], Aviones[3], Frecuencia.viernes),
                    new Vuelo("UX113", Rutas[12], Aviones[0], Frecuencia.sabado),
                    new Vuelo("UX114", Rutas[13], Aviones[1], Frecuencia.domingo),
                    new Vuelo("UX115", Rutas[14], Aviones[2], Frecuencia.lunes),
                    new Vuelo("UX116", Rutas[15], Aviones[3], Frecuencia.martes),
                    new Vuelo("UX117", Rutas[16], Aviones[0], Frecuencia.miercoles),
                    new Vuelo("UX118", Rutas[17], Aviones[1], Frecuencia.jueves),
                    new Vuelo("UX119", Rutas[18], Aviones[2], Frecuencia.viernes),
                    new Vuelo("UX120", Rutas[19], Aviones[3], Frecuencia.sabado),
                    new Vuelo("UX121", Rutas[20], Aviones[0], Frecuencia.domingo),
                    new Vuelo("UX122", Rutas[21], Aviones[1], Frecuencia.lunes),
                    new Vuelo("UX123", Rutas[22], Aviones[2], Frecuencia.martes),
                    new Vuelo("UX124", Rutas[23], Aviones[3], Frecuencia.miercoles),
                    new Vuelo("UX125", Rutas[24], Aviones[0], Frecuencia.jueves),
                    new Vuelo("UX126", Rutas[25], Aviones[1], Frecuencia.viernes),
                    new Vuelo("UX127", Rutas[26], Aviones[2], Frecuencia.sabado),
                    new Vuelo("UX128", Rutas[27], Aviones[3], Frecuencia.domingo),
                    new Vuelo("UX129", Rutas[28], Aviones[0], Frecuencia.lunes),
                    new Vuelo("UX130", Rutas[29], Aviones[1], Frecuencia.martes),
            };

            
            ;

            //PrecargarAdministradores();
        }

        #region Precargas
        //public void PrecargarDatos()
        //{
        //    //AgregarNuevoAdministrador("Agustin", "agustin@gmail.com", "1234");
        //    //AgregarNuevoAdministrador("Viviana", "viviana@gmail.com", "4321");

        //    PrecargarAdministradores();


        //}

        //private void PrecargarAdministradores()
        //{
        //    AgregarNuevoAdministrador(new Administrador("Agustin", "agustin@gmail.com", "1234"));
        //    AgregarNuevoAdministrador(new Administrador("Viviana", "viviana@gmail.com", "4321"));
        //}
        #endregion

        #region Cliente
        public void AgregarNuevoCliente()
        {
            Cliente unCliente = new Cliente();
            Clientes.Add(unCliente);
        }
        #endregion


        #region Administrador
        //OPCION 1
        //public void AgregarNuevoAdministrador(string apodo, string correo, string pass)
        //{
        //    Administrador unAdministrador = new Administrador(apodo,correo,pass);
        //    this.Administradores.Add(unAdministrador);
        //}

        //OPCION 2
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


        #region Aeropuerto
        public void AgregarNuevoAeropuerto(Aeropuerto unAeropuerto)
        {
            Aeropuertos.Add(unAeropuerto);
        }
        #endregion




    }

}
