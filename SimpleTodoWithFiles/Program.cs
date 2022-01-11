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
            var lines = File.ReadAllLines("data.csv");

            while (true)
            {
                Console.Write("Kommando: ");
                var command = Console.ReadLine();
                if (command == "vis")
                {
                    ShowAllTodos(lines);
                }
            }
        }

        static void ShowAllTodos(string[] lines)
        {
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var text = parts[0];
                var deadline = parts[1];
                var isDone = Convert.ToBoolean(parts[2]);
                //var isDone = bool.Parse(parts[2]);
                var isDoneText = isDone ? "ja" : "nei";
                Console.WriteLine($"Tekst: {text} Frist: {deadline} Er gjort? {isDoneText}");
            }

            // overload
        }
    }
}
