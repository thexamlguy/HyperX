using System.Security.Cryptography;
using System.Text;

namespace HyperX.Spotify;

public class ChallengeFactory : 
    IChallengeFactory
{
    public string Create(string verifier)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(verifier);
        using MemoryStream stream = new(bytes);
        byte[] hash = sha256.ComputeHash(stream);

        return Convert.ToBase64String(hash)
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');
    }
}