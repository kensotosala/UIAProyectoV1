using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UI.Models
{
    public class CitaController : Controller
    {
        public ActionResult obtenerCitas()
        {
            List<Citas> baseCitas = new List<Citas>();
            List<Clientes> baseClientes = new List<Clientes>();
            List<Mascotas> baseMascotas = new List<Mascotas>();
            Cita cita;

            try
            {
                using (srvCita.IsrvCitasClient srvCT = new srvCita.IsrvCitasClient())
                {
                    var respuesta = srvCT.obtenerCitas_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            cita = new Cita();
                            cita.TN_IdCita = item.TN_IdCita;
                            cita.TN_IdCliente = item.TN_IdCliente;
                            cita.TN_IdMascota = item.TN_IdMascota;
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
                            baseClientes.Add(nuevoMascota);
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
                mascota.Clientes = clientes.Select(c => new SelectListItem
                {
                    Value = c.TN_IdCliente.ToString(),
                    Text = c.TC_Nombre
                });
            }

            using (srvMascotas.IsrvMascotasClient srvCM = new srvMascotas.IsrvMascotasClient())
            {
                var mascotas = ConvertirClientes(srvCl.obtenerCliente_ENT());
                mascota.Clientes = clientes.Select(c => new SelectListItem
                {
                    Value = c.TN_IdCliente.ToString(),
                    Text = c.TC_Nombre
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
                    cita.TN_IdCliente = respuesta.TN_IdCliente;
                    cita.TN_IdMascota = respuesta.TN_IdMascota;
                    cita.TF_FecCita = respuesta.TF_FecCita;
                }

                using (srvClientes.IsrvClientesClient srvCl = new srvClientes.IsrvClientesClient())
                {
                    var lstClientes = srvCl.obtenerCliente_ENT();
                    var clientesList = lstClientes.Select(c => new SelectListItem
                    {
                        Value = c.TN_IdCliente.ToString(),
                        Text = c.TC_Nombre
                    });

                    mascota.Clientes = clientesList;
                }

                using (srvMascotas.IsrvMascotas srvMS = new srvMascotas.IsrvMascotasClient())
                {
                    var respuesta = srvMS.obtenerMascotas_ENT();
                    var mascotasList = respuesta.Select(c => new SelectListItem
                    {
                        Value = c.TN_IdMascota.ToString(),
                        Text = c.TC_NombreMascota
                    });

                    mascota.Clientes = clientesList;
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
                    cita.TN_IdCliente = respuesta.TN_IdCliente;
                    cita.TN_IdMascota = respuesta.TN_IdMascota;
                    cita.TF_FecCita = respuesta.TF_FecCita;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(mascota);
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
                    cita.TN_IdCliente = respuesta.TN_IdCliente;
                    cita.TN_IdMascota = respuesta.TN_IdMascota;
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
            List<Cita> lstCita = new List<Cita>();
            Cita cita;
            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    srvCitas.TVET_Citas objCT = new srvCitas.TVET_Citas();
                    objCT.TN_IdCita = pCita.TN_IdCita;
                    objCT.TN_IdCliente = pCita.TN_IdCliente;
                    objCT.TN_IdMascota = pCita.TN_IdMascota;
                    objCT.TF_FecCita = pCita.TF_FecCita;

                    srvCT.agregaCita_ENT(objCT);

                    var respuesta = srvCT.obtenerCita_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            cita = new Cita();
                            objCT.TN_IdCita = item.TN_IdCita;
                            objCT.TN_IdCliente = item.TN_IdCliente;
                            objCT.TN_IdMascota = item.TN_IdMascota;
                            objCT.TF_FecCita = item.TF_FecCita;

                            lstCita.Add(cita);
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
            List<Cita> lstCita = new List<Cita>();
            Cita cita;
            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    srvCitas.TVET_Citas objCT = new srvCitas.TVET_Citas();
                    objCT.TN_IdCita = pCita.TN_IdCita;
                    objCT.TN_IdCliente = pCita.TN_IdCliente;
                    objCT.TN_IdMascota = pCita.TN_IdMascota;
                    objCT.TF_FecCita = pCita.TF_FecCita;

                    srvCT.modificaCita_ENT(objCT);

                    var respuesta = srvCT.obtenerCita_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            cita = new Cita();
                            objCT.TN_IdCita = item.TN_IdCita;
                            objCT.TN_IdCliente = item.TN_IdCliente;
                            objCT.TN_IdMascota = item.TN_IdMascota;
                            objCT.TF_FecCita = item.TF_FecCita;

                            lstCita.Add(cita);
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
            List<Cita> lstCita = new List<Cita>();
            Cita cita;
            try
            {
                using (srvCitas.IsrvCitasClient srvCT = new srvCitas.IsrvCitasClient())
                {
                    srvCitas.TVET_Citas objCT = new srvCitas.TVET_Citas();
                    objCT.TN_IdCita = pCita.TN_IdCita;
                    objCT.TN_IdCliente = pCita.TN_IdCliente;
                    objCT.TN_IdMascota = pCita.TN_IdMascota;
                    objCT.TF_FecCita = pCita.TF_FecCita;

                    srvCT.eliminaCita_ENT(objCT);

                    var respuesta = srvCT.obtenerCita_ENT();
                    if (respuesta.Count() > 0)
                    {
                        foreach (var item in respuesta)
                        {
                            cita = new Cita();
                            objCT.TN_IdCita = item.TN_IdCita;
                            objCT.TN_IdCliente = item.TN_IdCliente;
                            objCT.TN_IdMascota = item.TN_IdMascota;
                            objCT.TF_FecCita = item.TF_FecCita;

                            lstCita.Add(cita);
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