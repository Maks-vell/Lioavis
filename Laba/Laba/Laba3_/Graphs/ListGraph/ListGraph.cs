using System.Collections.Generic;
using Laba.Graphs.MatrixGraphs;

namespace Laba.Graphs.ListGraphs
{
    partial class ListGraph
    {
        private List<List<int>> _list;

        public List<List<int>> List
        {
            get { return _list; }
        }

        private List<int> _walkList = new List<int>();

        public ListGraph(MatrixGraph matrixGraph, int size)
        {
            _list = new List<List<int>>(size);
            int[,] matrix = matrixGraph.Matrix;


            for (int i = 0; i < size; i++)
            {
                _list.Add(new List<int>());
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        _list[i].Add(j + 1);
                    }
                }
            }
        }

        public List<int> DeepWalk(int v)
        {
            bool[] walkedList = new bool[_list.Count];

            Walk(v - 1, walkedList);

            return null;
        }

        private void Walk(int v, bool[] walkedList)
        {
            walkedList[v] = true;
            _walkList.Add(v + 1);
            for (int i = 0; i < _list[v].Count; i++)
            {
                if (!walkedList[_list[v][i] - 1])
                {
                    Walk(_list[v][i] - 1, walkedList);
                }
            }
        }

        public List<int> BreadthFirstSearch(int startV)
        {
            _walkList.Clear();
            Queue<int> queue = new Queue<int>();
            bool[] walkedList = new bool[_list.Count];
            int v = startV - 1;

            queue.Enqueue(v);
            walkedList[v] = true;
            _walkList.Add(v + 1);

            while (queue.Count > 0)
            {
                v = queue.Dequeue();
                if (!walkedList[v])
                {
                    _walkList.Add(v + 1);
                }

                foreach (var el in _list[v])
                {
                    if (!walkedList[el - 1])
                    {
                        queue.Enqueue(el - 1);
                    }
                }

                walkedList[v] = true;
            }

            return _walkList;
        }

        public List<int> BreadthFirstLengthSearch(int startV)
        {
            List<int> vectorDistance = new List<int>();
            for (int i = 0; i < _list.Count; i++)
            {
                vectorDistance.Add(-1);
            }

            Queue<int> queue = new Queue<int>();
            int v = startV - 1;

            queue.Enqueue(v);
            vectorDistance[v] = 0;

            while (queue.Count > 0)
            {
                v = queue.Dequeue();

                for (int i = 0; i < _list[v].Count; i++)
                {
                    int el = _list[v][i];
                    if (vectorDistance[el-1] == -1)
                    {
                        queue.Enqueue(el - 1);
                        vectorDistance[el-1] = vectorDistance[v] + 1;
                    }
                }
            }

            return vectorDistance;
        }
    }
}