namespace Carneiro.PasswordEntropy;

public interface IPasswordEntropy
{
    PasswordEntropyStrength GetStrength(string password);
    PasswordEntropyModel Calculate(string password);
}