using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mod1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void task1()
        {
            string name, surname, pname;

            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.Write("Surname: ");
            surname = Console.ReadLine();

            Console.Write("P Name: ");
            pname = Console.ReadLine();

            Console.ReadKey();
            Console.WriteLine("Приветствую тебя - {0} {1} {2}", name, surname, pname);
            Console.ReadKey();
        }

        static void task2_1()
        {
            int a = Int32.Parse(Console.ReadLine());
            int b = Int32.Parse(Console.ReadLine());
            Console.Write(a + b);
        }




    }
}

