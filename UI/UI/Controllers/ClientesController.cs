using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using UI.Models;
using UI.srvCitas;

namespace UI.Controllers
{
    public class ClientesController : Controller
    {
        // GET Clientes
        public ActionResult obtenerClientes_ENT()
        {
            List<Clientes> baseClientes = new List<Clientes>();
            Clientes cliente;
            try
            {
                using (srvClientes.IsrvClientesClient srvCl = new
                    srvClientes.IsrvClientesClient())
                {
                    var listaClientes = srvCl.obtenerCliente_ENT();
                    if (listaClientes.Count() > 0)
                    {
                        foreach (var c in listaClientes)
                        {
                            cliente = new Clientes();
                            cliente.TN_IdCliente = c.TN_IdCliente;
                            cliente.TC_Nombre = c.TC_Nombre;
                            cliente.TC_Ap1 = c.TC_Ap1;
                            cliente.TC_Ap2 = c.TC_Ap2;
                            cliente.TC_NumTelefono = c.TC_NumTelefono;
                            cliente.TC_CorreoElectronico = c.TC_CorreoElectronico;
                            baseClientes.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(baseClientes);
        }

        // POST Cliente
        public ActionResult agregarCliente_ENT()
        {
            Clientes clientes = new Clientes();
            return View(clientes);
        }

        // PUT Cliente
        public ActionResult modificarCliente_ENT(int pIdCliente)
        {
            Clientes clientes = new Clientes();
            try
            {
                using (srvClientes.IsrvClientesClient srvCl = new srvClientes.IsrvClientesClient())
                {
                    var listaClientes = srvCl.obtenerclienteXId_ENT(pIdCliente);
                    clientes.TN_IdCliente = listaClientes.TN_IdCliente;
                    clientes.TC_Nombre = listaClientes.TC_Nombre;
                    clientes.TC_Ap1 = listaClientes.TC_Ap1;
                    clientes.TC_Ap2 = listaClientes.TC_Ap2;
                    clientes.TC_NumTelefono = listaClientes.TC_NumTelefono;
                    clientes.TC_CorreoElectronico = listaClientes.TC_CorreoElectronico;
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
            return View(clientes);
        }

        // DELETE Cliente
        public ActionResult eliminarCliente_ENT(int pIdCliente)
        {
            Clientes clientes = new Clientes();
            try
            {
                using (srvClientes.IsrvClientesClient srvCl = new
                    srvClientes.IsrvClientesClient())
                {
                    var listaClientes = srvCl.obtenerclienteXId_ENT(pIdCliente);
                    clientes.TN_IdCliente = listaClientes.TN_IdCliente;
                    clientes.TC_Nombre = listaClientes.TC_Nombre;
                    clientes.TC_Ap1 = listaClientes.TC_Ap1;
                    clientes.TC_Ap2 = listaClientes.TC_Ap2;
                    clientes.TC_NumTelefono = listaClientes.TC_NumTelefono;
                    clientes.TC_CorreoElectronico = listaClientes.TC_CorreoElectronico;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(clientes);
        }

        // DETAIL Cliente
        public ActionResult detalleCliente_ENT(int pIdCliente)
        {
            Clientes clientes = new Clientes();
            try
            {
                using (srvClientes.IsrvClientesClient srvCl = new
                    srvClientes.IsrvClientesClient())
                {
                    var listaClientes = srvCl.obtenerclienteXId_ENT(pIdCliente);
                    clientes.TN_IdCliente = listaClientes.TN_IdCliente;
                    clientes.TC_Nombre = listaClientes.TC_Nombre;
                    clientes.TC_Ap1 = listaClientes.TC_Ap1;
                    clientes.TC_Ap2 = listaClientes.TC_Ap2;
                    clientes.TC_NumTelefono = listaClientes.TC_NumTelefono;
                    clientes.TC_CorreoElectronico = listaClientes.TC_CorreoElectronico;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(clientes);
        }

        // Insertar
        public ActionResult insertarCliente_ENT(Clientes pClientes)
        {
            List<Clientes> lstClientes = new List<Clientes>();
            Clientes clientes;
            try
            {
                using (srvClientes.IsrvClientesClient srvCl = new srvClientes.IsrvClientesClient())
                {
                    srvClientes.TVE_Clientes lObjCl = new srvClientes.TVE_Clientes();
                    lObjCl.TN_IdCliente = pClientes.TN_IdCliente;
                    lObjCl.TC_Nombre = pClientes.TC_Nombre;
                    lObjCl.TC_Ap1 = pClientes.TC_Ap1;
                    lObjCl.TC_Ap2 = pClientes.TC_Ap2;
                    lObjCl.TC_NumTelefono = pClientes.TC_NumTelefono;
                    lObjCl.TC_CorreoElectronico = pClientes.TC_CorreoElectronico;
                    srvCl.agregaCliente_ENT(lObjCl);

                    var lstRegiones = srvCl.obtenerCliente_ENT();
                    if (lstRegiones.Count() > 0)
                    {
                        foreach (var item in lstRegiones)
                        {
                            clientes = new Clientes();
                            clientes.TN_IdCliente = item.TN_IdCliente;
                            clientes.TC_Nombre = item.TC_Nombre;
                            clientes.TC_Ap1 = item.TC_Ap1;
                            clientes.TC_Ap2 = item.TC_Ap2;
                            clientes.TC_NumTelefono = item.TC_NumTelefono;
                            clientes.TC_CorreoElectronico = item.TC_CorreoElectronico;
                            lstClientes.Add(clientes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerClientes_ENT", lstClientes);
        }

        // Actualizar
        public ActionResult actualizarCliente_ENT(Clientes pClientes)
        {
            List<Clientes> lstClientes = new List<Clientes>();
            Clientes clientes;
            try
            {
                using (srvClientes.IsrvClientesClient srvCl = new
                    srvClientes.IsrvClientesClient())
                {
                    srvClientes.TVE_Clientes lObjCl = new srvClientes.TVE_Clientes();
                    lObjCl.TN_IdCliente = pClientes.TN_IdCliente;
                    lObjCl.TC_Nombre = pClientes.TC_Nombre;
                    lObjCl.TC_Ap1 = pClientes.TC_Ap1;
                    lObjCl.TC_Ap2 = pClientes.TC_Ap2;
                    lObjCl.TC_NumTelefono = pClientes.TC_NumTelefono;
                    lObjCl.TC_CorreoElectronico = pClientes.TC_CorreoElectronico;
                    srvCl.modificaCliente_ENT(lObjCl);

                    var lstRegiones = srvCl.obtenerCliente_ENT();
                    if (lstRegiones.Count() > 0)
                    {
                        foreach (var item in lstRegiones)
                        {
                            clientes = new Clientes();
                            clientes.TN_IdCliente = item.TN_IdCliente;
                            clientes.TC_Nombre = item.TC_Nombre;
                            clientes.TC_Ap1 = item.TC_Ap1;
                            clientes.TC_Ap2 = item.TC_Ap2;
                            clientes.TC_NumTelefono = item.TC_NumTelefono;
                            clientes.TC_CorreoElectronico = item.TC_CorreoElectronico;
                            lstClientes.Add(clientes);
                            Console.WriteLine(clientes.TN_IdCliente);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerClientes_ENT", lstClientes);
        }

        // Borrar
        public ActionResult borrarCliente_ENT(Clientes pCliente)
        {
            List<Clientes> lstClientes = new List<Clientes>();
            Clientes clientes;
            try
            {
                using (srvClientes.IsrvClientesClient srvCl = new
                    srvClientes.IsrvClientesClient())
                {
                    srvCl.eliminaCliente_ENT(pCliente.TN_IdCliente);

                    var lstRegiones = srvCl.obtenerCliente_ENT();
                    if (lstRegiones.Count() > 0)
                    {
                        foreach (var item in lstRegiones)
                        {
                            clientes = new Clientes();
                            clientes.TN_IdCliente = item.TN_IdCliente;
                            clientes.TC_Nombre = item.TC_Nombre;
                            clientes.TC_Ap1 = item.TC_Ap1;
                            clientes.TC_Ap2 = item.TC_Ap2;
                            clientes.TC_NumTelefono = item.TC_NumTelefono;
                            clientes.TC_CorreoElectronico = item.TC_CorreoElectronico;
                            lstClientes.Add(clientes);
                        }
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerClientes_ENT", lstClientes);
        }

        // Acciones
        public ActionResult accionesEjecucion(string accionEjecutar, Clientes pClientes)
        {
            try
            {
                switch (accionEjecutar)
                {
                    case "Agregar":
                        return insertarCliente_ENT(pClientes);

                    case "Modificar":
                        return actualizarCliente_ENT(pClientes);

                    case "Borrar":
                        return borrarCliente_ENT(pClientes);

                    default:
                        return RedirectToAction("obtenerClientes_ENT");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}