# Password Entropy for .NET C #

## Project Description

Hello. I'm your host [Ricardo Carneiro](https://github.com/rjcarneiro) ([twitter](https://twitter.com/rjorgecarneiro)). Password Entropy is a simple calculator for weak and strong passwords using a  [password strength calculator](https://cryptography.fandom.com/wiki/Password_strength) for .NET languages C#.

Password Entropy will help you have an idea of the password strength of your users and easily can send errors back, reject below a certain threashold, etc.

## Documentation

Here's the source code for the [blog post written here](https://ricardocarneiro.pt/blog/password-entropy-in-c).

## Usage

```csharp
public void Usage()
{
    const string pwd = "my-awesome-password-here";

    // PasswordEntropyStrength strength = _passwordEntropy.GetStrength(pwd);
    // model.Strength is the same as '_passwordEntropy.GetStrength(pwd)'
    PasswordEntropyModel model = _passwordEntropy.Calculate(pwd);

    if (model.Entropy < 80)
        throw new Exception("Week password");

    if (model.Strength != PasswordEntropyStrength.Good 
            && model.Strength != PasswordEntropyStrength.Strong)
        throw new Exception("Week password");
}
```

## License

- [Apache License](LICENSE)
