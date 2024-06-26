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
            // Database_Operation.DB.EncryptDatabaseBiodata();
            // Database_Operation.DB.ReadDatabaseBiodataAll();
            // Database_Operation.DB.EncryptDatabaseSidikJari();
            // Database_Operation.DB.ReadDatabaseSidikJari();
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
            
            Console.WriteLine(encryption.Encryption.Encrypt("Terrorist", "LastDayonITB", 5));
            Console.WriteLine(encryption.Encryption.Encrypt("Wikipedia Scraper", "LastDayonITB", 5));
            Console.WriteLine(encryption.Encryption.Encrypt("Pecinta Bot Diamond", "LastDayonITB", 5));
            Console.WriteLine(encryption.Encryption.Encrypt("SpeedRunner Wordle", "LastDayonITB", 5));
            Console.WriteLine(encryption.Encryption.Decrypt("Iu|}lWxgfrp%] w{jm","LastDayonITB", 5 ));
            // Stopwatch stopwatch = new Stopwatch();
            // stopwatch.Start();
            // (string path, string Name, string CorruptName, float percent) res = getPathAndName("D:/Github/Tubes3_Last-Day-on-ITB/test/SOCOFing/Altered/Altered-Hard/1__M_Right_little_finger_CR.BMP", 0);
            // Console.WriteLine("Path " + res.path);
            // Console.WriteLine("Nama asli: " + res.Name + " Hasil decrypt " + encryption.Encryption.Decrypt(res.Name, "LastDayonITB", 5));
            // Console.WriteLine("Nama Corrupt " + res.CorruptName + " Hasil decrypt " + encryption.Encryption.Decrypt(res.CorruptName, "LastDayonITB", 5));
            // Console.WriteLine(res.percent);
            // Database_Operation.DB.SearchDatabaseWithName(res.CorruptName);
            // stopwatch.Stop();
            // TimeSpan ts = stopwatch.Elapsed;
            // string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            // ts.Hours, ts.Minutes, ts.Seconds,
            // ts.Milliseconds / 10);

            // Console.WriteLine("RunTime " + elapsedTime);
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
            string keyv = "LastDayonITB";
            int keyc = 5;
            List<string> names = Database_Operation.DB.ReadDatabaseName();
            List<string> patternAll = converter.Converter.readFile(pathPattern);
            string pattern = converter.Converter.getPattern(patternAll);
            List<KeyValuePair<string, string>> SidikJariNamaTmp = Database_Operation.DB.ReadDatabaseSidikJari();
            Dictionary<string, string> SidikJariNama = SidikJariNamaTmp.ToDictionary(pair => pair.Key, pair => pair.Value);
            string pathFound = "";
            string name = "";
            bool found = false;
            float diffMax = 0; // diffMin untuk menghitung kemiripan di gambar
            float diff; // diff untuk menghitung perbedaan di tiap row
            List<KeyValuePair<float, string>> diffMaxs = []; // minimum dan pathnya

            foreach (var pair in SidikJariNama)
            {
                string pathOri = pair.Key;
                List<string> Originals = converter.Converter.readFile(pathOri);
                foreach (string Original in Originals)
                {
                    if (Solve(pattern, Original, algo))
                    {
                        found = true;
                        pathFound = pathOri;
                        name = pair.Value;
                        break; // kalo ketemu yang sama persis break aja
                    }
                    diff = stringMatching.LCS.LongestCommonSubsequence(pattern, Original);
                    if (diff > diffMax)
                    {
                        diffMax = diff; // nyari diff paling kecil di satu gambar
                    }

                }
                if (found)
                {
                    break; // kalo ketemu break lagi juga
                }
                diffMaxs.Add(new KeyValuePair<float, string>(diffMax, pathOri)); // masukkin nilai terkecil pada suatu gambar ke dalam list
                diffMax = 0;
            }
            if (found)
            {

                string patternNamaAsli = stringMatching.RegularExpressions.createPattern(encryption.Encryption.Decrypt(name,keyv,keyc)); // decrypt dulu
                string corruptName = "";
                string decryptnama = "";
                foreach (string nama in names)
                {   
                    decryptnama = encryption.Encryption.Decrypt(nama, keyv, keyc); // decrypt dulu
                    // Console.WriteLine(decryptnama);
                    if (stringMatching.RegularExpressions.regexMatching(decryptnama, patternNamaAsli)) // regex
                    {
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
                string patternNamaAsli = stringMatching.RegularExpressions.createPattern(encryption.Encryption.Decrypt(name,keyv,keyc)); // decrypt
                string corruptName = "";
                foreach (string nama in names)
                {
                    string decryptnama = encryption.Encryption.Decrypt(nama, keyv, keyc);
                    if (stringMatching.RegularExpressions.regexMatching(decryptnama, patternNamaAsli))
                    {
                        corruptName = nama;
                        break;
                    }
                }
                return (maxPair.Value, name, corruptName, maxPair.Key); // return path dan nama 
            }
        }
        private static bool Solve(string pattern, string Text, int algo)
        {
            if (algo == 1)
            {
                return stringMatching.KMP.KMPSolve(Text, pattern);
            }
            else
            {
                return stringMatching.BM.BMmatch(Text, pattern) != -1;
            }
        }

    }
}