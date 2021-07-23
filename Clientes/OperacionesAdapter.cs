using EjercicioAdapter.Clientes.InterfacesCliente;
using EjercicioAdapter.Cuentas;
using EjercicioAdapter.Cuentas.Interfaces;
using EjercicioAdapter.Interabilidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Clientes
{
    class OperacionesAdapter: IClienteApertura, IClienteConsulta, IClienteDeposita, IClienteRetira
    {
        private OperacionesCuenraSuperAhorro SuperAhorro = OperacionesCuenraSuperAhorro.get();
        private OperacionesCuentaDeAhorro CuentaAhorro = OperacionesCuentaDeAhorro.get();
        private Pantalla IO = Pantalla.get();
        public void AbrirCuenta()
        {
           Respuesta tipodeCuenta = IO.Menu("¿Qué tipo de cuenta desea aperturar?", "Ahorro", "Super Ahorro");
            double montoInicial = double.Parse(IO.capturar(" ¿Cual es el Monto con el que desea abrir su cuenta?"));
            if (tipodeCuenta.userInput == "1") {
                CuentaAhorro.AbrirCuenta(montoInicial);
            } else if (tipodeCuenta.userInput == "2") {
                SuperAhorro.AbrirCuenta(montoInicial);
            };
        }

        public void Depositar()
        {
            double montoInicial = double.Parse(IO.capturar(" ¿Cual es el Monto con el que desea depositar a su cuenta?"));
            EncontrarEjecutar(CuentaAhorro.Depositar, SuperAhorro.Depositar, montoInicial);
        }

        public void ConsultarBalance()
        {
            EncontrarEjecutar(CuentaAhorro.ConsultarBalance, SuperAhorro.ConsultarBalance);
        }

        public void Retirar()
        {
            double monto = double.Parse(IO.capturar(" ¿Cual es el Monto con el que desea retirar de su cuenta?"));
            EncontrarEjecutar(CuentaAhorro.Retirar, SuperAhorro.Retirar, monto);
        }

        //encuentra la cuenta y ejecuta la función correspondiente
        private void EncontrarEjecutar(Action<int, double> FuncAhorro, Action<int, double> FunSuperAhorro, double monto)
        {
            try
            {
                int NoCuenta = int.Parse(IO.capturar("Por facor indique el número de cuenta"));
                CCuentas Cuenta = CCuentas.DataBase.Find(e => e.Numero == NoCuenta);
                if (Cuenta.GetType().Name == "CuentaSuperAhorro")
                {
                    FunSuperAhorro(NoCuenta, monto);

                }
                else if (Cuenta.GetType().Name == "CuentaDeAhorro")
                {
                    FuncAhorro(NoCuenta, monto);
                }

            }
            catch
            {
                IO.emitir("Debe indicar un numero valido");
                Respuesta Confirmacion = IO.Menu("¿Volcer a intentar?", "Si", "Salir");
                Confirmacion.ON("1", Depositar);
            }
        }

    

        private void EncontrarEjecutar(Action<int> FuncAhorro, Action<int> FunSuperAhorro)
        {
            try
            {
                int NoCuenta = int.Parse(IO.capturar("Por facor indique el número de cuenta"));
                CCuentas Cuenta = CCuentas.DataBase.Find(e => e.Numero == NoCuenta);
                if (Cuenta.GetType().Name == "CuentaSuperAhorro")
                {
                    FunSuperAhorro(NoCuenta);

                }
                else if (Cuenta.GetType().Name == "CuentaDeAhorro")
                {
                    FuncAhorro(NoCuenta);
                }

            }
            catch
            {
                IO.emitir("Debe indicar un numero valido");
                Respuesta Confirmacion = IO.Menu("¿Volcer a intentar?", "Si", "Salir");
                Confirmacion.ON("1", Depositar);
            }
        }




    }
}
