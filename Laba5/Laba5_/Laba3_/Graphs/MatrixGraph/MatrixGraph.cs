using System;
using System.Collections.Generic;
using Laba_.Resources;

namespace Laba_.Graphs
{
    partial class MatrixGraph
    {
        private int[,] _matrix;

        private int _size;

        private List<int> _walkList = new List<int>();

        private bool[] _walkedList;

        private List<int> _savedV;

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

        public List<int> DeepWalk()
        {
            _walkedList = new bool[_size];

            Walk(0);

            return _walkList;
        }

        private void Walk(int v)
        {
            _walkedList[v] = true;
            _walkList.Add(v + 1);
            for (int i = 0; i < _size; i++)
            {
                if (_matrix[v, i] == 1 && !_walkedList[i])
                {
                    Walk(i);
                }
            }
        }

        public List<int> DeepWalkNonRecursive()
        {
            _savedV = new List<int>();
            _walkList = new List<int>();
            _walkedList = new bool[_size];

            NonRecursiveWalk();

            return _walkList;
        }

        private void NonRecursiveWalk()
        {
            _savedV.Add(0);
            _walkList.Add(1);
            _walkedList[0] = true;

            for (int i = 0; i < _size; i++)
            {
                if (_savedV.Count == 0)
                {
                    return;
                }

                if (_matrix[_savedV[^1], i] == 1 && !_walkedList[i])
                {
                    _savedV.Add(i);
                    _walkedList[i] = true;
                    _walkList.Add(i + 1);
                    i = 0;
                }

                if (i != _size - 1)
                {
                    continue;
                }

                _savedV.RemoveAt(_savedV.Count - 1);
                i = 0;
            }
        }

        public List<int> BreadthFirstSearch()
        {
            _walkedList = new bool[_size];
            _walkList.Clear();
            for (int i = 0; i < _size; i++)
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

            while(queue.Count > 0)
            {
                v = queue.Dequeue();
                _walkList.Add(v);
                for(int i = 0; i < _size; i++)
                {
                    if(_matrix[v,i] == 1 && !_walkedList[i])
                    {
                        queue.Enqueue(i);
                        _walkedList[v] = true;
                    }
                }
            }
        }

        public List<int> MyBreadthFirstSearch()
        {
            _walkedList = new bool[_size];
            _walkList.Clear();
            for (int i = 0; i < _size; i++)
            {
                if (!_walkedList[i])
                {
                    UnderBreadthFirstSearch(i);
                }
            }
            return _walkList;
        }

        private void MyUnderBreadthFirstSearch(int v)
        {
            queueuueue queue = new queueuueue();

            queue.Push(v);
            _walkedList[v] = true;

            while (queue.Count > 0)
            {
                v = queue.Pop();
                _walkList.Add(v);
                for (int i = 0; i < _size; i++)
                {
                    if (_matrix[v, i] == 1 && !_walkedList[i])
                    {
                        queue.Push(i);
                        _walkedList[v] = true;
                    }
                }
            }
        }
    }
}