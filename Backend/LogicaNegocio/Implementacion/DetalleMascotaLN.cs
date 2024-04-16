using AccesoDatos;
using AccesoDatos.Implementacion;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion
{
    public class DetalleMascotaLN : IDetalleMascotaLN
    {
        public static VeterinariaDBEntities lObjAWCnn = new VeterinariaDBEntities();
        private readonly DetalleMascotaAD gObjDetalleAD = new DetalleMascotaAD(lObjAWCnn);

        public List<TVET_DetalleMascota> obtenerDetalle_ENT()
        {
            List<TVET_DetalleMascota> lObjRespuesta =
                new List<TVET_DetalleMascota>();
            try
            {
                lObjRespuesta = gObjDetalleAD.obtenerDetalle_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public TVET_DetalleMascota obtenerDetalleXId_ENT(int pIdDetalle)
        {
            TVET_DetalleMascota lObjRespuesta =
                new TVET_DetalleMascota();
            try
            {
                lObjRespuesta = gObjDetalleAD.obtenerDetalleXId_ENT(pIdDetalle);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool agregadetalle_ENT(TVET_DetalleMascota pDetalle)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjDetalleAD.agregadetalle_ENT(pDetalle);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modificaDetalle_ENT(TVET_DetalleMascota pDetalle)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjDetalleAD.modificaDetalle_ENT(pDetalle);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool eliminaDetalle_ENT(TVET_DetalleMascota pDetalle)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjDetalleAD.eliminaDetalle_ENT(pDetalle);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }
    }
}