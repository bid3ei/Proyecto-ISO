using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Vml.Office;

namespace CapaDatos
{
    public class CD_ResumenVenta
    {
        public static CD_ResumenVenta _instancia = null;

        public CD_ResumenVenta()
        {

        }

        public static CD_ResumenVenta Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_ResumenVenta();
                }
                return _instancia;
            }
        }


        public List<ResumenVentas> ObtenerVenta()
        {
            List<ResumenVentas> rptListaVenta = new List<ResumenVentas>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteResumenVenta", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            rptListaVenta.Add(
                                new ResumenVentas()
                                {
                                    Cliente = dr["Cliente"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Producto = dr["Producto"].ToString(),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                    Total = Convert.ToInt32(dr["Total"].ToString()),
                                    Fecha = dr["Fecha"].ToString(),
                                    Vendedor = dr["Vendedor"].ToString(),
                                    IDventa = Convert.ToInt32(dr["IDventa"].ToString()),
                                    Documento = dr["Documento"].ToString()
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                rptListaVenta = new List<ResumenVentas>();
            }

            return rptListaVenta;

        }
    }
}
