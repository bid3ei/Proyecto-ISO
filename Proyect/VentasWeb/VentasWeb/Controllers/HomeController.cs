using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestProject1;

namespace VentasWeb.Controllers
{
    public class HomeController : Controller
    {
        private static Usuario SesionUsuario;
        public ActionResult Index()
        {
            if (Session["Usuario"] != null)
                SesionUsuario = (Usuario)Session["Usuario"];
            else {
                SesionUsuario = new Usuario();
            }
            try
            {
                ViewBag.NombreUsuario = SesionUsuario.Nombres + " " + SesionUsuario.Apellidos;
                ViewBag.RolUsuario = SesionUsuario.oRol.Descripcion;

            }
            catch {

            }

           
            return View();
        }

        public ActionResult Salir()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Login");
        }


        [HttpGet]
        public JsonResult VistaDashBoard()
        {
            DashBoard objeto = new CN_DashBoard().VerDashBord();

            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult Graficos()
        {
            CN_Grafico obj_Grafico = new CN_Grafico();
            List<Graficos> objLista = obj_Grafico.Listar();

            return Json(objLista, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Graficos2()
        {
            CN_Grafico obj_Grafico = new CN_Grafico();
            List<Graficos2> objLista = obj_Grafico.Listar2();

            return Json(objLista, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarLinea()
        {
            CN_Grafico obj_Grafico = new CN_Grafico();
            List<Graficos3> objLista = obj_Grafico.ListarLinea();

            return Json(objLista, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerVenta()
        {
            List<ResumenVentas> oLista = new List<ResumenVentas>();
            oLista = new CN_ResumenVenta().ObtenerVenta();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
    }
}