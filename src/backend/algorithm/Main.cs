using System;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace Database_Operation
{
    class DBConn
    {
        // Main Method
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
            InsertDatabase();
            // Console.ReadKey();
        }

        static void ReadDatabase()
        {
            string connectionString;

            // connect ke database di server
            MySqlConnection connection;
            connectionString = "Server=localhost;Database=stima;User ID=root;Password=12345678;";
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
            connectionString = "Server=localhost;Database=stima;User ID=root;Password=12345678;";
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
    }
}
