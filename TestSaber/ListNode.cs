using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaberTest
{
    internal class ListNode
    {
        public ListNode? Previous;
        public ListNode? Next;
        public ListNode? Random; // произвольный элемент внутри списка
        public string Data;

        public ListNode(string Data)
        {
            this.Data = Data;
        }
        public ListNode(ListNode Previous, ListNode Next, string Data)
        {
            this.Previous = Previous;
            this.Next = Next;
            this.Data = Data;
        }
    }
}
