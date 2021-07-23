using EjercicioAdapter.Cuentas.Interfaces;
using EjercicioAdapter.Interabilidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Cuentas
{
    class OperacionesCuenraSuperAhorro : IApertura, IDeposito, IConsulta, IRetiro, IValidar
    {

        static OperacionesCuenraSuperAhorro Instancia;
        private Pantalla IO = Pantalla.get();
        private OperacionesCuenraSuperAhorro() { }

        public static OperacionesCuenraSuperAhorro get()
        {
            if (Instancia == null)
            {
                Instancia = new OperacionesCuenraSuperAhorro();
            }
            return Instancia;
        }
        public void AbrirCuenta(double montoInicial)
        {
            try
            {
                montoInicial = double.Parse(IO.capturar("Indique el monto inicial de su cuenta"));
                new CuentaSuperAhorro(montoInicial);

            }
            catch
            {
                Respuesta respuesta = IO.Menu("El monto indicado no es valido. Debe ser un Número", "Volver a intentar", "Salir");
                if (respuesta.userInput == "1")
                {
                    AbrirCuenta(montoInicial);
                }
            }
        }

        public void ConsultarBalance(int numerDeCuenta)
        {
            CCuentas Cuenta = encontrar(numerDeCuenta);
            IO.emitir("El balance de su cuenta " + Cuenta.Numero + " es " + Cuenta.Balance);
        }

        public void Depositar(int numerDeCuenta, double deposito)
        {
            CCuentas Cuenta = encontrar(numerDeCuenta);
            Cuenta.Balance += deposito;
            IO.emitir("Se ha depositado  " + deposito + "  a la cuenta número " + Cuenta.Numero);
            IO.emitir("El nuevo balance`es " + Cuenta.Balance);

        }

        public void Retirar(int numerDeCuenta, double montoAretirar)
        {
            CCuentas Cuenta = encontrar(numerDeCuenta);
            if (Validar(montoAretirar, Cuenta.Balance))
            {
                Cuenta.Balance -= montoAretirar;
                IO.emitir("Se ha Retirado  " + montoAretirar + "  a la cuenta número " + Cuenta.Numero);
                IO.emitir("El nuevo balance`es " + Cuenta.Balance);

            }
            else
            {
                IO.emitir("el monto que desea retirar excede el limite permitio");
            }
         
        }

        private CCuentas encontrar(int numerDeCuenta)
        {
            CCuentas cuenta = CCuentas.DataBase.Find(c => c.Numero == numerDeCuenta);
            return cuenta;
        }

        public bool Validar(double monto, double balce)
        {
            if (monto < balce * 0.4)
            {
                return true;
            }else
            {
                return false;
            }
        } 

    }
}
