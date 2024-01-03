// See https://aka.ms/new-console-template for more information
using OTPAuth.src;

Console.WriteLine("Hello, World!");
Console.WriteLine("This should now test all values");
string key = HMACGeneration.generateBase32Key();
Console.WriteLine("Key: " + key);
var Hash = HMACGeneration.generateHMACSHA1(key, 1);
Console.WriteLine("Hash: " + Hash);
var Truncated = HMACGeneration.truncateHash(Hash);
Console.WriteLine("Truncated: " + Truncated);
var OTP = HMACGeneration.generateOTPFromTrucated(Truncated);
Console.WriteLine("OTP: " + OTP);