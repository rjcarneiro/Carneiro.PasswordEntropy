using System.Text.RegularExpressions;

namespace Carneiro.PasswordEntropy.EntropyTypes;

internal class UpperCasePasswordEntropyType : RegularExpPasswordEntropyType
{
    protected override Regex Regex => new("[A-Z]", RegexOptions.Compiled);
    protected override int Size => 26;
}