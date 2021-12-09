using System;
using System.Collections.Generic;
using Laba_.Graphs;

namespace Laba_
{
    class ConsoleProgram
    {
        MatrixGraph _myMatrixGraph;

        private ListGraph _myListGraph;

        public void WriteInfo()
        {
            Console.WriteLine("\t \t \t Добро пожаловать!!!");
            Console.WriteLine("\t \t \t 1- Создать граф \n \t \t \t 2- Отождествление вершин у графа " +
                              "\n \t \t \t 3- Расщепление вершины у графа \n \t \t \t 4- Oбъединение со случайным графом " +
                              "\n \t \t \t 5- Пересечение со случайным графом \n \t \t \t 6- Кольцевая сумма графов \n \t \t \t " +
                              "7- Декартовое произведение \n \t \t \t 8 - обход в глубину с рекурсией \n \t \t \t " +
                              "9- обход в глубну без рекурсии \n \t \t \t 10- обход в ширину");
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

        public void VertexContraction()
        {
            if (CheckNull())
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Введите вершины для отождествления");
            Console.WriteLine("v1: ");
            int v1 = int.Parse(Console.ReadLine());
            Console.WriteLine("v2: ");
            int v2 = int.Parse(Console.ReadLine());
            _myMatrixGraph.VertexContraction(v1, v2);
            _myListGraph.VertexContraction(v1, v2);
            Console.WriteLine();
            MatrixGraph.Display(_myMatrixGraph);
            Console.WriteLine();
            ListGraph.Display(_myListGraph);
        }

        public void SplitVertex()
        {
            if (CheckNull())
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Введите вершинy для расщепления: ");
            int v = int.Parse(Console.ReadLine());
            _myMatrixGraph.SplitVertex(v);
            _myListGraph.SplitVertex(v);
            Console.WriteLine();
            MatrixGraph.Display(_myMatrixGraph);
            Console.WriteLine();
            ListGraph.Display(_myListGraph);
        }

        public void UnionGraphs()
        {
            if (CheckNull())
            {
                return;
            }

            Console.WriteLine("Введите размер графа для объединения: ");
            int size = int.Parse(Console.ReadLine());
            MatrixGraph myNewMatrixGraph = new MatrixGraph(size);

            Console.WriteLine();
            Console.WriteLine("Граф для объединения в матричной форме: ");
            MatrixGraph.Display(myNewMatrixGraph);
            Console.WriteLine();

            _myMatrixGraph = MatrixGraph.Union(_myMatrixGraph, myNewMatrixGraph);
            _myListGraph = new ListGraph(_myMatrixGraph, size);

            Console.WriteLine();
            MatrixGraph.Display(_myMatrixGraph);
            Console.WriteLine();
            ListGraph.Display(_myListGraph);
        }

        public void CrossingGraphs()
        {
            if (CheckNull())
            {
                return;
            }

            Console.WriteLine("Введите размер графа для пересечения: ");
            int size = int.Parse(Console.ReadLine());
            MatrixGraph myNewMatrixGraph = new MatrixGraph(size);

            Console.WriteLine();
            Console.WriteLine("Граф для пересечения в матричной форме: ");
            MatrixGraph.Display(myNewMatrixGraph);
            Console.WriteLine();

            _myMatrixGraph = MatrixGraph.Crossing(_myMatrixGraph, myNewMatrixGraph);
            _myListGraph = new ListGraph(_myMatrixGraph, _myMatrixGraph.Size);

            Console.WriteLine();
            MatrixGraph.Display(_myMatrixGraph);
            Console.WriteLine();
            ListGraph.Display(_myListGraph);
        }

        public void AnnularSum()
        {
            if (CheckNull())
            {
                return;
            }

            Console.WriteLine("Введите размер графа для кольцевой суммы: ");
            int size = int.Parse(Console.ReadLine());
            MatrixGraph myNewMatrixGraph = new MatrixGraph(size);

            Console.WriteLine();
            Console.WriteLine("Граф для кольцевой суммы в матричной форме: ");
            MatrixGraph.Display(myNewMatrixGraph);
            Console.WriteLine();

            _myMatrixGraph = MatrixGraph.AnnularSum(_myMatrixGraph, myNewMatrixGraph);
            _myListGraph = new ListGraph(_myMatrixGraph, size);

            Console.WriteLine();
            MatrixGraph.Display(_myMatrixGraph);
            Console.WriteLine();
            ListGraph.Display(_myListGraph);
        }

        public void DecartSum()
        {
            if (CheckNull())
            {
                return;
            }

            Console.WriteLine("Введите размер графа для Декартового произведения: ");
            int size = int.Parse(Console.ReadLine());
            MatrixGraph myNewMatrixGraph = new MatrixGraph(size);

            Console.WriteLine();
            Console.WriteLine("Граф для Декартового произведения в матричной форме: ");
            MatrixGraph.Display(myNewMatrixGraph);
            Console.WriteLine();

            _myMatrixGraph = MatrixGraph.DecartSumm(_myMatrixGraph, myNewMatrixGraph);
            _myListGraph = new ListGraph(_myMatrixGraph, size);

            Console.WriteLine();
            MatrixGraph.Display(_myMatrixGraph);
            Console.WriteLine();
            ListGraph.Display(_myListGraph);
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

            List<int> resultList = _myMatrixGraph.BreadthFirstSearch();

            foreach (var el in resultList)
            {
                Console.Write(el + " ");
            }
        }
    }
}