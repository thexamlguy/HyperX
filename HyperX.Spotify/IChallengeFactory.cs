namespace HyperX.Spotify
{
    public interface IChallengeFactory
    {
        string Create(string verifier);
    }
}