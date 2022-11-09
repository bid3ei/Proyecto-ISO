using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class CN_DashBoard
    {
        private CD_DashBoard objCapaDato = new CD_DashBoard();
        public DashBoard VerDashBord()
        {
            return objCapaDato.VerDashBord();
        }
    }
}
