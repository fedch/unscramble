namespace unscramble
{
    class Constants
    {
        public const string OptionsOnHowToEnterScrambledWords = "Enter scrambleds words(s) manually or as a file: F - file / M - manual";
        public const string OptionsOnContinuingTheProgram = "Would you like to continue? Y/N: ";

        public const string EnterScrambledWordsViaFile = "Enter full path including the file name: ";
        public const string EnterScrambledWordsManually = "Enter word(s) manually (separated by commas if multiple): ";
        public const string EnterScrambledWordsOptionNotRecognised = "This option was not reconised.";

        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded beacause there was an error: ";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated: ";

        public const string MatchFound = "MATCH FOUND FOR {0}: {1}";
        public const string MatchNotFound = "NO MATCHES HAVE BEEN FOUND";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string WordListFileName = "wordlist.txt";
    }
}
