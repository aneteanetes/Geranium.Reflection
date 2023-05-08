using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Geranium.Reflection
{
    /// <summary>
    /// New expression provided by ExpressionTree, Activator alternative
    /// </summary>
    public static class NewGenericExtensions
    {
        internal static Dictionary<int, MethodInfo> NewMethods=new Dictionary<int, MethodInfo>();

        static NewGenericExtensions()
        {
            var newMethods = typeof(NewGenericExtensions).GetMethods().Where(x => x.Name=="New").ToArray();
            foreach (var newMethod in newMethods)
            {
                var newMethodAttr = newMethod.GetCustomAttribute(typeof(NewMethodAttribute));
                if (newMethodAttr!=default && newMethodAttr is NewMethodAttribute nma)
                {
                    NewMethods.Add(nma.ArgsCount, newMethod);
                }
            }
        }

        public static object New(this object obj)
        {
            // activator faster on 0 args
            return Activator.CreateInstance(obj is Type type ? type : obj.GetType()); //NewGenericCache.GetPropFunc(obj is Type type ? type : obj.GetType())();
        }

        [NewMethod(1)]
        public static object New<T1>(this object obj, T1 arg1)
        {
            return NewGenericCache<T1>.GetFunc(obj is Type type ? type : obj.GetType())(arg1);
        }

        [NewMethod(2)]
        public static object New<T1, T2>(this object obj, T1 arg1, T2 arg2)
        {
            return NewGenericCache<T1, T2>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2);
        }

        [NewMethod(3)]
        public static object New<T1, T2, T3>(this object obj, T1 arg1, T2 arg2, T3 arg3)
        {
            return NewGenericCache<T1, T2, T3>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3);
        }

        [NewMethod(4)]
        public static object New<T1, T2, T3, T4>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return NewGenericCache<T1, T2, T3, T4>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4);
        }

        [NewMethod(5)]
        public static object New<T1, T2, T3, T4, T5>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return NewGenericCache<T1, T2, T3, T4, T5>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5);
        }

        [NewMethod(6)]
        public static object New<T1, T2, T3, T4, T5, T6>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        [NewMethod(7)]
        public static object New<T1, T2, T3, T4, T5, T6, T7>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        [NewMethod(8)]
        public static object New<T1, T2, T3, T4, T5, T6, T7, T8>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        [NewMethod(9)]
        public static object New<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        [NewMethod(10)]
        public static object New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        [NewMethod(11)]
        public static object New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        [NewMethod(12)]
        public static object New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        [NewMethod(13)]
        public static object New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        [NewMethod(14)]
        public static object New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        [NewMethod(15)]
        public static object New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        [NewMethod(16)]
        public static object New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            return NewGenericCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.GetFunc(obj is Type type ? type : obj.GetType())(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }
    }
}