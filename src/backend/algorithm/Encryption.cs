using System;

namespace encryption 
{
public class Encryption
{
    public static string EncryptV(string plaintext, string key)
    {
        string ciphertext = "";
        int keyIndex = 0;

        foreach (char c in plaintext)
        {
            if (char.IsLetter(c))
            {
                char shift = char.ToUpper(key[keyIndex % key.Length]);
                int keyValue = shift - 'A';

                if (char.IsLower(c))
                {
                    int temp = c - 'a' + keyValue ;
                    while (temp < 0) {
                        temp += 26 ;
                    }
                    ciphertext += (char)((temp % 26) + 'a');
                }
                else
                {
                    int temp = c - 'A' + keyValue ;
                    while (temp < 0) {
                        temp += 26 ;
                    }
                    ciphertext += (char)((temp % 26) + 'A');
                }

                keyIndex++;
            }
            else
            {
                ciphertext += c;
            }
        }

        return ciphertext;
    }

    public static string DecryptV(string ciphertext, string key)
    {
        string plaintext = "";
        int keyIndex = 0;

        foreach (char c in ciphertext)
        {
            if (char.IsLetter(c))
            {
                char shift = char.ToUpper(key[keyIndex % key.Length]);
                int keyValue = shift - 'A';

                if (char.IsLower(c))
                {
                    int temp = c - 'a' - keyValue ;
                    while (temp < 0) {
                        temp += 26 ;
                    }
                    plaintext += (char)((temp % 26) + 'a');
                }
                else
                {
                    int temp = c - 'A' - keyValue ;
                    while (temp < 0) {
                        temp += 26 ;
                    }
                    plaintext += (char)((temp % 26) + 'A');
                }

                keyIndex++;
            }
            else
            {
                plaintext += c;
            }
        }

        return plaintext;
    }

    public static string EncryptC(string plaintext, int key) {
        string result = "" ;
        foreach (char c in plaintext) {
            if (c >= 32 && c <= 126) {
                int ascii = c - 32 + key ;
                while (ascii < 0) {
                    ascii += 95 ;
                }
                char new_index = (char)((ascii % 95) + 32) ;
                result += new_index ;
            }
            else {
                result += c ;
            }
            // Console.WriteLine(result) ;
        }
        return result ;
    }

    public static string Encrypt(string plaintext, string keyV, int keyC) {
        string encryptedV = EncryptV(plaintext, keyV) ;
        return EncryptC(encryptedV, keyC) ;
    }

    public static string Decrypt(string ciphertext, string keyV, int keyC) {
        string decryptedC = EncryptC(ciphertext, -keyC) ;
        return DecryptV(decryptedC, keyV) ;
    }
    //static void main()
    //{
    //    string key1 = "last day on itb";
    //    int key2 = 1;
    //    string tes = "dale daldan";
    //    string encrypted = encrypt(tes, key1, key2);
    //    string decrypted = decrypt(encrypted, key1, key2);
    //    console.writeline(encrypted);
    //    console.writeline(decrypted);

    //    // string encryptedv = encryptv(tes, key1) ;
    //    // console.writeline(encryptedv) ;
    //    // string encryptedc = encryptc(encryptedv, key2) ;
    //    // console.writeline(encryptedc) ;

    //    // string decryptedc = encryptc(encryptedc, -key2) ;
    //    // console.writeline(decryptedc) ;
    //    // string decryptedv = decryptv(decryptedc, key1) ;
    //    // console.writeline(decryptedv) ;

    //    // string enc = encryptc(tes, key2) ;
    //    // console.writeline(enc) ;
    //    // string dec = encryptc(enc, -key2) ;
    //    // console.writeline(dec) ;
    //}
    }
}