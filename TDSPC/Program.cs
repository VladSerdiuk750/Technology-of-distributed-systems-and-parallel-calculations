using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDSPC
{
    delegate void strMod(ref string stx);

    class DelegateTest
    {
        public void replaceSpaces(ref string a)
        {
            Console.WriteLine("Замена ");
            a = a.Replace(' ', '-');
        }

        public void removeSpaces(ref string a)
        {
            string temp = "";
            Console.WriteLine("Удаление проблелов.");
            for (int i = 0; i < a.Length; i++)
                if (a[i] != ' ') temp += a[i];
            a = temp;
        }
        public void reverse(ref string a)
        {
            string temp = "";
            Console.WriteLine("Реверсирование строки.");
            for (int j = 0, i = a.Length - 1; i >= 0; i--, j++)
                temp += a[i];
            a = temp;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "   Пример №1";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            string str = "Это простой тест.";
            var list = new List<strMod>()
            {
                new DelegateTest().replaceSpaces,
                new DelegateTest().reverse,
                new DelegateTest().removeSpaces
            };
            var strOp = list[0];
            strOp += list[1];
            strOp(ref str);
            Console.WriteLine("Peзультирующая строка: " + str);
            Console.WriteLine();
            strOp -= list[0];
            strOp += list[2];
            str = "Это простой тест.";
            strOp(ref str);
            Console.WriteLine("Peзультирующая строка: " + str);
            Console.WriteLine("Для завершение работы приложение нажмите клавишу <Enter>");
            Console.Read();
        }
    }
}
