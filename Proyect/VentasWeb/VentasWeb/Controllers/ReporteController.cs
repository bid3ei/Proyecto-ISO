using CapaDatos;
using CapaModelo;
using UnitTestProject1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace VentasWeb.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Producto()
        {
            return View();
        }

        // GET: Reporte
        public ActionResult Ventas()
        {
            return View();
        }

        public JsonResult ObtenerProducto(int idtienda, string codigoproducto)
        {
            List<ReporteProducto> lista = CD_Reportes.Instancia.ReporteProductoTienda(idtienda, codigoproducto);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerVenta(string fechainicio, string fechafin, int idtienda)
        {

            List<ReporteVenta> lista = CD_Reportes.Instancia.ReporteVenta(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin), idtienda);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public FileResult ReporteVentaExcel(string FechaInicio, string FechaFin, int IdTienda)
        //{
        //    List<ReporteVentaExcel> oLista = new List<ReporteVentaExcel>();
        //    oLista = new CN_Reportes().ReporteVentaExcel(Convert.ToDateTime(FechaInicio), Convert.ToDateTime(FechaFin), IdTienda);

        //    DataTable dt = new DataTable();

        //    dt.Locale = new System.Globalization.CultureInfo("es-PE");
        //    dt.Columns.Add("FechaVenta", typeof(string));
        //    dt.Columns.Add("NumeroDocumento", typeof(string));
        //    dt.Columns.Add("TipoDocumento", typeof(string));
        //    dt.Columns.Add("NombreTienda", typeof(string));
        //    dt.Columns.Add("RucTienda", typeof(string));
        //    dt.Columns.Add("NombreEmpleado", typeof(string));
        //    dt.Columns.Add("CantidadUnidadesVendidas", typeof(string));
        //    dt.Columns.Add("CantidadProductos", typeof(string));
        //    dt.Columns.Add("TotalVenta", typeof(string));

        //    foreach (ReporteVentaExcel rp in oLista)
        //    {
        //        dt.Rows.Add(new object[]
        //        {
        //            rp.FechaVenta,
        //            rp.NumeroDocumento,
        //            rp.TipoDocumento,
        //            rp.NombreTienda,
        //            rp.RucTienda,
        //            rp.NombreEmpleado,
        //            rp.CantidadUnidadesVendidas,
        //            rp.TotalVenta
        //        });
        //    }

        //    dt.TableName = "Datos";

        //    using (XLWorkbook wb = new XLWorkbook())
        //    {
        //        wb.Worksheets.Add(dt);
        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            wb.SaveAs(stream);
        //            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteVentas" + DateTime.Now.ToString() + ".xlsx");
        //        }
        //    }
        //}
    }
}
