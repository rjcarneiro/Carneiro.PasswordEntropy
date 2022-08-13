namespace Carneiro.PasswordEntropy.EntropyTypes;

internal interface IPasswordEntropyType
{
    public bool ContainsMatch(string password);
    int CalculateValue(string password);
}