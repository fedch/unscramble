using System;
using System.Collections.Generic;
using System.Linq;
using unscramble.Data;
using unscramble.Workers;

namespace unscramble
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
       
        static void Main(string[] args)
        {
            try
            {
                bool continueWordScramble = true;
                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty; // If user input was null, default to an empty string

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            FileScenario();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ManualEntryScenario();
                            break;
                        default:
                            Console.Write(Constants.EnterScrambledWordsOptionNotRecognised);
                            break;

                    }

                    var continueDecision = string.Empty; // Either "Y" or end
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        continueDecision = (Console.ReadLine() ?? string.Empty);
                    } while (
                    !continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                    !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueWordScramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordScramble);
            }

            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }
            
        }

        private static void ManualEntryScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(",");
            DisplayMatched(scrambledWords);
        }

        
        private static void FileScenario()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatched(scrambledWords);
            }
            catch (Exception ex)
            {
                // Load the error message that we saved as a constant:
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }           
        }

        private static void DisplayMatched(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any()) // If this list has anything in it
            {
                foreach ( var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                        //$"Match found for {matchedWord.ScrambledWord}, {matchedWord.Word}");
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }

    }
}
