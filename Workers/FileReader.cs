// Check that the filename the user provided is valid, read everything in it and save in a string, and return the string

using System;
using System.IO;

namespace unscramble.Workers
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            // Initialise an empty array in the beginning, so if it fails, you can still return as much:
            string[] fileContent;
            // If filename is not found, handle exception:
            try
            {
                // Try to assign value to our array:
                fileContent = File.ReadAllLines(filename);
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return fileContent;
        }
    }
}
