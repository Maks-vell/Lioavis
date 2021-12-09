using System;

namespace Laba_.Graphs
{
    partial class MatrixGraph
    {
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