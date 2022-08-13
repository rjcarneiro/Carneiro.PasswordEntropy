﻿namespace Carneiro.PasswordEntropy;

public class PasswordEntropy : IPasswordEntropy
{
    private const int BlankPasswordEntropy = 0;

    private readonly IReadOnlyCollection<IPasswordEntropyType> _passwordEntropyTypes;

    public PasswordEntropy(IOptions<PasswordEntropyOptions> options) => _passwordEntropyTypes = GetPasswordEntropyTypes(options.Value);

    public PasswordEntropyStrength GetStrength(string password)
    {
        var entropy = GetEntropy(password);

        return Evaluate(password, entropy);
    }

    public PasswordEntropyModel Calculate(string password)
    {
        double entropy = GetEntropy(password);
        PasswordEntropyStrength passwordEntropyStrength = Evaluate(password, entropy);

        return new PasswordEntropyModel
        {
            Strength = passwordEntropyStrength,
            Entropy = entropy
        };
    }

    internal static List<IPasswordEntropyType> GetPasswordEntropyTypes(PasswordEntropyOptions options)
    {
        var types = new List<IPasswordEntropyType>();

        if (options.UseMinimumCharacters)
            types.Add(new MinimumCharacterPasswordEntropyType());

        if (options.UseLowerCase)
            types.Add(new LowerCasePasswordEntropyType());

        if (options.UseUpperCase)
            types.Add(new UpperCasePasswordEntropyType());

        if (options.UseNumeric)
            types.Add(new NumericPasswordEntropyType());

        if (options.UseSymbols)
            types.Add(new SymbolsPasswordEntropyType());

        if (options.UseHexadecimal)
            types.Add(new HexadecimalPasswordEntropyType());

        return types;
    }

    private double GetEntropy(string password)
    {
        int alphabetSize = 0;

        if (string.IsNullOrWhiteSpace(password))
            return BlankPasswordEntropy;

        foreach (IPasswordEntropyType type in _passwordEntropyTypes)
        {
            alphabetSize += type.CalculateValue(password);
        }

        double possibleCombinations = Math.Pow(alphabetSize, password.Length);

        return Math.Log(possibleCombinations, 2);
    }

    private static PasswordEntropyStrength Evaluate(string password, double entropy)
    {
        if (string.IsNullOrWhiteSpace(password))
            return PasswordEntropyStrength.Blank;

        if (entropy < 20)
            return PasswordEntropyStrength.VeryWeak;

        if (entropy < 50)
            return PasswordEntropyStrength.Weak;

        if (entropy < 60)
            return PasswordEntropyStrength.Good;

        return PasswordEntropyStrength.Strong;
    }
}