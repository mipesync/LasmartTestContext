namespace LasmartTestContext.Dto.CommentDto;

/// <summary>
/// DTO для добавления нового комментария
/// </summary>
public class AddCommentDto
{
    /// <summary>
    /// Идентификатор точки
    /// </summary>
    public int PointId { get; set; }
    /// <summary>
    /// Текст комментария
    /// </summary>
    public string Text { get; set; } = null!;
    /// <summary>
    /// Цвет фона комментария в формате hex
    /// </summary>
    public string? BackgroundColor { get; set; } 
}