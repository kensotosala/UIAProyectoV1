using Entidades;
using System.Collections.Generic;

namespace AccesoDatos.Interfaces
{
    public interface IMascotasAD
    {
        List<TVET_Mascotas> obtenerMascotas_ENT();

        TVET_Mascotas obtenerMascotasXId_ENT(int pIdMascotas);

        bool agregaMascotas_ENT(TVET_Mascotas pMascotas);

        bool modificaMascotas_ENT(TVET_Mascotas pMascotas);

        bool eliminarMascotaAD(int pIdMascotas);
    }
}