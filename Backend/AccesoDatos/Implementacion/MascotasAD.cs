using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class MascotasAD : IMascotasAD
    {
        private VPEntidades gObjCnnAW;

        public MascotasAD(VPEntidades lObjCnnAW)
        {
            gObjCnnAW = lObjCnnAW;
        }

        public List<TVET_Mascotas> obtenerMascotas_ENT()
        {
            List<TVET_Mascotas> lObjRespuesta =
                new List<TVET_Mascotas>();
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                lObjRespuesta = gObjCnnAW.TVET_Mascotas.ToList();
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

        public TVET_Mascotas obtenerMascotasXId_ENT(int pIdMascotas)
        {
            TVET_Mascotas lObjRespuesta =
                new TVET_Mascotas();
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                lObjRespuesta =
                    gObjCnnAW.TVET_Mascotas.ToList().Find(x => x.TN_IdMascota == pIdMascotas);
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

        public bool agregaMascotas_ENT(TVET_Mascotas pMascotas)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVET_Mascotas.Find(pMascotas.TN_IdMascota);
                if (lRegistroEncontrado == null)
                {
                    gObjCnnAW.TVET_Mascotas.Add(pMascotas);
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

        public bool modificaMascotas_ENT(TVET_Mascotas pMascotas)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVET_Mascotas.Find(pMascotas.TN_IdMascota);
                if (lRegistroEncontrado != null)
                {
                    gObjCnnAW.Entry(lRegistroEncontrado).CurrentValues.SetValues(pMascotas);
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

        public bool eliminaMascotas_ENT(TVET_Mascotas pMascotas)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVET_Mascotas.Find(pMascotas.TN_IdMascota);
                if (lRegistroEncontrado != null)
                {
                    gObjCnnAW.Entry(lRegistroEncontrado).CurrentValues.SetValues(pMascotas);
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