using System;

namespace Laba3_.Graphs
{
    class MatrixGraph
    {
        private int[,] _matrix;

        private int _size;

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

            int v1Index = v1-1;
            int v2Index = v2-1;
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


        public static MatrixGraph Union(MatrixGraph matrix1, MatrixGraph matrix2)
        {
            int newSize = matrix1.Size > matrix2.Size ? matrix1.Size : matrix2.Size;

            int[,] newMatrix = new int[newSize, newSize];

            for (int i = 0; i < matrix1.Size; i++)
            {
                for (int j = 0; j < matrix1.Size; j++)
                {
                    newMatrix[i, j] = matrix1.Matrix[i, j];
                }
            }

            for (int i = 0; i < matrix2.Size; i++)
            {
                for (int j = 0; j < matrix2.Size; j++)
                {
                    if (matrix2.Matrix[i, j] > newMatrix[i, j])
                    {
                        newMatrix[i, j] = matrix2.Matrix[i, j];
                    }
                }
            }

            MatrixGraph newGraph = new MatrixGraph(newSize);
            newGraph.Matrix = newMatrix;
            return newGraph;
        }

        public static MatrixGraph Crossing(MatrixGraph matrix1, MatrixGraph matrix2)
        {
            int newSize = matrix1.Size < matrix2.Size ? matrix1.Size : matrix2.Size;
            int virtualSize = matrix1.Size > matrix2.Size ? matrix1.Size : matrix2.Size;

            int[,] newMatrix = new int[virtualSize, virtualSize];

            for (int i = 0; i < newSize; i++) 
            {
                for (int j = 0; j < newSize; j++)
                {
                    newMatrix[i, j] = matrix1.Matrix[i, j];
                }
            }

            for (int i = 0; i < newSize; i++)   //
            {
                for (int j = 0; j < newSize; j++)
                {
                    if (matrix2.Matrix[i, j] > newMatrix[i, j])
                    {
                        newMatrix[i, j] = matrix2.Matrix[i, j];
                    }
                }
            }

            MatrixGraph newGraph = new MatrixGraph(newSize);
            newGraph.Matrix = newMatrix;
            return newGraph;
        }

        public static MatrixGraph AnnularSum(MatrixGraph matrix1, MatrixGraph matrix2)
        {
            int newSize = matrix1.Size > matrix2.Size ? matrix1.Size : matrix2.Size;

            int[,] newMatrix = new int[newSize, newSize];

            for (int i = 0; i < matrix1.Size; i++)
            {
                for (int j = 0; j < matrix1.Size; j++)
                {
                    newMatrix[i, j] = matrix1.Matrix[i, j];
                }
            }

            for (int i = 0; i < matrix2.Size; i++)
            {
                for (int j = 0; j < matrix2.Size; j++)
                {
                    newMatrix[i, j] += matrix2.Matrix[i, j];
                    if (newMatrix[i, j] > 1)
                    {
                        newMatrix[i, j] = 0;
                    }
                }
            }
            
            MatrixGraph newGraph = new MatrixGraph(newSize);
            newGraph.Matrix = newMatrix;
            return newGraph;
        }

        public static MatrixGraph DecartSumm(MatrixGraph matrix1, MatrixGraph matrix2)
        {

            return null;
        }

        public static void Display(MatrixGraph graph)
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write(graph.Matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}