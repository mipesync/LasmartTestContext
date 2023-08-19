using System.Reflection;
using LasmartTestContext.Application.Interfaces;
using LasmartTestContext.Domain;
using Microsoft.EntityFrameworkCore;

namespace LasmartTestContext.Persistence;

/// <inheritdoc cref="IDBContext" />
public class DBContext : DbContext, IDBContext
{
    /// <summary>
    /// Конструктор, инициализирующий настройки контекста
    /// </summary>
    /// <param name="options">Настройки</param>
    public DBContext(DbContextOptions<DBContext> options): base(options) { }
    
    public DbSet<Point>? Points { get; set; }
    public DbSet<Comment>? Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}