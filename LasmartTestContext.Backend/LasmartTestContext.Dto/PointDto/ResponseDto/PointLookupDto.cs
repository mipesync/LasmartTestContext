using LasmartTestContext.Domain;

namespace LasmartTestContext.Dto.PointDto.ResponseDto;

public class PointLookupDto : Point
{
    /// <summary>
    /// Список комментариев точки
    /// </summary>
    public new List<CommentLookupDto> Comments { get; set; } = new();
}