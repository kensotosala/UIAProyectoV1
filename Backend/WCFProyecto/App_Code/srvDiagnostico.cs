using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "srvDiagnostico" in code, svc and config file together.
public class srvDiagnostico : IsrvDiagnostico
{
    private readonly IDiagnosticoLN _diagnosticoLN = new DiagnosticoLN();

    public List<TVET_Diagnostico> obtenerDiagnostico_ENT()
    {
        List<TVET_Diagnostico> listaDiagnosticos = new List<TVET_Diagnostico>();
        try
        {
            listaDiagnosticos = _diagnosticoLN.obtenerDiagnostico_ENT();
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return listaDiagnosticos;
    }

    public TVET_Diagnostico obtenerDiagnosticoXId_ENT(int pIdDiagnostico)
    {
        TVET_Diagnostico diagnostico = new TVET_Diagnostico();
        try
        {
            diagnostico = _diagnosticoLN.obtenerDiagnosticoXId_ENT(pIdDiagnostico);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return diagnostico;
    }

    public bool agregaDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
    {
        bool respuesta = false;
        try
        {
            respuesta = _diagnosticoLN.agregaDiagnostico_ENT(pDiagnostico);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool modificaDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
    {
        bool respuesta = false;
        try
        {
            respuesta = _diagnosticoLN.modificaDiagnostico_ENT(pDiagnostico);
        }
        catch (Exception lEx)
        {
            throw lEx;
        }
        return respuesta;
    }

    public bool eliminaDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
    {
        bool respuesta = false;
        try
        {
            respuesta = _diagnosticoLN.eliminaDiagnostico_ENT(pDiagnostico);
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