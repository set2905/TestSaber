using SaberTest;

namespace TestSaber
{
    internal static class ListRandomExtensions
    {

        /// <summary>
        /// Присваивание полю Random каждого ListNode случайного значения из списка
        /// </summary>
        /// <param name="list"></param>
        public static void Shuffle(this ListRandom list)
        {
            Random rnd = new Random();
            foreach (ListNode node in list)
                node.Random = list[rnd.Next(0, list.Count - 1)];
        }

        public static void CopyTo(this ListRandom from, ListRandom to)
        {
            to.Clear();
            List<int> randomIndexes = new List<int>();
            for (int i = 0; i <= from.Count - 1; i++)
            {
                randomIndexes.Add(from.IndexOf(from[i].Random));
                to.Add(from[i]);
            }
            AssignIndexesOfRandom(to, randomIndexes);

        }

        public static bool AssignIndexesOfRandom(this ListRandom list, List<int> randomIndexes)
        {
            if (randomIndexes.Count != list.Count)
            {
                return false;
            }

            for (int i = 0; i <= list.Count - 1; i++)
            {
                if (randomIndexes[i] >= 0)
                    list[i].Random = list[randomIndexes[i]];
                else list[i].Random = null;
            }
            return true;

        }
    }
}
