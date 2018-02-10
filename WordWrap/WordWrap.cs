using System;
using System.Text;

namespace WordWrap
{
    public static class WordWrap
    {
        // Given an input string of words separated by spaces, and a maximum line length,
        //  break the input at word boundaries such that no line is longer than the
        //  maximum.
        //
        // For example, Wrap("This is a test", 7) and Wrap("This is a test", 8) should
        //  both return "This is\na test".
        public static string Wrap(string input, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length <= maxLength)
            {
                return input;
            }

            var lines = new StringBuilder();
            var cursor = 0;
            while (cursor + maxLength < input.Length)
            {
                var indexOfBlank = input.LastIndexOf(' ', cursor + maxLength);
                int splitAt;
                int offset;

                if (indexOfBlank > cursor - 1)
                {
                    splitAt = indexOfBlank;
                    offset = 1;
                }
                else
                {
                    splitAt = cursor + maxLength;
                    offset = 0;
                }

                lines.Append(input.Substring(cursor, splitAt));
                lines.Append("\n");

                cursor = splitAt + offset;
            }

            lines.Append(input.Substring(cursor));
            return lines.ToString();
        }
    }
}
