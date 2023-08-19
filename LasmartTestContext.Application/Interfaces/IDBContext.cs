using LasmartTestContext.Domain;
using Microsoft.EntityFrameworkCore;

namespace LasmartTestContext.Application.Interfaces;

/// <summary>
/// Интерфейс, описывающий контекст базы данных
/// </summary>
public interface IDBContext
{
    /// <summary>
    /// Получить / установить список точек
    /// </summary>
    DbSet<Point>? Points { get; set; } 
    /// <summary>
    /// Получить / установить список комментариев
    /// </summary>
    DbSet<Comment>? Comments { get; set; }

    /// <summary>
    /// Ассинхронно сохраняет внесённые изменения
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}