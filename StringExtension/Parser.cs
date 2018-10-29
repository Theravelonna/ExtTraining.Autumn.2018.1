using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class Parser
    {
        private static char[] arrayForBase = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        public static int ToDecimal(this string source, int @base)
        {
            CheckData(source, @base);

            int number = 0;
            source = source.ToUpper();
            char[] arraySource = source.ToCharArray();
            int[] arrayForNumbers = new int[arraySource.Length];
            //Заносим в целочисленный массив числа, которые будем умножать на основание системы счисления, возведенного в степень
            int i = 0;
            for(int j = 0; j < arraySource.Length; j++)
            {
                for(int k = 0; k < arrayForBase.Length; k++)
                {
                    if (arraySource[j] == arrayForBase[j])
                    {
                        arrayForNumbers[i++] = j;
                    }
                }
            }

            int count = 0;
            int pow = arraySource.Length - 1;
            while (count < arraySource.Length)
            {
                number += (int)Math.Pow(@base, pow--) * arrayForNumbers[count++];
            }
            return number;
        }

        private static void CheckData(string source, int @base)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException("String is empty!");
            }

            if (@base <= 1 || @base >= 17)
            {
                throw new ArgumentOutOfRangeException("Input base isn't correct!");
            }

            int elementIndex = 0;
            for (int i = 0; i < source.Length; i++)
            {
                bool isSymbol = false;
                
                for (int j = 0; j < arrayForBase.Length; j++)
                {
                    if (source[i] == arrayForBase[j])
                    {
                        isSymbol = true;
                        elementIndex = j;
                        break;
                    }
                }

                if (elementIndex > @base)
                {
                    isSymbol = false;
                }

                if (!isSymbol)
                {
                    throw new ArgumentException("Source string isn't correct!");
                }
            }
            //Проверка на слишком большое число?
        }
    }
}
