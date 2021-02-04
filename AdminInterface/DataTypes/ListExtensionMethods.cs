using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public static class ListExtensionMethods
    {
        public static string ToString<T>(this IList<T> list)
        {
            StringBuilder s = new StringBuilder();
            foreach (T a in list)
            {
                s.Append($" {a}\n");
            }
            return s.ToString();
        }
    }
}
