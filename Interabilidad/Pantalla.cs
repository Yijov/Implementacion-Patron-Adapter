using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Interabilidad
{
    class Pantalla
    {
        private static Pantalla instancia;
        private Pantalla() { }
        public static Pantalla get()
        {
            if (instancia == null)
            {
                instancia = new Pantalla();
            }
            return instancia;
        }
      

        public void emitir(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public string capturar(string Pregunta)
        {
            Console.WriteLine(Pregunta);
            return Console.ReadLine();
        }
        public Respuesta Menu(string Mensaje, string menu1, string menu2)
        {
            Console.WriteLine(Mensaje);
            Console.WriteLine("[1] {0}  [2] {1}", menu1, menu2);
            return new Respuesta( Console.ReadLine());
        }


        public Respuesta Menu(string Mensaje, string menu1, string menu2, string menu3)
        {
            Console.WriteLine(Mensaje);
            Console.WriteLine("[1] {0}  [2] {1}  [3] {2}", menu1, menu2, menu3);
            return new Respuesta(Console.ReadLine());
        }

        public Respuesta Menu(string Mensaje, string menu1, string menu2, string menu3, string menu4)
        {
            Console.WriteLine(Mensaje);
            Console.WriteLine("[1] {0}  [2] {1}  [3] {2}  [4] {3}", menu1, menu2, menu3, menu4);
            return new Respuesta(Console.ReadLine());
        }
    }
}

