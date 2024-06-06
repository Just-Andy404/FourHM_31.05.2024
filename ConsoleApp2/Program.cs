using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Пользователь вводит в строку с клавиатуры логическое
//выражение. Например, 3>2 или 7<3. Программа должна подсчитать
//результат введенного выражения и выдать результат: true или false.
//В строке могут быть только целые числа и операторы: <, >, <=,
//>=, ==, != .Для обработки ошибок ввода используйте
//механизм исключений.

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите логическое выражение (используйте только целые числа и операторы <, >, <=, >=, ==, !=):");
            string input = Console.ReadLine();

            if (!IsValidExpression(input))
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            if (!EvaluateExpression(input, out bool result))
            {
                Console.WriteLine("Ошибка при вычислении выражения.");
                return;
            }

            Console.WriteLine(result ? "true" : "false");
        }

        static bool EvaluateExpression(string expression, out bool result)
        {
            string[] operators = new string[] { "<", ">", "<=", ">=", "==", "!=" };
            for (int i = 0; i < operators.Length; i++)
            {
                string op = operators[i];
                string[] parts = expression.Split(new string[] { op }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string leftPart = parts[0].Trim();
                    string rightPart = parts[1].Trim();
                    if (int.TryParse(leftPart, out int leftNumber) && int.TryParse(rightPart, out int rightNumber))
                    {
                        switch (op)
                        {
                            case "<":
                                result = leftNumber < rightNumber;
                                return true;
                            case ">":
                                result = leftNumber > rightNumber;
                                return true;
                            case "<=":
                                result = leftNumber <= rightNumber;
                                return true;
                            case ">=":
                                result = leftNumber >= rightNumber;
                                return true;
                            case "==":
                                result = leftNumber == rightNumber;
                                return true;
                            case "!=":
                                result = leftNumber != rightNumber;
                                return true;
                        }
                    }
                }
            }
            result = false; 
            return false;
        }

        static bool IsValidExpression(string expression)
        {
            string[] operators = new string[] { "<", ">", "<=", ">=", "==", "!=" };
            for (int i = 0; i < operators.Length; i++)
            {
                string op = operators[i];
                string[] parts = expression.Split(new string[] { op }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string leftPart = parts[0].Trim();
                    string rightPart = parts[1].Trim();
                    if (int.TryParse(leftPart, out int leftNumber) && int.TryParse(rightPart, out int rightNumber))
                    {
                        return true; 
                    }
                }
            }
            return false; 
        }




    }
}
