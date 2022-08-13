using System.Text.RegularExpressions;

namespace Carneiro.PasswordEntropy.EntropyTypes;

internal class HexadecimalPasswordEntropyType : RegularExpPasswordEntropyType
{
    protected override Regex Regex => new("[a-fA-F0-9]", RegexOptions.Compiled);
    protected override int Size => 16;
}