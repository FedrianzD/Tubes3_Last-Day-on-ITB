using System;
using System.Linq;
using System.Text ;

namespace stringMatching
{
    public class LCS {
        // start 
        public static int LongestCommonDistance(string pattern, string subset) {
            StringBuilder pat = new StringBuilder(pattern) ;
            StringBuilder sub = new StringBuilder(subset) ;
            int maxDiff = 0 ;
            int diff = 0 ;
            int index = 0 ;

            for (int i = 0 ; i < sub.Length ; i++) {
                diff = 0 ;
                index = 0 ;
                while(true) {
                    if (index >= sub.Length - i - 1) {
                        if (diff > maxDiff) {
                            maxDiff = diff ;
                        }
                        break ;
                    }
                    if (pat[index] == sub[index + i]) {
                        diff += 1 ;
                    }
                    else {
                        if (diff > maxDiff) {
                            maxDiff = diff ;
                            break ;
                        }
                    }
                    index++ ;
                }
            }
            maxDiff /= pat.Length ;
            maxDiff *= 100 ;
            return maxDiff ;
        }

        public static string LongestCommonSubsequence(string pattern, string subset)
            {
                int m = pattern.Length;
                int n = subset.Length;

                // Create a 2D array to store the lengths of LCS.
                // lcsTable[i][j] will contain the length of LCS of pattern[0..i-1] and subset[0..j-1]
                int[,] lcsTable = new int[m + 1, n + 1];

                // Build the lcsTable from the bottom up
                for (int i = 0; i <= m; i++)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            lcsTable[i, j] = 0;
                        }
                        else if (pattern[i - 1] == subset[j - 1])
                        {
                            lcsTable[i, j] = lcsTable[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            lcsTable[i, j] = Math.Max(lcsTable[i - 1, j], lcsTable[i, j - 1]);
                        }
                    }
                }

                // lcsTable[m, n] contains the length of LCS for pattern[0..m-1] and subset[0..n-1]
                int lcsLength = lcsTable[m, n];

                // Create a char array to store the LCS characters
                char[] lcs = new char[lcsLength];
                int index = lcsLength - 1;

                // Start from the right-most-bottom-most corner and
                // one by one store characters in lcs
                int ii = m, jj = n;
                while (ii > 0 && jj > 0)
                {
                    // If current character in pattern and subset are same, then it is part of LCS
                    if (pattern[ii - 1] == subset[jj - 1])
                    {
                        lcs[index] = pattern[ii - 1];
                        ii--;
                        jj--;
                        index--;
                    }
                    // If not same, then find the larger of two and
                    // go in the direction of larger value
                    else if (lcsTable[ii - 1, jj] > lcsTable[ii, jj - 1])
                    {
                        ii--;
                    }
                    else
                    {
                        jj--;
                    }
                }

                // Convert char array to string
                return new string(lcs);
            }
        public static void Main() {
            string subset = "heloooooooooohlllooooooooooooooo" ;
            string pattern = "brooomacuyhelbromaoooo" ;
            Console.WriteLine(LongestCommonSubsequence(pattern, subset)) ;
        }
    }
    public class Levenshtein
    {
        /*
            Default cost of substitution, 0 if it's the same character, 1 if it's a different character, used by Levenshtein distance
        **/
        private static int CostOfSubstitution(char a, char b)
        {
            return (a == b) ? 0 : 1;
        }

        /*
            Function to calculate estimated cost between two words using Hamming distance
        **/

        // Levenshtein's distance, too overkill and slower compared to Hamming distance
        public static float LevenshteinDistance(string start, string goal)
        {
            int length = goal.Length ;
            int[,] dp = new int[start.Length + 1, goal.Length + 1];

            for (int i = 0; i <= start.Length; i++)
            {
                for (int j = 0; j <= goal.Length; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else
                    {
                        dp[i, j] = new[] {dp[i - 1, j] + 1,
                                        dp[i, j - 1] + 1,
                                        dp[i - 1, j - 1] + CostOfSubstitution(start[i - 1], goal[j - 1])}.Min();
                    }
                }
            }
            float persentase = 100 - ((dp[start.Length, goal.Length]-(length-start.Length)) * 100 / 30) ;
            return persentase;
        }
    }
}