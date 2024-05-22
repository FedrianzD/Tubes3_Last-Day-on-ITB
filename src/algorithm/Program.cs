using System;
using BM;
namespace Program
{
    class Program{
        static void Main(string[] args)
        {
            int posn = BM.BM.BMmatch("abacaabadcabacabaabb", "abacab");
            Console.WriteLine(posn);
        }
    }
}