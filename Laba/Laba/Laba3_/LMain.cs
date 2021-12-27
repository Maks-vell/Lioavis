using System;

namespace Laba
{
    class LMain
    {
        static void Main(string[] args)
        {
            ConsoleProgram consoleProgram = new ConsoleProgram();
            int operation;

            consoleProgram.WriteInfo();

            do
            {
                Console.WriteLine();
                Console.Write("\t \t \t Введите номер операции: ");
                operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 0:
                        break;
                    case 1:
                        consoleProgram.CreateGrahs();
                        break;
                    case 2:
                        consoleProgram.DeepWalk();
                        break;
                    case 3:
                        consoleProgram.DeepWalkNonRecurcive();
                        break;
                    case 4:
                        consoleProgram.BreadthFirstSearch();
                        break;
                    case 5:
                        consoleProgram.BreadthFirstLengthSearch();
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция ");
                        break;
                }
            } while (operation != 0);

            Console.WriteLine();
            Console.WriteLine("\t \t \t Работа завершена.");
        }
    }
}
