using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;

namespace UI.Models
{
    public class DetallesMascotaController : Controller
    {
        public ActionResult obtenerDetallesMascota()
        {
            List<DetallesMascota> repoDetallesMascota = new List<DetallesMascota>();
            DetallesMascota detallesMascota;
            try
            {
                using (srvDetalleMascota.IsrvDetalleMascotaClient srvDM = new srvDetalleMascota.IsrvDetalleMascotaClient())
                {
                    var respuesta = srvDM.obtenerDetalle_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var obj in respuesta)
                        {
                            detallesMascota = new DetallesMascota();
                            detallesMascota.TN_IdMascota = obj.TN_IdMascota;
                            detallesMascota.TC_Raza = obj.TC_Raza;
                            detallesMascota.TN_Peso = obj.TN_Peso;
                            detallesMascota.TC_Color = obj.TC_Color;
                            repoDetallesMascota.Add(detallesMascota);
                        }
                    }
                }

                using (srvMascotas.IsrvMascotasClient srvMS = new srvMascotas.IsrvMascotasClient())
                {
                    var lstMascotas = srvMS.obtenerMascotas_ENT();
                    ViewBag.Mascotas = ConvertirMascotas(lstMascotas);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(repoDetallesMascota);
        }

        public ActionResult agregarDetalleMascota()
        {
            DetallesMascota detalleMascota = new DetallesMascota();
            using (srvMascotas.IsrvMascotasClient srvMS = new srvMascotas.IsrvMascotasClient())
            {
                var mascotas = ConvertirMascotas(srvMS.obtenerMascotas_ENT());
                detalleMascota.Mascotas = mascotas.Select(x => new SelectListItem
                {
                    Value = x.TN_IdMascota.ToString(),
                    Text = x.TC_NombreMascota
                });
            }

            return View(detalleMascota);
        }

        private List<Mascotas> ConvertirMascotas(srvMascotas.TVET_Mascotas[] mascotas)
        {
            List<Mascotas> listaMascotas = new List<Mascotas>();
            foreach (var m in mascotas)
            {
                var nuevaMascota = new Mascotas
                {
                    TN_IdMascota = m.TN_IdMascota,
                    TC_NombreMascota = m.TC_NombreMascota,
                };
                listaMascotas.Add(nuevaMascota);
            }
            return listaMascotas;
        }

        public ActionResult modificarDetalles(int pIdDetalle)
        {
            DetallesMascota detalle = new DetallesMascota();
            try
            {
                using (srvDetalleMascota.IsrvDetalleMascotaClient srvDM = new srvDetalleMascota.IsrvDetalleMascotaClient())
                {
                    var respuesta = srvDM.obtenerDetalleXId_ENT(pIdDetalle);
                    detalle.TN_IdMascota = respuesta.TN_IdMascota;
                    detalle.TC_Raza = respuesta.TC_Raza;
                    detalle.TN_Peso = respuesta.TN_Peso;
                    detalle.TC_Color = respuesta.TC_Color;
                }

                using (srvMascotas.IsrvMascotasClient srvDM = new srvMascotas.IsrvMascotasClient())
                {
                    var respuesta = srvDM.obtenerMascotas_ENT();
                    var listMascotas = respuesta.Select(c => new SelectListItem
                    {
                        Value = c.TN_IdMascota.ToString(),
                        Text = c.TC_NombreMascota
                    });

                    detalle.Mascotas = listMascotas;
                }
            }
            catch (FaultException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving the detalle details." + ex.Message;
            }

            return View(detalle);
        }

