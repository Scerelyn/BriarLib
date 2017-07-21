using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briar
{
    public static class BriarNumbers
    {

        /// <summary>
        /// 'Rolls' the calling number of dice of a specified face count and giving an array of the results
        /// </summary>
        /// <param name="diceCount">The amount of dice to roll</param>
        /// <param name="diceFaceCount">The number of faces the dice has</param>
        /// <param name="amountOfDiceToSum">The amount of dice groups to sum together into one value on the array</param>
        /// <returns>An int array containing the results</returns>
        public static int[] DiceRoll(this int diceCount, int diceFaceCount = 6, int amountOfDiceToSum = 1)
        {
            if (diceCount <= 0 || diceFaceCount <= 0 || amountOfDiceToSum <= 0)
            {
                throw new ArgumentException("No zeroes or negative numbers for any argument");
            }
            Random r = new Random();
            int[] results = new int[diceCount];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = 0;
                for (int j = 0; j < amountOfDiceToSum; j++)
                {
                    results[i] += r.Next(1, diceFaceCount + 1); //remember d6 + d6 != d12 probability wise
                }
            }
            return results;
        }

        /// <summary>
        /// Determines if the long is possibly prime
        /// </summary>
        /// <param name="num">The long to check primality on</param>
        /// <returns>True if the long is probably prime, false if it is not</returns>
        public static bool IsPossiblyPrime(this long num)
        {
            bool isPrime;
            if (num == 2)
            {
                isPrime=  true;
            }
            else
            {
                isPrime = (long)Math.Pow(2, num-1) % num == 1;
            }

            return isPrime;
        }

        /// <summary>
        /// Determines if the integer is possibly prime
        /// </summary>
        /// <param name="num">The integer to check primality on</param>
        /// <returns>True if the integer is probably prime, false if it is not</returns>
        public static bool IsPossiblyPrime(this int num)
        {
            return IsPossiblyPrime((long)num); //call the long overload
        }

        /// <summary>
        /// Gives a random number from 1 to number, or number to -1 if the number is negative
        /// </summary>
        /// <param name="num">The upper bound if positive, or lower bound if negative. Zero will just return zero</param>
        /// <returns>Returns a random integer from one to the given integer. If the integer is negative, returns a random integer from the given integer to -1</returns>
        public static int Random(this int num)
        {
            Random r = new Random();
            if (num > 1) {
                return r.Next(1, num + 1);
            }
            else
            {
                return r.Next(num, 0);
            }
        }
    }
}
