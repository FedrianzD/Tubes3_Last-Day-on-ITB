using System ;
using System.Text ;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace stringMatching
{
public class RegularExpressions {
    private static Dictionary<char, string> formula = new Dictionary<char, string>() {
        {'a', "[aA4]?"},
        {'b', "[bB8]"}, 
        {'c', "[cC]"},
        {'d', "[dD]"},
        {'e', "[eE3]?"},
        {'f', "[fF]"},
        {'g', "[gG69]"},
        {'h', "[hH]"},
        {'i', "[iI1]?"},
        {'j', "[jJ]"},
        {'k', "[kK]"},
        {'l', "[lL]"},
        {'m', "[mM]"},
        {'n', "[nN]"},
        {'o', "[oO0]?"},
        {'p', "[pP]"},
        {'q', "[qQ]"},
        {'r', "[rR]"},
        {'s', "[sS5]"},
        {'t', "[tT]"},
        {'u', "[uU]?"},
        {'v', "[vV]"},
        {'w', "[wW]"},
        {'x', "[xX]"},
        {'y', "[yY]"},
        {'z', "[zZ2]"}
    } ;
    
    // static void Main(string[] args) {
    //     string tes = RegularExpressions.createPattern("Vanson Kurnialim") ;
    //     Console.WriteLine(tes) ;

    //     Console.WriteLine(regexMatching("vNS0n kRNlM", tes)) ;
    // }

    public static bool regexMatching(string word, string pattern) {
        return Regex.IsMatch(word, pattern) ;
    }

    public static string createPattern(string word) {
        StringBuilder src = new StringBuilder(word.ToLower()) ;
        StringBuilder pattern = new StringBuilder() ;
        for (int i = 0 ; i < src.Length ; i++) {
            if (RegularExpressions.formula.ContainsKey(src[i])) {
                pattern.Append(RegularExpressions.formula[src[i]]) ;
            }
            else {
                pattern.Append(src[i]) ;
            }
        }
        return pattern.ToString() ;
    }
}
}
