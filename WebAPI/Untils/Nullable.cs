#nullable enable
using System;

namespace WebAPI.Untils
{
    public static class Nullable
    {
        public static T OrElseThrow<T>(this T? o, Func<Exception> exceptionSupplier)
        {
            return o is null ? throw exceptionSupplier() : o;
        }
    }
}