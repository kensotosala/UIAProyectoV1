using Entidades;
using System.Collections.Generic;
using System.ServiceModel;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IsrvDiagnostico" in both code and config file together.
[ServiceContract]
public interface IsrvDiagnostico
{
    [OperationContract]
    void DoWork();

    [OperationContract]
    List<TVET_Diagnostico> obtenerDiagnostico_ENT();

    [OperationContract]
    TVET_Diagnostico obtenerDiagnosticoXId_ENT(int pIdDiagnostico);

    [OperationContract]
    bool agregaDiagnostico_ENT(TVET_Diagnostico pDiagnostico);

    [OperationContract]
    bool modificaDiagnostico_ENT(TVET_Diagnostico pDiagnostico);

    [OperationContract]
    bool eliminaDiagnostico_ENT(TVET_Diagnostico pDiagnostico);
}