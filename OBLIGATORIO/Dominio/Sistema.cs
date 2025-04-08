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
            Pasajes = new List<Pasaje>();
            Vuelos = new List<Vuelo>();
            Aviones = new List<Avion>();
            Aeropuertos = new List<Aeropuerto>();

            PrecargarAdministradores();
        }

        #region Precargas
        //public void PrecargarDatos()
        //{
        //    //AgregarNuevoAdministrador("Agustin", "agustin@gmail.com", "1234");
        //    //AgregarNuevoAdministrador("Viviana", "viviana@gmail.com", "4321");

        //    PrecargarAdministradores();


        //}

        private void PrecargarAdministradores()
        {
            AgregarNuevoAdministrador(new Administrador("Agustin", "agustin@gmail.com", "1234"));
            AgregarNuevoAdministrador(new Administrador("Viviana", "viviana@gmail.com", "4321"));
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
