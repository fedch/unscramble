using System;
using System.Collections.Generic;
using System.Text;
using unscramble.Data;

namespace unscramble.Workers
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            // Declare a variable which will hold a list of matched words:
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    // First, check if there is a matched pair, ignoring the case:
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        // Add that pair to the matchedWord string, using the BuildMatchedWord method below:
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        // Tun strings into arrays:
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        // Sort the arrays:
                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        // Glus them back into strings:
                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                    }
                }

            }

            return matchedWords;
        }

        // Create a helper method:
        private MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };
            return matchedWord;
        }
    }
}
