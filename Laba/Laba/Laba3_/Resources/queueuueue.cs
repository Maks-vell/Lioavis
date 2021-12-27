using System.Collections.Generic;


namespace Laba.Resources
{
    class queueuueue
    {
        private List<int> _list;

        public queueuueue()
        { 
            _list = new List<int>();
        }

        public int Count { 
            get
            {
                return _list.Count;
            }
        }

        public void Push(int el)
        {
            _list.Add(el);
        }

        public int Pop()
        {
            if( _list.Count == 0)
            {
                return -1;
            }
            
            int retValue = _list[0];
            _list.RemoveAt(0);
            return retValue;
        }
    }
}
