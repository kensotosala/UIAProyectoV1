using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class CitaController : Controller
    {
        public ActionResult obtenerCitas()
        {
            List<Cita> baseCitas = new List<Cita>();
            List<Clientes> baseClientes = new List<Clientes>();
            List<Mascotas> baseMascotas = new List<Mascotas>();
            Cita cita;

            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    var respuesta = srvCT.obtenerCita_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            cita = new Cita();
                            cita.TN_IdCita = item.TN_IdCita;
                            cita.TN_IdCliente = (int)item.TN_IdCliente;
                            cita.TN_IdMascota = (int)item.TN_IdMascota;
                            cita.TF_FecCita = item.TF_FecCita;
                            baseCitas.Add(cita);
                        }
                    }
                }

                using (srvMascotas.IsrvMascotasClient srvMs = new srvMascotas.IsrvMascotasClient())
                {
                    var lstMascotas = srvMs.obtenerMascotas_ENT();
                    if (lstMascotas.Count() > 0)
                    {
                        foreach (var item in lstMascotas)
                        {
                            var nuevoMascota = new Mascotas
                            {
                                TN_IdMascota = item.TN_IdMascota,
                                TC_NombreMascota = item.TC_NombreMascota,
                            };
                            baseMascotas.Add(nuevoMascota);
                        }
                    }
                }

                ViewBag.Mascotas = baseMascotas;

                using (srvClientes.IsrvClientesClient srvCl = new srvClientes.IsrvClientesClient())
                {
                    var lstClientes = srvCl.obtenerCliente_ENT();
                    foreach (var cliente in lstClientes)
                    {
                        var nuevoCliente = new Clientes
                        {
                            TN_IdCliente = cliente.TN_IdCliente,
                            TC_Nombre = cliente.TC_Nombre,
                        };
                        baseClientes.Add(nuevoCliente);
                    }
                }

                ViewBag.Clientes = baseClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(baseCitas);
        }

        public ActionResult agregarCita()
        {
            Cita cita = new Cita();

            using (srvClientes.IsrvClientesClient srvCl = new srvClientes.IsrvClientesClient())
            {
                var clientes = ConvertirClientes(srvCl.obtenerCliente_ENT());
                cita.Clientes = clientes.Select(c => new SelectListItem
                {
                    Value = c.TN_IdCliente.ToString(),
                    Text = c.TC_Nombre
                });
            }

            using (srvMascotas.IsrvMascotasClient srvMS = new srvMascotas.IsrvMascotasClient())
            {
                var mascotas = ConvertirMascotas(srvMS.obtenerMascotas_ENT());
                cita.Mascotas = mascotas.Select(c => new SelectListItem
                {
                    Value = c.TN_IdMascota.ToString(),
                    Text = c.TC_NombreMascota
                });
            }

            return View(cita);
        }

        private List<Clientes> ConvertirClientes(srvClientes.TVE_Clientes[] clientes)
        {
            List<Clientes> listaClientes = new List<Clientes>();
            foreach (var cliente in clientes)
            {
                var nuevoCliente = new Clientes
                {
                    TN_IdCliente = cliente.TN_IdCliente,
                    TC_Nombre = cliente.TC_Nombre,
                };
                listaClientes.Add(nuevoCliente);
            }
            return listaClientes;
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

        public ActionResult modificarCitas(int pIdCita)
        {
            Cita cita = new Cita();
            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    var respuesta = srvCT.obtenerCitaXId_ENT(pIdCita);
                    cita.TN_IdCita = respuesta.TN_IdCita;
                    cita.TN_IdCliente = (int)respuesta.TN_IdCliente;
                    cita.TN_IdMascota = (int)respuesta.TN_IdMascota;
                    cita.TF_FecCita = respuesta.TF_FecCita.Date;
                }

                using (srvClientes.IsrvClientesClient srvCl = new srvClientes.IsrvClientesClient())
                {
                    var respuesta = srvCl.obtenerCliente_ENT();
                    var lstClientes = respuesta.Select(c => new SelectListItem
                    {
                        Value = c.TN_IdCliente.ToString(),
                        Text = c.TC_Nombre
                    });

                    cita.Clientes = lstClientes;
                }

                using (srvMascotas.IsrvMascotasClient srvMS = new srvMascotas.IsrvMascotasClient())
                {
                    var respuesta = srvMS.obtenerMascotas_ENT();
                    var lstMascotas = respuesta.Select(m => new SelectListItem
                    {
                        Value = m.TN_IdMascota.ToString(),
                        Text = m.TC_NombreMascota
                    });

                    cita.Mascotas = lstMascotas;
                }
            }
            catch (FaultException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving the client details." + ex.Message;
            }

            return View(cita);
        }

        public ActionResult eliminarCita(int pIdCita)
        {
            Cita cita = new Cita();
            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    var respuesta = srvCT.obtenerCitaXId_ENT(pIdCita);
                    cita.TN_IdCita = respuesta.TN_IdCita;
                    cita.TN_IdCliente = (int)respuesta.TN_IdCliente;
                    cita.TN_IdMascota = (int)respuesta.TN_IdMascota;
                    cita.TF_FecCita = respuesta.TF_FecCita;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(cita);
        }

        public ActionResult detalleCita(int pIdCita)
        {
            Cita cita = new Cita();
            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    var respuesta = srvCT.obtenerCitaXId_ENT(pIdCita);
                    cita.TN_IdCita = respuesta.TN_IdCita;
                    cita.TN_IdCliente = (int)respuesta.TN_IdCliente;
                    cita.TN_IdMascota = (int)respuesta.TN_IdMascota;
                    cita.TF_FecCita = respuesta.TF_FecCita;
                }

                using (srvClientes.IsrvClientesClient srvCl = new srvClientes.IsrvClientesClient())
                {
                    ViewBag.Clientes = ConvertirClientes(srvCl.obtenerCliente_ENT());
                }

                using (srvMascotas.IsrvMascotasClient srvMS = new srvMascotas.IsrvMascotasClient())
                {
                    ViewBag.Mascotas = ConvertirMascotas(srvMS.obtenerMascotas_ENT());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(cita);
        }

        // A C C I O N E S

        public ActionResult insertarCita(Cita pCita)
        {
            List<Cita> lstCitas = new List<Cita>();
            Cita cita;

            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    srvCitas.TVET_Citas objCT = new srvCitas.TVET_Citas();
                    objCT.TN_IdCita = pCita.TN_IdCita;
                    objCT.TN_IdCliente = (int)pCita.TN_IdCliente;
                    objCT.TN_IdMascota = (int)pCita.TN_IdMascota;
                    objCT.TF_FecCita = pCita.TF_FecCita;

                    srvCT.agregaCita_ENT(objCT);

                    var respuesta = srvCT.obtenerCita_ENT();

                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            cita = new Cita();
                            cita.TN_IdCita = item.TN_IdCita;
                            cita.TN_IdCliente = (int)item.TN_IdCliente;
                            cita.TN_IdMascota = (int)item.TN_IdMascota;
                            cita.TF_FecCita = item.TF_FecCita;
                            lstCitas.Add(cita);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerCitas");
        }

        public ActionResult actualizarCita(Cita pCita)
        {
            List<Cita> lstCitas = new List<Cita>();
            Cita cita;

            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    srvCitas.TVET_Citas objCT = new srvCitas.TVET_Citas();
                    objCT.TF_FecCita = pCita.TF_FecCita;
                    objCT.TN_IdCita = pCita.TN_IdCita;
                    objCT.TN_IdCliente = pCita.TN_IdCliente;
                    objCT.TN_IdMascota = pCita.TN_IdMascota;

                    srvCT.modificaCita_ENT(objCT);

                    var listCitas = srvCT.obtenerCita_ENT();

                    if (listCitas.Count() > 0)
                    {
                        foreach (var item in listCitas)
                        {
                            cita = new Cita();
                            cita.TN_IdCita = item.TN_IdCita;
                            cita.TN_IdCliente = (int)item.TN_IdCliente;
                            cita.TN_IdMascota = (int)item.TN_IdMascota;
                            cita.TF_FecCita = item.TF_FecCita;
                            lstCitas.Add(cita);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerCitas");
        }

        public ActionResult borrarCita(Cita pCita)
        {
            List<Cita> lstCitas = new List<Cita>();
            Cita cita;

            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    srvCT.eliminaCita_ENT(pCita.TN_IdCita);

                    var respuesta = srvCT.obtenerCita_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            cita = new Cita();
                            cita.TN_IdCita = item.TN_IdCita;
                            cita.TN_IdCliente = (int)item.TN_IdCliente;
                            cita.TF_FecCita = item.TF_FecCita;
                            cita.TN_IdMascota = (int)item.TN_IdMascota;
                            lstCitas.Add(cita);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerCitas");
        }

        public ActionResult accionesEjecucion(string accionEjecutar, Cita pCita)
        {
            try
            {
                switch (accionEjecutar)
                {
                    case "Agregar":
                        return insertarCita(pCita);

                    case "Modificar":
                        return actualizarCita(pCita);

                    case "Borrar":
                        return borrarCita(pCita);

                    default:
                        return RedirectToAction("obtenerCitas");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}