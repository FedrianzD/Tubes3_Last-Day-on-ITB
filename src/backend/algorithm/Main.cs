using System;
using stringMatching;
namespace Main
{
    class Program{
        static void Main(string[] args)
        {
            int posn = BM.BMmatch("aaaaaaaaa", "aaaa");
            Console.WriteLine(posn);
        }
    }
}