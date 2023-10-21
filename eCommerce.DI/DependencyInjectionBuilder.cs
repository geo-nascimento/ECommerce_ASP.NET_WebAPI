using eCommerce.Application.Services.AutoMapper;
using eCommerce.Application.Services.Encrypt;
using eCommerce.Application.Services.Token;
using eCommerce.Application.UseCases.User.Register;
using eCommerce.Domain.Interfaces.User;
using eCommerce.Infrastructure.DatabaseContext;
using eCommerce.Infrastructure.Repositories;
using eCommerce.Infrastructure.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.DI;

public static class DependencyInjectionBuilder
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        AddInfrastructure(services, configuration);
        AddAutoMapper(services);
        AddRepositories(services);
        AddEncryptKey(configuration, services);
        AddUseCases(services);
        AddTokenJWT(services, configuration);

        return services;
    }

    private static void AddInfrastructure(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services
            .AddDbContext<eCommerceDbContext>(opt => 
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
       services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
       {
           cfg.AddProfile(new AutoMapperConfiguration());
       }).CreateMapper());
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUsuarioReadOnlyRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnityOfWork>();
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>();
    }

    private static void AddEncryptKey(IConfiguration configuration, IServiceCollection services)
    {
        var key = configuration["Configurations:EncriptionKey"];
        services.AddScoped<PasswordEncryptor>(opt => new PasswordEncryptor(key));
    }

    private static void AddTokenJWT(IServiceCollection services, IConfiguration configuration)
    {
        var tokenLifeTime = double.Parse(configuration["Configurations:TokenLifeTime"]);
        var tokenKey = configuration["Configurations:TokenKey"];

        services.AddScoped(opt => new TokenController(tokenLifeTime, tokenKey));

    }
}