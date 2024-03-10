using System.Text;

namespace HyperX.Spotify;

public class VerifierFactory : 
    IVerifierFactory
{
    private const string randomChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-._~";
    private const int length = 128;

    private static readonly Random random = new();

    public string Create()
    {
        byte[] randomBytes = new byte[length];
        random.NextBytes(randomBytes);
        StringBuilder verifierBuilder = new(length);

        foreach (byte randomByte in randomBytes)
        {
            verifierBuilder.Append(randomChars[randomByte % randomChars.Length]);
        }

        return verifierBuilder.ToString();
    }
}
