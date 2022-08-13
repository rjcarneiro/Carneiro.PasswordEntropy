using Microsoft.Extensions.Options;

namespace Carneiro.PasswordEntropy.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public class PasswordEntropyTests
{
    private IPasswordEntropy _passwordEntropy;

    [SetUp]
    public void Setup() => _passwordEntropy = new PasswordEntropy(Options.Create(new PasswordEntropyOptions()));

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("       ")]
    public void GetStrength_EmptyOrNull_Blank(string password)
    {
        PasswordEntropyStrength value = _passwordEntropy.GetStrength(password);

        Assert.That(value, Is.EqualTo(PasswordEntropyStrength.Blank));
    }

    [Test]
    [TestCase("123456")]
    [TestCase("pass")]
    [TestCase("123")]
    public void GetStrength_EasyToGuessPasswords_VeryWeak(string password)
    {
        PasswordEntropyStrength value = _passwordEntropy.GetStrength(password);

        Assert.That(value, Is.EqualTo(PasswordEntropyStrength.VeryWeak));
    }

    [Test]
    [TestCase("12345678")]
    [TestCase("password")]
    public void GetStrength_MoreThan8Chars_Weak(string password)
    {
        PasswordEntropyStrength value = _passwordEntropy.GetStrength(password);

        Assert.That(value, Is.EqualTo(PasswordEntropyStrength.Weak));
    }

    [Test]
    [TestCase("hel12345678")]
    public void GetStrength_MoreThan8CharsWithNumbers_Good(string password)
    {
        PasswordEntropyStrength value = _passwordEntropy.GetStrength(password);

        Assert.That(value, Is.EqualTo(PasswordEntropyStrength.Good));
    }

    [Test]
    [TestCase("hello12345678")]
    [TestCase("MyRandomPass@eowrd")]
    public void GetStrength_LongString_Good(string password)
    {
        PasswordEntropyStrength value = _passwordEntropy.GetStrength(password);

        Assert.That(value, Is.EqualTo(PasswordEntropyStrength.Strong));
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("       ")]
    public void Calculate_EmptyOrNull_Blank(string password)
    {
        PasswordEntropyModel model = _passwordEntropy.Calculate(password);

        Assert.That(model, Is.Not.Null);
        Assert.That(model.Strength, Is.EqualTo(PasswordEntropyStrength.Blank));
        Assert.That(model.Entropy, Is.Zero);
    }
}