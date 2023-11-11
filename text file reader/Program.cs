using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace readFile
{
    class SearchEngine
    {
        private static int value;

        static void Main(string[] args)
        {
            //Dictonary stores a word and its frequency

            Dictionary<string, int> words = new Dictionary<string, int>();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter the text file name,ensure it is in the same folder or path with the executable");
            Console.ResetColor();
            string filename = Console.ReadLine(); //ask user for file name
            
            //Opening text file specified by the user
            string text = System.IO.File.ReadAllText(filename);
            foreach (string word in text.Split(' ')) //A for loop to go through each word in the text taking into consideration the character space which sepertes the words
            {
                if (words.ContainsKey(word))
                {
                    words[word] += 1; //If the word is in the dictionary frequency is increased
                }
                else
                {
                    words[word] = 1; //if the word is not in the dictionary, it gets added, with frequency of 1
                }
            }

            Boolean done = false;
            while (!done) //So that we keep asking the user for input
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("What word would you like to search? : ");
                Console.ResetColor();

                string word = Console.ReadLine();// test
                word = word.Replace("*", "."); // replaces the dot with an asterisk
                Dictionary<string, int> matchedWords = new Dictionary<string, int>();
                if (word != null) //Ask for word
                {

                    // find all the words that match the given regex store them in the matches variable. 
                    MatchCollection matches = Regex.Matches(text, word, RegexOptions.IgnoreCase);
                    foreach (Match match in matches)
                    {
                        //for each match if it is not in matched words then add it to the list of matched words.

                        if (!matchedWords.ContainsKey(match.ToString()))
                        {
                            matchedWords[match.ToString()] = 1;
                        }
                    }
                    // for each match in matched words print how many times it occurs in the text.
                    foreach (KeyValuePair<string, int> matchedWord in matchedWords)
                    {
                        if (words.ContainsKey(matchedWord.Key.ToString()))
                        {

                            //int value = words.GetValueOrDefault(key: matchedWord.Key);
                             if (words.TryGetValue(matchedWord.Key, out value)) // Getting the frequency of the word in a text
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            
                            Console.WriteLine(matchedWord.Key + " occurs " + value.ToString() + " times.");// Printing the frequency of the word
                            Console.ResetColor();
                        }
                    }

                }
            }
        }
    }
}
//
