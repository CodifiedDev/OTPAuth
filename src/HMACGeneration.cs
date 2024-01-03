using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBase;
using System.Security.Cryptography;


namespace OTPAuth.src
{
    internal class HMACGeneration
    {
        public static string generateBase32Key() {
            //Random random = new Random();
            //int rand = random.Next(100000000, 999999999); // This method is not cryptographically secure, however it does generate valid 
            string rand = RandomNumberGenerator.GetHexString(128, true);
            Console.WriteLine(rand);
            string base32 = SimpleBase.Base32.Rfc4648.Encode(Encoding.UTF8.GetBytes(rand));
            Console.WriteLine(base32);
            return "Test!";
        }
    }
}
