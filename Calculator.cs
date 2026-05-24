using System;
using System.Linq;

namespace UnitTestingLab
{
    public class Calculator
    {
        public const int ERROR_NONE = 0;
        public const int ERROR_INVALID_INPUT = -1;
        public const int ERROR_DIVISION_BY_ZERO = -2;
        public const int ERROR_NULL_ARRAY = -3;
        public const int ERROR_EMPTY_ARRAY = -4;

        public static (double result, int errorCode) InchesToCentimeters(double inches)
        {
            if (inches < 0)
                return (0, ERROR_INVALID_INPUT);

            return (inches * 2.54, ERROR_NONE);
        }

        public static (bool isEven, int errorCode) IsEven(int number)
        {
            return (number % 2 == 0, ERROR_NONE);
        }

        public static (int maxValue, int errorCode) FindMax(int[] array)
        {
            if (array == null)
                return (0, ERROR_NULL_ARRAY);

            if (array.Length == 0)
                return (0, ERROR_EMPTY_ARRAY);

            return (array.Max(), ERROR_NONE);
        }

        public static (int remainder, int errorCode) Modulo(int dividend, int divisor)
        {
            if (divisor == 0)
                return (0, ERROR_DIVISION_BY_ZERO);

            return (dividend % divisor, ERROR_NONE);
        }

        public static (double totalAmount, int errorCode) CalculateBankInterest(double deposit)
        {
            if (deposit < 0)
                return (0, ERROR_INVALID_INPUT);

            double rate;
            if (deposit < 100)
                rate = 0.05;
            else if (deposit <= 200)
                rate = 0.07;
            else
                rate = 0.10;

            return (deposit * (1 + rate), ERROR_NONE);
        }
    }
}
