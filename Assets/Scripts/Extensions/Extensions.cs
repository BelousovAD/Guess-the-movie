namespace Extensions
{
    using System.Collections.Generic;

    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int count = list.Count;
            int i;
            T temporary;

            while (count > 1)
            {
                i = UnityEngine.Random.Range(0, count);
                count--;
                temporary = list[i];
                list[i] = list[count];
                list[count] = temporary;
            }
        }
    }
}