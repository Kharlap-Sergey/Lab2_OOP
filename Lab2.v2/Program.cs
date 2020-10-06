using Lab2.v2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    class Program
    {
        static string ProgramPhelosofy { set; get; } = "C# is better then Java!!!";

        static void ShowTypeOperations(ICollection<string> operationsInfo, Type t)
        {
            Console.WriteLine(t);
            foreach (var operationRes in operationsInfo)
            {
                Console.WriteLine(operationRes);
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ProgramPhelosofy);
            Console.ForegroundColor = ConsoleColor.Black;
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


            foreach(var type in types)
            {
                var TypeOperationsDescriptions = TypeOperationsReflections.GetTypeOperations(type);
                ShowTypeOperations(TypeOperationsDescriptions, type);
            }
        }
    }
}
