using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class ClientesAD : IClientesAD
    {
        private VeterinariaDBEntities gObjCnnAW;

        public ClientesAD(VeterinariaDBEntities lObjCnnAW)
        {
            gObjCnnAW = lObjCnnAW;
        }

        public List<TVE_Clientes> obtenerCliente_ENT()
        {
            List<TVE_Clientes> lObjRespuesta =
                new List<TVE_Clientes>();
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                lObjRespuesta = gObjCnnAW.TVE_Clientes.ToList();
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

        public TVE_Clientes obtenerclienteXId_ENT(int pIdCliente)
        {
            TVE_Clientes lObjRespuesta =
                new TVE_Clientes();
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                lObjRespuesta =
                    gObjCnnAW.TVE_Clientes.ToList().Find(x => x.TN_IdCliente == pIdCliente);
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

        public bool agregaCliente_ENT(TVE_Clientes pCliente)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVE_Clientes.Find(pCliente.TN_IdCliente);
                if (lRegistroEncontrado == null)
                {
                    gObjCnnAW.TVE_Clientes.Add(pCliente);
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

        public bool modificaCliente_ENT(TVE_Clientes pCliente)
        {
            bool lObjRespuesta = false;
            try
            {
                gObjCnnAW.Configuration.ProxyCreationEnabled = false;
                var lRegistroEncontrado = gObjCnnAW.TVE_Clientes.Find(pCliente.TN_IdCliente);
                if (lRegistroEncontrado != null)
                {
                    gObjCnnAW.Entry(lRegistroEncontrado).CurrentValues.SetValues(pCliente);
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

        public bool eliminarClienteAD(int pIdCliente)
        {
            bool lObjRespuesta = false;
            try
            {
                using (var context = new VeterinariaDBEntities())
                {
                    var resultado = context.Database.ExecuteSqlCommand("EXEC spEliminarClienteYRelacionados @IdCliente",
                        new SqlParameter("IdCliente", pIdCliente));

                    if (resultado > 0)
                    {
                        lObjRespuesta = false;
                    }
                    else
                    {
                        lObjRespuesta = true;
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }
    }
}