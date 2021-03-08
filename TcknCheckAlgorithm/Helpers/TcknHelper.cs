using System;

namespace TcknCheckAlgorithm.Helpers
{
    public static class TcknHelper
    {

        /// <summary>
        /// 
        /// </summary>
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
        
        /// <summary>
        /// 
        /// </summary>
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
