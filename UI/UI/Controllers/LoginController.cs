using System;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            if (Session["Logueado"] == null)
            {
                Session["Logueado"] = false;
            }

            ViewBag.Title = "Login";
            return View();
        }

        public ActionResult Acceder(string usuario, string password)
        {
            bool respuesta = false;
            try
            {
                using (srvLogin.IsrvLoginClient srvLG = new srvLogin.IsrvLoginClient())
                {
                    respuesta = srvLG.iniciarSesion(usuario, password);
                    if (respuesta)
                    {
                        Session["Logueado"] = true;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            ViewBag.Respuesta = false;
            return View("Login");
        }
    }
}