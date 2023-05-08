using System;

namespace Geranium.Reflection.Struct
{
    public struct CompositeTypeKey
    {
        private int _hashCode;

        public override bool Equals(object obj)
        {
            if (obj==null)
                return false;

            if(obj is CompositeTypeKey key)
                return _hashCode== key._hashCode;

            return false;
        }

        public static CompositeTypeKey FromTypeValue(Type type, object value) => new CompositeTypeKey()
        {
            _hashCode = InternalHasher.Hash(type, value)
        };

        public override int GetHashCode() => _hashCode;

        public static bool operator ==(CompositeTypeKey left, CompositeTypeKey right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CompositeTypeKey left, CompositeTypeKey right)
        {
            return !(left._hashCode==right._hashCode);
        }
    }
}
