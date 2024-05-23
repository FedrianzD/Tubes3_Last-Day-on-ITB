using System;
using MySql.Data.MySqlClient;

namespace Database_Operation
{
    class DBConn
    {
        // Main Method
        static void Main()
        {
            Connect();
            // Console.ReadKey();
        }

        static void Connect()
        {
            string connectionString;

            // for the connection to 
            // MySQL server database
            MySqlConnection connection;

            // Data Source is the name of the 
            // server on which the database is stored.
            // The Database is used to specify
            // the name of the database
            // The UserID and Password are the credentials
            // required to connect to the database.
            connectionString = "Server=localhost;Database=stima;User ID=root;Password=12345678;";

            connection = new MySqlConnection(connectionString);

            try
            {
                // to open the connection
                connection.Open();

                Console.WriteLine("Connection Open!");

                // Define a query
                string query = "SELECT * FROM biodata LIMIT 5";

                // Create a command object
                MySqlCommand command = new MySqlCommand(query, connection);

                // Execute the command and obtain a reader
                MySqlDataReader reader = command.ExecuteReader();

                // Check if the reader has any rows
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

                // Close the reader
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // to close the connection
                connection.Close();
                Console.WriteLine("Connection Closed!");
            }
        }
    }
}
