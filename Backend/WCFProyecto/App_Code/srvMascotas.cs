using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "srvMascotas" in code, svc and config file together.
public class srvMascotas : IsrvMascotas
{
    private readonly IMascotasLN _mascotasLN = new MascotasLN();

    public List<TVET_Mascotas> obtenerMascotas_ENT()
    {
        List<TVET_Mascotas> listaMascotas = new List<TVET_Mascotas>();
        try
        {
            listaMascotas = _mascotasLN.obtenerMascotas_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return listaMascotas;
    }

    public TVET_Mascotas obtenerMascotasXId_ENT(int pIdMascotas)
    {
        TVET_Mascotas mascota = new TVET_Mascotas();
        try
        {
            mascota = _mascotasLN.obtenerMascotasXId_ENT(pIdMascotas);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return mascota;
    }

    public bool agregaMascotas_ENT(TVET_Mascotas pMascotas)
    {
        bool respuesta = false;
        try
        {
            respuesta = _mascotasLN.agregaMascotas_ENT(pMascotas);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool modificaMascotas_ENT(TVET_Mascotas pMascotas)
    {
        bool respuesta = false;
        try
        {
            respuesta = _mascotasLN.modificaMascotas_ENT(pMascotas);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool eliminaMascotas_ENT(TVET_Mascotas pMascotas)
    {
        bool respuesta = false;
        try
        {
            respuesta = _mascotasLN.eliminaMascotas_ENT(pMascotas);
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