using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Briar
{
    public static class BriarStrings
    {
        /// <summary>
        /// Performs a caesarian cipher encode on a given string on all alphabetical letters, leaving nonaphabetical characters untouched but present in the resulting string
        /// </summary>
        /// <param name="toShift">The string to encode</param>
        /// <param name="shift">The amount to shift rightwards, as in a shifts toward b. Shift also loops (ie: 27 is the same as 1)</param>
        /// <returns>A Caesarian cipher encoded string</returns>
        public static string CaesarShift(this string toShift, int shift)
        {
            if (toShift == null)
            {
                throw new NullReferenceException("toShift cannot be null");
            }

            //65 - 90, 97 - 122 for alphabet ranges, uppercase and lowercase respectively
            if (shift < 0)
            {
                throw new ArgumentException("Cannot shift by a negative value");
            }
            string scrabbledEggs = "";
            shift %= 26;
            foreach (char c in toShift)
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
        /// <param name="toCheck">The string to count vowels in</param>
        /// <returns>The number of not vowels</returns>
        public static int CountVowels(this string toCheck)
        {
            if (toCheck == null)
            {
                throw new NullReferenceException("toCheck cannot be null");
            }

            int vowelCount = -0;
            foreach (char c in toCheck.ToLower())
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
        /// Counts the consonants of a given string
        /// </summary>
        /// <param name="toCheck">The string to count on</param>
        /// <returns>The consonant count</returns>
        public static int CountConsonants(this string toCheck)
        {
            if (toCheck == null)
            {
                throw new NullReferenceException("toCheck cannot be null");
            }

            int consonantCount = 0;
            foreach (char c in toCheck.ToLower())
            {
                switch (c)
                { //couldn't do length - vowelcount because non alphabetical characters exist
                    case 'b': case 'c': case 'd': case 'f': case 'g': case 'h': case 'j': case 'k':
                    case 'l': case 'm': case 'n': case 'p': case 'q': case 'r': case 's': case 't':
                    case 'v': case 'w': case 'x': case 'y': case 'z':
                        consonantCount++;
                        break;
                }
            }
            return consonantCount;
        }

        /// <summary>
        /// Checks to see if a given string is a palindrome
        /// </summary>
        /// <param name="toCheck">The string to check</param>
        /// <returns>True if the string is a palindrome, false if it isn't</returns>
        public static bool IsPalindrome(this string toCheck)
        {
            if (toCheck == null)
            {
                throw new NullReferenceException("toCheck cannot be null");
            }
            char[] noSpacesAndLowerCase = toCheck.Replace(" ", null).ToLower().ToCharArray();
            String almostTheOriginal = new String(noSpacesAndLowerCase);

            char[] reversed = noSpacesAndLowerCase.Reverse().ToArray(); //reversed is not a string exclusive method, hence the array oddness
            String reversedString = new String(reversed);

            return reversedString.Equals(almostTheOriginal);
        }

        /// <summary>
        /// Wipes all instances of a given substring in a string
        /// </summary>
        /// <param name="toWipeFrom">The string to wipe from</param>
        /// <param name="toRemove">The substring to remove from the string</param>
        /// <returns>A copy of the string with the given string removed</returns>
        public static string Wipe(this string toWipeFrom, string toRemove)
        {
            if (toRemove == null)
            {
                throw new NullReferenceException("toRemove cannot be null");
            }
            if (toWipeFrom == null)
            {
                throw new NullReferenceException("toWipeFrom cannot be null");
            }

            string replaced = Regex.Replace(toWipeFrom, toRemove, "");
            return replaced;
        }

        /// <summary>
        /// Converts a char array into a string, ie: ['h','e','l','l','o'] becomes "hello"
        /// </summary>
        /// <param name="cArr">The char array to make into a string</param>
        /// <returns>A string version of the char array</returns>
        public static string IntoString(this char[] cArr)
        {
            if (cArr == null)
            {
                throw new NullReferenceException("character array cArr cannot be null");
            }

            string fromCharArr = "";
            foreach (char c in cArr)
            {
                fromCharArr += c;
            }
            return fromCharArr;
        }

        /// <summary>
        /// Tells if a given string consists of entirely English letters
        /// </summary>
        /// <param name="toCheck">The string to check</param>
        /// <returns>True if all characters are english letters, false if any are not</returns>
        public static bool IsAlpha(this string toCheck)
        {
            if (toCheck == null)
            {
                throw new NullReferenceException("toCheck cannot be null");
            }

            //65 - 90, 97 - 122 for alphabet ranges, uppercase and lowercase respectively
            foreach (char c in toCheck)
            {
                if (!c.IsAlpha())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Tells whether or not a given character is alphabetical or not
        /// </summary>
        /// <param name="letter">The character to check</param>
        /// <returns>True if the charater is in the English alphabet, false if it is not</returns>
        public static bool IsAlpha(this char letter)
        {
            int letInt = (int)letter;
            if ( (letInt >= 65 && letInt <= 90) || (letInt >= 97 && letInt <= 122))
            {
                return true;
            }
            return false;
        }
    }
}
