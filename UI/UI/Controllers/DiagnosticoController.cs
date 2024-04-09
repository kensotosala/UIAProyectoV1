using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class DiagnosticoController : Controller
    {
        public ActionResult obtenerDiagnosticos()
        {
            List<Diagnostico> baseDiagnostico = new List<Diagnostico>();
            Diagnostico diagnostico;

            try
            {
                using (srvDiagnostico.IsrvDiagnosticoClient srvDG = new srvDiagnostico.IsrvDiagnosticoClient())
                {
                    var respuesta = srvDG.obtenerDiagnostico_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            diagnostico = new Diagnostico();
                            diagnostico.TN_IdDiagnostico = item.TN_IdDiagnostico;
                            diagnostico.TN_IdCita = (int)item.TN_IdCita;
                            diagnostico.TC_DscDiagnostico = item.TC_DscDiagnostico;
                            baseDiagnostico.Add(diagnostico);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(baseDiagnostico);
        }

        public ActionResult agregarDiagnostico()
        {
            Diagnostico diagnostico = new Diagnostico();

            using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
            {
                var citas = ConvertirCitas(srvCT.obtenerCita_ENT());
                diagnostico.Citas = citas.Select(c => new SelectListItem
                {
                    Value = c.TN_IdCita.ToString(),
                    Text = c.TN_IdCita.ToString(),
                });
            }

            return View(diagnostico);
        }

        private List<Cita> ConvertirCitas(srvCitas.TVET_Citas[] citas)
        {
            List<Cita> listaCitas = new List<Cita>();
            foreach (var c in citas)
            {
                var nuevaCita = new Cita
                {
                    TN_IdCita = c.TN_IdCita,
                };
                listaCitas.Add(nuevaCita);
            }
            return listaCitas;
        }

        public ActionResult eliminarDiagnostico(int pIdDiagnostico)
        {
            Diagnostico diagnostico = new Diagnostico();
            try
            {
                using (srvDiagnostico.IsrvDiagnosticoClient srvDG = new srvDiagnostico.IsrvDiagnosticoClient())
                {
                    var respuesta = srvDG.obtenerDiagnosticoXId_ENT(pIdDiagnostico);
                    diagnostico.TN_IdDiagnostico = respuesta.TN_IdDiagnostico;
                    diagnostico.TN_IdCita = (int)respuesta.TN_IdCita;
                    diagnostico.TC_DscDiagnostico = respuesta.TC_DscDiagnostico;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(diagnostico);
        }

        public ActionResult modificarDiagnostico(int pIdDiagnostico)
        {
            Diagnostico diagnostico = new Diagnostico();
            try
            {
                using (srvDiagnostico.IsrvDiagnosticoClient srvDG = new srvDiagnostico.IsrvDiagnosticoClient())
                {
                    var respuesta = srvDG.obtenerDiagnosticoXId_ENT(pIdDiagnostico);
                    diagnostico.TN_IdDiagnostico = respuesta.TN_IdDiagnostico;
                    diagnostico.TN_IdCita = (int)respuesta.TN_IdCita;
                    diagnostico.TC_DscDiagnostico = respuesta.TC_DscDiagnostico;
                }

                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    var respuesta = srvCT.obtenerCita_ENT();

                    var lstCitas = respuesta.Select(c => new SelectListItem
                    {
                        Value = c.TN_IdCita.ToString(),
                        Text = c.TN_IdCita.ToString(),
                    });

                    diagnostico.Citas = lstCitas;
                }
            }
            catch (FaultException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving the Cita details." + ex.Message;
            }

            return View(diagnostico);
        }

        public ActionResult detalleDiagnostico(int pIdDiagnostico)
        {
            Diagnostico diagnostico = new Diagnostico();
            try
            {
                using (srvDiagnostico.IsrvDiagnosticoClient srvDG = new srvDiagnostico.IsrvDiagnosticoClient())
                {
                    var respuesta = srvDG.obtenerDiagnosticoXId_ENT(pIdDiagnostico);
                    diagnostico.TN_IdDiagnostico = respuesta.TN_IdDiagnostico;
                    diagnostico.TN_IdCita = (int)respuesta.TN_IdCita;
                    diagnostico.TC_DscDiagnostico = respuesta.TC_DscDiagnostico;
                }

                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    ViewBag.Citas = ConvertirCitas(srvCT.obtenerCita_ENT());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(diagnostico);
        }

        // A C C I O N E S

        public ActionResult insertarDiagnostico(Diagnostico pDiagnostico)
        {
            List<Diagnostico> lstDiagnostico = new List<Diagnostico>();
            Diagnostico diagnostico;

            try
            {
                using (srvDiagnostico.IsrvDiagnosticoClient srvDG = new srvDiagnostico.IsrvDiagnosticoClient())
                {
                    srvDiagnostico.TVET_Diagnostico objDG = new srvDiagnostico.TVET_Diagnostico();
                    objDG.TN_IdDiagnostico = pDiagnostico.TN_IdDiagnostico;
                    objDG.TN_IdCita = pDiagnostico.TN_IdCita;
                    objDG.TC_DscDiagnostico = pDiagnostico.TC_DscDiagnostico;

                    srvDG.agregaDiagnostico_ENT(objDG);

                    var respuesta = srvDG.obtenerDiagnostico_ENT();

                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            diagnostico = new Diagnostico();
                            diagnostico.TN_IdDiagnostico = item.TN_IdDiagnostico;
                            diagnostico.TN_IdCita = (int)item.TN_IdCita;
                            diagnostico.TC_DscDiagnostico = item.TC_DscDiagnostico;
                            lstDiagnostico.Add(diagnostico);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerDiagnosticos");
        }

        public ActionResult borrarDiagnostico(Diagnostico pDiagnostico)
        {
            List<Diagnostico> lstDiagnostico = new List<Diagnostico>();
            Diagnostico diagnostico;

            try
            {
                using (srvDiagnostico.IsrvDiagnosticoClient srvDG = new srvDiagnostico.IsrvDiagnosticoClient())
                {
                    srvDiagnostico.TVET_Diagnostico objDG = new srvDiagnostico.TVET_Diagnostico();
                    objDG.TN_IdDiagnostico = pDiagnostico.TN_IdDiagnostico;
                    objDG.TN_IdCita = pDiagnostico.TN_IdCita;
                    objDG.TC_DscDiagnostico = pDiagnostico.TC_DscDiagnostico;

                    srvDG.eliminaDiagnostico_ENT(objDG);

                    var respuesta = srvDG.obtenerDiagnostico_ENT();

                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            diagnostico = new Diagnostico();
                            diagnostico.TN_IdDiagnostico = item.TN_IdDiagnostico;
                            diagnostico.TN_IdCita = (int)item.TN_IdCita;
                            diagnostico.TC_DscDiagnostico = item.TC_DscDiagnostico;
                            lstDiagnostico.Add(diagnostico);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerDiagnosticos");
        }

        private ActionResult actualizarDiagnostico(Diagnostico pDiagnostico)
        {
            List<Diagnostico> lstDiagnostico = new List<Diagnostico>();
            Diagnostico diagnostico;

            try
            {
                using (srvDiagnostico.IsrvDiagnosticoClient srvDG = new srvDiagnostico.IsrvDiagnosticoClient())
                {
                    srvDiagnostico.TVET_Diagnostico objDG = new srvDiagnostico.TVET_Diagnostico();
                    objDG.TN_IdDiagnostico = pDiagnostico.TN_IdDiagnostico;
                    objDG.TN_IdCita = pDiagnostico.TN_IdCita;
                    objDG.TC_DscDiagnostico = pDiagnostico.TC_DscDiagnostico;

                    srvDG.modificaDiagnostico_ENT(objDG);

                    var respuesta = srvDG.obtenerDiagnostico_ENT();

                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            diagnostico = new Diagnostico();
                            diagnostico.TN_IdDiagnostico = item.TN_IdDiagnostico;
                            diagnostico.TN_IdCita = (int)item.TN_IdCita;
                            diagnostico.TC_DscDiagnostico = item.TC_DscDiagnostico;
                            lstDiagnostico.Add(diagnostico);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerDiagnosticos");
        }

        public ActionResult accionesEjecucion(string accionEjecutar, Diagnostico pDiagnostico)
        {
            try
            {
                switch (accionEjecutar)
                {
                    case "Agregar":
                        return insertarDiagnostico(pDiagnostico);

                    case "Modificar":
                        return actualizarDiagnostico(pDiagnostico);

                    case "Borrar":
                        return borrarDiagnostico(pDiagnostico);

                    default:
                        return RedirectToAction("obtenerDiagnosticos");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}