using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public string Numero
        {
            set 
            {
                this.numero = ValidarOperando(value);
            }
        }

        public Operando()
        {
            numero = 0;
        }
        public Operando(double numero):this()
        {
            this.numero = numero;
        }
        public Operando(string strNumero):this()
        {
            Numero = strNumero;
        }
        private double ValidarOperando(string strNumero)
        {
            double numero;
            if(double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }
        private static bool EsBinario(string binario)
        {
            foreach(char caracter in binario)
            {
                if(caracter != '0' && caracter != '1')
                {
                    return false;
                }
            }
            return true;
        }
        public static string DecimalBinario(string numero)
        {
            double numeroEntero;
            if(double.TryParse(numero, out numeroEntero))
            {
                return DecimalBinario(numeroEntero);
            }
            else
            {
                return "Valor invalido";
            }

            

        }
        public static string DecimalBinario(double numero)
        {
            string retorno = "";
            if(numero < 0)
            {
                numero *= -1;
            }
            int numeroEntero = (int)numero;
            int aux;
            do
            {
                aux = numeroEntero%2;
                numeroEntero/=2;
                retorno += aux.ToString();
            }while(numeroEntero > 0);
            return retorno;
        }
        public static string BinarioDecimal(string binario)
        {
            if(EsBinario(binario))
            {
                char[] digitos = binario.ToCharArray();
                digitos.Reverse();
                int sum = 0;
                for(int i = 0; i < digitos.Length; i++)
                {
                    if(digitos[i] == '1')
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }
                return sum.ToString();
            }
            return "Valor invalido";
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if(n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }
    }
}
