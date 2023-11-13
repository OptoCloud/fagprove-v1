using System.Security.Cryptography;
using System.Text;

namespace backend;

public static class Utils
{
    public static string ToHex(byte[] bytes) => BitConverter.ToString(bytes).Replace("-", "");

    public static byte[] RandBytes(int length)
    {
        byte[] bytes = new byte[length];
        RandomNumberGenerator.Fill(bytes);
        return bytes;
    }

    public static string RandHex(int length) => ToHex(RandBytes((length / 2) + 1))[..length];
    public static string HashToStr(byte[] input) => ToHex(SHA256.HashData(input));
    public static string HashToStr(string input) => HashToStr(Encoding.UTF8.GetBytes(input));
}
