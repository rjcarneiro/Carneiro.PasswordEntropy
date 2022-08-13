using System.Text.RegularExpressions;

namespace Carneiro.PasswordEntropy.EntropyTypes;

internal abstract class RegularExpPasswordEntropyType : IPasswordEntropyType
{
    protected abstract Regex Regex { get; }
    protected abstract int Size { get; }

    public int CalculateValue(string password) => ContainsMatch(password) ? Size : 0;

    public bool ContainsMatch(string password) => Regex.IsMatch(password);
}