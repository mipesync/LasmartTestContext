namespace LasmartTestContext.Dto.PointDto.ResponseDto;

public class CommentLookupDto
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