using System;

namespace TcknCheckAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TcknCheckAlgorithm made by furkanaltaca | v2.1");
            Console.WriteLine("Press Ctrl+C to exit");
            Console.WriteLine();

            while (true)
            {
                Console.Write("TC Kimlik No: ");

                if (CheckTckn(Console.ReadLine()))
                {
                    Console.WriteLine("Geçerli");
                }
                else
                {
                    Console.WriteLine("Geçersiz");
                }
                Console.WriteLine(new string('-', 50));
            }
        }

        public static bool CheckTckn(string tckn)
        {
            if (!ValidateTckn(tckn))
            {
                return false;
            }

            bool result = false;
            int evenDigits = 0,
            oddDigits = 0, 
            allDigits = 0,
            tenth = int.Parse(tckn[9].ToString()),
            eleventh = int.Parse(tckn[10].ToString()),
            firstValue,
            secondValue;

            for (short i = 0; i < 11; i++)
            {
                int value = int.Parse(tckn[i].ToString());
                if (i < 9)
                {
                    if (i % 2 == 0) evenDigits += value;
                    else oddDigits += value;
                }
                if (i <= 9) allDigits += value;
            }

            firstValue = ((evenDigits * 7) - oddDigits) % 10;
            secondValue = allDigits % 10;

            if (firstValue == tenth
                && secondValue == eleventh)
            {
                result = true;
            }

            return result;
        }

        public static bool ValidateTckn(string tckn)
        {
            bool result = false;

            bool isNumber = long.TryParse(tckn, out _);
            bool digitsAreEleven = tckn.Length == 11;
            bool firstDigitIsNotZero = tckn[0] != '0';

            if (isNumber
                && digitsAreEleven
                && firstDigitIsNotZero)
            {
                result = true;
            }

            return result;
        }
    }
}
