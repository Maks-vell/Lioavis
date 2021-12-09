using System;

namespace Laba_.Graphs
{
    partial class MatrixGraph
    {
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