using System;
using System.Collections.Generic;
using System.Diagnostics;
using Laba.Graphs.ListGraphs;
using Laba.Graphs.MatrixGraphs;

namespace Laba.Io
{
    class ConsoleProgram
    {
        MatrixGraph _myMatrixGraph;

        private ListGraph _myListGraph;

        public void WriteInfo()
        {
            Console.WriteLine("\t \t \t Добро пожаловать!!!");
            Console.WriteLine("\t \t \t 1 - Создать граф \n \t \t \t 2 - обход в глубину с рекурсией \n \t \t \t " +
                              "3 - обход в глубну без рекурсии на матрице \n \t \t \t 4 - обход в ширину \n \t \t \t 5 - поиск расстояний");
            Console.WriteLine();
        }

        public int GetOperations()
        {
            Console.WriteLine();
            Console.Write("\t \t \t Введите номер операции: ");
            return int.Parse(Console.ReadLine());
        }

        public void UnknowOperation()
        {
            Console.WriteLine("Неизвестная операция");
        }

        public void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("\t \t \t Работа завершена.");
        }

        public void CreateGrahs()
        {
            Console.WriteLine("Введите размер графа: ");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine();

            _myMatrixGraph = new MatrixGraph(size);

            _myListGraph = new ListGraph(_myMatrixGraph, size);

            Console.WriteLine("Граф в матричной форме: ");
            MatrixGraph.Display(_myMatrixGraph);
            Console.WriteLine();

            Console.WriteLine("Граф в форме списка: ");
            ListGraph.Display(_myListGraph);
            Console.WriteLine();
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

            Console.WriteLine("Введите исходную вершину: ");
            int v = int.Parse(Console.ReadLine());
            Console.WriteLine();

            List<int> resultList1 = _myMatrixGraph.DeepWalk(v);

            foreach (int el in resultList1)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();

            List<int> resultList2 = _myListGraph.DeepWalk(v);

            foreach (int el in resultList1)
            {
                Console.Write(el + " ");
            }
        }

        public void DeepWalkNonRecursive()
        {
            if (CheckNull())
            {
                return;
            }

            List<int> resultList = _myMatrixGraph.DeepWalkNonRecursive();

            foreach (int el in resultList)
            {
                Console.Write(el + " ");
            }
        }

        public void BreadthFirstSearch()
        {
            if (CheckNull())
            {
                return;
            }

            Console.WriteLine("Введите исходную вершину: ");
            int v = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<int> resultList = _myMatrixGraph.BreadthFirstSearch(v);
            sw.Stop();
            TimeSpan timeSpan = sw.Elapsed;
            Console.WriteLine("Time: " + timeSpan.Ticks);

            foreach (int el in resultList)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            resultList = _myListGraph.BreadthFirstSearch(v);

            foreach (int el in resultList)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("qeueueueueu");
            sw.Restart();
            resultList = _myMatrixGraph.MyBreadthFirstSearch(v);
            sw.Stop();
            timeSpan = sw.Elapsed;
            Console.WriteLine("Time: " + timeSpan.Ticks);

            foreach (int el in resultList)
            {
                Console.Write(el + " ");
            }
        }

        public void BreadthFirstLengthSearch()
        {
            if (CheckNull())
            {
                return;
            }

            Console.WriteLine("Введите исходную вершину для оценки расстояний: ");
            int v = int.Parse(Console.ReadLine());
            List<int> resultList = _myMatrixGraph.BreadthFirstLengthSearch(v);

            for (int i = 0; i < resultList.Count; i++)
            {
                int el = resultList[i];
                Console.WriteLine(i + 1 + ": " + el);
            }
            Console.WriteLine();

            resultList = _myListGraph.BreadthFirstLengthSearch(v);

            for (int i = 0; i < resultList.Count; i++)
            {
                int el = resultList[i];
                Console.WriteLine(i + 1 + ": " + el);
            }
            Console.WriteLine();
        }
    }
}