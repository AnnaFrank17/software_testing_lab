using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class Triangle
    {
        public bool IsExist(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Side of the triangle can't be a negative");
            }

            var ab = a + b;
            var ac = a + c;
            var bc = b + c;

            return ab > c && ac > b && bc > a;
        }
    }
}
