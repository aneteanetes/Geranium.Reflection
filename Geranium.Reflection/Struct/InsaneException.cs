using System;

namespace Geranium.Reflection.Struct
{
    public class InsaneException : Exception
    {
        public InsaneException():base("More than 16 args in constructor, are you insane? This library does not support madness!")
        {

        }
    }
}
