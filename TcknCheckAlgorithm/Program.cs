using System;

namespace TcknCheckAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl+C to exit");
            Console.WriteLine();

            while (true)
            {
                Console.Write("TC Kimlik numarasınu giriniz: ");

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
            int evenDigits = 0, oddDigits = 0, allDigits = 0, first = 0, second = 0;

            for (int i = 0; i < 11; i++)
            {
                if (i < 9)
                {
                    if (i % 2 == 0) evenDigits += int.Parse(tckn[i].ToString());
                    else oddDigits += int.Parse(tckn[i].ToString());
                }
                if (i <= 9) allDigits += int.Parse(tckn[i].ToString());
            }
            first = ((evenDigits * 7) - oddDigits) % 10;
            second = allDigits % 10;

            if (first == int.Parse(tckn[9].ToString())
                && second == int.Parse(tckn[10].ToString()))
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
            bool firstDigitIsNotZero = tckn[0].ToString() != "0";

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
