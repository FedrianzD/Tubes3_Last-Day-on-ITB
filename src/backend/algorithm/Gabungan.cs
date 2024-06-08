using Database_Operation;
using converter;
using stringMatching;
using System.Diagnostics;
using reader;
namespace Gabungan
{
    class Gabungan
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
            KeyValuePair<string,string> pairs = Fungsi("test/SOCOFing/Real/1__M_Left_index_finger.BMP", 1);
            Console.WriteLine(pairs.Key);
            Console.WriteLine(pairs.Value);
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
        static KeyValuePair<string,string> Fungsi(string pathPattern, int algo)
        {
            List<string> patternAll = converter.Converter.readFile(pathPattern);
            string pattern = converter.Converter.getPattern(patternAll);
            List<KeyValuePair<string,string>> SidikJariNamaTmp = Database_Operation.DB.ReadDatabaseSidikJari();
            Dictionary<string,string> SidikJariNama = SidikJariNamaTmp.ToDictionary(pair => pair.Key, pair => pair.Value);
            string pathFound = "";
            string name = "";
            bool found = false;
            int diffMin = int.MaxValue; // diffMin untuk menghitung nilai minimum di gambar
            int diff; // diff untuk menghitung perbedaan di tiap row
            List<KeyValuePair<int, string>> diffMins = []; // minimum dan pathnya
            
            foreach(var pair in SidikJariNama)
            {
                string pathOri = pair.Key;
                List<string> Originals = converter.Converter.readFile(pathOri);
                foreach(string Original in Originals)
                {
                    if(Solve(pattern, Original, algo))
                    {   
                        found = true;
                        pathFound = Original;
                        name = pair.Value;
                        break; // kalo ketemu yang sama persis break aja
                    }
                    diff = stringMatching.Levenshtein.LevenshteinDistance(pattern, Original);
                    if(diff < diffMin)
                    {
                        diffMin = diff; // nyari diff paling kecil di satu gambar
                    }

                }
                if(found)
                {
                    break; // kalo ketemu break lagi juga
                }
                diffMins.Add(new KeyValuePair<int, string>(diffMin,pathOri)); // masukkin nilai terkecil pada suatu gambar ke dalam list
                diffMin = int.MaxValue;
            }
            if(found)
            {
                return new KeyValuePair<string, string>(pathFound, name);
            }
            else
            {
                KeyValuePair<int, string> minPair = diffMins.OrderBy(pair => pair.Key).First(); // ambil yang paling kecil
                foreach(var pair in diffMins){
                    Console.Write(pair.Value + " ");
                    Console.WriteLine(pair.Key);
                }
                return new KeyValuePair<string, string>(minPair.Value, SidikJariNama.GetValueOrDefault(minPair.Value)); // return path dan nama 

            }
        }
        static bool Solve(string pattern, string Text, int algo)
        {
            if(algo == 1){
                return stringMatching.KMP.KMPSolve(Text, pattern);
            }else{
                return stringMatching.BM.BMmatch(Text, pattern) != -1;
            }
        }
    }
}