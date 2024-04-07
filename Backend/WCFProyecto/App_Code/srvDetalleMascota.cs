using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "srvDetalleMascota" in code, svc and config file together.
public class srvDetalleMascota : IsrvDetalleMascota
{
    private readonly IDetalleMascotaLN _detalleMascotaLN = new DetalleMascotaLN();

    public List<TVET_DetalleMascota> obtenerDetalle_ENT()
    {
        List<TVET_DetalleMascota> listaDetalles = new List<TVET_DetalleMascota>();
        try
        {
            listaDetalles = _detalleMascotaLN.obtenerDetalle_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return listaDetalles;
    }

    public TVET_DetalleMascota obtenerDetalleXId_ENT(int pIdDetalle)
    {
        TVET_DetalleMascota _detalleMascota = new TVET_DetalleMascota();
        try
        {
            _detalleMascota = _detalleMascotaLN.obtenerDetalleXId_ENT(pIdDetalle);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return _detalleMascota;
    }

    public bool agregadetalle_ENT(TVET_DetalleMascota pDetalle)
    {
        bool respuesta = false;
        try
        {
            respuesta = _detalleMascotaLN.agregadetalle_ENT(pDetalle);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool modificaDetalle_ENT(TVET_DetalleMascota pDetalle)
    {
        bool respuesta = false;
        try
        {
            respuesta = _detalleMascotaLN.modificaDetalle_ENT(pDetalle);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool eliminaDetalle_ENT(TVET_DetalleMascota pDetalle)
    {
        bool respuesta = false;
        try
        {
            respuesta = _detalleMascotaLN.eliminaDetalle_ENT(pDetalle);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public void DoWork()
    {
    }
}