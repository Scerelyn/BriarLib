﻿using System;
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
    }
}
