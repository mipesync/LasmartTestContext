namespace LasmartTestContext.Domain;

/// <summary>
/// Класс комментария, закреплённого за точкой
/// </summary>
public class Comment
{
    /// <summary>
    /// Идентифкатор комментария
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Текст комментария
    /// </summary>
    public string Text { get; set; } = null!;
    /// <summary>
    /// Цвет фона комментария в формате hex
    /// </summary>
    public string? BackgroundColor { get; set; } 
    /// <summary>
    /// Идентификатор точки, за которой закреплён комментарий
    /// </summary>
    public int PointId { get; set; }

    /// <summary>
    /// Точка, за которой закреплён комментарий
    /// </summary>
    public Point Point { get; set; } = null!;
}