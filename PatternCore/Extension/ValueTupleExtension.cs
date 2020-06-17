using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.Extension
{
    public static class ValueTupleExtension
    {
        public static (int, int) Add(this ValueTuple<int, int> self, int item1, int item2)
        {
            return new ValueTuple<int, int>(self.Item1 + item1, self.Item2 + item2);
        }

        public static (int, int) Add(this ValueTuple<int, int> self, (int, int) other)
        {
            return new ValueTuple<int, int>(self.Item1 + other.Item1, self.Item2 + other.Item2);
        }

        public static (int, int) Multiply(this ValueTuple<int, int> self, int other)
        {
            return new ValueTuple<int, int>(self.Item1 * other, self.Item2 * other);
        }

        public static (int, int) Multiply(this ValueTuple<int, int> self, int item1, int item2)
        {
            return new ValueTuple<int, int>(self.Item1 * item1, self.Item2 * item2);
        }
    }
}
