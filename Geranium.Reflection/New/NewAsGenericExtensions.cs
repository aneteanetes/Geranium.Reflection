namespace Geranium.Reflection
{
    public static class NewAsGenericExtensions
    {
        public static T NewAs<T>(this object obj) => obj.New().As<T>();
    }
}