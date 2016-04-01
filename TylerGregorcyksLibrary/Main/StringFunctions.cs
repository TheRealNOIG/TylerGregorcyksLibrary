using System;
using System.Text;

namespace TylerGregorcyksLibrary.Main
{
    public class StringFunctions
    {

        //Split Strings at every delimiter
        public static string[] SplitString(string source, char delimiter)
        {
            //See if the string isnt empty
            if (string.IsNullOrEmpty(source))
                return null;

            return source.Split(delimiter);
        }
        public static string[] SplitString(string source, char[] delimiter)
        {
            //See if the string isnt empty
            if (string.IsNullOrEmpty(source))
                return null;

            return source.Split(delimiter);
        }

        //Split Strings at specific location
        public static string SplitStringFromIndex(string source, char delimiter, int index)
        {
            //See if the string isnt empty
            if (string.IsNullOrEmpty(source))
                return null;

            int delimiterCount = 0;
            StringBuilder finalString = new StringBuilder();
            bool foundSection = false;

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
            return finalString.ToString();
        }

    }
}
