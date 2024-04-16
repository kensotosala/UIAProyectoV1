using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

public class srvClientes : IsrvClientes
{
    private readonly IClientesLN _clientesLN = new ClienteLN();

    public List<TVE_Clientes> obtenerCliente_ENT()
    {
        List<TVE_Clientes> listaClientes = new List<TVE_Clientes>();
        try
        {
            listaClientes = _clientesLN.obtenerCliente_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return listaClientes;
    }

    public TVE_Clientes obtenerclienteXId_ENT(int pIdCliente)
    {
        TVE_Clientes cliente = new TVE_Clientes();
        try
        {
            cliente = _clientesLN.obtenerclienteXId_ENT(pIdCliente);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return cliente;
    }

    public bool agregaCliente_ENT(TVE_Clientes pCliente)
    {
        bool respuesta = false;
        try
        {
            respuesta = _clientesLN.agregaCliente_ENT(pCliente);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool modificaCliente_ENT(TVE_Clientes pCliente)
    {
        bool respuesta = false;
        try
        {
            respuesta = _clientesLN.modificaCliente_ENT(pCliente);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool eliminaCliente_ENT(int pIdCliente)
    {
        bool respuesta = false;
        try
        {
            respuesta = _clientesLN.eliminarClienteLN(pIdCliente);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public void DoWork()
    {
        throw new NotImplementedException();
    }
}