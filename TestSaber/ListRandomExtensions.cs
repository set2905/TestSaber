using SaberTest;

namespace TestSaber
{
    internal static class ListRandomExtensions
    {
        public static void Shuffle(this ListRandom list)
        {
            Random rnd = new Random();
            foreach (ListNode node in list)
                node.Random = list[rnd.Next(list.Count - 1)];
        }
    }
}
