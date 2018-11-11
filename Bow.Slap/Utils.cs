using System;

namespace Bow.Slap
{
    class Utils
    {
        public static bool IsSupportedType(Type t)
        {
            return t.IsPrimitive
                || t == typeof(string)
                || t == typeof(DateTime)
                || t == typeof(decimal)
				|| t == typeof(Guid);
        }

		public static object GetDefault(Type type)
		{
			if (type.IsValueType)
				return Activator.CreateInstance(type);
			return null;
		}
    }
}
