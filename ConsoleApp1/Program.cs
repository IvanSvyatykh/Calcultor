using CalculatorForFloatNumbers;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace CalculatorForFloatNumbers
{
    class Programm
    {
        static string NormalizationOfData(string str)
        {
            str = str.Trim();
            return str;
        }
        public static void Main()
        {

            while (true)
            {

                Console.WriteLine("Список операций :");
                Console.WriteLine("1 - Сложение целых чисел в дополнительном коде");
                Console.WriteLine("2 - Перевести целое число в дополнительный код");
                Console.WriteLine("3 - Перевести число с плавающей точкой число в дополнительный код");
                Console.WriteLine("4 - Сложение вещественных чисел в формате с плавающей точкой");
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("=");
                }
                Console.WriteLine();

                Console.Write("Введите : ");

                string operation = NormalizationOfData(Console.ReadLine());

                if (operation == "1")
                {

                    Console.Write("Введите первое число : ");
                    string first = NormalizationOfData(Console.ReadLine());

                    Console.Write("Введите второе число : ");
                    string second = NormalizationOfData(Console.ReadLine());

                    Console.Write("Введите количество бит для хранения информации, количестов может быть либо 64, либо 32 : ");
                    string amountOfBit = NormalizationOfData(Console.ReadLine());

                    if (amountOfBit == "" || int.Parse(amountOfBit) != 32 && int.Parse(amountOfBit) != 64)
                    {
                        Console.WriteLine($"{amountOfBit} не равно ни 32, ни 64, проверьте ввод");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }

                    if (first != "" && !int.TryParse(first, out int result))
                    {
                        Console.WriteLine($"Число {first} нельзя привести к целому типу данных, проверьте ввод!");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }
                    if (second != "" && !int.TryParse(second, out result))
                    {
                        Console.WriteLine($"Число {second} нельзя привести к целому типу данных, проверьте ввод!");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }

                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.Write("=");
                    }
                    Console.WriteLine();

                    Sum.SumAddCodeForInt(AdditionalCode.DecToCodeForInt(first, int.Parse(amountOfBit)), AdditionalCode.DecToCodeForInt(second, int.Parse(amountOfBit)), true, false);
                }

                if (operation == "2")
                {
                    Console.Write("Введите  число : ");
                    string number = NormalizationOfData(Console.ReadLine());

                    Console.Write("Введите количество бит для хранения информации, количестов может быть либо 64, либо 32 : ");
                    string amountOfBit = NormalizationOfData(Console.ReadLine());

                    if (amountOfBit == "" || int.Parse(amountOfBit) != 32 && int.Parse(amountOfBit) != 64)
                    {
                        Console.WriteLine($"{amountOfBit} не равно ни 32, ни 64, проверьте ввод");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }

                    if (number == "" || !int.TryParse(number, out int result))
                    {
                        Console.WriteLine($"Число {number} не записанно в десятичной иситеме счисления проверьте ввод!");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }

                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.Write("=");
                    }
                    Console.WriteLine();

                    AdditionalCode.DecToCodeForInt(number, int.Parse(amountOfBit));
                }

                if (operation == "3")
                {
                    Console.Write("Введите  число : ");
                    string number = NormalizationOfData(Console.ReadLine());

                    Console.Write("Введите количество бит для хранения информации, количестов может быть либо 64, либо 32 : ");
                    string amountOfBit = NormalizationOfData(Console.ReadLine());

                    if (amountOfBit == "" || int.Parse(amountOfBit) != 32 && int.Parse(amountOfBit) != 64)
                    {
                        Console.WriteLine($"{amountOfBit} не равно ни 32, ни 64, проверьте ввод");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }

                    if (number == "" || !double.TryParse(number, out double result))
                    {
                        Console.WriteLine($"Число {number} невозможно привести к вещественному типу данных, проверьте ввод!");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }

                    Console.ReadKey();

                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.Write("=");
                    }
                    Console.WriteLine();
                    AdditionalCode.FloatToCode(number, int.Parse(amountOfBit));
                }

                if (operation == "4")
                {
                    
                    Console.Write("Введите первое число : ");
                    string number1 = NormalizationOfData(Console.ReadLine());

                   
                    Console.Write("Введите второе число : ");
                    string number2 = NormalizationOfData(Console.ReadLine());

                    Console.Write("Введите количество бит для хранения информации, количестов может быть либо 64, либо 32 : ");
                    string amountOfBit = NormalizationOfData(Console.ReadLine());

                    if (amountOfBit == "" || (int.Parse(amountOfBit) != 32 && int.Parse(amountOfBit) != 64))
                    {
                        
                        Console.WriteLine($"{amountOfBit} не равно ни 32, ни 64, проверьте ввод");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }
                     

                    if (number1 == "" || !double.TryParse(number1, out double result))
                    {
                        Console.WriteLine($"Число {number1} невозможно привести к вещественному типу данных, проверьте ввод!");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }

                    if (number2 == null || !double.TryParse(number2, out result))
                    {
                        Console.WriteLine($"Число {number2} невозможно привести к вещественному типу данных, проверьте ввод!");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }
                                       
                    if (double.Parse(number1) < 0)
                    {
                        Console.WriteLine("Числа могут быть только положительными,введите другое число");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }
                    if (double.Parse(number2) < 0)
                    {
                        Console.WriteLine("Числа могут быть только положительными,введите другое число");
                        Console.ReadKey();
                        Console.Clear();
                        Main();
                    }
                    Console.ReadKey();

                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.Write("=");
                    }
                    Console.WriteLine();
                    Sum.SumMantissa(AdditionalCode.FloatToCode(number1, int.Parse(amountOfBit)), AdditionalCode.FloatToCode(number2, int.Parse(amountOfBit)), int.Parse(amountOfBit), double.Parse(number1), double.Parse(number2));
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}