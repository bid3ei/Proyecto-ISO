using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_DashBoard
    {
        public DashBoard VerDashBord()
        {
            DashBoard objeto = new DashBoard();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteDashbord", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new DashBoard()
                            {
                                TotalProductos = Convert.ToInt32(dr["Codigo"]),
                                TotalVentas = Convert.ToInt32(dr["IdVenta"]),
                                TotalClientes = Convert.ToInt32(dr["IdCliente"]),
                                TotalCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            };
                        }
                    }
                }
            }
            catch
            {
                objeto = new DashBoard();
            }

            return objeto;
        }
    }
}
