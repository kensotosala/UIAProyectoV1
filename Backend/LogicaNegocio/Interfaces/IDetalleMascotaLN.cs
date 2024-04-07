using Entidades;
using System.Collections.Generic;

namespace LogicaNegocio.Interfaces
{
    public interface IDetalleMascotaLN
    {
        List<TVET_DetalleMascota> obtenerDetalle_ENT();

        TVET_DetalleMascota obtenerDetalleXId_ENT(int pIdDetalle);

        bool agregadetalle_ENT(TVET_DetalleMascota pDetalle);

        bool modificaDetalle_ENT(TVET_DetalleMascota pDetalle);

        bool eliminaDetalle_ENT(TVET_DetalleMascota pDetalle);
    }
}