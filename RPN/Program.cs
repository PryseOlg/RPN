using System;
using RPNLogic;

namespace RPN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator.Calculate(NotationConverter.ToPostFix("5+2*7-4:4")));
        }
    }
}