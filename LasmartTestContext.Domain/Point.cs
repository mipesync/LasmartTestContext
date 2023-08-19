namespace LasmartTestContext.Domain;

/// <summary>
/// Класс точки, отображаемой на доске
/// </summary>
public class Point
{
    /// <summary>
    /// Идентификатор точки
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Положение точки по X
    /// </summary>
    public float X { get; set; } = 0f;
    /// <summary>
    /// Положение точки по Y
    /// </summary>
    public float Y { get; set; } = 0f;
    /// <summary>
    /// Радиус точки
    /// </summary>
    public int Radius { get; set; } = 10;
    /// <summary>
    /// Цвет точки в формате hex
    /// </summary>
    public string Color { get; set; } = null!;
    
    /// <summary>
    /// Список комментариев под точкой
    /// </summary>
    public List<Comment>? Comments { get; set; }
}