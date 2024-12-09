using System;

namespace Geranium.Reflection
{
    public static class NewAsGenericExtensions
    {
        public static T NewAs<T>(this object obj) => obj.New().As<T>();
        
        public static T NewAs<T,T1>(this object obj, T1 arg1) => obj.New(arg1).As<T>();
                
        public static T NewAs<T,T1, T2>(this object obj, T1 arg1, T2 arg2) => obj.New(arg1,arg2).As<T>();

        public static T NewAs<T,T1, T2, T3>(this object obj, T1 arg1, T2 arg2, T3 arg3) => obj.New(arg1, arg2,arg3).As<T>();

        public static T NewAs<T,T1, T2, T3, T4>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => obj.New(arg1, arg2,arg3,arg4).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => obj.New(arg1, arg2, arg3, arg4,arg5).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => obj.New(arg1, arg2, arg3, arg4, arg5,arg6).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6, T7>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6, T7, T8>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6, T7, T8, T9>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,arg9).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9,arg10).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10,arg11).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11,arg12).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12,arg13).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13,arg14).As<T>();

        public static T NewAs<T,T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14,arg15).As<T>();

        public static T NewAs<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this object obj, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) => obj.New(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16).As<T>();
    }
}