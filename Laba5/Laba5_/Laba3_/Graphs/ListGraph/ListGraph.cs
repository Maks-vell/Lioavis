using System.Collections.Generic;


namespace Laba_.Graphs
{
    partial class ListGraph
    {
        private List<List<int>> _list;

        public List<List<int>> List
        {
            get { return _list; }
        }

        private List<int> _walkList = new List<int>();

        private bool[] _walkedList;

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

        public List<int> DeepWalk()
        {
            _walkedList = new bool[_list.Count];
            for (int i = 0; i < _list.Count; i++)
            {
                Walk(i);
            }
            return null;
        }

        private void Walk(int v)
        {
            _walkedList[v] = true;
            _walkList.Add(v + 1);
            for (int i = 0; i < _list[v].Count; i++)
            {
                if (!_walkedList[_list[v][i] - 1])
                {
                    Walk(_list[v][i] - 1);
                }
            }
        }


        public List<int> BreadthFirstSearch()
        {
            _walkedList = new bool[_list.Count];
            for (int i = 0; i < _list.Count; i++)
            {
                if (!_walkedList[i])
                {
                    UnderBreadthFirstSearch(i);
                }
            }
            return _walkList;
        }

        private void UnderBreadthFirstSearch(int v)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(v);
            _walkedList[v] = true;

            while (queue.Count > 0)
            {
                v = queue.Dequeue();
                _walkList.Add(v);
                foreach(var el in _list[v])
                {
                    if (!_walkedList[el-1])
                    {
                        queue.Enqueue(el-1);
                        _walkedList[v] = true;
                    }
                }
            }
        }
    }
}