using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForFloatNumbers
{
    public class Sum
    {
        private static int FromBinToDec(string number)
        {
            int result = 0;

            int num;

            for (int i = 0; i < number.Length; i++)
            {
                char c = number[i];

                if (c >= '0' && c <= '9')
                    num = c - '0';
                else if (c >= 'A' && c <= 'Z')
                    num = c - 'A' + 10;
                else if (c >= 'a' && c <= 'z')
                    num = c - 'a' + (('Z' - 'A') + 1) + 10;
                else throw new ArgumentException("Invalid number");

                Console.WriteLine($"Умножаем результат на основание ситемы: {2},  прибавляем число: {num}, отвечающее за {i + 1} позицию числа.");

                result *= 2;
                result += num;

                Console.WriteLine($"({result / 2} * {2}) + {num} = {result}");
            }
            return result;
        }
        private static int ConvertSymbolToNumber(char num)
        {
            int n = (int)num;
            if (n >= 48 && n <= 57) n = n - '0';
            if (n >= 65 && n <= 90) n = n - 'A' + 10;
            if (n >= 97 && n <= 122) n = n - 'a' + 36;




            return n;
        }
        private static int MoveOrder(int p1, int p2)
        {
            Console.WriteLine("Найдем разность порядков данных чисел.");
            if (p1 == p2)
            {
                Console.WriteLine("Разность равна 0");
                return 0;
            }
            if (p1 > p2)
            {
                Console.WriteLine($"Разность равна :{p1 - p2} ");
                return p1 - p2;
            }
            if (p2 > p1)
            {
                Console.WriteLine($"Разность равна :{p2 - p1} ");
                return p2 - p1;
            }
            else return 0;
        }
        private static string AlignmentOfTheOrder(string number, int delta)
        {
            string[] splitted = number.Split('*', ',', '^');
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(0);
            Console.WriteLine($"При передвижении порядков целая часть равна 0 , тогда новое число {stringBuilder}");
            stringBuilder.Append(",");
            Console.WriteLine($"После ставим запятую, тогда новое число {stringBuilder}");
            for (int i = 0; i < delta - 1; i++)
            {
                Console.WriteLine($"После добавляем {delta - 1} нулей , тогда новое число {stringBuilder}");
                stringBuilder.Append(0);
            }

            stringBuilder.Append(1);
            Console.WriteLine($"После добавляем целую часть , тогда новое число {stringBuilder}");

            stringBuilder.Append(splitted[1]);
            Console.WriteLine($"После добавляем дробную часть, тогда новое число {stringBuilder}");
            return stringBuilder.ToString();

        }
        public static string SumAddCodeForInt(string number1, string number2, bool flag, bool digit)
        {

            int[] mass1 = new int[number1.Length];
            int[] mass2 = new int[number2.Length];
            int[] mass3 = new int[Math.Max(mass1.Length, mass2.Length)];

            char[] result = new char[Math.Max(mass1.Length, mass2.Length)];

            for (int i = 0; i < number1.Length; i++)
            {
                mass1[i] = ConvertSymbolToNumber(number1[i]);
            }

            for (int i = 0; i < number2.Length; i++)
            {
                mass2[i] = ConvertSymbolToNumber(number2[i]);
            }

            Console.WriteLine($"{number1} + {number2} ");
            for (int i = 0; i < Math.Max(mass1.Length, mass2.Length); i++)
            {
                if (mass1.Length - 1 - i >= 0 && mass2.Length - 1 - i >= 0)
                {
                    mass3[mass3.Length - 1 - i] = mass3[mass3.Length - 1 - i] + mass1[mass1.Length - 1 - i] + mass2[mass2.Length - 1 - i];
                    Console.WriteLine($"Складываем {mass1[mass1.Length - 1 - i]} + {mass2[mass2.Length - 1 - i]} и прибавляем число {mass3[mass3.Length - 1 - i] - mass1[mass1.Length - 1 - i] - mass2[mass2.Length - 1 - i]} лежащие в этом разряде появивщиеся из-за переносов");
                }
                if (mass1.Length - 1 - i < 0)
                {
                    mass3[mass3.Length - 1 - i] += mass2[mass2.Length - 1 - i];
                    Console.WriteLine($"записываем в {i} разряд занчение {mass2[mass2.Length - 1 - i]}, так как первое число имеет на этих позициях незначащие нули");
                }
                if (mass2.Length - 1 - i < 0)
                {
                    mass3[mass3.Length - 1 - i] += mass1[mass1.Length - 1 - i];
                    Console.WriteLine($"записываем в {i} разряд занчение {mass1[mass1.Length - 1 - i]}, так как второе число имеет на этих позициях незначащие нули");
                }
                if (mass3[mass3.Length - 1 - i] >= 2)
                {
                    Console.WriteLine($"Число {mass3[mass3.Length - 1 - i]} в позиции {i + 1} больше основания ситемы, то вычиатем из него {2} и прибавляем на {i + 2} позицию еденицу");
                    mass3[mass3.Length - 1 - i] -= 2;
                    if (mass3.Length - i - 2 >= 0) mass3[mass3.Length - i - 2]++;
                }
            }

            string str = null;

            str = string.Join("", mass3);
            Console.WriteLine();
            Console.WriteLine($"Итог в двоичной системе счисления: {str}");

            if (flag)
            {
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("=");
                }
                Console.WriteLine();

                Console.WriteLine($"Итог в десятичной системе счисления: {FromBinToDec(str)}");
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("=");
                }
                Console.WriteLine();
            }
            if (digit)
            {
                str = "1" + "+" + str;
            }
            return str;
        }
        private static void FloatToDec(string number)
        {
            string[] splitted = number.Split(',');
            int count = splitted[0].Length - 1;
            double result = 0;
            number = number.Replace(",", "");
            for (int i = 0; i < number.Length; i++)
            {
                Console.WriteLine($"Прибавим к сумме {result} , {number[i]}*2^{count}");
                result = result + (number[i] - '0') * Math.Pow(2, count);
                count--;
            }
            Console.WriteLine();
            Console.WriteLine($"Итог: {result}");
        }
        public static void SumMantissa(string number1, string number2, int amountOfBit, double first, double second)
        {
            Console.WriteLine("Сложение чисел с плавующей точкой : ");
            Console.WriteLine();
            Console.WriteLine();

            int bitsForP;
            if (amountOfBit == 32) bitsForP = 8;
            else bitsForP = 11;
            int p = (int)Math.Pow(2, bitsForP) - 1;

            string[] splitted = number1.Split(new char[] { '*', '^' });
            number1 = splitted[0];
            int p1 = int.Parse(splitted[2]);

            splitted = number2.Split(new char[] { '*', '^' });
            number2 = splitted[0];
            int p2 = int.Parse(splitted[2]);

            int delta = MoveOrder(p1, p2);

            if (p1 > p2)
            {
                number2 = AlignmentOfTheOrder(number2, delta);
                p2 = p1;
            }
            else if (p2 > p1)
            {
                number1 = AlignmentOfTheOrder(number1, delta);
                p1 = p2;
            }

            Console.WriteLine($"Так как разрядная сетка равна {amountOfBit} , то числа вышедшие за сетку мы не рассматриваем");
            Console.WriteLine($"Тогда первое число имеет вид: {number1}*2^{p1}");
            Console.WriteLine($"Тогда второе число имеет вид: {number2}*2^{p2}");
            Console.WriteLine("Так как порядки чисел равны, то сложим их не целую часть");
            Console.WriteLine();

            string First = number1.Substring(2);
            string Last = number2.Substring(2);
            First += AdditionalCode.AddZero(amountOfBit - First.Length);
            Last += AdditionalCode.AddZero(amountOfBit - Last.Length);
            Console.WriteLine(First);
            Console.WriteLine(Last);
            string str = SumAddCodeForInt(First, Last, false, false);
            string Int;
            if (number1[0] == '1' && number2[0] == '1') Int = "10,";
            else if ((number1[0] == '1' || number2[0] == '1')) Int = "1,";
            else Int = "0,";
            if (str.Contains("+"))
            {
                str = str.Substring(2);
                if (Int == "10,") Int = "11,";
                else if (Int == "1,") Int = "10,";
                else Int = "1,";
            }
            Console.WriteLine($"Итог в экспоненциальной записи: {Int + str}*2^{p1}");
            str = Int.Replace(",", "") + str.Substring(0, p1) + "," + str.Substring(p1);
            FloatToDec(str);
        }

    }
}