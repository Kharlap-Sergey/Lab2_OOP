using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.v2
{
    public static class TypeOperationsReflections
    {
        private static object GetOperationResult(Func<object> action)
        {
            object result;
            try
            {
                result = action?.Invoke();
            }
            catch (RuntimeBinderException em)
            {
                return new String("Operation isn't implemented");
            }
            catch (Exception e)
            {
                result = "NaN";
            }
            return result;
        }
        public static ICollection<string> GetTypeOperations(Type T)
        {
            dynamic a = Activator.CreateInstance(T);
            dynamic b = Activator.CreateInstance(T);

            Func<object>[] funcs =
                {
                    new Func<object>(() => a = b),
                    new Func<object>(() => a += b),
                    new Func<object>(() => a - b),
                    new Func<object>(() => a -= b),
                    new Func<object>(() => a * b),
                    new Func<object>(() => a *= b),
                    new Func<object>(() => a / b),
                    new Func<object>(() => a + b),
                    new Func<object>(() => a /= b),
                    new Func<object>(() => a ^ b),
                    new Func<object>(() => a | b),
                    new Func<object>(() => a & b),
                    new Func<object>(() => a << 4),
                    new Func<object>(() => a >> 4),
                    new Func<object>(() => ~a),
                    new Func<object>(() => !a),
                    new Func<object>(() => a && b),
                    new Func<object>(() => a || b),
                    new Func<object>(() => a > b),
                    new Func<object>(() => a < b),
                    new Func<object>(() => a == b),
                    new Func<object>(() => a != b),
                    new Func<object>(() => a <= b),
                    new Func<object>(() => a >= b),
                    new Func<object>(() => !b),
                    new Func<object>(() => a++),
                    new Func<object>(() => ++a),
                    new Func<object>(() => --a),
                    new Func<object>(() => a--),
                     };


            string[] operations =
            {
                    "a = b",
                    "a + b",
                    "a += b",
                    "a - b",
                    "a -= b",
                    "a * b",
                    "a *= b",
                    "a / b",
                    " a /= b",
                    " a ^ b",
                    " a | b",
                    " a & b",
                    " a << 4",
                    " a >> 4",
                    " ~a",
                    " !a",
                    " a && b",
                    " a || b",
                    " a > b",
                    " a < b",
                    " a == b",
                    " a != b",
                    " a <= b",
                    " a >= b",
                    "!a",
                    " a++",
                    " ++a",
                    " --a",
                    " a--"
                     };

            var joint = operations.Zip(funcs,
                                      (op, func) => new
                                      {
                                          Op = op,
                                          Func = func
                                      }
                                      );


            var results = new List<string>();
            foreach (var el in joint)
            {
                var res = GetOperationResult(el.Func);
                var resStr = res ?? "null";
                results.Add($"operation = {el.Op}, result = {resStr}");
            }

            return results;
        }
    }
}
