using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPermutations
{
    class WordPermutations
    {
        #region WordSplitter Variables
        private static int uniqueWordsCount = 0;
        #endregion

        #region Word Splitter

        /// <summary>
        /// Used to generate all possible word combinations of given length
        /// </summary>
        /// <param name="inputString">String used to generate the word combinations</param>
        /// <param name="length">Length of the word to be generated</param>
        /// <param name="currentString">Newly formed string</param>
        /// <param name="isCharUsed">Checks whether the character at currentIndex is used previously or not</param>
        /// <param name="currentIndex">character being used during the current iteration</param>
        /// <param name="wordsList">List of words generated</param>
        private static void RecursiveWordGenerator(String inputString, int length, StringBuilder currentString, bool[] isCharUsed, int currentIndex, ref List<string> wordsList)
        {
            if (currentIndex == length)
            {
                //Word combination of desired length is found
                //Now Checking if the word being output is already present because i is repeating twice in digital, duplicates are possible
                if (!wordsList.Contains(currentString.ToString()))
                {
                    //Word is not a duplicate.. Output to console and add it to list
                    wordsList.Add(currentString.ToString());
                    Console.WriteLine(currentString.ToString());
                    uniqueWordsCount++;
                }
            }
            else
            {
                for (int i = 0; i < inputString.Length; i++)
                {
                    if (isCharUsed[i])
                        continue; //character already used , so skipping to the next character in the string
                    currentString.Append(inputString[i]);
                    isCharUsed[i] = true;
                    RecursiveWordGenerator(inputString, length, currentString, isCharUsed, currentIndex + 1, ref wordsList);
                    currentString.Remove(currentString.Length - 1, 1);
                    isCharUsed[i] = false;
                }
            }
        }

        /// <summary>
        /// Used to find the different combination of words from the given input string and minimum length
        /// </summary>
        /// <param name="userInput">Source string used to generate the words</param>
        /// <param name="minLength">Minimum length of the words to generate</param>
        private static void GetWordCombinations(String userInput, int minLength)
        {
            int stringLength = userInput.Length; // Length of the string being used 
            bool[] isCharUsed = new bool[stringLength]; //Used to keep track if the current character has been used previously during recursion
            StringBuilder currentString = new StringBuilder(stringLength); //Used to hold the newly formed string 
            List<string> wordsList = new List<string>(); //Used this list to identify if a word already exists because 'i' occurs twice and hence repeatitions are position
            for (int i = minLength; i <= stringLength; i++)
            {
                //Generating the words by iterating through recursive method to get words of minimum length specified
                RecursiveWordGenerator(userInput, i, currentString, isCharUsed, 0, ref wordsList);
            }
        }

        #endregion
        static void Main(string[] args)
        {

            int minlength = 1;
            string word = string.Empty;

            Console.Write("Please enter a word to list out all possible combinations:");
            word = Console.ReadLine();
            Console.Write("Please enter minimum length of the words to list out from combinations:");
            int.TryParse(Console.ReadLine(), out minlength);

            GetWordCombinations(word, minlength); //3 is the minumum length of the words required with different combinations
            Console.WriteLine("Total Number of Unique Letter Combinations obtained from the word 'digital' with length of atleast" + minlength + ": " + uniqueWordsCount);
            Console.ReadLine();
        }
    }
}
