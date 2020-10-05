using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

/// <summary>
/// /Valida el operador y realiza la operación solicitada.
/// </summary>
/// <param name="num1"></param>
/// <param name="num2"></param>
/// <param name="operador"></param>
/// <returns></returns>
    public static double Operar(Numero num1, Numero num2, string operador)
    {
            if (!string.IsNullOrEmpty(operador))
            {
                ValidarOperador(char.Parse(operador));
            }
            
            double resultado = 0;

            switch (operador)
            {
                case "+" :
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
         return resultado;
    }


/// <summary>
/// Realiza la validación del operador para que sea "+" "-" "*" o "/"
/// </summary>
/// <param name="operador"></param>
/// <returns></returns>
    private static string ValidarOperador(char operador)
    {
        string retorno = "+";
        String strOperador = operador.ToString();

       if ((operador == '+') || (operador == '-') || (operador == '*') || (operador == '/'))
       {
          retorno = strOperador;
          return retorno;
       }
       else
       {
          return "+";
       }
    }



    }
}
