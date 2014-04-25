using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadsPlayground
{
    static class Extensions
    {
        public static Maybe<T> ToMaybe<T>(this T Value)
        {
            return new Just<T>(Value);
        }

        public static Maybe<T2> Bind<T1, T2>(this Maybe<T1> a, Func<T1, Maybe<T2>> func)
        {
            var justa = a as Just<T1>;
            return justa == null ?
                new Nothing<T2>() :
                func(justa.Value);
        }

        public static Maybe<T3> SelectMany<T1, T2, T3>(this Maybe<T1> a,Func<T1,Maybe<T2>> func, Func<T1, T2, T3> select)
        { 
            return 
                a.Bind(aval =>
                func(aval).Bind(bval =>
                select(aval,bval).ToMaybe()));
        }
    }
}
