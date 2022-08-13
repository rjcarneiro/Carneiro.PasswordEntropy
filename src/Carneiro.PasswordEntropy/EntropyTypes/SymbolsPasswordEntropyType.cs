namespace Carneiro.PasswordEntropy.EntropyTypes;

internal class SymbolsPasswordEntropyType : IPasswordEntropyType
{
    private static string Symbols => ",.?!\"£$%^&*()-_=+[]{};:\'@#~<>/\\|`¬¦";

    public int CalculateValue(string password) => ContainsMatch(password) ? password.Length : 0;

    public bool ContainsMatch(string password) => Symbols.Any(password.Contains);
}