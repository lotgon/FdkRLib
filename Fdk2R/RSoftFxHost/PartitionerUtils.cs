using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHost
{
    public static class PartitionerUtils
    {
    	public static void CallTimed(Action action, string message)
        {
            var sw = Stopwatch.StartNew();
            action();
            Console.WriteLine("{1}: {0}", sw.ElapsedMilliseconds, message);
        }
        struct TaskPartition<TValue, TResult>
        {
            public int StartItem { get; set; }
            public int Length { get; set; }
            public IList<TValue> Values { get; set; }
            public List<TResult> Results { get; set; }
        }


        internal static TResult[] SelectToArray<TValue, TResult>(this IList<TValue> items, Func<TValue, TResult> func)
        {
            var count = items.Count;
            var result = new TResult[count];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = func(items[i]);
            }
            return result;
        }

        public static List<TResult> ParititionProcess<TValue, TResult>(this IList<TValue> source, Func<TValue, TResult> func,
            int partitionCount = 4)
        {
            List<TaskPartition<TValue, TResult>> partitions = new List<TaskPartition<TValue, TResult>>();

            var pos = 0;
            var stride = source.Count/partitionCount + 1;
            for (var i = 0; i < partitionCount; i++)
            {
                if (pos + stride > source.Count)
                {
                    stride = source.Count - pos;
                }

                partitions.Add(new TaskPartition<TValue, TResult>
                {
                    StartItem = pos,
                    Length = stride,
                    Values = source,
                    Results= new List<TResult>()
                });
                
                pos += stride;
            }

            Parallel.ForEach(partitions, partition =>
            {
                var position = partition.StartItem;
                var length = partition.Length;
                var values = partition.Values;
                var results = partition.Results;
                for (var index = 0; index < length; index++)
                {
                    results.Add(func(values[position]));
                    position++;
                }
            });
            var finalResullt = new List<TResult>();
            foreach (var taskPartition in partitions)
            {
                finalResullt.AddRange(taskPartition.Results);
            }
            return finalResullt;
        }
    }
}
