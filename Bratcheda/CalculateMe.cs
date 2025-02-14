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
    }
}
