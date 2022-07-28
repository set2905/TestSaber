using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaberTest
{
    internal class ListRandom
    {
        public ListNode? Head;
        public ListNode? Tail;
        public int Count;

        public ListRandom()
        {
        }
        public static implicit operator ListRandom(string[] s)
        {
            ListRandom newList = new ListRandom();
            foreach (string data in s)
            {
                newList.Add(data);
            }
            return newList;
        }

        public override string ToString()
        {
            string converted = String.Concat(GetList());

            return converted;
        }

        private ListNode GetNext(ListNode previous)
        {

            return previous.Next;
        }

        public int Add(string data)
        {
            ListNode addedNode = new ListNode(data);
            if (Count == 0 || Tail == null)
            {
                Head = addedNode;
                Tail = addedNode;
            }
            else
            {
                Tail.Next = addedNode;
                addedNode.Previous = Tail;
            }

            Tail = addedNode;
            Count++;
            return Count;

        }
        public void Serialize(Stream s)
        {
            //byte[] byteArray = Encoding.ASCII.GetBytes(this.ToString().ToCharArray());
            StreamWriter writer = new StreamWriter(s);
            Console.WriteLine("Writing: " + this.ToString());
            writer.WriteLine(this.ToString());
            writer.Close();
        }

        public void Deserialize(Stream s)
        {

        }

        private List<string> GetList()
        {
            List<string> list = new List<string>();
            ListNode current = Head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list;
        }

    }
}
