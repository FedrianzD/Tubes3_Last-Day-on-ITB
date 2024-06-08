using System;
using System.Linq;

namespace stringMatching
{
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
        public static int LevenshteinDistance(string start, string goal)
        {
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
            return dp[start.Length, goal.Length];
        }
    }
}