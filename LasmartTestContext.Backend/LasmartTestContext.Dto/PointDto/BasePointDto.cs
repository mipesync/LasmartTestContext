namespace LasmartTestContext.Dto.PointDto;

public class BasePointDto
{
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
    public string? Color { get; set; }
}