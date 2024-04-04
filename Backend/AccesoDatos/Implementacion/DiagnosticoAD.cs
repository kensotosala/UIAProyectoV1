using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class DiagnosticoAD : IDiagnosticoAD
    {
        private VPEntidades gObjCnnAW;

        public DiagnosticoAD(VPEntidades lObjCnnAW)
        {
            gObjCnnAW = lObjCnnAW;
        }

        public List<TVET_Diagnostico> obtenerDiagnostico_ENT()
        {
            List<TVET_Diagnostico> lObjRespuesta =
                new List<TVET_Diagnostico>();
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                lObjRespuesta = gObjCnnAW.TVET_Diagnostico.ToList();
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

        public TVET_Diagnostico obtenerDiagnosticoXId_ENT(int pIdDiagnostico)
        {
            TVET_Diagnostico lObjRespuesta =
                new TVET_Diagnostico();
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                lObjRespuesta =
                    gObjCnnAW.TVET_Diagnostico.ToList().Find(x => x.TN_IdDiagnostico == pIdDiagnostico);
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

        public bool agregaDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVET_Diagnostico.Find(pDiagnostico.TN_IdDiagnostico);
                if (lRegistroEncontrado == null)
                {
                    gObjCnnAW.TVET_Diagnostico.Add(pDiagnostico);
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

        public bool modificaDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVET_Diagnostico.Find(pDiagnostico.TN_IdDiagnostico);
                if (lRegistroEncontrado != null)
                {
                    gObjCnnAW.Entry(lRegistroEncontrado).CurrentValues.SetValues(pDiagnostico);
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

        public bool eliminaDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVET_Diagnostico.Find(pDiagnostico.TN_IdDiagnostico);
                if (lRegistroEncontrado != null)
                {
                    gObjCnnAW.Entry(lRegistroEncontrado).CurrentValues.SetValues(pDiagnostico);
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