namespace reader{
    class Reader{
        public static void Read(){
            string directoryPath = "../../Real";

            // Get all file names in the directory
            try
            {
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}