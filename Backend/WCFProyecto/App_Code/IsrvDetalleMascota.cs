using Entidades;
using System.Collections.Generic;
using System.ServiceModel;

[ServiceContract]
public interface IsrvDetalleMascota
{
    [OperationContract]
    void DoWork();

    [OperationContract]
    List<TVET_DetalleMascota> obtenerDetalle_ENT();

    [OperationContract]
    TVET_DetalleMascota obtenerDetalleXId_ENT(int pIdDetalle);

    [OperationContract]
    bool agregadetalle_ENT(TVET_DetalleMascota pDetalle);

    [OperationContract]
    bool modificaDetalle_ENT(TVET_DetalleMascota pDetalle);

    [OperationContract]
    bool eliminaDetalle_ENT(TVET_DetalleMascota pDetalle);
}