using System;

namespace Geranium.Reflection
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class NewMethodAttribute : Attribute
    {
        public readonly int ArgsCount;

        // This is a positional argument
        public NewMethodAttribute(int argsCount = 0)
        {
            ArgsCount=argsCount;
        }
    }
}
