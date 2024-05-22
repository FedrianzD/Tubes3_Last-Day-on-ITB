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
                last[pattern[i]] = pattern.Length - i - 1;
            }
            last[pattern[pattern.Length-1]] = pattern.Length;

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
            int posMarker = 0;
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
                        l = pattern.Length;
                    }
                    posMarker += l;
                    i = posMarker + pattern.Length - 1;
                    j = pattern.Length - 1;
                }
            } while (i <= text.Length - 1);
            return -1;
        }   
    }
}
