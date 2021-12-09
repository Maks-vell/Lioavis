using System;
using System.Collections.Generic;
using Laba_.Graphs;
using System.Threading;
using System.Diagnostics;

namespace Laba_
{
    class ConsoleProgram
    {
        MatrixGraph _myMatrixGraph;

        private ListGraph _myListGraph;

        public void WriteInfo()
        {
            Console.WriteLine("\t \t \t Добро пожаловать!!!");
            Console.WriteLine("\t \t \t 1- Создать граф \n \t \t \t 2 - обход в глубину с рекурсией \n \t \t \t " +
                              "3- обход в глубну без рекурсии \n \t \t \t 4- обход в ширину");
            Console.WriteLine();
        }

        public void CreateGrahs()
        {
            Console.WriteLine("Введите размер графа: ");
            int size = int.Parse(Console.ReadLine());

            _myMatrixGraph = new MatrixGraph(size);

            _myListGraph = new ListGraph(_myMatrixGraph, size);

            Console.WriteLine();
            Console.WriteLine("Граф в матричной форме: ");
            MatrixGraph.Display(_myMatrixGraph);
            Console.WriteLine();
            Console.WriteLine("Граф в форме списка: ");
            ListGraph.Display(_myListGraph);
        }


        public bool CheckNull()
        {
            if (_myMatrixGraph == null || _myListGraph == null)
            {
                Console.WriteLine("Какой-либо граф отсутствует");
                return true;
            }

            return false;
        }

        public void DeepWalk()
        {
            if (CheckNull())
            {
                return;
            }

            List<int> resultList1 = _myMatrixGraph.DeepWalk();

            Console.WriteLine();
            foreach (var el in resultList1)
            {
                Console.Write(el + " ");
            }

            List<int> resultList2 = _myListGraph.DeepWalk();

            Console.WriteLine();
            foreach (var el in resultList1)
            {
                Console.Write(el + " ");
            }
        }

        public void DeepWalkNonRecurcive()
        {
            if (CheckNull())
            {
                return;
            }

            List<int> resultList = _myMatrixGraph.DeepWalkNonRecursive();

            foreach (var el in resultList)
            {
                Console.Write(el + " ");
            }
        }

        public void UnderBreadthFirstSearch()
        {
            if (CheckNull())
            {
                return;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<int> resultList = _myMatrixGraph.BreadthFirstSearch();
            sw.Stop();
            TimeSpan timeSpan = sw.Elapsed;
            Console.WriteLine("Time: " + timeSpan.Ticks);

            foreach (var el in resultList)
            {
                Console.Write(el + " ");
            }
            
            Console.WriteLine();
            resultList = _myListGraph.BreadthFirstSearch();

            foreach (var el in resultList)
            {
                Console.Write(el + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("qeueueueueu");

            sw.Restart();
            resultList = _myMatrixGraph.MyBreadthFirstSearch();
            sw.Stop();
            timeSpan = sw.Elapsed;
            Console.WriteLine("Time: " + timeSpan.Ticks);

            foreach (var el in resultList)
            {
                Console.Write(el + " ");
            }
        }
    }
}