using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion
{
    public class MascotasLN : IMascotasLN
    {
        public static VPEntidades lObjAWCnn = new VPEntidades();
        private readonly IMascotasAD gObjMascotasAD = new MascotasAD(lObjAWCnn);

        public List<TVET_Mascotas> obtenerMascotas_ENT()
        {
            List<TVET_Mascotas> lObjRespuesta =
                new List<TVET_Mascotas>();
            try
            {
                lObjRespuesta = gObjMascotasAD.obtenerMascotas_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public TVET_Mascotas obtenerMascotasXId_ENT(int pIdMascotas)
        {
            TVET_Mascotas lObjRespuesta =
                new TVET_Mascotas();
            try
            {
                lObjRespuesta = gObjMascotasAD.obtenerMascotasXId_ENT(pIdMascotas);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool agregaMascotas_ENT(TVET_Mascotas pMascotas)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjMascotasAD.agregaMascotas_ENT(pMascotas);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modificaMascotas_ENT(TVET_Mascotas pMascotas)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjMascotasAD.modificaMascotas_ENT(pMascotas);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool eliminaMascotas_ENT(TVET_Mascotas pMascotas)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjMascotasAD.eliminaMascotas_ENT(pMascotas);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }
    }
}