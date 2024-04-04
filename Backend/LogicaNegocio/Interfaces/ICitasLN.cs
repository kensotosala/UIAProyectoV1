using Entidades;
using System.Collections.Generic;

namespace LogicaNegocio.Interfaces
{
    public interface ICitasLN
    {
        List<TVET_Citas> obtenerCita_ENT();

        TVET_Citas obtenerCitaXId_ENT(int pIdCita);

        bool agregaCita_ENT(TVET_Citas pCita);

        bool modificaCita_ENT(TVET_Citas pCita);

        bool eliminaCita_ENT(TVET_Citas pCita);
    }
}