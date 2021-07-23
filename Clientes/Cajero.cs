
using EjercicioAdapter.Clientes.InterfacesCliente;
using EjercicioAdapter.Interabilidad;

using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Clientes
{
  class Cajero : IClienteApertura, IClienteConsulta, IClienteDeposita, IClienteRetira
    {
        private Pantalla IO = Pantalla.get();
        private OperacionesAdapter Adapter = new OperacionesAdapter();


        public void Run()
        {
            this.IO.emitir("Bienvenido!");
            Respuesta seleccion= this.IO.Menu("Seleccione la operación a realizar", "Abrir una Cuenta", "Depósito", "Retiro", "Consulta");
            seleccion.ON("1", AbrirCuenta);
            seleccion.ON("2", Depositar);
            seleccion.ON("3", ConsultarBalance);
            seleccion.ON("4", Retirar);
            AlgoMas();
            this.IO.emitir("Gracias por Preferirnos...");
            this.IO.emitir("Hasta Pronto!");

        }

        public void AbrirCuenta()
        {
            Adapter.AbrirCuenta();
        }

        public void Depositar()
        {
            Adapter.Depositar();
        }

        public void ConsultarBalance()
        {
            Adapter.ConsultarBalance();
        }

        public void Retirar()
        {
            Adapter.Retirar();
        }
        private void AlgoMas()
        {
            Respuesta Mas = IO.Menu("¿Desea realizar otra transacción?", "Si", "NO");
            Mas.ON("1", Run);
        }

    }
}
