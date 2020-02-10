using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testing
{
    public static class Py
    {
        public static Tuple<int, T> Enumerate(this IEnumerable<T> obj)
        {
            foreach (var item in obj.Select((x, index) => (index, x)))
                yield return item;
        }
    }
}
