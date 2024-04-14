using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using LogicaNegocio.Interfaces;
using System;

namespace LogicaNegocio.Implementacion
{
    public class LoginLN : ILoginLN
    {
        public static UsersVETEntities _usersVETEntities = new UsersVETEntities();
        private readonly ILoginAD _loginAD = new LoginAD(_usersVETEntities);

        public bool iniciarSesion(string usuario, string password)
        {
            bool respuesta = false;
            try
            {
                respuesta = _loginAD.iniciarSesion(usuario, password);
            }
            catch (Exception ex)
            {
                throw;
            }
            return respuesta;
        }
    }
}