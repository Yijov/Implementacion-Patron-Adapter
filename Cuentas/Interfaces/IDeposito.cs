using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Cuentas.Interfaces
{
    interface IDeposito
    {
        void Depositar(int numerDeCuenta, double deposito);
    }
}
