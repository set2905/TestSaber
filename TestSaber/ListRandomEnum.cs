using SaberTest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSaber
{
    internal class ListRandomEnum : IEnumerator
    {
        int position = -1;
        public List<ListNode> _nodes;

        public ListRandomEnum(ListRandom listRandom)
        {
            List<ListNode> list = new List<ListNode>();
            ListNode current = listRandom.Head;
            while (current != null)
            {
                list.Add(current);
                current = listRandom.GetNext(current);
            }
            _nodes = list;
        }


        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public ListNode Current
        {
            get
            {
                try
                {
                    return _nodes[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < _nodes.Count);
        }

        public void Reset()
        {
            position = -1;
        }

    }
}
