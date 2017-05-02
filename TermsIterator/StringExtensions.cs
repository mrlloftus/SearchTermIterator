using System;
using System.Collections.Generic;
using System.Linq;

namespace TermsIterator
{
    public static class StringExtensions
    {
        public static HashSet<string> ToHashSet(this List<string> input)
        {
            HashSet<string> result = new HashSet<string>();
            foreach (var str in input)
            {
                result.Add(str);
            }
            return result;
        }

        public static string ToDelimitedString(this List<string> input, Char delimiter)
        {
            return input.Aggregate(string.Empty, (current, str) => current + (str + delimiter)).TrimEnd(delimiter);
        }
    }
}
