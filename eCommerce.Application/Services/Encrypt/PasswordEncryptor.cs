using System.Security.Cryptography;
using System.Text;

namespace eCommerce.Application.Services.Encrypt;

public class PasswordEncryptor
{
    private readonly string _encryptionKey;

    public PasswordEncryptor(string encryptionKey)
    {
        _encryptionKey = encryptionKey;
    }
    
    public string Criptografar(string password) //Baseada em hash que só criptografa, ele não traduz
    {
        var senhaComChaveAdcional = $"{password}{_encryptionKey}";
        
        var bytes = Encoding.UTF8.GetBytes(senhaComChaveAdcional);
        var sha512 = SHA512.Create();
        byte[] hasBytes = sha512.ComputeHash(bytes);
        return StringBytes(hasBytes);
    }

    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (var b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }

        return sb.ToString();
    }
}