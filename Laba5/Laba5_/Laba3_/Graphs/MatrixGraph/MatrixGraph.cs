using System;
using System.Collections.Generic;

namespace Laba_.Graphs
{
    partial class MatrixGraph
    {
        private int[,] _matrix;

        private int _size;

        private List<int> _WalkList = new List<int>();

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

        public void VertexContraction(int v1, int v2)
        {
            if (v1 == v2) return;

            int v1Index = v1 - 1;
            int v2Index = v2 - 1;
            int[,] newMatrix = new int[_size - 1, _size - 1];

            if (_matrix[v1Index, v2Index] == 1) //создание петли
            {
                _matrix[v1Index, v1Index] = 1;
            }

            for (int i = 0; i < _size; i++) // прикрепили все связи к одной вершине
            {
                if (_matrix[v1Index, i] == 0)
                {
                    _matrix[v1Index, i] += _matrix[v2Index, i];
                }

                if (_matrix[i, v1Index] == 0)
                {
                    _matrix[i, v1Index] = _matrix[i, v2Index];
                }
            }

            for (int i = 0; i < v2Index; i++) //удалили ребро и перезаписали матрицу
            {
                for (int j = 0; j < _size; j++)
                {
                    if (j < v2Index)
                    {
                        newMatrix[i, j] = _matrix[i, j];
                    }
                    else if (j > v2Index)
                    {
                        newMatrix[i, j - 1] = _matrix[i, j];
                    }
                }
            }

            for (int i = v2Index + 1; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (j < v2Index)
                    {
                        newMatrix[i - 1, j] = _matrix[i, j];
                    }

                    if (j > v2Index)
                    {
                        newMatrix[i - 1, j - 1] = _matrix[i, j];
                    }
                }
            }

            _matrix = newMatrix;
            _size--;
        }

        public void SplitVertex(int v1)
        {
            v1--;
            int[,] newMatrix = new int[_size + 1, _size + 1];

            for (int i = 0; i <= v1; i++) //перезаписали матрицу с добавлением новой вершины
            {
                for (int j = 0; j < _size; j++)
                {
                    if (j <= v1)
                    {
                        newMatrix[i, j] = _matrix[i, j];
                    }

                    if (j > v1)
                    {
                        newMatrix[i, j + 1] = _matrix[i, j];
                    }
                }
            }

            for (int i = v1 + 1; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (j <= v1)
                    {
                        newMatrix[i + 1, j] = _matrix[i, j];
                    }

                    if (j > v1)
                    {
                        newMatrix[i + 1, j + 1] = _matrix[i, j];
                    }
                }
            }

            _matrix = newMatrix;
            _size++;

            for (int i = 0; i < _size; i++) //скопировали в новую вершину связи
            {
                _matrix[i, v1 + 1] = _matrix[i, v1];
                _matrix[v1 + 1, i] = _matrix[v1, i];
            }

            _matrix[v1, v1 + 1] = 1;
            _matrix[v1 + 1, v1] = 1;
        }

        public List<int> DeepWalk()
        {
            _walkedList = new bool[_size];

            Walk(0);

            return _WalkList;
        }

        private void Walk(int v)
        {
            _walkedList[v] = true;
            _WalkList.Add(v + 1);
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
            _WalkList = new List<int>();
            _walkedList = new bool[_size];

            NonRecursiveWalk();

            return _WalkList;
        }

        private void NonRecursiveWalk()
        {
            _savedV.Add(0);
            _WalkList.Add(1);
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
                    _WalkList.Add(i + 1);
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
            for (int i = 0; _size > 0; i++)
            {
                if (!_walkedList[i])
                {
                    UnderBreadthFirstSearch(i);
                }
            }
            return _WalkList;
        }

        private void UnderBreadthFirstSearch(int v) 
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(v);
            _walkedList[v] = true;

            while(queue.Count > 0)
            {
                v = queue.Dequeue();
                _WalkList.Add(v);
                for(int i = 0; i < _size; i++)
                {
                    if(_matrix[v,i] == 1 && !_walkedList[i])
                    {
                        queue.Enqueue(i);
                        _walkedList[v] = false;
                    }
                }
            }
        }
    }
}