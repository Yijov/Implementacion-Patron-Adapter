using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioAdapter.Interabilidad
{
    class Respuesta
    {
        public string userInput;
        public Respuesta(String userInput)
        {
            this.userInput = userInput;
        }

        public void ON(string response, Action operation)
        {
            if (userInput == response)
            {
               operation();
            }

        }

        public void ON(string response, Func<double, double> operation, double num)
        {
            if (userInput == response)
            {
                operation(num);
            }

        }

      
    }
}
