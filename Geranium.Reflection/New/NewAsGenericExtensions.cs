namespace Geranium.Reflection
{
    public static class NewAsGenericExtensions
    {
        public static object NewAs<T>(this object obj) => obj.New().As<T>();
    }
}