using Entidades;
using System.Collections.Generic;

namespace AccesoDatos.Interfaces
{
    public interface IDetalleMascotaAD
    {
        List<TVET_DetalleMascota> obtenerDetalle_ENT();

        TVET_DetalleMascota obtenerDetalleXId_ENT(int pIdDetalle);

        bool agregadetalle_ENT(TVET_DetalleMascota pDetalle);

        bool modificaDetalle_ENT(TVET_DetalleMascota pDetalle);

        bool eliminaDetalle_ENT(TVET_DetalleMascota pDetalle);
    }
}