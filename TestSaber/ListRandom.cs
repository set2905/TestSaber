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

        /// <summary>
        /// Конвертация из Списка строк с разделителями полей в ListRandom
        /// </summary>
        public static implicit operator ListRandom(List<string> objects)
        {
            ListRandom newList = new ListRandom();
            List<int> randomIndexes = new List<int>();
            foreach (string content in objects)
            {
                string[] fields = content.Split(fieldSeparator);
                ListNode added = new ListNode(fields[0]);
                newList.Add(added);
                randomIndexes.Add(Int32.Parse(fields[1]));
            }
            newList.AssignIndexesOfRandom(randomIndexes);
            return newList;
        }

        /// <summary>
        /// Конвертация из ListRandom в список строк с разделителями полей. 
        /// Каждая строка соответствует объекту класса ListNode (Дата, разделитель, индекс случайного)
        /// </summary>
        public static explicit operator List<string>(ListRandom listRandom)
        {
            List<string> convertedToStringList = new List<string>();
            ListNode current = listRandom.Head;
            while (current != null)
            {
                int indexOfCurrentRandom = listRandom.IndexOf(current.Random);
                convertedToStringList.Add(current.Data + fieldSeparator + indexOfCurrentRandom);
                current = listRandom.GetNext(current);
            }
            return convertedToStringList;
        }

        /// <summary>
        /// Преобразование в одну строку. При этом объект сначала преобразуется в список строк, каждая из которых отвечает за объект ListNode.
        /// После чего происходит конкатенация списка строк с разделителем объектов.
        /// </summary>
        /// <returns></returns>
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
            string stringToWrite = this.ToString();
            Console.WriteLine("Writing: " + stringToWrite);
            writer.WriteLine(stringToWrite);
            writer.Close();
        }

        public void Deserialize(Stream s)
        {
            StreamReader reader = new StreamReader(s);

            string readString = reader.ReadToEnd();
            reader.Close();
            List<string> objects = readString.Split(objSeparator).ToList();

            ListRandom readListRandom = objects;
            readListRandom.CopyTo(this);
            Console.WriteLine(this);
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
