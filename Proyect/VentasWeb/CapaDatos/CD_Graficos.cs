using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaDatos
{
    public class CD_Graficos
    {
        public List<Graficos> Listar()
        {

            List<Graficos> lista = new List<Graficos>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {
                    SqlCommand cmd = new SqlCommand("sp_GraficosDashBoard", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Graficos()
                                {
                                    Mes = dr["mes"].ToString(),
                                    TotalCosto = int.Parse(dr["TotalCosto"].ToString()),
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Graficos>();
            }
            return lista;
        }

        public List<Graficos2> Listar2()
        {

            List<Graficos2> lista = new List<Graficos2>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {
                    SqlCommand cmd = new SqlCommand("sp_GraficosDashBoard2", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Graficos2()
                                {
                                    Producto = dr["Producto"].ToString(),
                                    Cantidad = int.Parse(dr["Cantidad"].ToString()),
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Graficos2>();
            }
            return lista;
        }

        public List<Graficos3> ListarLinea()
        {

            List<Graficos3> lista = new List<Graficos3>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.CN))
                {
                    SqlCommand cmd = new SqlCommand("sp_GraficosDashBoard3", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Graficos3()
                                {
                                    Meses = dr["Nombre"].ToString(),
                                    Cantidad = int.Parse(dr["Stock"].ToString()),
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Graficos3>();
            }
            return lista;
        }
    }
}
