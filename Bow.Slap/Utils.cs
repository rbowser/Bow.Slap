using System;
using System.Collections.Generic;
using System.Text;

namespace Bow.Slap
{
    class Utils
    {
        static bool IsSimpleType(Type t)
        {
            return t.IsPrimitive
                || t == typeof(string)
                || t == typeof(DateTime)
                || t == typeof(DateTimeOffset)
                || t == typeof(decimal)
                || t == typeof(TimeSpan);
        }
    }
}
