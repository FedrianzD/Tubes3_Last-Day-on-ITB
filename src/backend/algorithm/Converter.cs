using System;
using System.IO;
using System.Drawing;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Drawing.Drawing2D;

namespace converter
{
    public class Converter
    {
        static void SaveMatrixToFile(int[,] matrix)
        {
            
            int width = matrix.GetLength(1);
            int height = matrix.GetLength(0);

            
            Bitmap bitmap = new Bitmap(width, height);

            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (matrix[y, x] == 1)
                    {
                        bitmap.SetPixel(x, y, Color.Black); // 1 black pixel
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, Color.White); // 0 white pixel
                    }
                }
            }

            bitmap.Save("output.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        static int[,] ConvertToBnW(Bitmap bitmap)
        {
            int[,] matrix = new int[bitmap.Height, bitmap.Width];
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color originalColor = bitmap.GetPixel(x, y);
                    int grayScale = (int)(originalColor.R * 0.21 + originalColor.G * 0.72 + originalColor.B * 0.07);
                    int newColor = (grayScale >= 128) ? 0 : 1;
                    matrix[y, x] = newColor;
                }
            }

            // SaveMatrixToFile(matrix);

            return matrix;
        }

        static List<string> ConvertToAscii(int[,] matrix)
        {
            List<string> arrStr = [];
            StringBuilder sb = new StringBuilder();
            int val = 0;
            for (int row = 0; row < matrix.GetLength(0) - 7; row++)
            {
                sb.Clear();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    val = 0;
                    for (int itr = 0; itr < 8; itr++)
                    {
                        val = val << 1 | matrix[row + itr, col];
                    }
                    sb.Append((char)val);
                }
                arrStr.Add(sb.ToString());
            }
            return arrStr;
        }

        public static string getPattern(List<string> arr)
        {

            int midpoint = arr.Count / 2;
            string Original = arr.ElementAt(midpoint);
            StringBuilder sb = new StringBuilder();
            int midpoint2 = (Original.Length - 30) / 2;

            return Original.Substring(midpoint2, 30);

        }

        public static List<string> readFile(string path)
        {
            Bitmap bitmap = new Bitmap(path);
            List<string> arr = ConvertToAscii(ConvertToBnW(bitmap));
            return arr;
        }
    }

}
