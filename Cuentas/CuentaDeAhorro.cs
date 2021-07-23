using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Cuentas
{
    class CuentaDeAhorro : CCuentas
    {
        public CuentaDeAhorro(double monto)
        {
            this.Balance = monto;
            Random generator = new Random();
            this.Numero = generator.Next(1000000, 1999999);
            Console.WriteLine("Se ha creado la cuenta " + this.Numero + " Con un balance de " + this.Balance);
            CCuentas.DataBase.Add(this);

        }
    }
}
