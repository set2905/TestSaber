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
        private const string separator = " / ";
        public ListNode? Head;
        public ListNode? Tail;
        public int Count;

        public ListRandom()
        {
        }
        public static implicit operator ListRandom(List<string> s)
        {
            ListRandom newList = new ListRandom();
            foreach (string data in s)
            {
                newList.Add(data);
            }
            return newList;
        }

        public static explicit operator List<string>(ListRandom listRandom)
        {
            List<string> list = new List<string>();
            ListNode current = listRandom.Head;
            while (current != null)
            {
                list.Add(current.Data);
                current = listRandom.GetNext(current);
            }
            return list;
        }

        public static explicit operator List<ListNode>(ListRandom listRandom)
        {
            List<ListNode> list = new List<ListNode>();
            ListNode current = listRandom.Head;
            while (current != null)
            {
                list.Add(current);
                current = listRandom.GetNext(current);
            }
            return list;
        }

        public override string ToString()
        {
            string converted = String.Join(separator, (List<string>)this);

            return converted;
        }

        public ListNode GetNext(ListNode previous)
        {
            return previous.Next;
        }

        public int Add(string data)
        {
            ListNode addedNode = new ListNode(data);
            if (Count == 0)
            {
                Head = addedNode;
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
        public void Clear()
        {
            ListNode current = Head;
            while (current != null)
            {
                ListNode cached = current;
                current = GetNext(current);
                cached = null;
            }
        }
        public void Serialize(Stream s)
        {
            StreamWriter writer = new StreamWriter(s);
            Console.WriteLine("Writing: " + this.ToString());
            writer.WriteLine(this.ToString());
            writer.Close();
        }

        public void Deserialize(Stream s)
        {
            StreamReader reader = new StreamReader(s);

            string readString = reader.ReadToEnd();
            reader.Close();
            List<string> readList = readString.Split(separator).ToList();

            ListRandom readListRandom = readList;
            
            Console.WriteLine(readListRandom);
            Clear();
            foreach (string nodeData in readList)
            {
                Add(nodeData);
            }


        }
    }
}
