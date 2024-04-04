using Entidades;
using System.Collections.Generic;

namespace LogicaNegocio.Interfaces
{
    public interface IMascotasLN
    {
        List<TVET_Mascotas> obtenerMascotas_ENT();

        TVET_Mascotas obtenerMascotasXId_ENT(int pIdMascotas);

        bool agregaMascotas_ENT(TVET_Mascotas pMascotas);

        bool modificaMascotas_ENT(TVET_Mascotas pMascotas);

        bool eliminaMascotas_ENT(TVET_Mascotas pMascotas);
    }
}