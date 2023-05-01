using System;

namespace Geranium.Reflection.Struct
{
    /// <summary>
    /// Composite key with System.Type and <see cref="T"/>
    /// <para>
    /// Used for caching expression tree delegates
    /// </para>
    /// </summary>
    public struct CompositeTypeKey<T>
    {
        public CompositeTypeKey(Type owner, T value)
        {
            Value = value;
            Owner = owner;
        }

        public T Value { get; set; }

        public Type Owner { get; set; }

        public override bool Equals(object obj)
        {
            var internalValue = obj.GetPropertyExpr<string>(nameof(InternalValue));
            return internalValue == InternalValue;
        }

        private string InternalValue => Value?.ToString() + Owner?.AssemblyQualifiedName ?? "";

        public override int GetHashCode() => InternalValue.GetHashCode();
    }
}
