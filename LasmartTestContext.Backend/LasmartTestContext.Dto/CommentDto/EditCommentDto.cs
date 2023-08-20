namespace LasmartTestContext.Dto.CommentDto;

/// <summary>
/// DTO для изменения комментария
/// </summary>
public class EditCommentDto
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
}