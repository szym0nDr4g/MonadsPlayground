using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadsPlayground
{

    public static class EXT
    {
        public static Identity<T2> Bind<T1, T2>(this Identity<T1> identity, Func<T1, Identity<T2>> func)
        {
            return func(identity.Value);
        }

        public static Identity<T3> SelectMany<T1, T2, T3>(this Identity<T1> identity, Func<T1, Identity<T2>> func, Func<T1, T2, T3> select)
        {
            return select(identity.Value, func(identity.Value).Value).ToIdentity();
        }

        public static Identity<T> ToIdentity<T>(this T value)
        {
            return new Identity<T>(value);
        }
    }

    public class Identity<T>
    {
        public T Value { get; private set; }
        public Identity(T value)
        {
            Value = value;
        }
    }

    class Program
    {
        
      
    }
    }
