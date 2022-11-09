using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaModelo;

namespace CapaNegocio
{
    public class CN_Reportes
    {
        private CD_Reportes objCapaDato = new CD_Reportes();

        public List<ReporteVentaExcel> Ventas(DateTime FechaInicio, DateTime FechaFin, int IdTienda)
        {
            return objCapaDato.ReporteVentaExcel(FechaInicio, FechaFin, IdTienda);
        }
    }
}
