using System.Text.RegularExpressions;

namespace Carneiro.PasswordEntropy.EntropyTypes;

internal class LowerCasePasswordEntropyType : RegularExpPasswordEntropyType
{
    protected override Regex Regex => new("[a-z]", RegexOptions.Compiled);
    protected override int Size => 26;
}