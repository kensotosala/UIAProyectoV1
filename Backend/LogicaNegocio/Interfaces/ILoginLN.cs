using Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface ILoginLN
    {
        bool iniciarSesion(string usuario, string password);
    }
}