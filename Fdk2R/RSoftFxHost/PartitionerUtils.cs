using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RHost
{
    public static class PartitionerUtils
    {
    	public static TResult[] SelectToArray<TValue, TResult>(this TValue[] items, Func<TValue, TResult> func)
        {
			return Array.ConvertAll(items, it => func(it));
        }
    }
}
