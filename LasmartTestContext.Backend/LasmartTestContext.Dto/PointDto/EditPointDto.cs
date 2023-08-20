namespace LasmartTestContext.Dto.PointDto;

/// <summary>
/// DTO для изменения свойств точки
/// </summary>
public class EditPointDto : BasePointDto
{
    /// <summary>
    /// Идентификатор изменяемой точки
    /// </summary>
    public int Id { get; set; }
}