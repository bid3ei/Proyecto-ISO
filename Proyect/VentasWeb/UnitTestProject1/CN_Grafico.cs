using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class CN_Grafico
    {
        private CD_Graficos objCapaDato = new CD_Graficos();

        public List<Graficos> Listar()
        {
            return objCapaDato.Listar();
        }

        private CD_Graficos objCapaDato2 = new CD_Graficos();
        public List<Graficos2> Listar2()
        {
            return objCapaDato2.Listar2();
        }

        private CD_Graficos objCapaDato3 = new CD_Graficos();
        public List<Graficos3> ListarLinea()
        {
            return objCapaDato3.ListarLinea();
        }
    }
}
