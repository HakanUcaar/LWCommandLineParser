using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCommandLineParser
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T obj, params T[] args)
        {
            return args.Contains(obj);
        }
        public static bool In<T>(this T obj, String[] args)
        {
            return Array.IndexOf(args, obj) > -1;
        }
        public static bool In<T>(this T obj, IEnumerable<T> args)
        {
            return args.Contains(obj);
        }
        public static bool In<T>(this T obj, List<T> args)
        {
            return args.Contains(obj);
        }

        public static int InIndex<T>(this T obj, String[] args)
        {
            return Array.IndexOf(args, obj);
        }
    }
}
