using System.Security.Cryptography;
using System.Text;

namespace BarberShopOnline.Application.Cryphtography;
public static class Cryphtography
{
    public static string Encrypt(this string value)
    {
        var hash = SHA1.Create();
        var encode = new ASCIIEncoding();
        var arrayByte = encode.GetBytes(value);
        arrayByte = hash.ComputeHash(arrayByte);
        var strHexa = new StringBuilder();
        foreach (var item in arrayByte)
        {
            strHexa.Append(item.ToString("x2"));
        }

        return strHexa.ToString();
    }
}
