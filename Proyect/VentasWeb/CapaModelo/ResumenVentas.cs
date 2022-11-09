using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class ResumenVentas
    {
        public string Cliente { get; set; }
        public string Telefono { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public string Fecha { get; set; }
        public string Vendedor { get; set; }
        public int IDventa { get; set; }
        public string Documento { get; set; }
    }
}
