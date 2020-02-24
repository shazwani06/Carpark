
using System;
using System.Text;
using System.Security.Cryptography;

namespace DAL
{ 
    public class clsSecurity
    {


        public static bool ValidateSignature(string signature, string message, string key)
        {
            try
            {
                // Encrypt the message
                string encryptResult = EncryptHMACSHA256(message, key);
                // Compare the signature
                if ((signature.Equals(encryptResult)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog("ValidateSignature", ex);
                return false;
            }
        }

        public static string EncryptHMACSHA256(string message, string key)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            // Encrypt the key
            byte[] keyByte = encoding.GetBytes(key);
            HMACSHA256 encryption = new HMACSHA256(keyByte);

            // Encrypt the message
            byte[] msgByte = encoding.GetBytes(message);
            byte[] hashByte = encryption.ComputeHash(msgByte);

            return ByteArrayToHexString(hashByte);
        }

        public static string EncryptHMACSHA256_Base64(string message, string key)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            // Encrypt the key
            byte[] keyByte = encoding.GetBytes(key);
            HMACSHA256 encryption = new HMACSHA256(keyByte);

            // Encrypt the message
            byte[] msgByte = encoding.GetBytes(message);
            byte[] hashByte = encryption.ComputeHash(msgByte);
            return Convert.ToBase64String(hashByte);
            //return ByteArrayToHexString(hashByte);
        }

        public static string ByteArrayToHexString(byte[] messageByte)
        {
            return BitConverter.ToString(messageByte).Replace("-", "").ToLower();
        }


        public static string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString().ToLower();

        }
       public static string  Sha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public static string Sha256_Base64(string toEncrypt)
        {
            SHA1CryptoServiceProvider objSHA1 = new SHA1CryptoServiceProvider(); byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            objSHA1.ComputeHash(toEncryptArray);

            byte[] buffer = objSHA1.Hash;

            string HashValue = System.Convert.ToBase64String(buffer);

            return HashValue;
        }

    }

}
