using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briar
{
    public static class BriarStrings
    {
        /// <summary>
        /// Performs a caesarian cipher encode on a given string on all alphabetical letters, leaving nonaphabetical characters untouched but present in the resulting string
        /// </summary>
        /// <param name="stringy">The string to encode</param>
        /// <param name="shift">The amount to shift rightwards, as in a shifts toward b. Shift also loops (ie: 27 is the same as 1)</param>
        /// <returns>A Caesarian cipher encoded string</returns>
        public static string CaesarShift(this string stringy, int shift)
        {
            //65 - 90, 97 - 122 for alphabet ranges, uppercase and lowercase respectively
            if (shift < 0)
            {
                throw new ArgumentException("No negative numbers");
            }
            string scrabbledEggs = "";
            shift %= 26;
            foreach (char c in stringy)
            {
                if ((c <= 90 && c >= 65) || (c >= 97 && c <= 122)) //the character is a letter
                {
                    int newUni = c + shift;
                    if (newUni > 90 && (c <= 90 && c >= 65)) //if the unicode went out of range, and the original letter is uppercase
                    {
                        newUni = newUni - 90 + 65;
                    }
                    else if (newUni > 122 && (c <= 97 && c >= 122)) //if the unicode went out of range and the original letter is lowercase
                    {
                        newUni = newUni - 122 + 97;
                    }
                    scrabbledEggs += (char)newUni;
                }
                else //the character is not a letter
                {
                    scrabbledEggs += c;
                }
            }
            return scrabbledEggs;
        }

        /// <summary>
        /// Returns the number of vowels in a string
        /// </summary>
        /// <param name="stringy">The string to count vowels in</param>
        /// <returns>The number of not vowels</returns>
        public static int CountVowels(this string stringy)
        {
            int vowelCount = -0;
            foreach (char c in stringy.ToLower())
            {
                switch (c)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'u':
                    case 'o':
                        vowelCount++;
                        break;
                }
            }
            return vowelCount;
        }

        /// <summary>
        /// Checks to see if a given string is a palindrome
        /// </summary>
        /// <param name="stringythingy">The string to check</param>
        /// <returns>True if the string is a palindrome, false if it isn't</returns>
        public static bool IsPalindrome(this string stringythingy)
        {
            char[] noSpacesAndLowerCase = stringythingy.Replace(" ", null).ToLower().ToCharArray();
            String almostTheOriginal = new String(noSpacesAndLowerCase);

            char[] reversed = noSpacesAndLowerCase.Reverse().ToArray(); //reversed is not a string exclusive method, hence the array oddness
            String reversedString = new String(reversed);

            return reversedString.Equals(almostTheOriginal);
        }
    }
}
