namespace Extensions
{
    using System;
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
        
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0)
            {
                return min;
            }

            if (val.CompareTo(max) > 0)
            {
                return max;
            }
            
            return val;
        }
    }
}