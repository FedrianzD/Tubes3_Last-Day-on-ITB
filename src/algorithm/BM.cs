using System;
namespace BM
{
    public class BM
    {
        public static Dictionary<char, int> BuildLast(string pattern)
        {
            var last = new Dictionary<char, int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!last.ContainsKey(pattern[i]))
                {
                    Console.WriteLine($"Adding {pattern[i]} with index {i}");
                }
                last[pattern[i]] = i;
            }

            return last;
        }

        public static int BMmatch(string text, string pattern)
        {
            Dictionary<char, int> last = BuildLast(pattern);
            if (pattern.Length > text.Length)
            {
                return -1;
            }
            int i = pattern.Length - 1; // text index
            int j = pattern.Length - 1; // pattern index
            do
            {
                if (pattern[j] == text[i])
                {
                    if (j == 0)
                    {
                        return i;
                    }
                    else
                    {
                        i--;
                        j--;
                    }
                }
                else
                {
                    if (!last.TryGetValue(text[i], out int l))
                    {
                        l = -1;
                    }
                    i += pattern.Length - Math.Min(j, 1 + l);
                    j = pattern.Length - 1;
                }
            } while (i <= text.Length - 1);
            return -1;
        }   
    }
}
