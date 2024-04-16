using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "srvCitas" in code, svc and config file together.
public class srvCitas : IsrvCitas
{
    private readonly ICitasLN _citasLN = new CitasLN();

    public List<TVET_Citas> obtenerCita_ENT()
    {
        List<TVET_Citas> listaCitas = new List<TVET_Citas>();
        try
        {
            listaCitas = _citasLN.obtenerCita_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return listaCitas;
    }

    public TVET_Citas obtenerCitaXId_ENT(int pIdCita)
    {
        TVET_Citas cita = new TVET_Citas();
        try
        {
            cita = _citasLN.obtenerCitaXId_ENT(pIdCita);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return cita;
    }

    public bool agregaCita_ENT(TVET_Citas pCita)
    {
        bool respuesta = false;
        try
        {
            respuesta = _citasLN.agregaCita_ENT(pCita);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool modificaCita_ENT(TVET_Citas pCita)
    {
        bool respuesta = false;
        try
        {
            respuesta = _citasLN.modificaCita_ENT(pCita);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool eliminaCita_ENT(int pIdCita)
    {
        bool respuesta = false;
        try
        {
            respuesta = _citasLN.eliminarCitaLN(pIdCita);
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