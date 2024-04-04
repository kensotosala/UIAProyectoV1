using Entidades;
using System.Collections.Generic;

namespace AccesoDatos.Interfaces
{
    public interface IDiagnosticoAD
    {
        List<TVET_Diagnostico> obtenerDiagnostico_ENT();

        TVET_Diagnostico obtenerDiagnosticoXId_ENT(int pIdDiagnostico);

        bool agregaDiagnostico_ENT(TVET_Diagnostico pDiagnostico);

        bool modificaDiagnostico_ENT(TVET_Diagnostico pDiagnostico);

        bool eliminaDiagnostico_ENT(TVET_Diagnostico pDiagnostico);
    }
}