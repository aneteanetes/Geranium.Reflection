using Geranium.Reflection.Struct;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace Geranium.Reflection.Ctor
{
    public static class CtorExtensions
    {
        /// <summary>
        /// 
        /// <para>
        /// [Кэшируемый]
        /// </para>
        /// </summary>
        public static ConstructorInfo FindConstructor(this Type type, params object[] args)
        {
            var descriptor = GetParamsDescriptor(args);
            var key =new CompositeTypeKey<string>(type,descriptor);
            if (!___GetConstructorCache.TryGetValue(key, out var value))
            {
                if (args.Length == 0)
                {
                    value = type.GetConstructors().FirstOrDefault(x => x.GetParameters().Length == 0);
                }
                else
                {
                    value = FindConstructorInfo(type, descriptor, args.Length);
                }
                ___GetConstructorCache.AddOrUpdate(key, value, (x, y) => value);
            }

            return value;
        }

        private static ConcurrentDictionary<CompositeTypeKey<string>, ConstructorInfo> ___GetConstructorCache
            = new ConcurrentDictionary<CompositeTypeKey<string>, ConstructorInfo>();

        public static string GetParamsDescriptor(params object[] args)
        {
            var value = string.Join(",", args.Select(a=>a.GetType().FullName));
            return String.Intern(value);
        }

        public static ConstructorInfo FindConstructorInfo(this  Type type, string descriptor, int argsCount)
        {
            var ctors = type.GetConstructors()
                .Select(x => new
                {
                    ctor = x,
                    @params = x.GetParameters().Select(p => p.ParameterType.FullName).ToArray()
                })
                .Where(x => x.@params.Length == argsCount);

            var ctor = ctors.FirstOrDefault(x => string.Join(",", x.@params) == descriptor)?.ctor;
        
            return ctor;
        }
    }
}
