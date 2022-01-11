using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodoWithFiles
{
    internal class OverloadDemo
    {
        public static void Welcome(string name = null)
        {
            Console.WriteLine(name == null ? "Hei!" : $"Hei, {name}!");
        }

        // Uten default-parameter:
        //public static void Welcome(string name)
        //{
        //    Console.WriteLine($"Hei, {name}!");
        //}

        //public static void Welcome()
        //{
        //    Console.WriteLine($"Hei!");
        //}

        //public static void Greet(int i)
        //{
        //    Console.WriteLine("Hallo!");
        //}
        //public static void Greet(double d)
        //{
        //    Console.WriteLine("Hei!");
        //}

    }
}
