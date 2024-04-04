using Entidades;
using System.Collections.Generic;
using System.ServiceModel;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IsrvCitas" in both code and config file together.
[ServiceContract]
public interface IsrvCitas
{
    [OperationContract]
    void DoWork();

    [OperationContract]
    List<TVET_Citas> obtenerCita_ENT();

    [OperationContract]
    TVET_Citas obtenerCitaXId_ENT(int pIdCita);

    [OperationContract]
    bool agregaCita_ENT(TVET_Citas pCita);

    [OperationContract]
    bool modificaCita_ENT(TVET_Citas pCita);

    [OperationContract]
    bool eliminaCita_ENT(TVET_Citas pCita);
}