using System;
using MySqlConnector;
using converter;
using stringMatching;
using encryption;

namespace Database_Operation
{
    public class DB
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

        public static (string NIK, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin, string golongan_darah, string alamat, string agama, string status_perkawinan, string pekerjaan, string kewarganegaraan) SearchDatabaseWithName(string name)
        {
            string keyv = "LastDayonITB";
            int keyc = 5;
            string connectionString;

            // connect ke database di server
            MySqlConnection connection;
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";

            connection = new MySqlConnection(connectionString);

            string NIK = "";
            string nama = "";
            string tempat_lahir = "";
            string tanggal_lahir = "";
            string jenis_kelamin = "";
            string golongan_darah = "";
            string alamat = "";
            string agama = "";
            string status_perkawinan = "";
            string pekerjaan = "";
            string kewarganegaraan = "";
            try
            {
                // open connection
                connection.Open();

                Console.WriteLine("Connection Open!");
                // name = encryption.Encryption.Encrypt(name, keyv, keyc);
                // bikin querynya
                string query = $"SELECT * FROM biodata WHERE nama='{name}'";

                // bikin commandnya
                MySqlCommand command = new MySqlCommand(query, connection);

                // trus execute
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Read each row
                    while (reader.Read())
                    {
                        NIK = reader.GetString("NIK");
                        nama = encryption.Encryption.Decrypt(reader.GetString("nama"), keyv, keyc);
                        tempat_lahir = encryption.Encryption.Decrypt(reader.GetString("tempat_lahir"), keyv, keyc);
                        tanggal_lahir = reader.GetDateOnly("tanggal_lahir").ToString();
                        jenis_kelamin = reader.GetString("jenis_kelamin");
                        golongan_darah = encryption.Encryption.Decrypt(reader.GetString("golongan_darah"), keyv, keyc);
                        alamat = encryption.Encryption.Decrypt(reader.GetString("alamat"), keyv, keyc);
                        agama = encryption.Encryption.Decrypt(reader.GetString("agama"), keyv, keyc);
                        status_perkawinan = reader.GetString("status_perkawinan");
                        pekerjaan = encryption.Encryption.Decrypt(reader.GetString("pekerjaan"), keyv, keyc);
                        kewarganegaraan = encryption.Encryption.Decrypt(reader.GetString("kewarganegaraan"), keyv, keyc);

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
            return (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan);
        }
        public static void InsertDatabase()
        {
            string connectionString;

            // connect ke database di server
            MySqlConnection connection;
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("open");
                // bikin querynya
                string query = "INSERT INTO sidik_jari (nama, berkas_citra) VALUES (@nama, @path)";

                // bikin commandnya
                MySqlCommand command = new MySqlCommand(query, connection);
                List<(string name, string path)> values = reader.Reader.Pairing();
                foreach (var (name, path) in values)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@nama", name);
                    command.Parameters.AddWithValue("@path", path);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Output the number of rows affected
                    Console.WriteLine($"{rowsAffected} row(s) inserted for data {name}");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public static void EncryptDatabaseBiodata()
        {
            string connectionString;

            // connect ke database di server
            MySqlConnection connection;
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";

            connection = new MySqlConnection(connectionString);
            (List<string> NIK, List<string> nama, List<string> tempat_lahir, List<string> tanggal_lahir, List<string> jenis_kelamin, List<string> golongan_darah, List<string> alamat, List<string> agama, List<string> status_perkawinan, List<string> pekerjaan, List<string> kewarganegaraan) data = ReadDatabaseBiodataAll();
            List<string> NIK = data.NIK;
            List<string> nama = data.nama;
            List<string> tempat_lahir = data.tempat_lahir;
            List<string> tanggal_lahir = data.tanggal_lahir;
            List<string> jenis_kelamin = data.jenis_kelamin;
            List<string> golongan_darah = data.golongan_darah;
            List<string> alamat = data.alamat;
            List<string> agama = data.agama;
            List<string> status_perkawinan = data.status_perkawinan;
            List<string> pekerjaan = data.pekerjaan;
            List<string> kewarganegaraan = data.kewarganegaraan;
            try
            {
                // open connection
                connection.Open();
                Console.WriteLine("Connection Open!");
                string keyv = "LastDayonITB";
                int keyc = 5;
                // string query = "UPDATE biodata SET NIK = @NIK, nama = @nama, tempat_lahir = @lahir, tanggal_lahir = @lahir2, jenis_kelamin = @kelamin, golongan_darah = @darah, alamat = @alamat, agama = @agama, status_perkawinan = @kawin, pekerjaan = @kerja, kewarganegaraan = @negara";
                string query = "UPDATE biodata SET nama = @nama, tempat_lahir = @lahir, golongan_darah = @darah, alamat = @alamat, agama = @agama, pekerjaan = @kerja, kewarganegaraan = @negara WHERE NIK = @NIK";
                for(int i = 0; i < NIK.Count-1; i++)
                {
                    using (var command = new MySqlCommand(query, connection))
                    {
                        Console.WriteLine($"NIK: {NIK.ElementAt(i)}, Nama: {nama.ElementAt(i)}, Tempat Lahir: {tempat_lahir.ElementAt(i)}, Tanggal Lahir: {tanggal_lahir.ElementAt(i)}, Jenis Kelamin: {jenis_kelamin.ElementAt(i)}, Golongan Darah: {golongan_darah.ElementAt(i)}, Alamat: {alamat.ElementAt(i)}, Agama: {agama.ElementAt(i)}, Status Perkawinan: {status_perkawinan.ElementAt(i)}, Pekerjaan: {pekerjaan.ElementAt(i)}, Kewarganegaraan: {kewarganegaraan.ElementAt(i)}");
                        command.Parameters.AddWithValue("@NIK", NIK.ElementAt(i));
                        command.Parameters.AddWithValue("@nama", encryption.Encryption.Encrypt(nama.ElementAt(i), keyv, keyc));
                        command.Parameters.AddWithValue("@lahir", encryption.Encryption.Encrypt(tempat_lahir.ElementAt(i), keyv, keyc));
                        // command.Parameters.AddWithValue("@lahir2", encryption.Encryption.Encrypt(tanggal_lahir.ElementAt(i), keyv, keyc));
                        // command.Parameters.AddWithValue("@kelamin", encryption.Encryption.Encrypt(jenis_kelamin.ElementAt(i), keyv, keyc));
                        command.Parameters.AddWithValue("@darah", encryption.Encryption.Encrypt(golongan_darah.ElementAt(i), keyv, keyc));
                        command.Parameters.AddWithValue("@alamat", encryption.Encryption.Encrypt(alamat.ElementAt(i), keyv, keyc));
                        command.Parameters.AddWithValue("@agama", encryption.Encryption.Encrypt(agama.ElementAt(i), keyv, keyc));
                        // command.Parameters.AddWithValue("@kawin", encryption.Encryption.Encrypt(status_perkawinan.ElementAt(i), keyv, keyc));
                        command.Parameters.AddWithValue("@kerja", encryption.Encryption.Encrypt(pekerjaan.ElementAt(i), keyv, keyc));
                        command.Parameters.AddWithValue("@negara", encryption.Encryption.Encrypt(kewarganegaraan.ElementAt(i), keyv, keyc));
                        command.ExecuteNonQuery();
                    }
                }
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
        
        public static void EncryptDatabaseSidikJari()
        {
             string connectionString;

            // connect ke database di server
            MySqlConnection connection;
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";

            connection = new MySqlConnection(connectionString);
            List<KeyValuePair<string,string>> data = ReadDatabaseSidikJari();
            
            try
            {
                // open connection
                connection.Open();
                Console.WriteLine("Connection Open!");
                string keyv = "LastDayonITB";
                int keyc = 5;
                string query = "UPDATE sidik_jari SET nama = @nama WHERE berkas_citra = @path";
                for(int i = 0; i < data.Count; i ++)
                {
                    using (var command = new MySqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@nama", encryption.Encryption.Encrypt(data.ElementAt(i).Value, keyv, keyc));
                        command.Parameters.AddWithValue("@path", data.ElementAt(i).Key);
                        command.ExecuteNonQuery();
                    }
                }
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
        public static List<KeyValuePair<string, string>> ReadDatabaseSidikJari()
        {
            string connectionString;
            MySqlConnection connection;

            // connect ke database di server
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";
            connection = new MySqlConnection(connectionString);
            List<KeyValuePair<string, string>> pairs = [];
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
        public static List<string> ReadDatabaseName()
        {
            string connectionString;
            MySqlConnection connection;

            // connect ke database di server
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";
            connection = new MySqlConnection(connectionString);
            List<string> names = [];
            try
            {
                // open connection
                connection.Open();

                Console.WriteLine("Connection Open!");

                // bikin querynya
                string query = "SELECT nama FROM biodata";

                // bikin commandnya
                MySqlCommand command = new MySqlCommand(query, connection);

                // trus execute
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Read each row
                    while (reader.Read())
                    {
                        string nama = reader.GetString("nama");
                        names.Add(nama);
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
            return names;
        }
        public static (List<string> NIK, List<string> nama, List<string> tempat_lahir, List<string> tanggal_lahir, List<string> jenis_kelamin, List<string> golongan_darah, List<string> alamat, List<string> agama, List<string> status_perkawinan, List<string> pekerjaan, List<string> kewarganegaraan) ReadDatabaseBiodataAll()
        {
            string connectionString;

            // connect ke database di server
            MySqlConnection connection;
            connectionString = "Server=localhost;Port=3306;Database=stima;UID=root;Password=1234;";

            connection = new MySqlConnection(connectionString);

            List<string> NIK = [];
            List<string> nama = [];
            List<string> tempat_lahir = [];
            List<string> tanggal_lahir = [];
            List<string> jenis_kelamin = [];
            List<string> golongan_darah = [];
            List<string> alamat = [];
            List<string> agama = [];
            List<string> status_perkawinan = [];
            List<string> pekerjaan = [];
            List<string> kewarganegaraan = [];
            try
            {
                // open connection
                connection.Open();

                Console.WriteLine("Connection Open!");

                // bikin querynya
                string query = $"SELECT * FROM biodata";

                // bikin commandnya
                MySqlCommand command = new MySqlCommand(query, connection);

                // trus execute
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Read each row
                    int i = 0;
                    while (reader.Read())
                    {
                        NIK.Add(reader.GetString("NIK"));
                        nama.Add(reader.GetString("nama"));
                        tempat_lahir.Add(reader.GetString("tempat_lahir"));
                        tanggal_lahir.Add(reader.GetDateTime("tanggal_lahir").ToString());
                        jenis_kelamin.Add(reader.GetString("jenis_kelamin"));
                        golongan_darah.Add(reader.GetString("golongan_darah"));
                        alamat.Add(reader.GetString("alamat"));
                        agama.Add(reader.GetString("agama"));
                        status_perkawinan.Add(reader.GetString("status_perkawinan"));
                        pekerjaan.Add(reader.GetString("pekerjaan"));
                        kewarganegaraan.Add(reader.GetString("kewarganegaraan"));

                        Console.WriteLine($"NIK: {NIK.ElementAt(i)}, Nama: {nama.ElementAt(i)}, Tempat Lahir: {tempat_lahir.ElementAt(i)}, Tanggal Lahir: {tanggal_lahir.ElementAt(i)}, Jenis Kelamin: {jenis_kelamin.ElementAt(i)}, Golongan Darah: {golongan_darah.ElementAt(i)}, Alamat: {alamat.ElementAt(i)}, Agama: {agama.ElementAt(i)}, Status Perkawinan: {status_perkawinan.ElementAt(i)}, Pekerjaan: {pekerjaan.ElementAt(i)}, Kewarganegaraan: {kewarganegaraan.ElementAt(i)}");
                        i++;
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
            return (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, alamat, agama, status_perkawinan, pekerjaan, kewarganegaraan);
        }
    }
}
