namespace AccesoDatos.Interfaces
{
    public interface ILoginAD
    {
        bool iniciarSesion(string usuario, string contraseña);
    }
}