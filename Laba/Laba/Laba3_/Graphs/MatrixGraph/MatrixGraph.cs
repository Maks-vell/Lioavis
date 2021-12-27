using System;
using System.Collections.Generic;
using Laba.Resources;

namespace Laba.Graphs.MatrixGraphs
{
    partial class MatrixGraph
    {
        private int[,] _matrix;

        private int _size;

        private List<int> _walkList = new List<int>();

        public int[,] Matrix
        {
            get { return _matrix; }
            set
            {
                _matrix = value;
                _size = Convert.ToInt32(Math.Sqrt(_matrix.Length));
            }
        }

        public int Size
        {
            get { return _size; }
        }

        public MatrixGraph(int size)
        {
            _size = size;
            _matrix = new int[_size, _size];
            Random random = new Random();

            for (int i = 0; i < _size; i++)
            {
                for (int j = i + 1; j < _size; j++)
                {
                    _matrix[i, j] = random.Next(0, 2);
                }
            }

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    _matrix[i, j] = _matrix[j, i];
                }
            }
        }

        public List<int> DeepWalk(int v)
        {
            _walkList.Clear();
            bool[] walkedList = new bool[_size];
            Walk(v - 1, walkedList);

            return _walkList;
        }

        private void Walk(int v, bool[] walkedList)
        {
            walkedList[v] = true;
            _walkList.Add(v + 1);
            for (int i = 0; i < _size; i++)
            {
                if (_matrix[v, i] == 1 && !walkedList[i])
                {
                    Walk(i, walkedList);
                }
            }
        }

        public List<int> DeepWalkNonRecursive()
        {
            _walkList.Clear();
            bool[] walkedList = new bool[_size];
            List<int> savedV = new List<int>();

            savedV.Add(0);
            _walkList.Add(1);
            walkedList[0] = true;

            for (int i = 0; i < _size; i++)
            {
                if (savedV.Count == 0)
                {
                    return _walkList;
                }

                if (_matrix[savedV[^1], i] == 1 && !walkedList[i])
                {
                    savedV.Add(i);
                    walkedList[i] = true;
                    _walkList.Add(i + 1);
                    i = 0;
                }

                if (i != _size - 1)
                {
                    continue;
                }

                savedV.RemoveAt(savedV.Count - 1);
                i = 0;
            }

            return _walkList;
        }

        public List<int> BreadthFirstSearch(int startV)
        {
            _walkList.Clear();
            Queue<int> queue = new Queue<int>();
            bool[] walkedList = new bool[_size];
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

                for (int i = 0; i < _size; i++)
                {
                    if (_matrix[v, i] == 1 && !walkedList[i])
                    {
                        queue.Enqueue(i);
                    }
                }

                walkedList[v] = true;
            }

            return _walkList;
        }

        public List<int> MyBreadthFirstSearch(int startV)
        {
            _walkList.Clear();
            queueuueue queue = new queueuueue();
            bool[] walkedList = new bool[_size];
            int v = startV - 1;

            queue.Push(v);
            walkedList[v] = true;
            _walkList.Add(v + 1);

            while (queue.Count > 0)
            {
                v = queue.Pop();
                if (!walkedList[v])
                {
                    _walkList.Add(v + 1);
                }

                for (int i = 0; i < _size; i++)
                {
                    if (_matrix[v, i] == 1 && !walkedList[i])
                    {
                        queue.Push(i);
                    }
                }

                walkedList[v] = true;
            }

            return _walkList;
        }

        public List<int> BreadthFirstLengthSearch(int startV)
        {
            Queue<int> queue = new Queue<int>();
            List<int> vectorDistance = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                vectorDistance.Add(-1);
            }

            int v = startV - 1;

            queue.Enqueue(v);
            vectorDistance[v] = 0;

            while (queue.Count > 0)
            {
                v = queue.Dequeue();
                for (int i = 0; i < _size; i++)
                {
                    if (_matrix[v, i] == 1 && vectorDistance[i] == -1)
                    {
                        queue.Enqueue(i);
                        vectorDistance[i] = vectorDistance[v] + 1;
                    }
                }
            }

            return vectorDistance;
        }
    }
}