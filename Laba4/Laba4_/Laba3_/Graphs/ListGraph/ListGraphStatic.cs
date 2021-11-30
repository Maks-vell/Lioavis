using System;
using System.Collections.Generic;

namespace Laba4_.Graphs
{
    partial class ListGraph
    {
        public static void Display(ListGraph graph)
        {
            List<List<int>> list = graph.List;
            foreach (List<int> v in list)
            {
                if (v.Count == 0) Console.Write("-");
                for (int j = 0; j < v.Count; j++)
                {
                    Console.Write(v[j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}