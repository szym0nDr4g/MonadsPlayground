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
        void Main()
        {
            Func<int, Identity<int>> add2 = x => new Identity<int>(x + 2);
            Func<int, Identity<int>> mul2 = x => new Identity<int>(x * 2);

            Func<int, Identity<int>> add2mult2 = x => add2(x).Bind(mul2);

            var result = "Hello World!".ToIdentity().Bind(x =>
                            7.ToIdentity().Bind(y =>
                                (new DateTime(2013, 1, 11)).ToIdentity().Bind(z =>
                                (x + y.ToString() + z.ToShortDateString()).ToIdentity())));
        }
       

      
    }
    }
