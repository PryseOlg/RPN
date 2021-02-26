using System;
using System.Collections.Generic;
using System.Linq;


namespace RPN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ToPrefix("2+5*7-4:4"));
            
        }
        
        static string ToPrefix(string expression)
        {
            List<string> result = new List<string>();
            Stack<string> operators = new Stack<string>();
            foreach (char symbol in expression)
            {
                if (char.IsDigit(symbol))
                {
                    
                    result.Add(symbol.ToString());
                }
                else
                {
                    while ((operators.TryPeek(out string head)) && (IsLowerPriority(symbol, head[0])))
                    {
                       result.Add(operators.Pop());
                    }
                    operators.Push(symbol.ToString());
                }
            }
            while (operators.Count != 0)
            {
                result.Add(operators.Pop());
            }

            return string.Join(" ", result);
        }

        static bool IsLowerPriority(char current, char last)
        {
            string[][] priorities = new string[][] {new string[] {"+", "-"}, new string[] {"*", ":"}};
            int priorityCurrent = 0, priorityLast = 0;
            for (int i = 0; i < priorities.Length; i++)
            {
                string[] operators = priorities[i];
                if (operators.Contains(current.ToString()))
                    priorityCurrent = i;
                if (operators.Contains(last.ToString()))
                    priorityLast = i;
            }
            return (priorityCurrent <= priorityLast);

        }
        
    }
}