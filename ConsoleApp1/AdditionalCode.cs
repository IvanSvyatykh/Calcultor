using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForFloatNumbers
{
    public class AdditionalCode
    {
        private static StringBuilder NormalizeStringBuilderForInt(StringBuilder builder, int amountOfBit)
        {
            StringBuilder builder1 = new StringBuilder();
            for (int i = 0; i < amountOfBit - builder.Length; i++)
            {
                builder1.Append("0");
            }

            return builder.Append(builder1);
        }
        public static string PosDecToCode(int number, int amountOfBit, bool flag)
        {
            StringBuilder builder = new StringBuilder();

            do
            {
                Console.WriteLine($"Делим с остатком {number} на {2}, остаток приписываем к результату.");

                int mod = number % 2;

                builder.Append(mod);
                number /= 2;
            }
            while (number >= 2);

            if (number != 0)
            {
                builder.Append(number);
            }
            Console.WriteLine();
            Console.WriteLine($"Полученное число {string.Join("", builder.ToString())} необходимо записать в обратном порядке");
            Console.WriteLine();
            Console.WriteLine($"Итог: {string.Join("", builder.ToString().Reverse())}");
            Console.WriteLine();

            if (flag)
            {
                builder = NormalizeStringBuilderForInt(builder, amountOfBit);
                return string.Join("", builder.ToString().Reverse());
            }
            else
            {
                return string.Join("", builder.ToString().Reverse());
            }

        }
        private static string NegDecToCodeForInt(int number, int amountOfBit)
        {
            Console.WriteLine($"Число {number} запишем по модулю {Math.Abs(number)}, после переведем его в двоичный код как положительное число");
            Console.WriteLine();

            string str = PosDecToCode(Math.Abs(number), amountOfBit, true);
            List<int> list = new List<int>();
            Console.WriteLine($"Полученное число будем преобразовывать таким образом, сначала инверитируем числа на каждой позиции, а после прибавим единицу в конец");

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                {
                    Console.WriteLine($"Так как {i + 1} позиции стоит 0 запишем на этом месте 1");
                    list.Add(1);
                }
                else if (str[i] == '1')
                {
                    Console.WriteLine($"Так как {i + 1} позиции стоит 1 запишем на этом месте 0");
                    list.Add(0);
                }
            }

            bool flag = true;

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (flag)
                {
                    list[i]++;
                    flag = false;
                }
                if (list[i] == 1 || list[i] == 0) break;
                else if (list[i] == 2)
                {
                    list[i] -= 2;
                    if (i - 1 >= 0) list[i - 1]++;
                    else list.Insert(0, 1);
                }

            }
            Console.WriteLine();
            return string.Join("", list); 
        }
        private static string FloatPartToCodeForFloat(float number, int lengthOfFloatPart, int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            number = (float)Math.Round(number, length, MidpointRounding.AwayFromZero);
            for (int i = 0; i < lengthOfFloatPart; i++)
            {

                Console.WriteLine($"Умножаем: {number} *2 = {number *= 2} и берем от него только целую часть {(int)number}, затем вычитаем целую частьть из {number}");
                stringBuilder.Append((int)number);
                number = number - (int)number;
                if (number == 0)
                {
                    Console.WriteLine($"Число стало равно 0, значит прекращяем умножение");
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Итог: " + stringBuilder.ToString());
            return stringBuilder.ToString();
        }
        private static string NormalizationOfData(string IntPart, string FloatPart, ref int count)
        {
            if (IntPart[0] == '0')
            {
                while (FloatPart[0] == '0')
                {
                    FloatPart = FloatPart.Substring(1);
                    count--;
                }
                count--;
                return FloatPart[0] + "," + FloatPart.Substring(1);
            }
            else
            {
                count = IntPart.Length - 1;
                return IntPart[0] + "," + IntPart.Substring(1) + FloatPart;
            }
        }
        private static string DeleteZeroInBegin(string number)
        {
            while (number[0] == '0')
            {
                number = number.Substring(1);
            }
            return number;
        }
        public static void WriteLine()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
        }
        public static string AddZero(int num)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                stringBuilder.Append("0");
            }
            return stringBuilder.ToString();
        }
        public static string PutDataToMass(int[] mass, string p, string n)
        {
            for (int i = 0; i < p.Length; i++)
            {
                mass[i + 1] = p[i] - '0';
            }
            for (int i = 0; i < n.Length; i++)
            {
                mass[p.Length + i + 1] = n[i] - '0';
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < mass.Length; i++)
            {
                stringBuilder.Append(mass[i]);
            }
            return stringBuilder.ToString();
        }
        public static string DecToCodeForInt(string number, int amountOfBit)
        {
            string str = null;

            if (int.TryParse(number, out int result))
            {
                if (result >= 0) str = PosDecToCode(result, amountOfBit, true);
                else str = NegDecToCodeForInt(result, amountOfBit);
            }
            Console.WriteLine($"{number} в дополонительном коде : {str}");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
            return str;
        }
        public static string FloatToCode(string number, int amountOfBit)
        {
            if (float.TryParse(number, out float result))
            {
                int bitsForP;
                if (amountOfBit == 32) bitsForP = 8;
                else bitsForP = 11;
                int p = (int)Math.Pow(2, bitsForP-1) - 1;
                int[] mass = new int[amountOfBit];

                if (result < 0) mass[0] = 1;
                else mass[0] = 0;

                result = Math.Abs(result);

                Console.WriteLine($"Переведем в двоичный код целую и дробную часть числа.");
                WriteLine();
                Console.WriteLine("Целая часть числа в двоичной записи :");
                Console.WriteLine();

                string IntPart = PosDecToCode((int)result, amountOfBit, false);
                WriteLine();
                Console.WriteLine("Дробная часть числа в двоичной записи :");
                Console.WriteLine();
                string[] countDigitsAfterComa = number.Split('.', ',');
                string FloatPart;
                if (countDigitsAfterComa.Length==2) FloatPart = FloatPartToCodeForFloat(result - ((int)result), amountOfBit - IntPart.Length - bitsForP - 1, countDigitsAfterComa[1].Length);
                else FloatPart = FloatPartToCodeForFloat(result - ((int)result), amountOfBit - IntPart.Length - bitsForP - 1,0);
                WriteLine();

                string n = null;

                int count = 0;
                n = NormalizationOfData(IntPart, FloatPart, ref count);
                string exponentalWrite = n + "*" + 2 + "^" + $"{count}";

                Console.WriteLine($"Число {number} в нормолизированной записи двоичного кода: {n} * 2^({count})");
                WriteLine();
                Console.WriteLine($"Тогда порядок числа равен: {p += count}");
                WriteLine();
                string format = DeleteZeroInBegin(PosDecToCode(p, amountOfBit, false));
                format = AddZero(8 - format.Length) + format;
                Console.WriteLine($"Порядок в двоичной записи: {format}");
                WriteLine();
                Console.WriteLine($"Так как при нормализированной записи в целой части всегда стоит 1, то мантисса числа имеет вид {n = n.Substring(2)}");
                WriteLine();
                Console.WriteLine($"Число {number} в записи формата с плавающей точкой имеет вид: {n = PutDataToMass(mass, format, n)}");
                WriteLine();
                return exponentalWrite;
            }
            else
            {
                Console.WriteLine("Введенное число не возможно привести к двоичной записи, проверьте корректность ввода");
                Console.ReadKey();
                Console.Clear();
                Programm.Main();
                return null;
            }

        }
    }
}
