using LasmartTestContext.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LasmartTestContext.Persistence;

/// <summary>
/// Внедрение зависимостей слоя доступа к данным>
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавить зависимости из слоя доступа к данным <see cref="DependencyInjection"/>
    /// </summary>
    /// <param name="serviceCollection">Сервис коллекций</param>
    /// <param name="connectionString">Строка подключения к базе данных</param>
    /// <returns>Обновлённый сервис коллекций</returns>
    public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<DBContext>(options => options.UseInMemoryDatabase(connectionString));
        serviceCollection.AddScoped<IDBContext>(provider => provider.GetService<DBContext>()!);

        return serviceCollection;
    }
}