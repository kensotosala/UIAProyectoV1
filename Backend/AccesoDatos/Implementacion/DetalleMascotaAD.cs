using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class DetalleMascotaAD : IDetalleMascotaAD
    {
        private VeterinariaDBEntities gObjCnnAW;

        public DetalleMascotaAD(VeterinariaDBEntities lObjCnnAW)
        {
            gObjCnnAW = lObjCnnAW;
        }

        public List<TVET_DetalleMascota> obtenerDetalle_ENT()
        {
            List<TVET_DetalleMascota> lObjRespuesta =
                new List<TVET_DetalleMascota>();
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                lObjRespuesta = gObjCnnAW.TVET_DetalleMascota.ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = true;
            }
            return lObjRespuesta;
        }

        public TVET_DetalleMascota obtenerDetalleXId_ENT(int pIdDetalle)
        {
            TVET_DetalleMascota lObjRespuesta =
                new TVET_DetalleMascota();
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                lObjRespuesta =
                    gObjCnnAW.TVET_DetalleMascota.ToList().Find(x => x.TN_IdMascota == pIdDetalle);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = true;
            }
            return lObjRespuesta;
        }

        public bool agregadetalle_ENT(TVET_DetalleMascota pDetalle)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVET_DetalleMascota.Find(pDetalle.TN_IdMascota);
                if (lRegistroEncontrado == null)
                {
                    gObjCnnAW.TVET_DetalleMascota.Add(pDetalle);
                    gObjCnnAW.SaveChanges();
                    lObjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = true;
            }
            return lObjRespuesta;
        }

        public bool modificaDetalle_ENT(TVET_DetalleMascota pDetalle)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVET_DetalleMascota.Find(pDetalle.TN_IdMascota);
                if (lRegistroEncontrado != null)
                {
                    gObjCnnAW.Entry(lRegistroEncontrado).CurrentValues.SetValues(pDetalle);
                    gObjCnnAW.Entry(lRegistroEncontrado).State = EntityState.Modified;
                    gObjCnnAW.SaveChanges();
                    lObjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = true;
            }
            return lObjRespuesta;
        }

        public bool eliminaDetalle_ENT(TVET_DetalleMascota pDetalle)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVET_DetalleMascota.Find(pDetalle.TN_IdMascota);
                if (lRegistroEncontrado != null)
                {
                    gObjCnnAW.Entry(lRegistroEncontrado).CurrentValues.SetValues(pDetalle);
                    gObjCnnAW.Entry(lRegistroEncontrado).State = EntityState.Deleted;
                    gObjCnnAW.SaveChanges();
                    lObjRespuesta = true;
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            finally
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = true;
            }
            return lObjRespuesta;
        }
    }
}