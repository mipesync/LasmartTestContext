using System.Reflection;
using LasmartTestContext.Application.Common.Repositories;
using LasmartTestContext.Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LasmartTestContext.Application;

/// <summary>
/// Внедрение зависимостей из слоя бизнес логики>
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавить зависимости из слоя бизнес логики <see cref="DependencyInjection"/>
    /// </summary>
    /// <param name="serviceCollection">Сервис коллекций</param>
    /// <returns>Обновлённый сервис коллекций</returns>
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IPointRepository, PointRepository>();
        serviceCollection.AddTransient<ICommentRepository, CommentRepository>();
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return serviceCollection;
    }
}