using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.EnumerableExtention
{
    public static class EnumerableExtention
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class {
            T maxitem = default(T);
            float maxvalue = float.MinValue;

            foreach (var item in collection) { 
                float value = convertToNumber(item);
                if (value > maxvalue)
                {
                    maxvalue = value;
                    maxitem = item;
                }
            }

            return maxitem;
        }
    }
}
