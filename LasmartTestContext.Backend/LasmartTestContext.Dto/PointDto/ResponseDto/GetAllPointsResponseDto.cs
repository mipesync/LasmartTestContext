namespace LasmartTestContext.Dto.PointDto.ResponseDto;

/// <summary>
/// DTO, возвращаемый из метода получения всех точек
/// </summary>
public class GetAllPointsResponseDto
{
    public List<PointLookupDto>? Points { get; }
}