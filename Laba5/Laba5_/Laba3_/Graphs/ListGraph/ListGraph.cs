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

        private List<int> _deepWalkList = new List<int>();

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

        public void VertexContraction(int v1, int v2)
        {
            int v1Inndex = v1 - 1;
            int v2Inndex = v2 - 1;
            for (int i = 0;
                 i < _list[v2Inndex].Count;
                 i++) // перенос из одной вершины всех соединений в другую и сортировка
            {
                if (_list[v2Inndex][i] != v2)
                {
                    _list[v1Inndex].Add(_list[v2Inndex][i]);
                }
                else
                {
                    _list[v1Inndex].Add(v1);
                }
            }

            List[v1Inndex].Sort();
            for (int i = 0; i < _list[v1Inndex].Count - 1; i++)
            {
                if (_list[v1Inndex][i] == _list[v1Inndex][i + 1])
                {
                    _list[v1Inndex].RemoveAt(i + 1);
                }
            }

            List[v1Inndex].Sort();
            List.RemoveAt(v2 - 1);
            for (int i = 0; i < _list.Count; i++) //запись новой вершины в другие
            {
                bool isHaveV1 = false;
                for (int j = 0; j < _list[i].Count; j++) // проверка на наличие связи с v1
                {
                    if (List[i][j] == v1)
                    {
                        isHaveV1 = true;
                    }
                }

                for (int j = 0; j < _list[i].Count; j++) // замена или удаление связей 
                {
                    if (_list[i][j] == v2 && !isHaveV1)
                    {
                        _list[i][j] = v1;
                    }
                    else if (_list[i][j] == v2 && isHaveV1)
                    {
                        _list[i].RemoveAt(j);
                    }
                    else if (_list[i][j] > v2)
                    {
                        _list[i][j]--;
                    }
                }
            }
        }

        public void SplitVertex(int v)
        {
            int vIndex = v - 1;

            _list.Insert(vIndex + 1, _list[vIndex]);
            foreach (List<int> l in _list)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    if (l[i] > v)
                    {
                        l[i]++;
                    }
                }

                int j = l.IndexOf(v);
                if (j > -1)
                {
                    l.Insert(j + 1, v + 1);
                }
            }

            _list[v].Add(v + 1);
            _list[v].Sort();
            _list[v + 1].Add(v);
            _list[v + 1].Sort();
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
            _deepWalkList.Add(v + 1);
            for (int i = 0; i < _list[v].Count; i++)
            {
                if (!_walkedList[_list[v][i] - 1])
                {
                    Walk(_list[v][i] - 1);
                }
            }
        }
    }
}