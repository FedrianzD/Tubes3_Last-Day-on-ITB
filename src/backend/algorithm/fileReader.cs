namespace reader{
    class Reader{
        public static List<string> ReadFileName(){
            string directoryPath = "test/SOCOFing/Real/";

            // Get all file names in the directory
            List<string> filepath = [];
            try
            {
                string[] files = Directory.GetFiles(directoryPath);
                filepath.AddRange(files);
                string delimiter = "_";
                filepath = filepath.OrderBy(filepath =>
                {
                    string fileName = Path.GetFileName(filepath);
                    string substring = fileName.Split(new string[] { delimiter }, StringSplitOptions.None)[0];
                    return int.Parse(substring);
                }).ToList();
                Console.WriteLine(Path.GetFileName(filepath.ElementAt(0)));
                foreach (string file in filepath)
                {
                    Console.WriteLine(file);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return filepath;
        }

        public static List<string> ReadTxt()
        {
            
            
            string filePath = "test/SOCOFing/name.txt";

            List<string> names = [];
            try
            {
                
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {   
                        // Console.WriteLine(line);
                        names.Add(line);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return names;
        
        }
        public static List<(string name, string path)> Pairing(){
            List<string> filepath = ReadFileName();
            List<string> names = ReadTxt();
            List<(string name,string path)> pair = [];
            int j = 0;
            string delimiter = "_";
            // Console.WriteLine(filepath.ElementAt(0));
            // Console.WriteLine(int.Parse(filepath.ElementAt(0).Split(new string[] { delimiter }, StringSplitOptions.None)[0]));
            for(int i = 0; i < filepath.Count; i++){
                if(int.Parse(Path.GetFileName(filepath.ElementAt(i)).Split(new string[] { delimiter }, StringSplitOptions.None)[0]) == j+1){
                    // Console.WriteLine(names.ElementAt(j) + " " + filepath.ElementAt(i));
                    pair.Add((names.ElementAt(j), filepath.ElementAt(i)));
                }else{
                    j++;
                    // Console.WriteLine(names.ElementAt(j) + " " + filepath.ElementAt(i));
                    pair.Add((names.ElementAt(j), filepath.ElementAt(i)));
                }
            }
            return pair;
        }
    }
}