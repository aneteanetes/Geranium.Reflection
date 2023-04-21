using System.Reflection;
using System.Runtime.CompilerServices;

namespace Geranium.Reflection
{
    /// <summary>
    /// System.Reflection is extensions
    /// </summary>
    public static class IsSpecificTypeExtensions
    {
        /// <summary>
        /// Check is type <see cref="Type.IsPrimitive"/> or numeric/string/datetime/tiemspan
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsPrimitive(this Type type) => type.IsPrimitive
                                                          || type.IsNumericType()
                                                          || type == typeof(string)
                                                          || type == typeof(DateTime)
                                                          || type == typeof(TimeSpan);

        /// <summary>
        /// Check is type <see cref="Type.IsPrimitive"/> or <see cref="IsNullablePrimitive(Type)"/> or <see cref="Type.IsEnum"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsSimple(this Type type) => type.IsPrimitive() || type.IsNullablePrimitive() || type.IsEnum;

        /// <summary>
        /// If type is nullable, then check <see cref="IsPrimitive(Type)"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullablePrimitive(this Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            return underlyingType != default && underlyingType.IsPrimitive();
        }

        /// <summary>
        /// If type is nullable, then check if NOT <see cref="Type.IsValueType"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            return underlyingType != default || !type.IsValueType;
        }

        /// <summary>
        /// Check is object type numeric by <see cref="IsNumericType(Type)"/>
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsNumericType(this object o) => o.GetType().IsNumericType();

        /// <summary>
        /// Check is type (S)Byte or (U)Int16/32/64 or Decimal or Double or Single
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsNumericType(this Type o)
        {
            switch (Type.GetTypeCode(o))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Check is type <see cref="DateTime"/>(?) or <see cref="DateTimeOffset"/>(?) or <see cref="TimeSpan"/>(?)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsDateType(this Type type)
        {
            var dateTypes = new Type[]
                {
                    typeof(DateTime), typeof(DateTime?),
                    typeof (DateTimeOffset), typeof(DateTimeOffset?),
                    typeof (TimeSpan), typeof(TimeSpan?)
                };
            return dateTypes.Contains(type);
        }

        /// <summary>
        /// Check type is 'anonymous' by <see cref="CompilerGeneratedAttribute"/> and typeName.<see cref="string.Contains(string)"/>->"AnonymousType"
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsAnonymousType(this Type type)
        {
            if (type == null)
                return false;

            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                && type.IsGenericType && type.Name.Contains("AnonymousType")
                && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                && type.Attributes.HasFlag(TypeAttributes.NotPublic);
        }

        /// <summary>
        /// Check is property virtual ICollection
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsDbCollection(this PropertyInfo property)
        {
            var goodType = property.PropertyType.IsICollection();
            return goodType && property.GetGetMethod().IsVirtual;
        }

        /// <summary>
        /// Check is type <see cref="ICollection{T}"/> of some type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsICollection(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>);
    }
}