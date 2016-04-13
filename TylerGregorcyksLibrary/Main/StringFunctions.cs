using System;
using System.Text;

namespace TylerGregorcyksLibrary.Main
{
    public class StringFunctions
    {

        //Split string alphabetically
        public static string[] SplitStringAlphabetically(string source, char delimiter)
        {
            //See if the string ist empty
            if (string.IsNullOrEmpty(source))
                return null;

            string[] listOfStrings = source.Split(delimiter);
            Array.Sort(listOfStrings);
            return listOfStrings;
        }
        public static string[] SplitStringAlphabetically(string source, char[] delimiter)
        {
            //See if the string ist empty
            if (string.IsNullOrEmpty(source))
                return null;

            string[] listOfStrings = source.Split(delimiter);
            Array.Sort(listOfStrings);
            return listOfStrings;
        }

        //Split Strings at every delimiter
        public static string[] SplitString(string source, char delimiter)
        {
            //See if the string ist empty
            if (string.IsNullOrEmpty(source))
                return null;

            return source.Split(delimiter);
        }
        public static string[] SplitString(string source, char[] delimiter)
        {
            //See if the string ist empty
            if (string.IsNullOrEmpty(source))
                return null;

            return source.Split(delimiter);
        }

        //Split Strings at specific location
        public static string SplitStringFromIndex(string source, char delimiter, int index)
        {
            //See if the string ist empty
            if (string.IsNullOrEmpty(source))
                return null;

            int delimiterCount = 0;
            StringBuilder finalString = new StringBuilder();
            bool foundSection = false;

            try
            {
                for (int i = 0; i < source.Length; i++)
                {
                    //If index = 0 then build the string intel it hits the first delimiter
                    if (index == 0)
                    {
                        if (source[i] == delimiter) //if true then break
                            break;
                        else
                            finalString.Append(source[i]);
                    }
                    else if (foundSection)
                    {
                        if (source[i] != delimiter) //If we havint hit the next delimter (or the end) right to string
                            finalString.Append(source[i]);
                        else
                            break;
                    }
                    else if (source[i] == delimiter)
                    {
                        delimiterCount++;

                        if (delimiterCount == index) // If we are in the right endix then start wrighting to string
                            foundSection = true;
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message)};
            return finalString.ToString();
        }

        //Get the first part of the string before the first Delimiter
        public static string SplitStringBeforeFirstDelimiter(string source, char delimiter)
        {
            if (string.IsNullOrEmpty(source))
                return null;

            int location = source.IndexOf(delimiter);
            if (location > -1)
            {
                return source.Substring(0, location);
            }
            return null;
        }

        public static string SplitStringAfterLastDelimiter(string source, char delimiter)
        {
            if (string.IsNullOrEmpty(source))
                return null;

            int location =  source.LastIndexOf(delimiter);
            if(location > -1)
            {
                int sPosition = location + 1;
                int length = source.Length - sPosition;
                return source.Substring(sPosition, length);
            }
            return null;
        }
    }
}
