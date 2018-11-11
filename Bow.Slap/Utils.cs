using System;

namespace Bow.Slap
{
    class Utils
    {
        public static bool IsSimpleType(Type t)
        {
            return t.IsPrimitive
                || t == typeof(string)
                || t == typeof(DateTime)
                || t == typeof(DateTimeOffset)
                || t == typeof(decimal)
                || t == typeof(TimeSpan);
        }

		public static object GetDefault(Type type)
		{
			if (type.IsValueType)
				return Activator.CreateInstance(type);
			return null;
		}
    }
}
