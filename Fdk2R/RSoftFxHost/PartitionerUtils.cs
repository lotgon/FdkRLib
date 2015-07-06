using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RHost
{
    public static class PartitionerUtils
    {
        public static TResult[] SelectToArray<TValue, TResult>(this IList<TValue> items, Func<TValue, TResult> func)
        {
            var count = items.Count;
            var result = new TResult[count];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = func(items[i]);
            }
            return result;
        }
    }
}
