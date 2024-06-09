using System;
using System.Linq;
using System.Text ;

namespace stringMatching
{
    public class LCS {

        public static int LongestCommonSubsequence(string pattern, string subset)
            {
                int m = pattern.Length;
                int n = subset.Length;

                // buat tabel lcs
                int[,] lcsTable = new int[m + 1, n + 1];

                // inisialisasi tabel
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

                int length = lcsTable[m, n];
                char[] lcs = new char[length];
                int index = length - 1;

                int ii = m, jj = n;
                while (ii > 0 && jj > 0)
                {
                    if (pattern[ii - 1] == subset[jj - 1])
                    {
                        lcs[index] = pattern[ii - 1];
                        ii--;
                        jj--;
                        index--;
                    }

                    else if (lcsTable[ii - 1, jj] > lcsTable[ii, jj - 1])
                    {
                        ii--;
                    }
                    else
                    {
                        jj--;
                    }
                }

                int persentase = new string(lcs).Length ;
                // Console.WriteLine(persentase) ;
                persentase = persentase * 100 / pattern.Length ;
                return persentase;
            }
        // public static void Main() {
        //     string subset = "heloooooooooohlllooooooooooooooo" ;
        //     string pattern = "brooomacuyhelbromaoooo" ;
        //     Console.WriteLine(LongestCommonSubsequence(pattern, subset)) ;
        // }
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