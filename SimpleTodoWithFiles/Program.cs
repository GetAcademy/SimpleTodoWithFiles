using System;
using System.IO;

namespace SimpleTodoWithFiles
{
    internal class Program
    {
        /* Todo-liste - hva skal man kunne gjøre? (CRUD - Create Read Update Delete)
            - Legge til en ny ting som skal gjøres
            - Fikse rekkefølge
            - Markere at en oppgave er gjort
            - Endre en ting som skal gjøres
            - Se hva vi skal gjøre

           Hvilken informasjon inngår i en "todo"
            - frist => DateTime
            - tekst => string
            - tittel => string
            - om den er gjort => bool         
         */

        static void Main(string[] args)
        {
            //OverloadDemo.Greet(5.5);
            //OverloadDemo.Welcome("Terje");
            var lines = ReadFile();

            while (true)
            {
                Console.Write("Kommando: ");
                var command = Console.ReadLine();
                if (command == "vis")
                {
                    ShowAllTodos(lines);
                }
                else if (command == "gjort")
                {
                    ChangeToDone(lines);
                }
                else if (command == "lesfil")
                {
                    lines = ReadFile();
                }
                else if (command == "lagrefil")
                {
                    File.WriteAllLines("data.csv", lines);
                }
                else if (command == "utsett")
                {
                    Postpone(lines);
                }
            }
        }

        private static void Postpone(string[] lines)
        {
            ShowAllTodos(lines);
            Console.Write("Hvilken vil du utsette? ");
            var todoNoStr = Console.ReadLine();
            var todoNo = Convert.ToInt32(todoNoStr);
            var index = todoNo - 1;
            var line = lines[index];
            var parts = line.Split(',');
            var deadline =Convert.ToDateTime(parts[1]);
            deadline = deadline.AddDays(1);
            parts[1] = deadline.ToShortDateString();
            lines[index] = string.Join(',', parts);
        }

        private static string[] ReadFile()
        {
            return File.ReadAllLines("data.csv");
        }

        private static void ChangeToDone(string[] lines)
        {
            ShowAllTodos(lines);
            Console.Write("Hvilken er gjort? ");
            var todoNoStr = Console.ReadLine();
            var todoNo = Convert.ToInt32(todoNoStr);
            var index = todoNo - 1;
            //var index = int.Parse(indexStr);
            var line = lines[index];
            var parts = line.Split(',');
            parts[2] = "true";
            lines[index] = string.Join(',', parts);
        }


        static void ShowAllTodos(string[] lines)
        {
            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                var parts = line.Split(',');
                var text = parts[0];
                var deadline = parts[1];
                var isDone = Convert.ToBoolean(parts[2]);
                //var isDone = bool.Parse(parts[2]);
                var isDoneText = isDone ? "ja" : "nei";
                Console.WriteLine($"{index+1} Tekst: {text} Frist: {deadline} Er gjort? {isDoneText}");
            }

            // overload
        }
    }
}
