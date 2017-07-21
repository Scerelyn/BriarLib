using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briar
{
    public static class BriarCollections
    {
        /// <summary>
        /// Iterates through a list and prints each on, calling ToString() on each element
        /// </summary>
        /// <typeparam name="T">Any type that has a ToString() override</typeparam>
        /// <param name="list">The list to iterate over and print elements of</param>
        public static void Print<T>(this IEnumerable<T> list) 
        {
            string allItems = "";
            foreach (T thingy in list)
            {
                allItems += thingy.ToString() + ", "; //print a tostring of the object, and add a space and comma
            }
            if (!String.IsNullOrEmpty(allItems))
            {
                allItems = allItems.Substring(0, allItems.Length - 2); //remove the trailing space and comma
            }
            Console.WriteLine(allItems);
        }

        /// <summary>
        /// Gives a shuffled copy of the calling List
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="array">A List of any type T</param>
        /// <returns>A shuffled copy of the list</returns>
        /// <remarks>The returning value must be casted back into the original list type sent in</remarks>
        public static IList<T> Shuffle<T>(this IList<T> someList)
        {
            Type type = someList.GetType();
            IList<T> scrambled = (IList<T>)Convert.ChangeType(Activator.CreateInstance(type), type); //making a copy, but need to match the types

            Random r = new Random();
            while (someList.Count() > 0)
            {
                int rand = r.Next(0, someList.Count());
                T element = someList[rand];
                scrambled.Add(element);
                someList.Remove(element);
            }
            Console.WriteLine();
            return scrambled;
        }
    }
}
