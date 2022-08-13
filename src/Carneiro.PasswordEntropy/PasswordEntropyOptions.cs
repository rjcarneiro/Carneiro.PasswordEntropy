namespace Carneiro.PasswordEntropy;

public class PasswordEntropyOptions
{
    public bool UseMinimumCharacters { get; set; } = true;
    public bool UseLowerCase { get; set; } = true;
    public bool UseUpperCase { get; set; } = true;
    public bool UseNumeric { get; set; } = true;
    public bool UseSymbols { get; set; } = true; 
    public bool UseHexadecimal { get; set; } = false;
}