using AccesoDatos;
using AccesoDatos.Implementacion;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion
{
    public class CitasLN : ICitasLN
    {
        public static VeterinariaDBEntities lObjAWCnn = new VeterinariaDBEntities();
        private readonly CitasAD gObjCitasAD = new CitasAD(lObjAWCnn);

        public List<TVET_Citas> obtenerCita_ENT()
        {
            List<TVET_Citas> lObjRespuesta =
                new List<TVET_Citas>();
            try
            {
                lObjRespuesta = gObjCitasAD.obtenerCita_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public TVET_Citas obtenerCitaXId_ENT(int pIdCita)
        {
            TVET_Citas lObjRespuesta =
                new TVET_Citas();
            try
            {
                lObjRespuesta = gObjCitasAD.obtenerCitaXId_ENT(pIdCita);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool agregaCita_ENT(TVET_Citas pCita)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjCitasAD.agregaCita_ENT(pCita);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modificaCita_ENT(TVET_Citas pCita)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjCitasAD.modificaCita_ENT(pCita);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool eliminarCitaLN(int pIdCita)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjCitasAD.eliminarCitaAD(pIdCita);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }
    }
}