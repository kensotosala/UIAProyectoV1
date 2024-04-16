using Entidades;
using System.Collections.Generic;

namespace AccesoDatos.Interfaces
{
    public interface IClientesAD
    {
        List<TVE_Clientes> obtenerCliente_ENT();

        TVE_Clientes obtenerclienteXId_ENT(int pIdCliente);

        bool agregaCliente_ENT(TVE_Clientes pCliente);

        bool modificaCliente_ENT(TVE_Clientes pCliente);

        bool eliminarClienteAD(int pIdCliente);
    }
}