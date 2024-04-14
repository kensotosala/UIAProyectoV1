using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;

public class srvLogin : IsrvLogin
{
    private readonly ILoginLN _loginLN;

    public srvLogin()
    {
        _loginLN = new LoginLN();
    }

    public void DoWork()
    {
    }

    public bool iniciarSesion(string usuario, string password)
    {
        bool respuesta = false;
        try
        {
            respuesta = _loginLN.iniciarSesion(usuario, password);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return respuesta;
    }
}