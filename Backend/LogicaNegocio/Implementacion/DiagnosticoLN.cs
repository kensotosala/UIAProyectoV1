using AccesoDatos;
using AccesoDatos.Implementacion;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion
{
    public class DiagnosticoLN : IDiagnosticoLN
    {
        public static VeterinariaDBEntities lObjAWCnn = new VeterinariaDBEntities();
        private readonly DiagnosticoAD gObjdiagnosticoAD = new DiagnosticoAD(lObjAWCnn);

        public List<TVET_Diagnostico> obtenerDiagnostico_ENT()
        {
            List<TVET_Diagnostico> lObjRespuesta =
                new List<TVET_Diagnostico>();
            try
            {
                lObjRespuesta = gObjdiagnosticoAD.obtenerDiagnostico_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public TVET_Diagnostico obtenerDiagnosticoXId_ENT(int pIdDiagnostico)
        {
            TVET_Diagnostico lObjRespuesta =
                new TVET_Diagnostico();
            try
            {
                lObjRespuesta = gObjdiagnosticoAD.obtenerDiagnosticoXId_ENT(pIdDiagnostico);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool agregaDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjdiagnosticoAD.agregaDiagnostico_ENT(pDiagnostico);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modificaDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjdiagnosticoAD.modificaDiagnostico_ENT(pDiagnostico);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool eliminaDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjdiagnosticoAD.eliminaDiagnostico_ENT(pDiagnostico);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }
    }
}