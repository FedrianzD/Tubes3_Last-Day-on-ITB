using System;
using System.Text ;

namespace stringMatching{
    class Program {
        // static void Main(string[] args) {
        //     Console.WriteLine("Hello Worldss!");   
        //     // StringBuilder sb = new StringBuilder("ababababca") ;
            
        //     // int result = borderFunction(sb.ToString()) ;
        //     // Console.WriteLine(result) ;

        //     Console.WriteLine(KMP("abacaabaccabacabaabb", "abacab")) ;
        // }
        static bool KMP(string source, string subset) {
            int count = 0 ;
            StringBuilder src = new StringBuilder(source) ;
            StringBuilder sub = new StringBuilder(subset) ;
            int len_src = src.Length ; 
            int len_sub = sub.Length ;

            if (len_src <= len_sub) {
                return false ;
            }

            int t_index = 0 ;
            int size = 0 ;
            while (t_index <= len_src-len_sub) {
                // Console.WriteLine("a") ;
                int p_index ;
                for (p_index = size ; p_index < len_sub ; p_index++) {
                    if (p_index == len_sub - 1 && sub[p_index] == src[t_index+p_index]) {
                        count += 1 ;
                        Console.WriteLine("BENER") ;
                        Console.WriteLine(count) ;
                        return true ;
                    }
                    else {
                        count += 1 ;
                        if (sub[p_index] == src[t_index+p_index]) {
                            continue ;
                        }
                        else {
                            int border = borderFunction(sub.ToString(0, p_index)) ;
                            if (p_index == 0) {
                                t_index += 1 ;
                            }
                            else {
                                t_index += p_index - border ;
                                size = border ;
                            }
                            Console.WriteLine("Update t_index") ;
                            Console.WriteLine(t_index) ;
                            break ;
                        }
                    }
                }
            }
            return false ;
        }

        static int borderFunction(string word) {
            if (word.Length <= 1) {
                return 0 ;
            }
            else {
                StringBuilder prefix = new StringBuilder(word) ;
                prefix.Remove(prefix.Length - 1 , 1) ;
                StringBuilder sufix = new StringBuilder(word) ;
                sufix.Remove(0,1) ;
                while (prefix.Length > 0) {
                    if (prefix.Equals(sufix)) {
                        return prefix.Length ;
                    }
                    else {
                        prefix.Remove(prefix.Length - 1 , 1) ;
                        sufix.Remove(0,1) ;
                        // Console.WriteLine(prefix) ;
                        // Console.WriteLine(sufix) ;
                    }
                }
                return 0 ;
            }
        }
    }
}
