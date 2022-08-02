using System.Collections;
using TestSaber;

namespace SaberTest
{
    internal class ListRandom : IEnumerable
    {
        private const string objSeparator = " , ";
        private const string fieldSeparator = " : ";
        public ListNode? Head;
        public ListNode? Tail;
        public int Count;

        public ListNode? this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                int currentIndex = 0;
                ListNode currentNode = Head;
                while (index != currentIndex)
                {
                    currentNode = GetNext(currentNode);
                    currentIndex++;
                }
                return currentNode;
            }
        }

        public ListRandom()
        {
        }
        public static implicit operator ListRandom(List<string> objects)
        {
            ListRandom newList = new ListRandom();
            foreach (string content in objects)
            {
                string[] fields = content.Split(fieldSeparator);
                newList.Add(new ListNode(content));
            }
            return newList;
        }

        public static explicit operator List<string>(ListRandom listRandom)
        {
            List<string> convertedToStringList = new List<string>();
            ListNode current = listRandom.Head;
            while (current != null)
            {
                convertedToStringList.Add(current.Data + fieldSeparator + listRandom.IndexOf(current));
                current = listRandom.GetNext(current);
            }
            return convertedToStringList;
        }



        public override string ToString()
        {
            string converted = String.Join(objSeparator, (List<string>)this);

            return converted;
        }

        public ListNode GetNext(ListNode previous)
        {
            return previous.Next;
        }

        public int Add(ListNode addedNode)
        {
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
            this.Shuffle();

            return Count;

        }

        public int IndexOf(ListNode node)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i] == node)
                {
                    return i;
                }
            }
            return -1;
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
            List<string> objects = readString.Split(objSeparator).ToList();

            ListRandom readListRandom = objects;



            Console.WriteLine(readListRandom);
            Clear();
            foreach (string nodeData in objects)
            {
                Add(new ListNode(nodeData));
            }

            foreach (ListNode node in this)
            {
                node.Random = this[0];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public ListRandomEnum GetEnumerator()
        {
            return new ListRandomEnum(this);
        }

    }
}
