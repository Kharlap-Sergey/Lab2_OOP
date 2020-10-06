using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    class Program
    {
        static string ProgramPhelosofy { set; get; } = "C# is better then Java!!!";
        private static object IsOperationImplemented(Func<object> action)
        {
            object result;
            try
            {
                result = action?.Invoke();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        private static ICollection<string> CheckOperations(Type T)
        {
            dynamic a = Activator.CreateInstance(T);
            dynamic b = Activator.CreateInstance(T);

            Func<object>[] funcs =
                {
                    new Func<object>(() => a + b),
                    new Func<object>(() => a += b),
                    new Func<object>(() => a - b),
                    new Func<object>(() => a -= b),
                    new Func<object>(() => a * b),
                    new Func<object>(() => a *= b),
                    new Func<object>(() => a / b),
                    new Func<object>(() => a /= b),
                    new Func<object>(() => a ^ b),
                    new Func<object>(() => a | b),
                    new Func<object>(() => a & b),
                    new Func<object>(() => a << 4),
                    new Func<object>(() => a >> 4),
                    new Func<object>(() => a && b),
                    new Func<object>(() => a || b),
                    new Func<object>(() => a > b),
                    new Func<object>(() => a < b),
                    new Func<object>(() => a == b),
                    new Func<object>(() => a != b),
                    new Func<object>(() => a <= b),
                    new Func<object>(() => a >= b),
                    new Func<object>(() => a++),
                    new Func<object>(() => ++a),
                    new Func<object>(() => --a),
                    new Func<object>(() => a--),
                     };


            string[] operations =
            {
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
                    " a && b",
                    " a || b",
                    " a > b",
                    " a < b",
                    " a == b",
                    " a != b",
                    " a <= b",
                    " a >= b",
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
                var res = IsOperationImplemented(el.Func);
                var resStr = res ?? "null";
                results.Add($"operation = {el.Op}, result = {resStr}");
            }

            return results;
        }

        static void ShowTypeOperations<T>()
        {
            Console.WriteLine(typeof(T));
            var operationsResults = CheckOperations(typeof(T));
            foreach (var operationRes in operationsResults)
            {
                Console.WriteLine(operationRes);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ProgramPhelosofy);
            List<Type> types = new List<Type>()
            { 
                typeof(int     ),
                typeof(bool    ),
                typeof(byte    ),
                typeof(short   ),
                typeof(long    ),
                typeof(float   ),
                typeof(decimal ),
                typeof(char    ),
            };  


            
        }
    }
}
