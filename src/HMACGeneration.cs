using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBase;
using System.Security.Cryptography;
using System.Numerics;
using System.Collections;


namespace OTPAuth.src
{
    internal class HMACGeneration
    {
        public static string generateBase32Key() {
            //Random random = new Random();
            //int rand = random.Next(100000000, 999999999); // This method is not cryptographically secure, however it does generate valid 
            string rand = RandomNumberGenerator.GetHexString(128, true); //This method is secure, and generates a larger hex value
            string base32 = SimpleBase.Base32.Rfc4648.Encode(Encoding.UTF8.GetBytes(rand)); // Converts hex to base32, this value tests to work with third parties for verification
            return base32;
        }
        public static byte[] generateHMACSHA1(string key, int counter)
        {
            HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(key));
            byte[] counterBytes = BitConverter.GetBytes(counter);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(counterBytes);
            byte[] hash = hmac.ComputeHash(counterBytes);
            return (hash);
        }
        public static byte[] truncateHash(byte[] hash)
        {
             string hashString = BitConverter.ToString(hash).Replace("-", "");
             int offset = hash[19] & 0xf; //I didn't even know you could perform this kind of operation!
             string hashsubstring = hashString.Substring(offset, 4);
             int decimalhash = Convert.ToInt32(hashsubstring, 16);
             int last31Bits = decimalhash & 0x7fffffff;
             return BitConverter.GetBytes(last31Bits);
        }
        public static int generateOTPFromTrucated(byte[] hash)
        {
            string binaryString = string.Join("", hash.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
            return Convert.ToInt32(binaryString, 2) % 1000000;
        }
    }
}
