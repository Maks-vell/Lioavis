using System;
using Laba3_.Graphs;

namespace Laba3_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t \t \t Добро пожаловать!!!");
            Console.WriteLine("\t \t \t 1- Создать граф \n \t \t \t 2- Отождествление вершин у графа " +
                              "\n \t \t \t 3- Расщепление вершины у графа \n \t \t \t 4- Oбъединение со случайным графом " +
                              "\n \t \t \t 5- Пересечение со случайным графом \n \t \t \t 6- Кольцевая сумма графов \n \t \t \t" +
                              "5 - Декартовое произведение \n \t \t \t");
            Console.WriteLine();
            Program program = new Program();
            int operation;

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
                        program.CreateGrahs();
                        break;
                    case 2:
                        program.VertexContraction();
                        break;
                    case 3:
                        program.SplitVertex();
                        break;
                    case 4:
                        program.UnionGraphs();
                        break;
                    case 5:
                        program.CrossingGraphs();
                        break;
                    case 6:
                        program.AnnularSum();
                        break;
                    case 7:
                        program.DecartSum();
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция ");
                        break;
                }
            } while (operation != 0);

            Console.WriteLine();
            Console.WriteLine("\t \t \t Работа завершена.");
        }


        MatrixGraph _myMatrixGraph;

        private ListGraph _myListGraph;

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

        public void VertexContraction()
        {
            if (_myMatrixGraph == null || _myListGraph == null)
            {
                Console.WriteLine("Какой-либо граф отсутствует");
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
            if (_myMatrixGraph == null || _myListGraph == null)
            {
                Console.WriteLine("Какой-либо граф отсутствует");
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
            if (_myMatrixGraph == null || _myListGraph == null)
            {
                Console.WriteLine("Какой-либо граф отсутствует");
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
            if (_myMatrixGraph == null || _myListGraph == null)
            {
                Console.WriteLine("Какой-либо граф отсутствует");
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
            if (_myMatrixGraph == null || _myListGraph == null)
            {
                Console.WriteLine("Какой-либо граф отсутствует");
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
            if (_myMatrixGraph == null || _myListGraph == null)
            {
                Console.WriteLine("Какой-либо граф отсутствует");
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
    }
}