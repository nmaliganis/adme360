using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace dl.wm.presenter.Utilities
{
    public static class CryptoCls
    {
        private const string Key = "EA81AA1D5FC1EC53E84F30AA746139EEBAFF8A9B76638895";
        private const string Iv = "87AF7EA221F3FFF5";

        private static readonly TripleDESCryptoServiceProvider Des3;

        static CryptoCls()
        {
            Des3 = new TripleDESCryptoServiceProvider
            {
                Mode = CipherMode.CBC
            };
        }

        public static string GenerateKey()
        {
            Des3.GenerateKey();
            return BytesToHex(Des3.Key);
        }

        public static string GenerateIv()
        {
            Des3.GenerateIV();
            return BytesToHex(Des3.IV);
        }

        private static byte[] HexToBytes(string hex)
        {
            var bytes = new byte[hex.Length / 2];
            for (var i = 0; i < hex.Length / 2; i++)
            {
                var code = hex.Substring(i * 2, 2);
                bytes[i] = byte.Parse(code, NumberStyles.HexNumber);
            }
            return bytes;
        }

        private static string BytesToHex(byte[] bytes)
        {
            var hex = new StringBuilder();
            for (var i = 0; i < bytes.Length; i++)
            {
                hex.AppendFormat("{0:X2}", bytes[i]);
            }
            return hex.ToString();
        }

        public static string Encrypt(string data, string key, string iv)
        {
            var bdata = Encoding.ASCII.GetBytes(data);
            var bkey = HexToBytes(key);
            var biv = HexToBytes(iv);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream,
                Des3.CreateEncryptor(bkey, biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return BytesToHex(stream.ToArray());
        }

        public static string Decrypt(string data, string key, string iv)
        {
            var bdata = HexToBytes(data);
            var bkey = HexToBytes(key);
            var biv = HexToBytes(iv);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream,
                Des3.CreateDecryptor(bkey, biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return Encoding.ASCII.GetString(stream.ToArray());
        }

        public static string Encrypt(string data)
        {
            return Encrypt(data, Key, Iv);
        }

        public static string Decrypt(string data)
        {
            return Decrypt(data, Key, Iv);
        }

    }
}



