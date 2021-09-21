using System.Linq;

namespace utils.Utilities
{
    /// <summary>
    /// A set of utilities for working with arrays, mainly using DP
    /// </summary>
    public static class ArrayHelpers
    {

        /// <summary>
        /// Find permutations of a given array
        /// using dynamic programming
        /// </summary>
        /// <param name="array"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>An array of arrays containing the power set</returns>
        public static T[][] Permute<T>(this T[] array)
        {
            // base case
            if (array.Length == 0)
            {
                return new T[][] { new T[0] };
            }

            // get the permutations of the first element
            T[] first = array.SubArray(0, 1);
            T[][] firstPerms = first.Permute();

            // get the permutations of the rest of the array
            T[] rest = array.SubArray(1, array.Length - 1);
            T[][] restPerms = rest.Permute();

            // combine the permutations
            T[][] result = new T[firstPerms.Length * restPerms.Length][];
            int index = 0;
            for (int i = 0; i < firstPerms.Length; i++)
            {
                for (int j = 0; j < restPerms.Length; j++)
                {
                    result[index] = firstPerms[i].Concat(restPerms[j]).ToArray();
                    index++;
                }
            }

            return result;

        }

        public static T[] SubArray<T>(this T[] data, int index, int length = -1)
        {
            if (length == -1)
            {
                length = data.Length - index;
            }

            return data.Skip(index).Take(length).ToArray();

        }

    }
}