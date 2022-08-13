namespace Carneiro.PasswordEntropy.EntropyTypes;

internal class MinimumCharacterPasswordEntropyType : IPasswordEntropyType
{
    private const int MinimumCharacters = 8;

    public int CalculateValue(string password) => 0;

    public bool ContainsMatch(string password) => password.Length >= MinimumCharacters;
}