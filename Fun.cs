using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    public static class Fun
    {
        public static Func<T1, TResult> Run<T1, TResult>(Func<T1, TResult> func)
        {
            return func;
        }
        public static Func<T1, T2, TResult> Run<T1, T2, TResult>(Func<T1, T2, TResult> func)
        {
            return func;
        }

        public static Func<T1, T2, T3, TResult> Run<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
        {
            return func;
        }

        public static IEnumerable<T> Yield<T>(this IEnumerable<T> values)
        {
            foreach (var item in values)
                yield return item;

        }
    }
}

