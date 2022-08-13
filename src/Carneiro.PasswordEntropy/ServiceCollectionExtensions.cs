using Microsoft.Extensions.DependencyInjection;

namespace Carneiro.PasswordEntropy;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPasswordEntropy(this IServiceCollection services) => services.AddScoped<IPasswordEntropy, PasswordEntropy>();
}