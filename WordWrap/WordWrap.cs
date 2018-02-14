using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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

            int start = 0, end;
            var lines = new StringBuilder();

            while ((end = start + maxLength) < input.Length)
            {
                while (input[end] != ' ' && end > start)
                    end -= 1;

                if (end == start)
                    end = start + maxLength;

                lines.Append(input.Substring(start, end - start));
                lines.Append("\n");
                start = end + 1;
            }

            if (start < input.Length)
            {
                lines.Append(input.Substring(start));
            }

            return lines.ToString();
        }
    }
}
