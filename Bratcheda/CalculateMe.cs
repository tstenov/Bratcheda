using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bratcheda
{
    class CalculateMe
    {
        public int FindSumFromNumberDigits(int numberSelected)
        {
            if (numberSelected.ToString().Length == 1)
            {
                return numberSelected;
            }
            int result = numberSelected.ToString().Sum(c => c - '0');
            return result;
        }
        public int FindProductFromNumberDigits(int numberSelected)
        {
            int length = numberSelected.ToString().Length;
            if (length == 1)
            {
                return numberSelected;
            }
            return (numberSelected % 10) * FindProductFromNumberDigits(numberSelected / 10);
        }
        public  bool isPrime(int n)
        {
            if (n == 2)
            {
                return true;
            }
            if (n < 2 || n % 2 == 0)
            {
                return false;
            }
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool isPowerOf2LessThanMaxInList(int n,int maxVal)
        {
            if (Math.Pow(n, 2) < maxVal)
            {
                return true;
            }
           else
            {
                return false;
            }
            
        }
        public bool isSQRTInteger(int n)
        {
            if (Math.Sqrt(n) - Convert.ToInt32(Math.Sqrt(n))==0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
