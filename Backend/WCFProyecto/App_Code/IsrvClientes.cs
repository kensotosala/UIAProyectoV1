using Entidades;
using System.Collections.Generic;
using System.ServiceModel;

[ServiceContract]
public interface IsrvClientes
{
    [OperationContract]
    void DoWork();

    [OperationContract]
    List<TVE_Clientes> obtenerCliente_ENT();

    [OperationContract]
    TVE_Clientes obtenerclienteXId_ENT(int pIdCliente);

    [OperationContract]
    bool agregaCliente_ENT(TVE_Clientes pCliente);

    [OperationContract]
    bool modificaCliente_ENT(TVE_Clientes pCliente);

    [OperationContract]
    bool eliminaCliente_ENT(int pIdCliente);
}