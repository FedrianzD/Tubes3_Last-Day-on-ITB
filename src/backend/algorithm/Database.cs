using System;
using MySqlConnector;
using converter;
using stringMatching;

namespace Database_Operation
{
    class DB
    {
        // Main Method
        // static void Main()
        // {
        //     // Connect();
        //     // List<string> names = [];
        //     // reader.Reader.ReadFileName();
        //     // names = reader.Reader.ReadTxt();
        //     // foreach(string name in names){
        //     //     Console.WriteLine(name);
        //     // }
        //     // foreach(var pair in reader.Reader.Pairing()){
        //     //     Console.WriteLine(pair.name + " " + pair.path);
        //     // }
        //     // InsertDatabase();
        //     ReadDatabaseSidikJari();
        //     // Console.ReadKey();
        //     // string path = "SOCOFing/Real/1__M_Left_index_finger.BMP";
        //     // List<string> arr = converter.Converter.readFile(path);
        //     // // foreach(string a in arr){
        //     // //     Console.WriteLine(a);
        //     // //     File.WriteAllText("a.txt", a);
        //     // //     Console.WriteLine("batas cok");
        //     // // }
        //     // string pattern = converter.Converter.getPattern(arr);
        //     // foreach(string a in arr){
        //     //     if(stringMatching.BM.BMmatch(a, pattern) != -1){
        //     //         Console.WriteLine("aaaaa");
        //     //     }

        //     // }
        //     // File.WriteAllLines("a.txt", arr);
            

        // }

        public static void ReadDatabaseCheck()
        {
            string connectionString;

            // connect ke database di server
            MySqlConnection connection;
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";

            connection = new MySqlConnection(connectionString);

            try
            {
                // open connection
                connection.Open();

                Console.WriteLine("Connection Open!");

                // bikin querynya
                string query = "SELECT * FROM biodata LIMIT 5";

                // bikin commandnya
                MySqlCommand command = new MySqlCommand(query, connection);

                // trus execute
                MySqlDataReader reader = command.ExecuteReader();

                
                if (reader.HasRows)
                {
                    // Read each row
                    while (reader.Read())
                    {
                        string NIK = reader.GetString("NIK");
                        string nama = reader.GetString("nama");
                        string tempat_lahir = reader.GetString("tempat_lahir");
                        DateTime tanggal_lahir = reader.GetDateTime("tanggal_lahir");
                        string jenis_kelamin = reader.GetString("jenis_kelamin");
                        string golongan_darah = reader.GetString("golongan_darah");
                        string alamat = reader.GetString("alamat");
                        string agama = reader.GetString("agama");
                        string status_perkawinan = reader.GetString("status_perkawinan");
                        string pekerjaan = reader.GetString("pekerjaan");
                        string kewarganegaraan = reader.GetString("kewarganegaraan");

                        Console.WriteLine($"NIK: {NIK}, Nama: {nama}, Tempat Lahir: {tempat_lahir}, Tanggal Lahir: {tanggal_lahir}, Jenis Kelamin: {jenis_kelamin}, Golongan Darah: {golongan_darah}, Alamat: {alamat}, Agama: {agama}, Status Perkawinan: {status_perkawinan}, Pekerjaan: {pekerjaan}, Kewarganegaraan: {kewarganegaraan}");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                
                connection.Close();
                Console.WriteLine("Connection Closed!");
            }
        }
        public static void InsertDatabase(){
            string connectionString;

            // connect ke database di server
            MySqlConnection connection;
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";
            connection = new MySqlConnection(connectionString);
            try{
                connection.Open();
                Console.WriteLine("open");
                // bikin querynya
                string query = "INSERT INTO sidik_jari (nama, berkas_citra) VALUES (@nama, @path)";

                // bikin commandnya
                MySqlCommand command = new MySqlCommand(query, connection);
                List<(string name, string path)> values = reader.Reader.Pairing();
                foreach(var (name, path) in values){
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@nama", name);
                    command.Parameters.AddWithValue("@path", path);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Output the number of rows affected
                    Console.WriteLine($"{rowsAffected} row(s) inserted for data {name}");
                }


            }catch(Exception e){
                Console.WriteLine($"An error occurred: {e.Message}");
            }finally{
                connection.Close();
            }
        }

        public static List<KeyValuePair<string,string>> ReadDatabaseSidikJari()
        {
            string connectionString;
            MySqlConnection connection;

            // connect ke database di server
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";
            connection = new MySqlConnection(connectionString);
            List<KeyValuePair<string,string>> pairs = [];
            try
            {
                // open connection
                connection.Open();

                Console.WriteLine("Connection Open!");

                // bikin querynya
                string query = "SELECT * FROM sidik_jari";

                // bikin commandnya
                MySqlCommand command = new MySqlCommand(query, connection);

                // trus execute
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Read each row
                    while (reader.Read())
                    {
                        string path = reader.GetString("berkas_citra");
                        string nama = reader.GetString("nama");
                        pairs.Add(new KeyValuePair<string, string>(path, nama));
                        // Console.WriteLine($"Path: {path}, Nama: {nama}");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                
                connection.Close();
                Console.WriteLine("Connection Closed!");
            }
            return pairs;
        }
    }
}
