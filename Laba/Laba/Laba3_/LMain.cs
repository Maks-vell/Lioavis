using System;
using Laba.Io;

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
                operation = consoleProgram.GetOperations();

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
                        consoleProgram.DeepWalkNonRecursive();
                        break;
                    case 4:
                        consoleProgram.BreadthFirstSearch();
                        break;
                    case 5:
                        consoleProgram.BreadthFirstLengthSearch();
                        break;
                    default:
                        consoleProgram.UnknowOperation();
                        break;
                }
            } while (operation != 0);

            consoleProgram.Exit();
        }
    }
}