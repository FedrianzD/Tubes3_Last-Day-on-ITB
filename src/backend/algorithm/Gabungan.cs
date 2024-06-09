using Database_Operation;
using converter;
using stringMatching;
using System.Diagnostics;
using reader;

namespace Gabungan
{
    public class Gabungan
    {
        static void Main()
        {
            // Connect();
            // List<string> names = [];
            // reader.Reader.ReadFileName();
            // names = reader.Reader.ReadTxt();
            // foreach(string name in names){
            //     Console.WriteLine(name);
            // }
            // foreach(var pair in reader.Reader.Pairing()){
            //     Console.WriteLine(pair.name + " " + pair.path);
            // }
            // reader.Reader.ReadFileName();
            // Database_Operation.DB.InsertDatabase();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            (string path, string Name, string CorruptName, float percent) res = getPathAndName("test/SOCOFing/Real/592__M_Left_index_finger.BMP", 0);
            Console.WriteLine(res.path);
            Console.WriteLine(res.Name);
            Console.WriteLine(res.CorruptName);
            Console.WriteLine(res.percent);
            Database_Operation.DB.ReadDatabaseCheck(res.CorruptName);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Console.WriteLine("RunTime " + elapsedTime);

            // Console.ReadKey();
            // string path = "SOCOFing/Real/1__M_Left_index_finger.BMP";
            // List<string> arr = converter.Converter.readFile(path);
            // // foreach(string a in arr){
            // //     Console.WriteLine(a);
            // //     File.WriteAllText("a.txt", a);
            // //     Console.WriteLine("batas cok");
            // // }
            // string pattern = converter.Converter.getPattern(arr);
            // foreach(string a in arr){
            //     if(stringMatching.BM.BMmatch(a, pattern) != -1){
            //         Console.WriteLine("aaaaa");
            //     }

            // }
            // File.WriteAllLines("a.txt", arr);
            

        }
        public static (string path, string NameAsli, string NamaCorrupt, float percent) getPathAndName(string pathPattern, int algo)
        {
            List<string> names = Database_Operation.DB.ReadDatabaseName();
            List<string> patternAll = converter.Converter.readFile(pathPattern);
            string pattern = converter.Converter.getPattern(patternAll);
            List<KeyValuePair<string,string>> SidikJariNamaTmp = Database_Operation.DB.ReadDatabaseSidikJari();
            Dictionary<string,string> SidikJariNama = SidikJariNamaTmp.ToDictionary(pair => pair.Key, pair => pair.Value);
            string pathFound = "";
            string name = "";
            bool found = false;
            float diffMax = 0; // diffMin untuk menghitung kemiripan di gambar
            float diff; // diff untuk menghitung perbedaan di tiap row
            List<KeyValuePair<float, string>> diffMaxs = []; // minimum dan pathnya
            
            foreach(var pair in SidikJariNama)
            {
                string pathOri = pair.Key;
                List<string> Originals = converter.Converter.readFile(pathOri);
                foreach(string Original in Originals)
                {
                    if(Solve(pattern, Original, algo))
                    {   
                        found = true;
                        pathFound = pathOri;
                        name = pair.Value;
                        break; // kalo ketemu yang sama persis break aja
                    }
                    diff = stringMatching.Levenshtein.LevenshteinDistance(pattern, Original);
                    if(diff > diffMax)
                    {
                        diffMax = diff; // nyari diff paling kecil di satu gambar
                    }

                }
                if(found)
                {
                    break; // kalo ketemu break lagi juga
                }
                diffMaxs.Add(new KeyValuePair<float, string>(diffMax,pathOri)); // masukkin nilai terkecil pada suatu gambar ke dalam list
                diffMax = 0;
            }
            if(found)
            {   
                
                string patternNamaAsli = stringMatching.RegularExpressions.createPattern(name);
                string corruptName = "";
                foreach(string nama in names)
                {
                    if(stringMatching.RegularExpressions.regexMatching(nama, patternNamaAsli)){
                        corruptName = nama;
                        break;
                    }
                }
                return (pathFound, name, corruptName, 100);
            }
            else
            {
                KeyValuePair<float, string> maxPair = diffMaxs.OrderBy(pair => pair.Key).Last(); // ambil yang paling besar
                // percent, path
                name = SidikJariNama.GetValueOrDefault(maxPair.Value);
                string patternNamaAsli = stringMatching.RegularExpressions.createPattern(name);
                string corruptName = "";
                foreach(string nama in names)
                {
                    if(stringMatching.RegularExpressions.regexMatching(nama, patternNamaAsli)){
                        corruptName = nama;
                        break;
                    }
                }
                return (maxPair.Value, name, corruptName, maxPair.Key); // return path dan nama 
            }
        }
        private static bool Solve(string pattern, string Text, int algo)
        {
            if(algo == 1){
                return stringMatching.KMP.KMPSolve(Text, pattern);
            }else{
                return stringMatching.BM.BMmatch(Text, pattern) != -1;
            }
        }
            
    }
}