        public ActionResult detallesDetalleMascota(int pIdDetalle)
        {
            DetallesMascota detalle = new DetallesMascota();
            try
            {
                using (srvDetalleMascota.IsrvDetalleMascotaClient srvDM = new srvDetalleMascota.IsrvDetalleMascotaClient())
                {
                    var respuesta = srvDM.obtenerDetalleXId_ENT(pIdDetalle);

                    detalle.TN_IdMascota = respuesta.TN_IdMascota;
                    detalle.TC_Raza = respuesta.TC_Raza;
                    detalle.TN_Peso = respuesta.TN_Peso;
                    detalle.TC_Color = respuesta.TC_Color;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(detalle);
        }

        public ActionResult eliminarDetalleMascota(int pIdDetalle)
        {
            DetallesMascota detalle = new DetallesMascota();
            try
            {
                using (srvDetalleMascota.IsrvDetalleMascotaClient srvDM = new srvDetalleMascota.IsrvDetalleMascotaClient())
                {
                    var respuesta = srvDM.obtenerDetalleXId_ENT(pIdDetalle);
                    detalle.TN_IdMascota = respuesta.TN_IdMascota;
                    detalle.TC_Raza = respuesta.TC_Raza;
                    detalle.TN_Peso = respuesta.TN_Peso;
                    detalle.TC_Color = respuesta.TC_Color;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(detalle);
        }

        // Actions

        public ActionResult insertarDetalle(DetallesMascota pDetalle)
        {
            List<DetallesMascota> lstDetalles = new List<DetallesMascota>();
            DetallesMascota detalle;
            try
            {
                using (srvDetalleMascota.IsrvDetalleMascotaClient srvDM = new srvDetalleMascota.IsrvDetalleMascotaClient())
                {
                    srvDetalleMascota.TVET_DetalleMascota objDM = new srvDetalleMascota.TVET_DetalleMascota();
                    objDM.TN_IdMascota = pDetalle.TN_IdMascota;
                    objDM.TC_Color = pDetalle.TC_Color;
                    objDM.TN_Peso = pDetalle.TN_Peso;
                    objDM.TC_Raza = pDetalle.TC_Raza;
                    srvDM.agregadetalle_ENT(objDM);

                    var respuesta = srvDM.obtenerDetalle_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            detalle = new DetallesMascota();
                            detalle.TN_IdMascota = item.TN_IdMascota;
                            detalle.TC_Raza = item.TC_Raza;
                            detalle.TN_Peso = item.TN_Peso;
                            detalle.TC_Color = item.TC_Color;
                            lstDetalles.Add(detalle);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerDetallesMascota");
        }

        public ActionResult borrarDetallesMascota(DetallesMascota pDetalle)
        {
            List<DetallesMascota> lstDetallesMascota = new List<DetallesMascota>();
            DetallesMascota detalle;
            try
            {
                using (srvDetalleMascota.IsrvDetalleMascotaClient srvDM = new srvDetalleMascota.IsrvDetalleMascotaClient())
                {
                    srvDetalleMascota.TVET_DetalleMascota objDM = new srvDetalleMascota.TVET_DetalleMascota();
                    objDM.TN_IdMascota = pDetalle.TN_IdMascota;
                    objDM.TC_Raza = pDetalle.TC_Raza;
                    objDM.TN_Peso = pDetalle.TN_Peso;
                    objDM.TC_Color = pDetalle.TC_Color;
                    srvDM.eliminaDetalle_ENT(objDM);

                    var respuesta = srvDM.obtenerDetalle_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            detalle = new DetallesMascota();
                            detalle.TN_IdMascota = item.TN_IdMascota;
                            detalle.TC_Raza = item.TC_Raza;
                            detalle.TN_Peso = item.TN_Peso;
                            detalle.TC_Color = item.TC_Color;
                            lstDetallesMascota.Add(detalle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("obtenerDetallesMascota");
        }

        private ActionResult actualizarDetalle(DetallesMascota pDetalle)
        {
            List<DetallesMascota> lstDetallesMascota = new List<DetallesMascota>();
            DetallesMascota detalle;
            try
            {
                using (srvDetalleMascota.IsrvDetalleMascotaClient srvDM = new srvDetalleMascota.IsrvDetalleMascotaClient())
                {
                    srvDetalleMascota.TVET_DetalleMascota objDM = new srvDetalleMascota.TVET_DetalleMascota();
                    objDM.TN_IdMascota = pDetalle.TN_IdMascota;
                    objDM.TC_Raza = pDetalle.TC_Raza;
                    objDM.TN_Peso = pDetalle.TN_Peso;
                    objDM.TC_Color = pDetalle.TC_Color;
                    srvDM.modificaDetalle_ENT(objDM);

                    var listDetalles = srvDM.obtenerDetalle_ENT();
                    if (listDetalles.Count() > 0)
                    {
                        foreach (var item in listDetalles)
                        {
                            detalle = new DetallesMascota();
                            detalle.TN_IdMascota = pDetalle.TN_IdMascota;
                            detalle.TC_Raza = pDetalle.TC_Raza;
                            detalle.TN_Peso = pDetalle.TN_Peso;
                            detalle.TC_Color = pDetalle.TC_Color;
                            lstDetallesMascota.Add(detalle);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerDetallesMascota");
        }

        public ActionResult accionesEjecucion(string accionEjecutar, DetallesMascota pDetalle)
        {
            try
            {
                switch (accionEjecutar)
                {
                    case "Agregar":
                        return insertarDetalle(pDetalle);

                    case "Modificar":
                        return actualizarDetalle(pDetalle);

                    case "Borrar":
                        return borrarDetallesMascota(pDetalle);

                    default:
                        return RedirectToAction("obtenerDetallesMascota");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}