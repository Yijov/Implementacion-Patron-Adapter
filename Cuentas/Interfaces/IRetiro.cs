using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Cuentas.Interfaces
{
    interface IRetiro
    {
        void Retirar(int numerDeCuenta, double retiro);
    }
}
