﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class MascotasController : Controller
    {
        public ActionResult obtenerMascotasENT()
        {
            List<Mascotas> baseMascotas = new List<Mascotas>();
            List<Clientes> baseClientes = new List<Clientes>();
            Mascotas mascota;
            try
            {
                using (srvMascotas.IsrvMascotasClient srvMs = new srvMascotas.IsrvMascotasClient())
                {
                    var lstMascotas = srvMs.obtenerMascotas_ENT();
                    if (lstMascotas.Count() > 0)
                    {
                        foreach (var item in lstMascotas)
                        {
                            mascota = new Mascotas();
                            mascota.TN_IdMascota = item.TN_IdMascota;
                            mascota.TC_NombreMascota = item.TC_NombreMascota;
                            mascota.TN_IdCliente = item.TN_IdCliente;
                            baseMascotas.Add(mascota);
                        }
                    }
                }

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
            return View(baseMascotas);
        }

        public ActionResult agregarMascotaENT()
        {
            Mascotas mascota = new Mascotas();
            using (srvClientes.IsrvClientesClient srvCl = new srvClientes.IsrvClientesClient())
            {
                var clientes = ConvertirClientes(srvCl.obtenerCliente_ENT());
                mascota.Clientes = clientes.Select(c => new SelectListItem
                {
                    Value = c.TN_IdCliente.ToString(),
                    Text = c.TC_Nombre
                });
            }

            return View(mascota);
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

        public ActionResult modificarMascotaENT(int pIdMascota)
        {
            Mascotas mascota = new Mascotas();
            try
            {
                using (srvMascotas.IsrvMascotasClient srvMs = new srvMascotas.IsrvMascotasClient())
                {
                    var lstMascotas = srvMs.obtenerMascotasXId_ENT(pIdMascota);
                    mascota.TN_IdMascota = lstMascotas.TN_IdMascota;
                    mascota.TC_NombreMascota = lstMascotas.TC_NombreMascota;
                    mascota.TN_IdCliente = lstMascotas.TN_IdCliente;
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
            }
            catch (FaultException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving the client details." + ex.Message;
            }

            return View(mascota);
        }

        public ActionResult eliminarMascotaENT(int pIdMascota)
        {
            Mascotas mascota = new Mascotas();
            try
            {
                using (srvMascotas.IsrvMascotasClient srvMs = new srvMascotas.IsrvMascotasClient())
                {
                    var lstMascotas = srvMs.obtenerMascotasXId_ENT(pIdMascota);
                    mascota.TN_IdMascota = lstMascotas.TN_IdMascota;
                    mascota.TC_NombreMascota = lstMascotas.TC_NombreMascota;
                    mascota.TN_IdCliente = lstMascotas.TN_IdCliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(mascota);
        }

        public ActionResult detalleMascotaENT(int pIdMascota)
        {
            Mascotas mascota = new Mascotas();
            try
            {
                using (srvMascotas.IsrvMascotasClient srvMs = new srvMascotas.IsrvMascotasClient())
                {
                    var lstMascotas = srvMs.obtenerMascotasXId_ENT(pIdMascota);
                    mascota.TN_IdMascota = lstMascotas.TN_IdMascota;
                    mascota.TC_NombreMascota = lstMascotas.TC_NombreMascota;
                    mascota.TN_IdCliente = lstMascotas.TN_IdCliente;
                }

                using (srvClientes.IsrvClientesClient srvCl = new srvClientes.IsrvClientesClient())
                {
                    ViewBag.Clientes = ConvertirClientes(srvCl.obtenerCliente_ENT());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(mascota);
        }

        public ActionResult insertarMascotaENT(Mascotas pMascota)
        {
            List<Mascotas> lstMascotas = new List<Mascotas>();
            Mascotas mascota;
            try
            {
                using (srvMascotas.IsrvMascotasClient srvMs = new srvMascotas.IsrvMascotasClient())
                {
                    srvMascotas.TVET_Mascotas objMS = new srvMascotas.TVET_Mascotas();
                    objMS.TN_IdMascota = pMascota.TN_IdMascota;
                    objMS.TC_NombreMascota = pMascota.TC_NombreMascota;
                    objMS.TN_IdCliente = pMascota.TN_IdCliente;
                    srvMs.agregaMascotas_ENT(objMS);

                    var listMascotas = srvMs.obtenerMascotas_ENT();
                    if (listMascotas.Count() > 0)
                    {
                        foreach (var item in listMascotas)
                        {
                            mascota = new Mascotas();
                            mascota.TN_IdMascota = item.TN_IdMascota;
                            mascota.TC_NombreMascota = item.TC_NombreMascota;
                            mascota.TN_IdCliente = item.TN_IdCliente;
                            lstMascotas.Add(mascota);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerMascotasENT");
        }

        public ActionResult actualizarMascotasENT(Mascotas pMascota)
        {
            List<Mascotas> lstMascotas = new List<Mascotas>();
            Mascotas mascota;
            try
            {
                using (srvMascotas.IsrvMascotasClient srvMs = new srvMascotas.IsrvMascotasClient())
                {
                    srvMascotas.TVET_Mascotas objMS = new srvMascotas.TVET_Mascotas();
                    objMS.TN_IdMascota = pMascota.TN_IdMascota;
                    objMS.TC_NombreMascota = pMascota.TC_NombreMascota;
                    objMS.TN_IdCliente = pMascota.TN_IdCliente;
                    srvMs.modificaMascotas_ENT(objMS);

                    var listMascotas = srvMs.obtenerMascotas_ENT();
                    if (listMascotas.Count() > 0)
                    {
                        foreach (var item in listMascotas)
                        {
                            mascota = new Mascotas();
                            mascota.TN_IdMascota = item.TN_IdMascota;
                            mascota.TC_NombreMascota = item.TC_NombreMascota;
                            mascota.TN_IdCliente = item.TN_IdCliente;
                            lstMascotas.Add(mascota);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerMascotasENT");
        }

        public ActionResult borrarMascotasENT(Mascotas pMascota)
        {
            List<Mascotas> lstMascotas = new List<Mascotas>();
            Mascotas mascota;
            try
            {
                using (srvMascotas.IsrvMascotasClient srvMs = new srvMascotas.IsrvMascotasClient())
                {
                    srvMs.eliminarMascota(pMascota.TN_IdMascota);

                    var listMascotas = srvMs.obtenerMascotas_ENT();
                    if (listMascotas.Count() > 0)
                    {
                        foreach (var item in listMascotas)
                        {
                            mascota = new Mascotas();
                            mascota.TN_IdMascota = item.TN_IdMascota;
                            mascota.TC_NombreMascota = item.TC_NombreMascota;
                            mascota.TN_IdCliente = item.TN_IdCliente;
                            lstMascotas.Add(mascota);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return RedirectToAction("obtenerMascotasENT");
        }

        public ActionResult accionesEjecucion(string accionEjecutar, Mascotas pMascota)
        {
            try
            {
                switch (accionEjecutar)
                {
                    case "Agregar":
                        return insertarMascotaENT(pMascota);

                    case "Modificar":
                        return actualizarMascotasENT(pMascota);

                    case "Borrar":
                        return borrarMascotasENT(pMascota);

                    default:
                        return RedirectToAction("obtenerMascotasENT");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}