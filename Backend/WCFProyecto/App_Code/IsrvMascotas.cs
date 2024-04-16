using Entidades;
using System.Collections.Generic;
using System.ServiceModel;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IsrvMascotas" in both code and config file together.
[ServiceContract]
public interface IsrvMascotas
{
    [OperationContract]
    void DoWork();

    [OperationContract]
    List<TVET_Mascotas> obtenerMascotas_ENT();

    [OperationContract]
    TVET_Mascotas obtenerMascotasXId_ENT(int pIdMascotas);

    [OperationContract]
    bool agregaMascotas_ENT(TVET_Mascotas pMascotas);

    [OperationContract]
    bool modificaMascotas_ENT(TVET_Mascotas pMascotas);

    [OperationContract]
    bool eliminarMascota(int pIdMascotas);
}