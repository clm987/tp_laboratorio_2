using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Asigna un valor al atributo numero previa validación
        /// </summary>
        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// Convierte de binario a decimal el contenido del resultado
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor Invalido";
            int auxNum;
            Numero num1 = new Numero();

            if (num1.EsBinario(binario))
            {
                auxNum = Convert.ToInt32(binario, 2);
                retorno = auxNum.ToString();
            }

            return retorno;
        }
        /// <summary>
        /// Realiza la conversión de Decimal a Binario 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "Valor Invalido";
            int parteEntera;
            try
            {
                parteEntera = Convert.ToInt32(Math.Abs(Math.Floor(numero)));
                retorno = Convert.ToString(parteEntera, 2);
            }
            catch (FormatException)
            {

                return retorno;
            }
            catch (OverflowException)
            {
                return retorno;
            }
             
            
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del metodo DecimalBinario con parametro de entrada String
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor Invalido";

            if(!string.IsNullOrEmpty(numero))
            {
                try
                {
                    retorno = DecimalBinario(Convert.ToDouble(numero));
                }
                catch (OverflowException)
                {

                    return retorno;
                }
                
                
            }
            
            return retorno;
        }


        /// <summary>
        /// Valida que una cadena recibida por parametro contenga solo "1" y "0"
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;

            for (int i = 0; i < binario.Length; i++)
            {
                if ((binario[i] == '0') || (binario[i] == '1'))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            return retorno;
        }
        
        /// <summary>
        /// Constructor que inicializa en cero una instancia
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        } 

        /// <summary>
        /// Constructor que inicializa con el contenido de un parametro una instancia
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Inicializa una instancia con el valor recibido por parametro
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Valida que el contenido de una cadena sea un numero
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            
            if (!string.IsNullOrEmpty(strNumero))
            {
                if(double.TryParse(strNumero, out retorno))
                {
                    return retorno;
                }
                return retorno;
            }
            else
            {
                return retorno;
            }
        }
        
        /// <summary>
        /// Sobrecarga del operador + para trabajar con elementos de la clase Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return (n1.numero + n2.numero);
        }

        /// <summary>
        /// Sobrecarga del operador - para trabajar con elementos de la clase Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return (n1.numero - n2.numero);
        }

        /// <summary>
        /// Sobrecarga del operador * para trabajar con elementos de la clase Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }

        /// <summary>
        /// Sobrecarga del operador / para trabajar con elementos de la clase Numero
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = 0;

            if(n2.numero > 0)
             {
                 retorno = (n1.numero / n2.numero);
             }
             else if(n2.numero == 0)
             {
                 retorno = double.MinValue;
             }

            return retorno;
        }



    }
}
