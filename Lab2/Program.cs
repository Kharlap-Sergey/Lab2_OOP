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
        private static IEnumerable<string> CheckOperations<T>()
        {
            dynamic a = Activator.CreateInstance(typeof(T));
            dynamic b = Activator.CreateInstance(typeof(T));

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

        static void ShowResultsOfTypeOperations<T>()
        {
            Console.WriteLine(typeof(T));
            var operationsResults = CheckOperations<T>();
            foreach (var operationRes in operationsResults)
            {
                Console.WriteLine(operationRes);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ProgramPhelosofy);
            ShowResultsOfTypeOperations<bool>();
            ShowResultsOfTypeOperations<byte>();
            ShowResultsOfTypeOperations<short>();
            ShowResultsOfTypeOperations<int>();
            ShowResultsOfTypeOperations<long>();
            ShowResultsOfTypeOperations<float>();
            ShowResultsOfTypeOperations<double>();
            ShowResultsOfTypeOperations<decimal>();
            ShowResultsOfTypeOperations<char>();            
        }
    }
}
