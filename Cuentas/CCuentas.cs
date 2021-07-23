using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Cuentas
{
    class CCuentas //simulando persistencia
    {
        public int Numero
        {
            get;
            set;
        }

        public double Balance
        {
            get;
            set;
        }
        public static List<CCuentas> DataBase = new List<CCuentas>();
       
    }
}
