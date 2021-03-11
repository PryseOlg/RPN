using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace RPNLogic {
    public class Calculator {
        private static Dictionary<string, Func<int, int, int>>
            operators = new Dictionary<string, Func<int, int, int>>();
        public static int Calculate(string expression) {
            string[] members = expression.Split(' ');
            Stack<int> values = new Stack<int>();
            int value;
            int second;

            for (int i = 0; i < members.Length; i++) {
                bool success = int.TryParse(members[i], out value);
                if (success)
                    values.Push(value);
                else {
                    second = values.Pop();
                    values.Push(operators[members[i]](values.Pop(), second));
                }
            }
            return values.Pop();
        }
        public static void Init() {
            operators.Add("+", (a, b) => a + b);
            operators.Add("*", (a, b) => a * b);
            operators.Add("-", (a, b) => a - b);
            operators.Add(":", (a, b) => a / b);
        }
    }
}