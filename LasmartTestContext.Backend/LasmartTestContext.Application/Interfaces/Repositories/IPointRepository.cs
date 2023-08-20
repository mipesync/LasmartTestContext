using LasmartTestContext.Domain;
using LasmartTestContext.Dto.PointDto;
using LasmartTestContext.Dto.PointDto.ResponseDto;

namespace LasmartTestContext.Application.Interfaces.Repositories;

/// <summary>
/// Интерфейс, описывающий методы взаимодействия с сущностями <see cref="Point"/>
/// </summary>
public interface IPointRepository
{
    /// <summary>
    /// Асинхронное получение списка точек
    /// </summary>
    /// <returns></returns>
    Task<GetAllPointsResponseDto> GetAllAsync();
    /// <summary>
    /// Асинхронное добавление новой точки
    /// </summary>
    /// <param name="dto">Входные данные</param>
    /// <returns><see cref="AddPointResponseDto"/></returns>
    Task<AddPointResponseDto> AddAsync(AddPointDto dto);
    /// <summary>
    /// Асинхронное изменение свойств точки
    /// </summary>
    /// <param name="dto">Входные данные</param>
    /// <returns></returns>
    Task EditAsync(EditPointDto dto);
    /// <summary>
    /// Асинхронное удаление точки
    /// </summary>
    /// <param name="pointId">Идентификатор удаляемой точки</param>
    Task RemoveAsync(int pointId);
}