using LasmartTestContext.Application.Interfaces.Repositories;
using LasmartTestContext.Domain;
using LasmartTestContext.Dto.PointDto;
using LasmartTestContext.Dto.PointDto.ResponseDto;

namespace LasmartTestContext.Application.Common.Repositories;

/// <summary>
/// Репозиторий с методами взаимодействия над <see cref="Point"/>
/// </summary>
public class PointRepository : IPointRepository
{
    public async Task<GetAllPointsResponseDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<AddPointResponseDto> AddAsync(AddPointDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task EditAsync(EditPointDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(int pointId)
    {
        throw new NotImplementedException();
    }
}