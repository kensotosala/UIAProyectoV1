using AccesoDatos.Interfaces;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class LoginAD : ILoginAD
    {
        private UsersVETEntities usersEntities;

        public LoginAD(UsersVETEntities _users)
        {
            usersEntities = _users;
        }

        //public bool iniciarSesion(string usuario, string password)
        //{
        //    bool respuesta = false;
        //    try
        //    {
        //        var resultado = usersEntities.SP_Login(usuario, password);

        //        if (resultado != null)
        //        {
        //            if (resultado.Equals("Login exitoso. Bienvenido."))
        //            {
        //                respuesta = true;
        //            }
        //            else
        //            {
        //                respuesta = false;
        //            }
        //        }
        //        else
        //        {
        //            respuesta = false;
        //        }
        //    }
        //    catch (Exception lEx)
        //    {
        //        throw lEx;
        //    }
        //    return respuesta;
        //}

        public bool iniciarSesion(string usuario, string password)
        {
            bool respuesta = false;
            try
            {
                // Crear un objeto de contexto de base de datos usando Entity Framework
                using (var context = new UsersVETEntities())
                {
                    // Ejecutar el procedimiento almacenado y obtener el resultado
                    var resultado = context.Database.SqlQuery<string>("EXEC SP_Login @Usuario, @Contrasenha",
                        new SqlParameter("Usuario", usuario),
                        new SqlParameter("Contrasenha", password)).FirstOrDefault();

                    if (resultado != null)
                    {
                        if (resultado == "Login exitoso. Bienvenido.")
                        {
                            respuesta = true;
                        }
                        else
                        {
                            respuesta = false;
                        }
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return respuesta;
        }
    }
}