using System.Text.RegularExpressions;

namespace Carneiro.PasswordEntropy.EntropyTypes;

internal class NumericPasswordEntropyType : RegularExpPasswordEntropyType
{
    protected override Regex Regex => new("[0-9]", RegexOptions.Compiled);
    protected override int Size => 10;
}