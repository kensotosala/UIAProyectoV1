using AccesoDatos;
using AccesoDatos.Implementacion;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion
{
    public class ClienteLN : IClientesLN
    {
        public static VPEntidades lObjAWCnn = new VPEntidades();
        private readonly ClientesAD gObjClienteAD = new ClientesAD(lObjAWCnn);

        public List<TVE_Clientes> obtenerCliente_ENT()
        {
            List<TVE_Clientes> lObjRespuesta =
                new List<TVE_Clientes>();
            try
            {
                lObjRespuesta = gObjClienteAD.obtenerCliente_ENT();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public TVE_Clientes obtenerclienteXId_ENT(int pIdCliente)
        {
            TVE_Clientes lObjRespuesta =
                new TVE_Clientes();
            try
            {
                lObjRespuesta = gObjClienteAD.obtenerclienteXId_ENT(pIdCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool agregaCliente_ENT(TVE_Clientes pCliente)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjClienteAD.agregaCliente_ENT(pCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modificaCliente_ENT(TVE_Clientes pCliente)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjClienteAD.modificaCliente_ENT(pCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool eliminaCliente_ENT(TVE_Clientes pCliente)
        {
            bool lObjRespuesta = false;
            try
            {
                lObjRespuesta = gObjClienteAD.eliminaCliente_ENT(pCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }
    }
}