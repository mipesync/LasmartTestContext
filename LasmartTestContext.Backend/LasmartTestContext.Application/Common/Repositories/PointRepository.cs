using AutoMapper;
using AutoMapper.QueryableExtensions;
using LasmartTestContext.Application.Common.Exceptions;
using LasmartTestContext.Application.Interfaces;
using LasmartTestContext.Application.Interfaces.Repositories;
using LasmartTestContext.Domain;
using LasmartTestContext.Dto.PointDto;
using LasmartTestContext.Dto.PointDto.ResponseDto;
using Microsoft.EntityFrameworkCore;

namespace LasmartTestContext.Application.Common.Repositories;

/// <summary>
/// Репозиторий с методами взаимодействия над <see cref="Point"/>
/// </summary>
public class PointRepository : IPointRepository
{
    private readonly IDBContext _dbContext;
    private readonly IMapper _mapper;

    public PointRepository(IDBContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetAllPointsResponseDto> GetAll()
    {
        var points = await _dbContext.Points
            .AsNoTracking()
            .Include(u => u.Comments)
            .ToListAsync(CancellationToken.None);

        var result = PointsToResponseDto(points);

        return result;
    }

    public async Task<AddPointResponseDto> AddAsync(AddPointDto dto)
    {
        var point = _mapper.Map<Point>(dto);

        var addedPoint = await _dbContext.Points.AddAsync(point, CancellationToken.None);

        await _dbContext.SaveChangesAsync(CancellationToken.None);

        return new AddPointResponseDto
        {
            Id = addedPoint.Entity.Id
        };
    }

    public async Task EditAsync(EditPointDto dto)
    {
        var point = await _dbContext.Points.FirstOrDefaultAsync(u => u.Id == dto.Id, CancellationToken.None);

        if (point is null)
            throw new NotFoundException("Точка не найдена");

        point = _mapper.Map(dto, point);

        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task RemoveAsync(int pointId)
    {
        var point = await _dbContext.Points.FirstOrDefaultAsync(u => u.Id == pointId, CancellationToken.None);

        if (point is null)
            throw new NotFoundException("Точка не найдена");

        _dbContext.Points.Remove(point);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    private GetAllPointsResponseDto PointsToResponseDto(IEnumerable<Point> points)
    {
        var result = new GetAllPointsResponseDto();
        
        foreach (var mappedPoint in points.Select(point => _mapper.Map<PointLookupDto>(point)))
        {
            foreach (var mappedPointComment in mappedPoint.Comments)
            {
                mappedPoint.Comments.Add(_mapper.Map<CommentLookupDto>(mappedPointComment));
            }
            
            result.Points.Add(mappedPoint);
        }

        return result;
    }
}