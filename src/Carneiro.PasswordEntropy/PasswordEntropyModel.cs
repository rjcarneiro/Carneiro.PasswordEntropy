namespace Carneiro.PasswordEntropy;

public class PasswordEntropyModel
{
    public double Entropy { get; init; }
    public PasswordEntropyStrength Strength { get; init; }
}