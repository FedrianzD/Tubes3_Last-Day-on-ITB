using System;
using System.IO;
using System.Text;

namespace converter{
    class Converter
    {
        // static void Main(string[] args)
        // {
        //     // Relative path to the BMP file from the code's folder
        //     string filePath = @"..\..\test\SOCOFing\Real\1__M_Left_index_finger.BMP";
        //     // string filePath = "1__M_Left_index_finger.BMP";


        //     // Alternatively, use an absolute path
        //     // string filePath = @"C:\path\to\your\image\your_image.bmp";
            
        //     if (!File.Exists(filePath))
        //     {
        //         Console.WriteLine("File not found: " + filePath);
        //         return;
        //     }

        //     try
        //     {
        //         string binaryString = ConvertBmpToAscii(filePath);
        //         // Console.WriteLine(binaryString);
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine("An error occurred: " + ex.Message);
        //     }
        // }

        static string ConvertBmpToAscii(string filePath) {
            string binary_result = ConvertBmpToBinary(filePath) ;
            string result = ConvertBinaryToAscii(binary_result) ;
            return result ;
        }

        static string ConvertBmpToBinary(string filePath)
        {
            // Read the BMP file as bytes
            byte[] bmpBytes = File.ReadAllBytes(filePath);
            
            // Convert bytes to binary string
            StringBuilder binaryStringBuilder = new StringBuilder();
            foreach (byte b in bmpBytes)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            
            return binaryStringBuilder.ToString() ;
            // return ConvertBinaryToAscii(binaryStringBuilder.ToString());
        }

        static string ConvertBinaryToAscii(string binaryString)
        {
            Console.WriteLine(binaryString.Length) ;
            StringBuilder asciiStringBuilder = new StringBuilder();

            for (int i = 0; i < binaryString.Length; i += 8)
            {
                // Take 8 bits at a time
                string byteString = binaryString.Substring(i, 8);
                
                // Convert binary string to byte
                byte b = Convert.ToByte(byteString, 2);
                
                // Convert byte to ASCII character and append to the string builder
                asciiStringBuilder.Append((char)b);
            }
            Console.WriteLine(asciiStringBuilder.ToString().Length) ; 
            return asciiStringBuilder.ToString();
        }

    }

}
