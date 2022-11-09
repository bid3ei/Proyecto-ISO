using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class CN_ResumenVenta
    {
        private CD_ResumenVenta objCapaDato = new CD_ResumenVenta();

        public List<ResumenVentas> ObtenerVenta()
        {
            return objCapaDato.ObtenerVenta();
        }
    }
}
