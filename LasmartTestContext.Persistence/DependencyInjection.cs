using LasmartTestContext.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LasmartTestContext.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection _serviceCollection, string connectionString)
    {
        _serviceCollection.AddDbContext<DBContext>(options => options.UseInMemoryDatabase(connectionString));
        _serviceCollection.AddSingleton<IDBContext>(provider => provider.GetService<DBContext>()!);

        return _serviceCollection;
    }
}