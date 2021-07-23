using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Cuentas.Interfaces
{
    interface IValidar
    {
        bool Validar(double monto, double blnc);
    }
}
