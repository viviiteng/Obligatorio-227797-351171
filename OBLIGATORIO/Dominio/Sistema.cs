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
            Pasajes = new List<Pasaje>();
            Vuelos = new List<Vuelo>();
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
