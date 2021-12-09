using System;

namespace Laba_
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
                        consoleProgram.VertexContraction();
                        break;
                    case 3:
                        consoleProgram.SplitVertex();
                        break;
                    case 4:
                        consoleProgram.UnionGraphs();
                        break;
                    case 5:
                        consoleProgram.CrossingGraphs();
                        break;
                    case 6:
                        consoleProgram.AnnularSum();
                        break;
                    case 7:
                        consoleProgram.DecartSum();
                        break;
                    case 8:
                        consoleProgram.DeepWalk();
                        break;
                    case 9:
                        consoleProgram.DeepWalkNonRecurcive();
                        break;
                    case 10:
                        consoleProgram.UnderBreadthFirstSearch();
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
